[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL1_5

#nowarn "9" // Unverifiable IL due to fixed expression and NativePtr library usage

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common
open Komodo.Backends.OpenGL.Api.Constants
open Microsoft.FSharp.NativeInterop

type private GenQueries = delegate of int * unativeint -> unit
let mutable private _glGenQueries = GenQueries(fun _ _ -> warn (notLinked<GenQueries>()))
let glGenQueries n ids = _glGenQueries.Invoke(n, ids)

type private DeleteQueries = delegate of int * unativeint -> unit
let mutable private _glDeleteQueries = DeleteQueries(fun _ _ -> warn (notLinked<DeleteQueries>()))
let glDeleteQueries n ids = _glDeleteQueries.Invoke(n, ids)

type private IsQuery = delegate of uint -> bool
let mutable private _glIsQuery = IsQuery(fun _ -> warn (notLinked<IsQuery>()); false; )
let glIsQuery id = _glIsQuery.Invoke(id)

type private BeginQuery = delegate of uint * uint -> unit
let mutable private _glBeginQuery = BeginQuery(fun _ _ -> warn (notLinked<BeginQuery>()))
let glBeginQuery target id = _glBeginQuery.Invoke(target, id)

type private EndQuery = delegate of uint -> unit
let mutable private _glEndQuery = EndQuery(fun _ -> warn (notLinked<EndQuery>()))
let glEndQuery target = _glEndQuery.Invoke(target)

type private GetQueryiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetQueryiv = GetQueryiv(fun _ _ _ -> warn (notLinked<GetQueryiv>()))
let glGetQueryiv target parameterName parameters = _glGetQueryiv.Invoke(target, parameterName, parameters)

type private GetQueryObjectiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetQueryObjectiv = GetQueryObjectiv(fun _ _ _ -> warn (notLinked<GetQueryObjectiv>()))
let glGetQueryObjectiv id parameterName parameters = _glGetQueryObjectiv.Invoke(id, parameterName, parameters)

type private GetQueryObjectuiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetQueryObjectuiv = GetQueryObjectuiv(fun _ _ _ -> warn (notLinked<GetQueryObjectuiv>()))
let glGetQueryObjectuiv id parameterName parameters = _glGetQueryObjectuiv.Invoke(id, parameterName, parameters)

type private BindBuffer = delegate of uint * uint -> unit
let mutable private _glBindBuffer = BindBuffer(fun _ _ -> warn (notLinked<BindBuffer>()))
let glBindBuffer target buffer = _glBindBuffer.Invoke(target, buffer)

type private DeleteBuffers = delegate of int * nativeptr<uint> -> unit
let mutable private _glDeleteBuffers = DeleteBuffers(fun _ _ -> warn (notLinked<DeleteBuffers>()))
let glDeleteBuffers n buffers = _glDeleteBuffers.Invoke(n, buffers)

type private GenBuffers = delegate of int * nativeptr<uint> -> unit
let mutable private _glGenBuffers = GenBuffers(fun _ _ -> warn (notLinked<GenBuffers>()))
let glGenBuffers n =
  let buffers = Array.zeroCreate n
  use ptr = fixed (&(buffers.[0])) in
    _glGenBuffers.Invoke(n, ptr)
  buffers
let glGenBuffer() =
  let ptr = NativePtr.stackalloc<uint> 1
  _glGenBuffers.Invoke(1, ptr)
  NativePtr.get ptr 0

type private IsBuffer = delegate of uint -> bool
let mutable private _glIsBuffer = IsBuffer(fun _ -> warn (notLinked<IsBuffer>()); false; )
let glIsBuffer buffer = _glIsBuffer.Invoke(buffer)

type private BufferData = delegate of uint * unativeint * voidptr * uint -> unit
let mutable private _glBufferData = BufferData(fun _ _ _ _ -> warn (notLinked<BufferData>()))
let glBufferData<'T when 'T : unmanaged>
  target
  (data:array<'T>)
  usage =
    use ptr = fixed (&data.[0]) in
      _glBufferData.Invoke(
        target,
        (data.Length * sizeof<'T>) |> unativeint,
        (NativePtr.toVoidPtr ptr),
        usage )

type private BufferSubData = delegate of uint * nativeptr<int> * unativeint * voidptr -> unit
let mutable private _glBufferSubData = BufferSubData(fun _ _ _ _ -> warn (notLinked<BufferSubData>()))
let glBufferSubData target offset size data = _glBufferSubData.Invoke(target, offset, size, data)

type private GetBufferSubData = delegate of uint * nativeptr<int> * unativeint * voidptr -> unit
let mutable private _glGetBufferSubData = GetBufferSubData(fun _ _ _ _ -> warn (notLinked<GetBufferSubData>()))
let glGetBufferSubData target offset size data = _glGetBufferSubData.Invoke(target, offset, size, data)

type private MapBuffer = delegate of uint * uint -> voidptr
let mutable private _glMapBuffer = MapBuffer(fun _ _ -> warn (notLinked<MapBuffer>()); GL_NULL; )
let glMapBuffer target access = _glMapBuffer.Invoke(target, access)

type private UnmapBuffer = delegate of uint -> bool
let mutable private _glUnmapBuffer = UnmapBuffer(fun _ -> warn (notLinked<UnmapBuffer>()); false; )
let glUnmapBuffer target = _glUnmapBuffer.Invoke(target)

type private GetBufferParameteriv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetBufferParameteriv = GetBufferParameteriv(fun _ _ _ -> warn (notLinked<GetBufferParameteriv>()))
let glGetBufferParameteriv target parameterName parameters = _glGetBufferParameteriv.Invoke(target, parameterName, parameters)

type private GetBufferPointerv = delegate of uint * uint * voidptr -> unit // Was originally void**
let mutable private _glGetBufferPointerv = GetBufferPointerv(fun _ _ _ -> warn (notLinked<GetBufferPointerv>()))
let glGetBufferPointerv target parameterName parameters = _glGetBufferPointerv.Invoke(target, parameterName, parameters)

let internal setup handler =
  _glGenQueries <- commonSetup handler _glGenQueries
  _glDeleteQueries <- commonSetup handler _glDeleteQueries
  _glIsQuery <- commonSetup handler _glIsQuery
  _glBeginQuery <- commonSetup handler _glBeginQuery
  _glEndQuery <- commonSetup handler _glEndQuery
  _glGetQueryiv <- commonSetup handler _glGetQueryiv
  _glGetQueryObjectiv <- commonSetup handler _glGetQueryObjectiv
  _glGetQueryObjectuiv <- commonSetup handler _glGetQueryObjectuiv
  _glBindBuffer <- commonSetup handler _glBindBuffer
  _glDeleteBuffers <- commonSetup handler _glDeleteBuffers
  _glGenBuffers <- commonSetup handler _glGenBuffers
  _glIsBuffer <- commonSetup handler _glIsBuffer
  _glBufferData <- commonSetup handler _glBufferData
  _glBufferSubData <- commonSetup handler _glBufferSubData
  _glGetBufferSubData <- commonSetup handler _glGetBufferSubData
  _glMapBuffer <- commonSetup handler _glMapBuffer
  _glUnmapBuffer <- commonSetup handler _glUnmapBuffer
  _glGetBufferParameteriv <- commonSetup handler _glGetBufferParameteriv
  _glGetBufferPointerv <- commonSetup handler _glGetBufferPointerv