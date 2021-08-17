[<AutoOpen>]
module Komodo.Backends.OpenGL.Module

open Komodo.Backends.OpenGL.Api

let setup handler =
  OpenGL1_0.setup handler
  OpenGL1_1.setup handler
  OpenGL1_2.setup handler
  OpenGL1_3.setup handler
  OpenGL1_4.setup handler
  OpenGL1_5.setup handler

  OpenGL2_0.setup handler
  OpenGL2_1.setup handler

  OpenGL3_0.setup handler
  OpenGL3_1.setup handler
  OpenGL3_2.setup handler
  OpenGL3_3.setup handler
