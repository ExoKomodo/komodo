module Scales.AST

type Expression =
    | Variable
    | Constant of float32
    | Add of Expression * Expression
    | Subtract of Expression * Expression
    | Multiply of Expression * Expression
    | Divide of Expression * Expression
