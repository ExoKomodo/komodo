module DSL.Lexer

open System.IO

let Lex source =
    printfn "Source: %s" source
    source.Split Array.empty
    |> Array.toList

let LexFile filePath =
    if File.Exists filePath then
        let source = File.ReadAllText filePath
        Lex source
    else
        []