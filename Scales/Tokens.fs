module Scales.Tokens

type Token = 
    | Comma
    | Identifier of string
    | LeftParenthesis
    | NumberLiteral of float32
    | RightParenthesis
    | StringLiteral of string