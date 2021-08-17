[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL1_3

open Komodo.Backends.OpenGL.Api.Common
open Komodo.Logging

type private ActiveTexture = delegate of uint -> unit
let mutable private _glActiveTexture = ActiveTexture(fun _ -> warn (notLinked<ActiveTexture> ()))
let glActiveTexture texture = _glActiveTexture.Invoke(texture)

type private SampleCoverage = delegate of float * bool -> unit
let mutable private _glSampleCoverage = SampleCoverage(fun _ _ -> warn (notLinked<SampleCoverage> ()))
let glSampleCoverage value invert = _glSampleCoverage.Invoke(value, invert)

type private CompressedTexImage3D = delegate of uint * int * uint * int * int * int * int * int * voidptr -> unit
let mutable private _glCompressedTexImage3D = CompressedTexImage3D(fun _ _ _ _ _ _ _ _ _ -> warn (notLinked<CompressedTexImage3D> ()))
let glCompressedTexImage3D target level internalFormat width height depth border imageSize imageData =
  _glCompressedTexImage3D.Invoke(target, level, internalFormat, width, height, depth, border, imageSize, imageData)

type private CompressedTexImage2D = delegate of uint * int * uint * int * int * int * int * voidptr -> unit
let mutable private _glCompressedTexImage2D = CompressedTexImage2D(fun _ _ _ _ _ _ _ _ -> warn (notLinked<CompressedTexImage2D> ()))
let glCompressedTexImage2D target level internalFormat width height border imageSize imageData =
  _glCompressedTexImage2D.Invoke(target, level, internalFormat, width, height, border, imageSize, imageData)

type private CompressedTexImage1D = delegate of uint * int * uint * int * int * int * voidptr -> unit
let mutable private _glCompressedTexImage1D = CompressedTexImage1D(fun _ _ _ _ _ _ _ -> warn (notLinked<CompressedTexImage1D> ()))
let glCompressedTexImage1D target level internalFormat width border imageSize imageData =
  _glCompressedTexImage1D.Invoke(target, level, internalFormat, width, border, imageSize, imageData)

type private CompressedTexSubImage3D = delegate of uint * int * int * int * int * int * int * int * uint * int * voidptr -> unit
let mutable private _glCompressedTexSubImage3D = CompressedTexSubImage3D(fun _ _ _ _ _ _ _ _ _ _ _ -> warn (notLinked<CompressedTexSubImage3D> ()))
let glCompressedTexSubImage3D target level xOffset yOffset zOffset width height depth format imageSize imageData =
  _glCompressedTexSubImage3D.Invoke(target, level, xOffset, yOffset, zOffset, width, height, depth, format, imageSize, imageData)

type private CompressedTexSubImage2D = delegate of uint * int * int * int * int * int * uint * int * voidptr -> unit
let mutable private _glCompressedTexSubImage2D = CompressedTexSubImage2D(fun _ _ _ _ _ _ _ _ _ -> warn (notLinked<CompressedTexSubImage2D> ()))
let glCompressedTexSubImage2D target level xOffset yOffset width height format imageSize imageData =
  _glCompressedTexSubImage2D.Invoke(target, level, xOffset, yOffset, width, height, format, imageSize, imageData)

type private CompressedTexSubImage1D = delegate of uint * int * int * int * uint * int * voidptr -> unit
let mutable private _glCompressedTexSubImage1D = CompressedTexSubImage1D(fun _ _ _ _ _ _ _ -> warn (notLinked<CompressedTexSubImage1D> ()))
let glCompressedTexSubImage1D target level xOffset width format imageSize imageData =
  _glCompressedTexSubImage1D.Invoke(target, level, xOffset, width, format, imageSize, imageData)

type private GetCompressedTexImage = delegate of uint * int * voidptr -> unit
let mutable private _glGetCompressedTexImage = GetCompressedTexImage(fun _ _ _ -> warn (notLinked<GetCompressedTexImage> ()))
let glGetCompressedTexImage target level imageData = _glGetCompressedTexImage.Invoke(target, level, imageData)

let internal setup handler =
  _glActiveTexture <- commonSetup handler _glActiveTexture
  _glSampleCoverage <- commonSetup handler _glSampleCoverage
  _glCompressedTexImage3D <- commonSetup handler _glCompressedTexImage3D
  _glCompressedTexImage2D <- commonSetup handler _glCompressedTexImage2D
  _glCompressedTexImage1D <- commonSetup handler _glCompressedTexImage1D
  _glCompressedTexSubImage3D <- commonSetup handler _glCompressedTexSubImage3D
  _glCompressedTexSubImage2D <- commonSetup handler _glCompressedTexSubImage2D
  _glCompressedTexSubImage1D <- commonSetup handler _glCompressedTexSubImage1D
  _glGetCompressedTexImage <- commonSetup handler _glGetCompressedTexImage
