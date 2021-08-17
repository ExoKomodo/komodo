[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL1_4

open Komodo.Backends.OpenGL.Api.Common
open Komodo.Logging

type private BlendFuncSeparate = delegate of uint * uint * uint * uint -> unit
let mutable private _glBlendFuncSeparate = BlendFuncSeparate(fun _ _ _ _ -> warn (notLinked<BlendFuncSeparate>()))
let glBlendFuncSeparate sFactorRGB dFactorRGB sFactorAlpha dFactorAlpha =
  _glBlendFuncSeparate.Invoke(sFactorRGB, dFactorRGB, sFactorAlpha, dFactorAlpha)

type private MultiDrawArrays = delegate of uint * nativeptr<int> * unativeint * int -> unit
let mutable private _glMultiDrawArrays = MultiDrawArrays(fun _ _ _ _ -> warn (notLinked<MultiDrawArrays>()))
let glMultiDrawArrays mode first count drawCount = _glMultiDrawArrays.Invoke(mode, first, count, drawCount)

type private MultiDrawElements = delegate of uint * unativeint * uint * voidptr * int -> unit
let mutable private _glMultiDrawElements = MultiDrawElements(fun _ _ _ _ _ -> warn (notLinked<MultiDrawElements>()))
let glMultiDrawElements mode count ``type`` indices drawCount =
  _glMultiDrawElements.Invoke(mode, count, ``type``, indices, drawCount)

type private PointParameterf = delegate of uint * single -> unit
let mutable private _glPointParameterf = PointParameterf(fun _ _ -> warn (notLinked<PointParameterf>()))
let glPointParameterf parameterName parameter = _glPointParameterf.Invoke(parameterName, parameter)

type private PointParameterfv = delegate of uint * nativeptr<single> -> unit
let mutable private _glPointParameterfv = PointParameterfv(fun _ _ -> warn (notLinked<PointParameterfv>()))
let glPointParameterfv parameterName parameters = _glPointParameterfv.Invoke(parameterName, parameters)

type private PointParameteri = delegate of uint * int -> unit
let mutable private _glPointParameteri = PointParameteri(fun _ _ -> warn (notLinked<PointParameteri>()))
let glPointParameteri parameterName parameter = _glPointParameteri.Invoke(parameterName, parameter)

type private PointParameteriv = delegate of uint * nativeptr<int> -> unit
let mutable private _glPointParameteriv = PointParameteriv(fun _ _ -> warn (notLinked<PointParameteriv>()))
let glPointParameteriv parameterName parameter = _glPointParameteriv.Invoke(parameterName, parameter)

type private BlendColor = delegate of single * single * single * single -> unit
let mutable private _glBlendColor = BlendColor(fun _ _ _ _ -> warn (notLinked<BlendColor>()))
let glBlendColor r g b a = _glBlendColor.Invoke(r g b a)

type private BlendEquation = delegate of uint -> unit
let mutable private _glBlendEquation = BlendEquation(fun _ -> warn (notLinked<BlendEquation>()))
let glBlendEquation mode = _glBlendEquation.Invoke(mode)

let internal setup handler =
  _glBlendFuncSeparate <- commonSetup handler _glBlendFuncSeparate
  _glMultiDrawArrays <- commonSetup handler _glMultiDrawArrays
  _glMultiDrawElements <- commonSetup handler _glMultiDrawElements
  _glPointParameterf <- commonSetup handler _glPointParameterf
  _glPointParameterfv <- commonSetup handler _glPointParameterfv
  _glPointParameteri <- commonSetup handler _glPointParameteri
  _glPointParameteriv <- commonSetup handler _glPointParameteriv
  _glBlendColor <- commonSetup handler _glBlendColor
  _glBlendEquation <- commonSetup handler _glBlendEquation
