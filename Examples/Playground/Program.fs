open Argu
open Komodo
open System

let DEFAULT_WIDTH = 800u
let DEFAULT_HEIGHT = 600u

type CliArguments =
  | [<Unique>][<EqualsAssignmentOrSpaced>] Width of width:uint
  | [<Unique>][<EqualsAssignmentOrSpaced>] Height of height:uint

  interface IArgParserTemplate with
    member s.Usage =
      match s with
      | Width _ -> $"set the initial display width (default: %d{DEFAULT_WIDTH})"
      | Height _ -> $"set the initial display height (default: %d{DEFAULT_HEIGHT})"

[<EntryPoint>]
let main argv =
  let errorHandler =
    ProcessExiter(
      colorizer=function
        | ErrorCode.HelpText -> None
        | _ -> Some ConsoleColor.Red )
  let results =
    ArgumentParser.Create<CliArguments>(programName="Playground", errorHandler=errorHandler).Parse argv

  let width = results.GetResult(Width, DEFAULT_WIDTH)
  let height = results.GetResult(Height, DEFAULT_HEIGHT)

  ( Game.play
      "Komodo Playground"
      width
      height
      "Resources/Shaders/fragment.glsl"
      "Resources/Shaders/vertex.glsl" ).ExitCode
