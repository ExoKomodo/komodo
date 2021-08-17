[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL1_1

open Komodo.Backends.OpenGL.Api.Common
open Komodo.Logging

type private DrawArrays = delegate of uint * int * int -> unit
let mutable private _glDrawArrays =
  DrawArrays(fun _ _ _ -> warn (notLinked<DrawArrays>()))
let glDrawArrays mode first count = _glDrawArrays.Invoke(mode, first, count)

type private DrawElements = delegate of uint * int * uint * voidptr -> unit
let mutable private _glDrawElements =
  DrawElements(fun _ _ _ _ -> warn (notLinked<DrawElements>()))
let glDrawElements mode count ``type`` indices = _glDrawElements.Invoke(mode, count, ``type``, indices)

type private GetPointerv = delegate of uint * voidptr -> unit // Originally void**
let mutable private _glGetPointerv =
  GetPointerv(fun _ _ -> warn (notLinked<GetPointerv>()))
let glGetPointerv parameterName parameters = _glGetPointerv.Invoke(parameterName, parameters)

type private PolygonOffset = delegate of single * single -> unit
let mutable private _glPolygonOffset =
  PolygonOffset(fun _ _ -> warn (notLinked<PolygonOffset>()))
let glPolygonOffset factor units = _glPolygonOffset.Invoke(factor, units)

type private CopyTexImage1D = delegate of uint * int * uint * int * int * int * int -> unit
let mutable private _glCopyTexImage1D =
  CopyTexImage1D(fun _ _ _ _ _ _ _ -> warn (notLinked<CopyTexImage1D>()))
let glCopyTexImage1D target level internalFormat x y width border =
  _glCopyTexImage1D.Invoke(target, level, internalFormat, x, y, width, border)

type private CopyTexImage2D = delegate of uint * int * uint * int * int * int * int * int -> unit
let mutable private _glCopyTexImage2D =
  CopyTexImage2D(fun _ _ _ _ _ _ _ _ -> warn (notLinked<CopyTexImage2D>()))
let glCopyTexImage2D target level internalFormat x y width height border =
  _glCopyTexImage2D.Invoke(target, level, internalFormat, x, y, width, height, border)

type private CopyTexSubImage1D = delegate of uint * int * int * int * int -> unit
let mutable private _glCopyTexSubImage1D =
  CopyTexSubImage1D(fun _ _ _ _ _ -> warn (notLinked<CopyTexSubImage1D>()))
let glCopyTexSubImage1D target level xOffset x y =
  _glCopyTexSubImage1D.Invoke(target, level, xOffset, x, y)

type private CopyTexSubImage2D = delegate of uint * int * int * int * int * int * int * int -> unit
let mutable private _glCopyTexSubImage2D =
  CopyTexSubImage2D(fun _ _ _ _ _ _ _ _ -> warn (notLinked<CopyTexSubImage2D>()))
let glCopyTexSubImage2D target level xOffset yOffset x y width height =
  _glCopyTexSubImage2D.Invoke(target, level, xOffset, yOffset, x, y, width, height)

type private TexSubImage1D = delegate of uint * int * int * int * uint * uint * voidptr -> unit
let mutable private _glTexSubImage1D =
  TexSubImage1D(fun _ _ _ _ _ _ _ -> warn (notLinked<TexSubImage1D>()))
let glTexSubImage1D target level xOffset width format ``type`` pixels =
  _glTexSubImage1D.Invoke(target, level, xOffset, width, format, ``type``, pixels)

type private TexSubImage2D = delegate of uint * int * int * int * int * int * uint * uint * voidptr -> unit
let mutable private _glTexSubImage2D =
  TexSubImage2D(fun _ _ _ _ _ _ _ _ _ -> warn (notLinked<TexSubImage2D>()))
let glTexSubImage2D target level xOffset yOffset width height format ``type`` pixels =
  _glTexSubImage2D.Invoke(target, level, xOffset, yOffset, width, height, format, ``type``, pixels)

type private BindTexture = delegate of uint * uint -> unit
let mutable private _glBindTexture =
  BindTexture(fun _ _ -> warn (notLinked<BindTexture>()))
let glBindTexture target texture = _glBindTexture.Invoke(target, texture)

type private DeleteTextures = delegate of int * unativeint -> unit
let mutable private _glDeleteTextures =
  DeleteTextures(fun _ _ -> warn (notLinked<DeleteTextures>()))
let glDeleteTextures n textures = _glDeleteTextures.Invoke(n, textures)

type private GenTextures = delegate of int * unativeint -> unit
let mutable private _glGenTextures =
  GenTextures(fun _ _ -> warn (notLinked<GenTextures>()))
let glGenTextures n textures = _glGenTextures.Invoke(n, textures)

type private IsTexture = delegate of uint -> unit
let mutable private _glIsTexture =
  IsTexture(fun _ -> warn (notLinked<IsTexture>()))
let glIsTexture texture = _glIsTexture.Invoke(texture)

let internal setup handler =
  _glDrawArrays <- commonSetup handler _glDrawArrays
  _glDrawElements <- commonSetup handler _glDrawElements
  _glGetPointerv <- commonSetup handler _glGetPointerv
  _glPolygonOffset <- commonSetup handler _glPolygonOffset
  _glCopyTexImage1D <- commonSetup handler _glCopyTexImage1D
  _glCopyTexImage2D <- commonSetup handler _glCopyTexImage2D
  _glCopyTexSubImage1D <- commonSetup handler _glCopyTexSubImage1D
  _glCopyTexSubImage2D <- commonSetup handler _glCopyTexSubImage2D
  _glTexSubImage1D <- commonSetup handler _glTexSubImage1D
  _glTexSubImage2D <- commonSetup handler _glTexSubImage2D
  _glBindTexture <- commonSetup handler _glBindTexture
  _glDeleteTextures <- commonSetup handler _glDeleteTextures
  _glGenTextures <- commonSetup handler _glGenTextures
  _glIsTexture <- commonSetup handler _glIsTexture
