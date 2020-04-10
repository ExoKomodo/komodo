module Scales

open FSharp.Compiler.Interactive.Shell
open System.Text
open System.IO

type Scale(source:string) =
    member this.Source = source

    static member val IsInitialized = false with get, set
    
    static member val KomodoDLLLocation = "../../../../Komodo/bin/Debug/netcoreapp3.1/Komodo.dll" with get, set
    
    static member private StdOutSB = new StringBuilder()
    static member private StdErrSB = new StringBuilder()
    static member private StdIn = new StringReader("")
    static member private StdOut = new StringWriter(Scale.StdOutSB)
    static member private StdErr = new StringWriter(Scale.StdErrSB)

    static member private Argv = [| "C:\\fsi.exe" |]
    static member private AllArgs = Array.append Scale.Argv [|"--noninteractive"|]
    static member private FSIConfig = FsiEvaluationSession.GetDefaultConfiguration()
    static member private FSISession = FsiEvaluationSession.Create(Scale.FSIConfig, Scale.AllArgs, Scale.StdIn, Scale.StdOut, Scale.StdErr)

    member this.Execute() =
        if not Scale.IsInitialized then Scale.Initialize()
        
        let command = sprintf "#r \"%s\"\n%s" Scale.KomodoDLLLocation this.Source
        let result, warnings = Scale.FSISession.EvalInteractionNonThrowing(command)
        match result with
            | Choice1Of2 option -> printfn "Checked and executed ok: %A" option.Value.ReflectionValue
            | Choice2Of2 ex -> printfn "Execution exception: %s" ex.Message
        for warning in warnings do
            printfn "Warning %s at %d,%d" warning.Message warning.StartLineAlternate warning.StartColumn

    static member Initialize() =
        Scale.IsInitialized <- true