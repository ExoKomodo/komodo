[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL3_3

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common

type private BindFragDataLocationIndexed = delegate of uint * uint * uint * nativeptr<char> -> unit
let mutable private _glBindFragDataLocationIndexed = BindFragDataLocationIndexed(fun _ _ _ _ -> warn (notLinked<BindFragDataLocationIndexed>()))
let glBindFragDataLocationIndexed program colorNumber index name =
  _glBindFragDataLocationIndexed.Invoke(program, colorNumber, index, name)

type private GetFragDataIndex = delegate of uint * nativeptr<char> -> int
let mutable private _glGetFragDataIndex = GetFragDataIndex(fun _ _ -> warn (notLinked<GetFragDataIndex>()); 0; )
let glGetFragDataIndex program name = _glGetFragDataIndex.Invoke(program, name)

type private GenSamplers = delegate of int * nativeptr<uint> -> unit
let mutable private _glGenSamplers = GenSamplers(fun _ _ -> warn (notLinked<GenSamplers>()))
let glGenSamplers count samplers = _glGenSamplers.Invoke(count, samplers)

type private DeleteSamplers = delegate of int * nativeptr<uint> -> unit
let mutable private _glDeleteSamplers = DeleteSamplers(fun _ _ -> warn (notLinked<DeleteSamplers>()))
let glDeleteSamplers count samplers = _glDeleteSamplers.Invoke(count, samplers)

type private IsSampler = delegate of uint -> bool
let mutable private _glIsSampler = IsSampler(fun _ -> warn (notLinked<IsSampler>()); false; )
let glIsSampler sampler = _glIsSampler.Invoke(sampler)

type private BindSampler = delegate of uint * uint -> unit
let mutable private _glBindSampler = BindSampler(fun _ _ -> warn (notLinked<BindSampler>()))
let glBindSampler ``unit`` sampler = _glBindSampler.Invoke(``unit``, sampler)

type private SamplerParameteri = delegate of uint * uint * int -> unit
let mutable private _glSamplerParameteri = SamplerParameteri(fun _ _ _ -> warn (notLinked<SamplerParameteri>()))
let glSamplerParameteri sampler parameterName parameter =
  _glSamplerParameteri.Invoke(sampler, parameterName, parameter)

type private SamplerParameteriv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glSamplerParameteriv = SamplerParameteriv(fun _ _ _ -> warn (notLinked<SamplerParameteriv>()))
let glSamplerParameteriv sampler parameterName parameter =
  _glSamplerParameteriv.Invoke(sampler, parameterName, parameter)

type private SamplerParameterf = delegate of uint * uint * single -> unit
let mutable private _glSamplerParameterf = SamplerParameterf(fun _ _ _ -> warn (notLinked<SamplerParameterf>()))
let glSamplerParameterf sampler parameterName parameter =
  _glSamplerParameterf.Invoke(sampler, parameterName, parameter)

type private SamplerParameterfv = delegate of uint * uint * nativeptr<single> -> unit
let mutable private _glSamplerParameterfv = SamplerParameterfv(fun _ _ _ -> warn (notLinked<SamplerParameterfv>()))
let glSamplerParameterfv sampler parameterName parameter =
  _glSamplerParameterfv.Invoke(sampler, parameterName, parameter)

type private SamplerParameterIiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glSamplerParameterIiv = SamplerParameterIiv(fun _ _ _ -> warn (notLinked<SamplerParameterIiv>()))
let glSamplerParameterIiv sampler parameterName parameter =
  _glSamplerParameterIiv.Invoke(sampler, parameterName, parameter)

type private SamplerParameterIuiv = delegate of uint * uint * nativeptr<uint> -> unit
let mutable private _glSamplerParameterIuiv = SamplerParameterIuiv(fun _ _ _ -> warn (notLinked<SamplerParameterIuiv>()))
let glSamplerParameterIuiv sampler parameterName parameter =
  _glSamplerParameterIuiv.Invoke(sampler, parameterName, parameter)

type private GetSamplerParameteriv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetSamplerParameteriv = GetSamplerParameteriv(fun _ _ _ -> warn (notLinked<GetSamplerParameteriv>()))
let glGetSamplerParameteriv sampler parameterName parameters =
  _glGetSamplerParameteriv.Invoke(sampler, parameterName, parameters)

type private GetSamplerParameterIiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetSamplerParameterIiv = GetSamplerParameterIiv(fun _ _ _ -> warn (notLinked<GetSamplerParameterIiv>()))
let glGetSamplerParameterIiv sampler parameterName parameters =
  _glGetSamplerParameterIiv.Invoke(sampler, parameterName, parameters)

type private GetSamplerParameterfv = delegate of uint * uint * nativeptr<single> -> unit
let mutable private _glGetSamplerParameterfv = GetSamplerParameterfv(fun _ _ _ -> warn (notLinked<GetSamplerParameterfv>()))
let glGetSamplerParameterfv sampler parameterName parameters =
  _glGetSamplerParameterfv.Invoke(sampler, parameterName, parameters)

type private GetSamplerParameterIuiv = delegate of uint * uint * nativeptr<uint> -> unit
let mutable private _glGetSamplerParameterIuiv = GetSamplerParameterIuiv(fun _ _ _ -> warn (notLinked<GetSamplerParameterIuiv>()))
let glGetSamplerParameterIuiv sampler parameterName parameters =
  _glGetSamplerParameterIuiv.Invoke(sampler, parameterName, parameters)

type private QueryCounter = delegate of uint * uint -> unit
let mutable private _glQueryCounter = QueryCounter(fun _ _ -> warn (notLinked<QueryCounter>()))
let glQueryCounter id target = _glQueryCounter.Invoke(id, target)

type private GetQueryObjecti64v = delegate of uint * uint * nativeptr<int64> -> unit
let mutable private _glGetQueryObjecti64v = GetQueryObjecti64v(fun _ _ _ -> warn (notLinked<GetQueryObjecti64v>()))
let glGetQueryObjecti64v id parameterName parameters = _glGetQueryObjecti64v.Invoke(id, parameterName, parameters)

type private GetQueryObjectui64v = delegate of uint * uint * nativeptr<uint64> -> unit
let mutable private _glGetQueryObjectui64v = GetQueryObjectui64v(fun _ _ _ -> warn (notLinked<GetQueryObjectui64v>()))
let glGetQueryObjectui64v id parameterName parameters = _glGetQueryObjectui64v.Invoke(id, parameterName, parameters)

type private VertexAttribDivisor = delegate of uint * uint -> unit
let mutable private _glVertexAttribDivisor = VertexAttribDivisor(fun _ _ -> warn (notLinked<VertexAttribDivisor>()))
let glVertexAttribDivisor index divisor = _glVertexAttribDivisor.Invoke(index, divisor)

type private VertexAttribP1ui = delegate of uint * uint * bool * nativeptr<uint> -> unit
let mutable private _glVertexAttribP1ui = VertexAttribP1ui(fun _ _ _ _ -> warn (notLinked<VertexAttribP1ui>()))
let glVertexAttribP1ui index ``type`` normalized value =
  _glVertexAttribP1ui.Invoke(index, ``type``, normalized, value)

type private VertexAttribP1uiv = delegate of uint * uint * bool * nativeptr<uint> -> unit
let mutable private _glVertexAttribP1uiv = VertexAttribP1uiv(fun _ _ _ _ -> warn (notLinked<VertexAttribP1uiv>()))
let glVertexAttribP1uiv index ``type`` normalized value =
  _glVertexAttribP1uiv.Invoke(index, ``type``, normalized, value)

type private VertexAttribP2ui = delegate of uint * uint * bool * uint -> unit
let mutable private _glVertexAttribP2ui = VertexAttribP2ui(fun _ _ _ _ -> warn (notLinked<VertexAttribP2ui>()))
let glVertexAttribP2ui index ``type`` normalized value =
  _glVertexAttribP2ui.Invoke(index, ``type``, normalized, value)

type private VertexAttribP2uiv = delegate of uint * uint * bool * nativeptr<uint> -> unit
let mutable private _glVertexAttribP2uiv = VertexAttribP2uiv(fun _ _ _ _ -> warn (notLinked<VertexAttribP2uiv>()))
let glVertexAttribP2uiv index ``type`` normalized value =
  _glVertexAttribP2uiv.Invoke(index, ``type``, normalized, value)

type private VertexAttribP3ui = delegate of uint * uint * bool * uint -> unit
let mutable private _glVertexAttribP3ui = VertexAttribP3ui(fun _ _ _ _ -> warn (notLinked<VertexAttribP3ui>()))
let glVertexAttribP3ui index ``type`` normalized value =
  _glVertexAttribP3ui.Invoke(index, ``type``, normalized, value)

type private VertexAttribP3uiv = delegate of uint * uint * bool * nativeptr<uint> -> unit
let mutable private _glVertexAttribP3uiv = VertexAttribP3uiv(fun _ _ _ _ -> warn (notLinked<VertexAttribP3uiv>()))
let glVertexAttribP3uiv index ``type`` normalized value =
  _glVertexAttribP3uiv.Invoke(index, ``type``, normalized, value)

type private VertexAttribP4ui = delegate of uint * uint * bool * uint -> unit
let mutable private _glVertexAttribP4ui = VertexAttribP4ui(fun _ _ _ _ -> warn (notLinked<VertexAttribP4ui>()))
let glVertexAttribP4ui index ``type`` normalized value =
  _glVertexAttribP4ui.Invoke(index, ``type``, normalized, value)

type private VertexAttribP4uiv = delegate of uint * uint * bool * nativeptr<uint> -> unit
let mutable private _glVertexAttribP4uiv = VertexAttribP4uiv(fun _ _ _ _ -> warn (notLinked<VertexAttribP4uiv>()))
let glVertexAttribP4uiv index ``type`` normalized value =
  _glVertexAttribP4uiv.Invoke(index, ``type``, normalized, value)

let internal setup handler =
  _glBindFragDataLocationIndexed <- commonSetup handler _glBindFragDataLocationIndexed
  _glGetFragDataIndex <- commonSetup handler _glGetFragDataIndex
  _glGenSamplers <- commonSetup handler _glGenSamplers
  _glDeleteSamplers <- commonSetup handler _glDeleteSamplers
  _glIsSampler <- commonSetup handler _glIsSampler
  _glBindSampler <- commonSetup handler _glBindSampler
  _glSamplerParameteri <- commonSetup handler _glSamplerParameteri
  _glSamplerParameteriv <- commonSetup handler _glSamplerParameteriv
  _glSamplerParameterf <- commonSetup handler _glSamplerParameterf
  _glSamplerParameterfv <- commonSetup handler _glSamplerParameterfv
  _glSamplerParameterIiv <- commonSetup handler _glSamplerParameterIiv
  _glSamplerParameterIuiv <- commonSetup handler _glSamplerParameterIuiv
  _glGetSamplerParameteriv <- commonSetup handler _glGetSamplerParameteriv
  _glGetSamplerParameterIiv <- commonSetup handler _glGetSamplerParameterIiv
  _glGetSamplerParameterfv <- commonSetup handler _glGetSamplerParameterfv
  _glGetSamplerParameterIuiv <- commonSetup handler _glGetSamplerParameterIuiv
  _glQueryCounter <- commonSetup handler _glQueryCounter
  _glGetQueryObjecti64v <- commonSetup handler _glGetQueryObjecti64v
  _glGetQueryObjectui64v <- commonSetup handler _glGetQueryObjectui64v
  _glVertexAttribDivisor <- commonSetup handler _glVertexAttribDivisor
  _glVertexAttribP1ui <- commonSetup handler _glVertexAttribP1ui
  _glVertexAttribP1uiv <- commonSetup handler _glVertexAttribP1uiv
  _glVertexAttribP2ui <- commonSetup handler _glVertexAttribP2ui
  _glVertexAttribP2uiv <- commonSetup handler _glVertexAttribP2uiv
  _glVertexAttribP3ui <- commonSetup handler _glVertexAttribP3ui
  _glVertexAttribP3uiv <- commonSetup handler _glVertexAttribP3uiv
  _glVertexAttribP4ui <- commonSetup handler _glVertexAttribP4ui
  _glVertexAttribP4uiv <- commonSetup handler _glVertexAttribP4uiv