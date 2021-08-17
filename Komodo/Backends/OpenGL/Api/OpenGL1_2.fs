[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL1_2

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common

type private DrawRangeElements = delegate of uint * uint * uint * int * uint * voidptr -> unit
let mutable private _glDrawRangeElements = DrawRangeElements(fun _ _ _ _ _ _ -> warn (notLinked<DrawRangeElements>()))
let glDrawRangeElements mode start ``end`` count ``type`` indices =
  _glDrawRangeElements.Invoke(mode, start, ``end``, count, ``type``, indices)

type private TexImage3D = delegate of uint * int * int * int * int * int * int * uint * uint * voidptr -> unit
let mutable private _glTexImage3D = TexImage3D(fun _ _ _ _ _ _ _ _ _ _ -> warn (notLinked<TexImage3D>()))
let glTexImage3D target level internalFormat width height depth border format ``type`` pixels =
  _glTexImage3D.Invoke(target, level, internalFormat, width, height, depth, border, format, ``type``, pixels)

type private TexSubImage3D = delegate of uint * int * int * int * int * int * int * int * uint * uint * voidptr -> unit
let mutable private _glTexSubImage3D = TexSubImage3D(fun _ _ _ _ _ _ _ _ _ _ _ -> warn(notLinked<TexSubImage3D>()))
let glTexSubImage3D target level xOffset yOffset zOffset width height depth format ``type`` pixels =
  _glTexSubImage3D.Invoke(target, level, xOffset, yOffset, zOffset, width, height, depth, format, ``type``, pixels)

type private CopyTexSubImage3D = delegate of uint * int * int * int * int * int * int * int * int -> unit
let mutable private _glCopyTexSubImage3D = CopyTexSubImage3D(fun _ _ _ _ _ _ _ _ _ -> warn(notLinked<CopyTexSubImage3D>()))
let glCopyTexSubImage3D target level xOffset yOffset zOffset width x y height =
  _glCopyTexSubImage3D.Invoke(target, level, xOffset, yOffset, zOffset, x, y, width, height)

let internal setup handler =
  _glDrawRangeElements <- commonSetup handler _glDrawRangeElements
  _glTexImage3D <- commonSetup handler _glTexImage3D
  _glTexSubImage3D <- commonSetup handler _glTexSubImage3D
  _glCopyTexSubImage3D <- commonSetup handler _glCopyTexSubImage3D
