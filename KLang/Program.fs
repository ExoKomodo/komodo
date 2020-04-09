open DSL

[<EntryPoint>]
let main argv =
    let tokens = Lexer.LexFile "lang.txt"
    printfn "# of tokens: %i" tokens.Length
    0
