[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL3_1

#nowarn "9" // Unverifiable IL due to fixed expression usage

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common

type private DrawArraysInstanced = delegate of uint * int * int * int -> unit
let mutable private _glDrawArraysInstanced = DrawArraysInstanced(fun _ _ _ _ -> warn (notLinked<DrawArraysInstanced>()))
let glDrawArraysInstanced mode first count instanceCount = _glDrawArraysInstanced.Invoke(mode, first, count, instanceCount)

type private DrawElementsInstanced = delegate of uint * int * uint * voidptr * int -> unit
let mutable private _glDrawElementsInstanced = DrawElementsInstanced(fun _ _ _ _ _ -> warn (notLinked<DrawElementsInstanced>()))
let glDrawElementsInstanced mode count ``type`` indices instanceCount = _glDrawElementsInstanced.Invoke(mode, count, ``type``, indices, instanceCount)

type private TexBuffer = delegate of uint * uint * uint -> unit
let mutable private _glTexBuffer = TexBuffer(fun _ _ _ -> warn (notLinked<TexBuffer>()))
let glTexBuffer target internalFormat buffer = _glTexBuffer.Invoke(target, internalFormat, buffer)

type private PrimitiveRestartIndex = delegate of uint -> unit
let mutable private _glPrimitiveRestartIndex = PrimitiveRestartIndex(fun _ -> warn (notLinked<PrimitiveRestartIndex>()))
let glPrimitiveRestartIndex index = _glPrimitiveRestartIndex.Invoke(index)

type private CopyBufferSubData = delegate of uint * uint * nativeptr<int> * nativeptr<int> * unativeint -> unit
let mutable private _glCopyBufferSubData = CopyBufferSubData(fun _ _ _ _ _ -> warn (notLinked<CopyBufferSubData>()))
let glCopyBufferSubData readTarget writeTarget readOffset writeOffset size =
  _glCopyBufferSubData.Invoke(readTarget, writeTarget, readOffset, writeOffset, size)

type private GetUniformIndices = delegate of uint * int * nativeptr<char> * nativeptr<uint> -> unit
let mutable private _glGetUniformIndices = GetUniformIndices(fun _ _ _ _ -> warn (notLinked<GetUniformIndices>()))
let glGetUniformIndices program uniformCount uniformNames uniformIndices =
  _glGetUniformIndices.Invoke(program, uniformCount, uniformNames, uniformIndices)

type private GetActiveUniformsiv = delegate of uint * int * nativeptr<uint> * uint * nativeptr<int> -> unit
let mutable private _glGetActiveUniformsiv = GetActiveUniformsiv(fun _ _ _ _ _ -> warn (notLinked<GetActiveUniformsiv>()))
let glGetActiveUniformsiv program uniformCount uniformIndices parameterName parameters =
  _glGetActiveUniformsiv.Invoke(program, uniformCount, uniformIndices, parameterName, parameters)

type private GetActiveUniformName = delegate of uint * uint * int * nativeptr<int> * nativeptr<char> -> unit
let mutable private _glGetActiveUniformName = GetActiveUniformName(fun _ _ _ _ _ -> warn (notLinked<GetActiveUniformName>()))
let glGetActiveUniformName program uniformIndex bufferSize length uniformName =
  _glGetActiveUniformName.Invoke(program, uniformIndex, bufferSize, length, uniformName)

type private GetUniformBlockIndex = delegate of uint * nativeptr<char> -> uint
let mutable private _glGetUniformBlockIndex = GetUniformBlockIndex(fun _ _ -> warn (notLinked<GetUniformBlockIndex>()); 0u; )
let glGetUniformBlockIndex program uniformBlockName = _glGetUniformBlockIndex.Invoke(program, uniformBlockName)

type private GetActiveUniformBlockiv = delegate of uint * uint * uint * nativeptr<int> -> unit
let mutable private _glGetActiveUniformBlockiv = GetActiveUniformBlockiv(fun _ _ _ _ -> warn (notLinked<GetActiveUniformBlockiv>()))
let glGetActiveUniformBlockiv program uniformBlockIndex parameterName parameters =
  _glGetActiveUniformBlockiv.Invoke(program, uniformBlockIndex, parameterName, parameters)

type private GetActiveUniformBlockName = delegate of uint * uint * int * nativeptr<int> * nativeptr<char> -> unit
let mutable private _glGetActiveUniformBlockName = GetActiveUniformBlockName(fun _ _ _ _ _ -> warn (notLinked<GetActiveUniformBlockName>()))
let glGetActiveUniformBlockName program uniformBlockIndex bufferSize length uniformBlockName =
  _glGetActiveUniformBlockName.Invoke(program, uniformBlockIndex, bufferSize, length, uniformBlockName)

type private UniformBlockBinding = delegate of uint * uint * uint -> unit
let mutable private _glUniformBlockBinding = UniformBlockBinding(fun _ _ _ -> warn (notLinked<UniformBlockBinding>()))
let glUniformBlockBinding program uniformBlockIndex uniformBlockBinding =
  _glUniformBlockBinding.Invoke(program, uniformBlockIndex, uniformBlockBinding)

let internal setup handler =
  _glDrawArraysInstanced <- commonSetup handler _glDrawArraysInstanced
  _glDrawElementsInstanced <- commonSetup handler _glDrawElementsInstanced
  _glTexBuffer <- commonSetup handler _glTexBuffer
  _glPrimitiveRestartIndex <- commonSetup handler _glPrimitiveRestartIndex
  _glCopyBufferSubData <- commonSetup handler _glCopyBufferSubData
  _glGetUniformIndices <- commonSetup handler _glGetUniformIndices
  _glGetActiveUniformsiv <- commonSetup handler _glGetActiveUniformsiv
  _glGetActiveUniformName <- commonSetup handler _glGetActiveUniformName
  _glGetUniformBlockIndex <- commonSetup handler _glGetUniformBlockIndex
  _glGetActiveUniformBlockiv <- commonSetup handler _glGetActiveUniformBlockiv
  _glGetActiveUniformBlockName <- commonSetup handler _glGetActiveUniformBlockName
  _glUniformBlockBinding <- commonSetup handler _glUniformBlockBinding
 