namespace Scales

open Scales
open Scales.AST
open Scales.Tokens
open System.IO

type Interpreter() =
    member public this.ExecuteFile(filePath:string) =
        printfn "Executing file..."
        if File.Exists filePath then
            File.ReadAllText filePath
            |> this.Execute
    
    member public this.Execute(source:string) =
        printfn "Executing source..."
        Lexer.Lex source
        |> this.Execute

    member public this.Interpret(expression:Expression) =
        match expression with
        | Variable -> fun (x:float32) -> x
        | Constant(value) -> fun (x:float32) -> value
        | Add(left, right) ->
            fun (x:float32) -> (x |> this.Interpret left) + (x |> this.Interpret right)
        | Subtract(left, right) ->
            fun (x:float32) -> (x |> this.Interpret left) - (x |> this.Interpret right)
        | Multiply(left, right) ->
            fun (x:float32) -> (x |> this.Interpret left) * (x |> this.Interpret right)
        | Divide(left, right) ->
            fun (x:float32) -> (x |> this.Interpret left) / (x |> this.Interpret right)
    
    member private this.Execute(tokens:Token list) =
        printfn "Lexed %i tokens" tokens.Length
        let f = this.Interpret(Add(Constant(1.0f), Variable))
        printfn "Output: %f" <| f 2.0f
