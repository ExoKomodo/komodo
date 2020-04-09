module Scales.Lexer

open Scales

let Lex (source:string) : Tokens.Token list =
    printfn "Source:\n%s\n" source
    [Tokens.NumberLiteral(1.0f); Tokens.Comma; Tokens.NumberLiteral(2.0f);]