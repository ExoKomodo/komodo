[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL2_1

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common

type private UniformMatrix2x3fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix2x3fv = UniformMatrix2x3fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix2x3fv>()))
let glUniformMatrix2x3fv location count transpose value = _glUniformMatrix2x3fv.Invoke(location, count, transpose, value)

type private UniformMatrix3x2fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix3x2fv = UniformMatrix3x2fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix3x2fv>()))
let glUniformMatrix3x2fv location count transpose value = _glUniformMatrix3x2fv.Invoke(location, count, transpose, value)

type private UniformMatrix2x4fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix2x4fv = UniformMatrix2x4fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix2x4fv>()))
let glUniformMatrix2x4fv location count transpose value = _glUniformMatrix2x4fv.Invoke(location, count, transpose, value)

type private UniformMatrix4x2fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix4x2fv = UniformMatrix4x2fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix4x2fv>()))
let glUniformMatrix4x2fv location count transpose value = _glUniformMatrix4x2fv.Invoke(location, count, transpose, value)

type private UniformMatrix3x4fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix3x4fv = UniformMatrix3x4fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix3x4fv>()))
let glUniformMatrix3x4fv location count transpose value = _glUniformMatrix3x4fv.Invoke(location, count, transpose, value)

type private UniformMatrix4x3fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix4x3fv = UniformMatrix4x3fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix4x3fv>()))
let glUniformMatrix4x3fv location count transpose value = _glUniformMatrix4x3fv.Invoke(location, count, transpose, value)

let internal setup handler =
  _glUniformMatrix2x3fv <- commonSetup handler _glUniformMatrix2x3fv
  _glUniformMatrix3x2fv <- commonSetup handler _glUniformMatrix3x2fv
  _glUniformMatrix2x4fv <- commonSetup handler _glUniformMatrix2x4fv
  _glUniformMatrix4x2fv <- commonSetup handler _glUniformMatrix4x2fv
  _glUniformMatrix3x4fv <- commonSetup handler _glUniformMatrix3x4fv
  _glUniformMatrix4x3fv <- commonSetup handler _glUniformMatrix4x3fv
