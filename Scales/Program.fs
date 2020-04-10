open Scales

[<EntryPoint>]
let main argv : int =
    let interpreter = new Interpreter()
    interpreter.ExecuteFile "../../../test.scl"
    0
