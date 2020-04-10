open Scales
open System.IO
open Komodo

[<EntryPoint>]
let main argv : int =
    let command = File.ReadAllText("../../../thing.fsx")
    let scale = Scale(command)
    scale.Execute()
    0
