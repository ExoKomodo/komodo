module Komodo.Game

open Komodo.Engine.Internals
open Komodo.Graphics
open Komodo.Logging

let play
  title
  width
  height
  fragmentShaderPath
  vertexShaderPath =
    info $"Starting up %s{title}"
    let config =
      { Config.Default with
          IsRunning = true
          DisplayConfig =
          { Display.Config.Default with
              Title = "Hello World"
              Width = width
              Height = height
              FragmentShaderPath = fragmentShaderPath
              VertexShaderPath = vertexShaderPath } }

    info "Loaded starting config"

    let defaultReturn config exitCode =
      printf "Default returning %d" exitCode
      { config with ExitCode = exitCode }
    let curriedUpdate = updateLoop updateDefault

    match Display.initialize config.DisplayConfig with
    | None ->
      fail "Failed to initialize display"
      defaultReturn config 1
    | Some(displayConfig) ->
        info "Starting game loop"
        curriedUpdate
          { config with
              DisplayConfig = displayConfig }
        |> shutdown
