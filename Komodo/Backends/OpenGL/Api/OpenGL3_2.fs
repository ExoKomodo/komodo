[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL3_2

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common

type private DrawElementsBaseVertex = delegate of uint * int * uint * voidptr * int -> unit
let mutable private _glDrawElementsBaseVertex = DrawElementsBaseVertex(fun _ _ _ _ _ -> warn (notLinked<DrawElementsBaseVertex>()))
let glDrawElementsBaseVertex mode count ``type`` indices baseVertex =
  _glDrawElementsBaseVertex.Invoke(mode, count, ``type``, indices, baseVertex)

type private DrawRangeElementsBaseVertex = delegate of uint * uint * uint * int * uint * voidptr * int -> unit
let mutable private _glDrawRangeElementsBaseVertex = DrawRangeElementsBaseVertex(fun _ _ _ _ _ _ _ -> warn (notLinked<DrawRangeElementsBaseVertex>()))
let glDrawRangeElementsBaseVertex mode start ``end`` count ``type`` indices baseVertex =
  _glDrawRangeElementsBaseVertex.Invoke(mode, start, ``end``, count, ``type``, indices, baseVertex)

type private DrawElementsInstancedBaseVertex = delegate of uint * int * uint * voidptr * int * int -> unit
let mutable private _glDrawElementsInstancedBaseVertex = DrawElementsInstancedBaseVertex(fun _ _ _ _ _ _ -> warn (notLinked<DrawElementsInstancedBaseVertex>()))
let glDrawElementsInstancedBaseVertex mode count ``type`` indices instanceCount baseVertex =
  _glDrawElementsInstancedBaseVertex.Invoke(mode, count, ``type``, indices, instanceCount, baseVertex)

type private MultiDrawElementsBaseVertex = delegate of uint * nativeptr<uint> * uint * voidptr * int * nativeptr<int> -> unit
let mutable private _glMultiDrawElementsBaseVertex = MultiDrawElementsBaseVertex(fun _ _ _ _ _ _ -> warn (notLinked<MultiDrawElementsBaseVertex>()))
let glMultiDrawElementsBaseVertex mode count ``type`` indices drawCount baseVertex =
  _glMultiDrawElementsBaseVertex.Invoke(mode, count, ``type``, indices, drawCount, baseVertex)

type private ProvokingVertex = delegate of uint -> unit
let mutable private _glProvokingVertex = ProvokingVertex(fun _ -> warn (notLinked<ProvokingVertex>()))
let glProvokingVertex mode = _glProvokingVertex.Invoke(mode)

type private FenceSync = delegate of uint * uint -> nativeint
let mutable private _glFenceSync = FenceSync(fun _ _ -> warn (notLinked<FenceSync>()); 0n; )
let glFenceSync condition flags = _glFenceSync.Invoke(condition, flags)

type private IsSync = delegate of nativeint -> bool
let mutable private _glIsSync = IsSync(fun _ -> warn (notLinked<IsSync>()); false; )
let glIsSync sync = _glIsSync.Invoke(sync)

type private DeleteSync = delegate of nativeint -> unit
let mutable private _glDeleteSync = DeleteSync(fun _ -> warn (notLinked<DeleteSync>()))
let glDeleteSync sync = _glDeleteSync.Invoke(sync)

type private ClientWaitSync = delegate of nativeint * uint * uint64 -> uint
let mutable private _glClientWaitSync = ClientWaitSync(fun _ _ _ -> warn (notLinked<ClientWaitSync>()); 0u; )
let glClientWaitSync sync flags timeout = _glClientWaitSync.Invoke(sync, flags, timeout)

type private WaitSync = delegate of nativeint * uint * uint64 -> uint
let mutable private _glWaitSync = WaitSync(fun _ _ _ -> warn (notLinked<WaitSync>()); 0u; )
let glWaitSync sync flags timeout = _glWaitSync.Invoke(sync, flags, timeout)

type private GetInteger64v = delegate of uint * nativeptr<int64> -> unit
let mutable private _glGetInteger64v = GetInteger64v(fun _ _ -> warn (notLinked<GetInteger64v>()))
let glGetInteger64v parameterName data = _glGetInteger64v.Invoke(parameterName, data)

type private GetSynciv = delegate of nativeint * uint * int * nativeptr<int> * nativeptr<int> -> unit
let mutable private _glGetSynciv = GetSynciv(fun _ _ _ _ _ -> warn (notLinked<GetSynciv>()))
let glGetSynciv sync parameterName count length values = _glGetSynciv.Invoke(sync, parameterName, count, length, values)

type private GetInteger64i_v = delegate of uint * uint * nativeptr<int64> -> unit
let mutable private _glGetInteger64i_v = GetInteger64i_v(fun _ _ _ -> warn (notLinked<GetInteger64i_v>()))
let glGetInteger64i_v target index data = _glGetInteger64i_v.Invoke(target, index, data)

type private GetBufferParameteri64v = delegate of uint * uint * nativeptr<int64> -> unit
let mutable private _glGetBufferParameteri64v = GetBufferParameteri64v(fun _ _ _ -> warn (notLinked<GetBufferParameteri64v>()))
let glGetBufferParameteri64v target parameterName parameters =
  _glGetBufferParameteri64v.Invoke(target, parameterName, parameters)

type private FramebufferTexture = delegate of uint * uint * uint * int -> unit
let mutable private _glFramebufferTexture = FramebufferTexture(fun _ _ _ _ -> warn (notLinked<FramebufferTexture>()))
let glFramebufferTexture target attachment texture level =
  _glFramebufferTexture.Invoke(target, attachment, texture, level)

type private TexImage2DMultisample = delegate of uint * int * uint * int * int * bool -> unit
let mutable private _glTexImage2DMultisample = TexImage2DMultisample(fun _ _ _ _ _ _ -> warn (notLinked<TexImage2DMultisample>()))
let glTexImage2DMultisample target samples internalFormat width height fixedSampleLocations =
  _glTexImage2DMultisample.Invoke(target, samples, internalFormat, width, height, fixedSampleLocations)

type private TexImage3DMultisample = delegate of uint * int * uint * int * int * int * bool -> unit
let mutable private _glTexImage3DMultisample = TexImage3DMultisample(fun _ _ _ _ _ _ _ -> warn (notLinked<TexImage3DMultisample>()))
let glTexImage3DMultisample target samples internalFormat width height depth fixedSampleLocations =
  _glTexImage3DMultisample.Invoke(target, samples, internalFormat, width, height, depth, fixedSampleLocations)

type private GetMultisamplefv = delegate of uint * uint * nativeptr<single> -> unit
let mutable private _glGetMultisamplefv = GetMultisamplefv(fun _ _ _ -> warn (notLinked<GetMultisamplefv>()))
let glGetMultisamplefv parameterName index value =
  _glGetMultisamplefv.Invoke(parameterName, index, value)

type private SampleMaski = delegate of uint * uint -> unit
let mutable private _glSampleMaski = SampleMaski(fun _ _ -> warn (notLinked<SampleMaski>()))
let glSampleMaski maskNumber mask = _glSampleMaski.Invoke(maskNumber, mask)


let internal setup handler =
  _glDrawElementsBaseVertex <- commonSetup handler _glDrawElementsBaseVertex
  _glDrawRangeElementsBaseVertex <- commonSetup handler _glDrawRangeElementsBaseVertex
  _glDrawElementsInstancedBaseVertex <- commonSetup handler _glDrawElementsInstancedBaseVertex
  _glMultiDrawElementsBaseVertex <- commonSetup handler _glMultiDrawElementsBaseVertex
  _glProvokingVertex <- commonSetup handler _glProvokingVertex
  _glFenceSync <- commonSetup handler _glFenceSync
  _glIsSync <- commonSetup handler _glIsSync
  _glDeleteSync <- commonSetup handler _glDeleteSync
  _glClientWaitSync <- commonSetup handler _glClientWaitSync
  _glWaitSync <- commonSetup handler _glWaitSync
  _glGetInteger64v <- commonSetup handler _glGetInteger64v
  _glGetSynciv <- commonSetup handler _glGetSynciv
  _glGetInteger64i_v <- commonSetup handler _glGetInteger64i_v
  _glGetBufferParameteri64v <- commonSetup handler _glGetBufferParameteri64v
  _glFramebufferTexture <- commonSetup handler _glFramebufferTexture
  _glTexImage2DMultisample <- commonSetup handler _glTexImage2DMultisample
  _glTexImage3DMultisample <- commonSetup handler _glTexImage3DMultisample
  _glGetMultisamplefv <- commonSetup handler _glGetMultisamplefv
  _glSampleMaski <- commonSetup handler _glSampleMaski