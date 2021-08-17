[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL3_0

#nowarn "9" // unverifiable IL due to NativePtr library usage

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common
open Komodo.Backends.OpenGL.Api.Constants
open Microsoft.FSharp.NativeInterop

type private ColorMaski = delegate of uint * uint * nativeptr<bool> -> unit
let mutable private _glColorMaski = ColorMaski(fun _ _ _ -> warn (notLinked<ColorMaski>()))
let glColorMaski target index data = _glColorMaski.Invoke(target, index, data)

type private GetBooleani_v = delegate of uint * bool * bool * bool * bool -> unit
let mutable private _glGetBooleani_v = GetBooleani_v(fun _ _ _ _ _ -> warn (notLinked<GetBooleani_v>()))
let glGetBooleani_v index r g b a = _glGetBooleani_v.Invoke(index, r, g, b, a)

type private GetIntegeri_v = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetIntegeri_v = GetIntegeri_v(fun _ _ _ -> warn (notLinked<GetIntegeri_v>()))
let glGetIntegeri_v target index data = _glGetIntegeri_v.Invoke(target, index, data)

type private Enablei = delegate of uint * uint -> unit
let mutable private _glEnablei = Enablei(fun _ _ -> warn (notLinked<Enablei>()))
let glEnablei target index = _glEnablei.Invoke(target, index)

type private Disablei = delegate of uint * uint -> unit
let mutable private _glDisablei = Disablei(fun _ _ -> warn (notLinked<Disablei>()))
let glDisablei target index = _glDisablei.Invoke(target, index)

type private IsEnabledi = delegate of uint * uint -> bool
let mutable private _glIsEnabledi = IsEnabledi(fun _ _ -> warn (notLinked<IsEnabledi>()); false; )
let glIsEnabledi target index = _glIsEnabledi.Invoke(target, index)

type private BeginTransformFeedback = delegate of uint -> unit
let mutable private _glBeginTransformFeedback = BeginTransformFeedback(fun _ -> warn (notLinked<BeginTransformFeedback>()))
let glBeginTransformFeedback primitiveMode = _glBeginTransformFeedback.Invoke(primitiveMode)

type private EndTransformFeedback = delegate of unit -> unit
let mutable private _glEndTransformFeedback = EndTransformFeedback(fun _ -> warn (notLinked<EndTransformFeedback>()))
let glEndTransformFeedback() = _glEndTransformFeedback.Invoke()

type private BindBufferRange = delegate of uint * uint * uint * nativeptr<int> * unativeint -> unit
let mutable private _glBindBufferRange = BindBufferRange(fun _ _ _ _ _ -> warn (notLinked<BindBufferRange>()))
let glBindBufferRange target index buffer offset size = _glBindBufferRange.Invoke(target, index, buffer, offset, size)

type private BindBufferBase = delegate of uint * uint * uint -> unit
let mutable private _glBindBufferBase = BindBufferBase(fun _ _ _ -> warn (notLinked<BindBufferBase>()))
let glBindBufferBase target index buffer = _glBindBufferBase.Invoke(target, index, buffer)

type private TransformFeedbackVaryings = delegate of uint * int * nativeptr<char> * uint -> unit
let mutable private _glTransformFeedbackVaryings = TransformFeedbackVaryings(fun _ _ _ _ -> warn (notLinked<TransformFeedbackVaryings>()))
let glTransformFeedbackVaryings program count varyings bufferMode =
  _glTransformFeedbackVaryings.Invoke(program, count, varyings, bufferMode)

type private GetTransformFeedbackVarying = delegate of uint * uint * int * unativeint * unativeint * nativeptr<int> * nativeptr<char> -> unit
let mutable private _glGetTransformFeedbackVarying = GetTransformFeedbackVarying(fun _ _ _ _ _ _ _ -> warn (notLinked<GetTransformFeedbackVarying>()))
let glGetTransformFeedbackVarying program index bufferSize length size ``type`` name =
  _glGetTransformFeedbackVarying.Invoke(program, index, bufferSize, length, size, ``type``, name)

type private ClampColor = delegate of uint * uint -> unit
let mutable private _glClampColor = ClampColor(fun _ _ -> warn (notLinked<ClampColor>()))
let glClampColor target clamp = _glClampColor.Invoke(target, clamp)

type private BeginConditionalRender = delegate of uint * uint -> unit
let mutable private _glBeginConditionalRender = BeginConditionalRender(fun _ _ -> warn (notLinked<BeginConditionalRender>()))
let glBeginConditionalRender id mode = _glBeginConditionalRender.Invoke(id, mode)

type private EndConditionalRender = delegate of unit -> unit
let mutable private _glEndConditionalRender = EndConditionalRender(fun _ -> warn (notLinked<EndConditionalRender>()))
let glEndConditionalRender() = _glEndConditionalRender.Invoke()

type private VertexAttribIPointer = delegate of uint * int * uint * int * voidptr -> unit
let mutable private _glVertexAttribIPointer = VertexAttribIPointer(fun _  _ _ _ _ -> warn (notLinked<VertexAttribIPointer>()))
let glVertexAttribIPointer index size ``type`` stride pointer = _glVertexAttribIPointer.Invoke(index, size, ``type``, stride, pointer)

type private GetVertexAttribIiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetVertexAttribIiv = GetVertexAttribIiv(fun _ _ _ -> warn (notLinked<GetVertexAttribIiv>()))
let glGetVertexAttribIiv index parameterName parameters = _glGetVertexAttribIiv.Invoke(index, parameterName, parameters)

type private GetVertexAttribIuiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetVertexAttribIuiv = GetVertexAttribIuiv(fun _ _ _ -> warn (notLinked<GetVertexAttribIuiv>()))
let glGetVertexAttribIuiv index parameterName parameters = _glGetVertexAttribIuiv.Invoke(index, parameterName, parameters)

type private VertexAttribI1i = delegate of uint * int -> unit
let mutable private _glVertexAttribI1i = VertexAttribI1i(fun _ _ -> warn (notLinked<VertexAttribI1i>()))
let glVertexAttribI1i index x = _glVertexAttribI1i.Invoke(index, x)

type private VertexAttribI2i = delegate of uint * int * int -> unit
let mutable private _glVertexAttribI2i = VertexAttribI2i(fun _ _ _ -> warn (notLinked<VertexAttribI2i>()))
let glVertexAttribI2i index x y = _glVertexAttribI2i.Invoke(index, x, y)

type private VertexAttribI3i = delegate of uint * int * int * int -> unit
let mutable private _glVertexAttribI3i = VertexAttribI3i(fun _ _ _ _ -> warn (notLinked<VertexAttribI3i>()))
let glVertexAttribI3i index x y z = _glVertexAttribI3i.Invoke(index, x, y, z)

type private VertexAttribI4i = delegate of uint * int * int * int * int -> unit
let mutable private _glVertexAttribI4i = VertexAttribI4i(fun _ _ _ _ _ -> warn (notLinked<VertexAttribI4i>()))
let glVertexAttribI4i index x y z w = _glVertexAttribI4i.Invoke(index, x, y, z, w)

type private VertexAttribI1ui = delegate of uint * uint -> unit
let mutable private _glVertexAttribI1ui = VertexAttribI1ui(fun _ _ -> warn (notLinked<VertexAttribI1ui>()))
let glVertexAttribI1ui index x = _glVertexAttribI1ui.Invoke(index, x)

type private VertexAttribI2ui = delegate of uint * uint * uint -> unit
let mutable private _glVertexAttribI2ui = VertexAttribI2ui(fun _ _ _ -> warn (notLinked<VertexAttribI2ui>()))
let glVertexAttribI2ui index x y = _glVertexAttribI2ui.Invoke(index, x, y)

type private VertexAttribI3ui = delegate of uint * uint * uint * uint -> unit
let mutable private _glVertexAttribI3ui = VertexAttribI3ui(fun _ _ _ _ -> warn (notLinked<VertexAttribI3ui>()))
let glVertexAttribI3ui index x y z = _glVertexAttribI3ui.Invoke(index, x, y, z)

type private VertexAttribI4ui = delegate of uint * uint * uint * uint * uint -> unit
let mutable private _glVertexAttribI4ui = VertexAttribI4ui(fun _ _ _ _ _ -> warn (notLinked<VertexAttribI4ui>()))
let glVertexAttribI4ui index x y z w = _glVertexAttribI4ui.Invoke(index, x, y, z, w)

type private VertexAttribI1iv = delegate of uint * nativeptr<int> -> unit
let mutable private _glVertexAttribI1iv = VertexAttribI1iv(fun _ _ -> warn (notLinked<VertexAttribI1iv>()))
let glVertexAttribI1iv index values = _glVertexAttribI1iv.Invoke(index, values)

type private VertexAttribI2iv = delegate of uint * nativeptr<int> -> unit
let mutable private _glVertexAttribI2iv = VertexAttribI2iv(fun _ _ -> warn (notLinked<VertexAttribI2iv>()))
let glVertexAttribI2iv index values = _glVertexAttribI2iv.Invoke(index, values)

type private VertexAttribI3iv = delegate of uint * nativeptr<int> -> unit
let mutable private _glVertexAttribI3iv = VertexAttribI3iv(fun _ _ -> warn (notLinked<VertexAttribI3iv>()))
let glVertexAttribI3iv index values = _glVertexAttribI3iv.Invoke(index, values)

type private VertexAttribI4iv = delegate of uint * nativeptr<int> -> unit
let mutable private _glVertexAttribI4iv = VertexAttribI4iv(fun _ _ -> warn (notLinked<VertexAttribI4iv>()))
let glVertexAttribI4iv index values = _glVertexAttribI4iv.Invoke(index, values)

type private VertexAttribI1uiv = delegate of uint * nativeptr<uint> -> unit
let mutable private _glVertexAttribI1uiv = VertexAttribI1uiv(fun _ _ -> warn (notLinked<VertexAttribI1uiv>()))
let glVertexAttribI1uiv index values = _glVertexAttribI1uiv.Invoke(index, values)

type private VertexAttribI2uiv = delegate of uint * nativeptr<uint> -> unit
let mutable private _glVertexAttribI2uiv = VertexAttribI2uiv(fun _ _ -> warn (notLinked<VertexAttribI2uiv>()))
let glVertexAttribI2uiv index values = _glVertexAttribI2uiv.Invoke(index, values)

type private VertexAttribI3uiv = delegate of uint * nativeptr<uint> -> unit
let mutable private _glVertexAttribI3uiv = VertexAttribI3uiv(fun _ _ -> warn (notLinked<VertexAttribI3uiv>()))
let glVertexAttribI3uiv index values = _glVertexAttribI3uiv.Invoke(index, values)

type private VertexAttribI4uiv = delegate of uint * nativeptr<uint> -> unit
let mutable private _glVertexAttribI4uiv = VertexAttribI4uiv(fun _ _ -> warn (notLinked<VertexAttribI4uiv>()))
let glVertexAttribI4uiv index values = _glVertexAttribI4uiv.Invoke(index, values)

type private VertexAttribI4bv = delegate of uint * nativeptr<sbyte> -> unit
let mutable private _glVertexAttribI4bv = VertexAttribI4bv(fun _ _ -> warn (notLinked<VertexAttribI4bv>()))
let glVertexAttribI4bv index values = _glVertexAttribI4bv.Invoke(index, values)

type private VertexAttribI4sv = delegate of uint * nativeptr<int16> -> unit
let mutable private _glVertexAttribI4sv = VertexAttribI4sv(fun _ _ -> warn (notLinked<VertexAttribI4sv>()))
let glVertexAttribI4sv index values = _glVertexAttribI4sv.Invoke(index, values)

type private VertexAttribI4ubv = delegate of uint * nativeptr<byte> -> unit
let mutable private _glVertexAttribI4ubv = VertexAttribI4ubv(fun _ _ -> warn (notLinked<VertexAttribI4ubv>()))
let glVertexAttribI4ubv index values = _glVertexAttribI4ubv.Invoke(index, values)

type private VertexAttribI4usv = delegate of uint * nativeptr<uint16> -> unit
let mutable private _glVertexAttribI4usv = VertexAttribI4usv(fun _ _ -> warn (notLinked<VertexAttribI4usv>()))
let glVertexAttribI4usv index values = _glVertexAttribI4usv.Invoke(index, values)

type private GetUniformuiv = delegate of uint * int * nativeptr<uint> -> unit
let mutable private _glGetUniformuiv = GetUniformuiv(fun _ _ _ -> warn (notLinked<GetUniformuiv>()))
let glGetUniformuiv program location parameters = _glGetUniformuiv.Invoke(program, location, parameters)

type private BindFragDataLocation = delegate of uint * uint * nativeptr<char> -> unit
let mutable private _glBindFragDataLocation = BindFragDataLocation(fun _ _ _ -> warn (notLinked<BindFragDataLocation>()))
let glBindFragDataLocation program color name = _glBindFragDataLocation.Invoke(program, color, name)

type private GetFragDataLocation = delegate of uint * nativeptr<char> -> int
let mutable private _glGetFragDataLocation = GetFragDataLocation(fun _ _ -> warn (notLinked<GetFragDataLocation>()); 0; )
let glGetFragDataLocation program name = _glGetFragDataLocation.Invoke(program, name)

type private Uniform1ui = delegate of int * uint -> unit
let mutable private _glUniform1ui = Uniform1ui(fun _ _ -> warn (notLinked<Uniform1ui>()))
let glUniform1ui location value = _glUniform1ui.Invoke(location, value)

type private Uniform2ui = delegate of int * uint * uint -> unit
let mutable private _glUniform2ui = Uniform2ui(fun _ _ _ -> warn (notLinked<Uniform2ui>()))
let glUniform2ui location value0 value1 = _glUniform2ui.Invoke(location, value0, value1)

type private Uniform3ui = delegate of int * uint * uint * uint -> unit
let mutable private _glUniform3ui = Uniform3ui(fun _ _ _ _ -> warn (notLinked<Uniform3ui>()))
let glUniform3ui location value0 value1 value2 = _glUniform3ui.Invoke(location, value0, value1, value2)

type private Uniform4ui = delegate of int * uint * uint * uint * uint -> unit
let mutable private _glUniform4ui = Uniform4ui(fun _ _ _ _ _ -> warn (notLinked<Uniform4ui>()))
let glUniform4ui location value0 value1 value2 value3 = _glUniform4ui.Invoke(location, value0, value1, value2, value3)

type private Uniform1uiv = delegate of int * int * nativeptr<uint> -> unit
let mutable private _glUniform1uiv = Uniform1uiv(fun _ _ _ -> warn (notLinked<Uniform1uiv>()))
let glUniform1uiv location count value = _glUniform1uiv.Invoke(location, count, value)

type private Uniform2uiv = delegate of int * int * nativeptr<uint> -> unit
let mutable private _glUniform2uiv = Uniform2uiv(fun _ _ _ -> warn (notLinked<Uniform2uiv>()))
let glUniform2uiv location count value = _glUniform2uiv.Invoke(location, count, value)

type private Uniform3uiv = delegate of int * int * nativeptr<uint> -> unit
let mutable private _glUniform3uiv = Uniform3uiv(fun _ _ _ -> warn (notLinked<Uniform3uiv>()))
let glUniform3uiv location count value = _glUniform3uiv.Invoke(location, count, value)

type private Uniform4uiv = delegate of int * int * nativeptr<uint> -> unit
let mutable private _glUniform4uiv = Uniform4uiv(fun _ _ _ -> warn (notLinked<Uniform4uiv>()))
let glUniform4uiv location count value = _glUniform4uiv.Invoke(location, count, value)

type private TexParameterIiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glTexParameterIiv = TexParameterIiv(fun _ _ _ -> warn (notLinked<TexParameterIiv>()))
let glTexParameterIiv target parameterName parameters = _glTexParameterIiv.Invoke(target, parameterName, parameters)

type private TexParameterIuiv = delegate of uint * uint * nativeptr<uint> -> unit
let mutable private _glTexParameterIuiv = TexParameterIuiv(fun _ _ _ -> warn (notLinked<TexParameterIuiv>()))
let glTexParameterIuiv target parameterName parameters = _glTexParameterIuiv.Invoke(target, parameterName, parameters)

type private GetTexParameterIiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetTexParameterIiv = GetTexParameterIiv(fun _ _ _ -> warn (notLinked<GetTexParameterIiv>()))
let glGetTexParameterIiv target parameterName parameters = _glGetTexParameterIiv.Invoke(target, parameterName, parameters)

type private GetTexParameterIuiv = delegate of uint * uint * nativeptr<uint> -> unit
let mutable private _glGetTexParameterIuiv = GetTexParameterIuiv(fun _ _ _ -> warn (notLinked<GetTexParameterIuiv>()))
let glGetTexParameterIuiv target parameterName parameters = _glGetTexParameterIuiv.Invoke(target, parameterName, parameters)

type private ClearBufferiv = delegate of uint * int * nativeptr<int> -> unit
let mutable private _glClearBufferiv = ClearBufferiv(fun _ _ _ -> warn (notLinked<ClearBufferiv>()))
let glClearBufferiv buffer drawBuffer value = _glClearBufferiv.Invoke(buffer, drawBuffer, value)

type private ClearBufferuiv = delegate of uint * int * nativeptr<uint> -> unit
let mutable private _glClearBufferuiv = ClearBufferuiv(fun _ _ _ -> warn (notLinked<ClearBufferuiv>()))
let glClearBufferuiv buffer drawBuffer value = _glClearBufferuiv.Invoke(buffer, drawBuffer, value)

type private ClearBufferfv = delegate of uint * int * nativeptr<single> -> unit
let mutable private _glClearBufferfv = ClearBufferfv(fun _ _ _ -> warn (notLinked<ClearBufferfv>()))
let glClearBufferfv buffer drawBuffer value = _glClearBufferfv.Invoke(buffer, drawBuffer, value)

type private ClearBufferfi = delegate of uint * int * single * int -> unit
let mutable private _glClearBufferfi = ClearBufferfi(fun _ _ _ _ -> warn (notLinked<ClearBufferfi>()))
let glClearBufferfi buffer drawBuffer depth stencil = _glClearBufferfi.Invoke(buffer, drawBuffer, depth, stencil)

type private GetStringi = delegate of uint * uint -> nativeptr<byte>
let mutable private _glGetStringi = GetStringi(fun _ _ -> warn (notLinked<GetStringi>()); NativePtr.ofVoidPtr GL_NULL; )
let glGetStringi name index = _glGetStringi.Invoke(name, index)

type private IsRenderbuffer = delegate of uint -> bool
let mutable private _glIsRenderbuffer = IsRenderbuffer(fun _ -> warn (notLinked<IsRenderbuffer>()); false; )
let glIsRenderbuffer renderBuffer = _glIsRenderbuffer.Invoke(renderBuffer)

type private BindRenderbuffer = delegate of uint * uint -> unit
let mutable private _glBindRenderbuffer = BindRenderbuffer(fun _ _ -> warn (notLinked<BindRenderbuffer>()))
let glBindRenderbuffer target renderBuffer = _glBindRenderbuffer.Invoke(target, renderBuffer)

type private DeleteRenderbuffers = delegate of int * nativeptr<uint>  -> unit
let mutable private _glDeleteRenderbuffers = DeleteRenderbuffers(fun _ _ -> warn (notLinked<DeleteRenderbuffers>()))
let glDeleteRenderbuffers n renderBuffers = _glDeleteRenderbuffers.Invoke(n, renderBuffers)

type private GenRenderbuffers = delegate of int * nativeptr<uint>  -> unit
let mutable private _glGenRenderbuffers = GenRenderbuffers(fun _ _ -> warn (notLinked<GenRenderbuffers>()))
let glGenRenderbuffers n renderBuffers = _glGenRenderbuffers.Invoke(n, renderBuffers)

type private RenderbufferStorage = delegate of uint * uint * int * int -> unit
let mutable private _glRenderbufferStorage = RenderbufferStorage(fun _ _ _ _ -> warn (notLinked<RenderbufferStorage>()))
let glRenderbufferStorage target internalFormat width height = _glRenderbufferStorage.Invoke(target, internalFormat, width, height)

type private GetRenderbufferParameteriv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetRenderbufferParameteriv = GetRenderbufferParameteriv(fun _ _ _ -> warn (notLinked<GetRenderbufferParameteriv>()))
let glGetRenderbufferParameteriv target parameterName parameters =
  _glGetRenderbufferParameteriv.Invoke(target, parameterName, parameters)

type private IsFramebuffer = delegate of uint -> bool
let mutable private _glIsFramebuffer = IsFramebuffer(fun _ -> warn (notLinked<IsFramebuffer>()); false; )
let glIsFramebuffer frameBuffer = _glIsFramebuffer.Invoke(frameBuffer)

type private BindFramebuffer = delegate of uint * uint -> unit
let mutable private _glBindFramebuffer = BindFramebuffer(fun _ _ -> warn (notLinked<BindFramebuffer>()))
let glBindFramebuffer target frameBuffer = _glBindFramebuffer.Invoke(target, frameBuffer)

type private DeleteFramebuffers = delegate of int * nativeptr<uint> -> unit
let mutable private _glDeleteFramebuffers = DeleteFramebuffers(fun _ _ -> warn (notLinked<DeleteFramebuffers>()))
let glDeleteFramebuffers n frameBuffers = _glDeleteFramebuffers.Invoke(n, frameBuffers)

type private GenFramebuffers = delegate of int * nativeptr<uint> -> unit
let mutable private _glGenFramebuffers = GenFramebuffers(fun _ _ -> warn (notLinked<GenFramebuffers>()))
let glGenFramebuffers n frameBuffers = _glGenFramebuffers.Invoke(n, frameBuffers)

type private CheckFramebufferStatus = delegate of uint -> uint
let mutable private _glCheckFramebufferStatus = CheckFramebufferStatus(fun _ -> warn (notLinked<CheckFramebufferStatus>()); 0u; )
let glCheckFramebufferStatus target = _glCheckFramebufferStatus.Invoke(target)

type private FramebufferTexture1D = delegate of uint * uint * uint * uint * int -> unit
let mutable private _glFramebufferTexture1D = FramebufferTexture1D(fun _ _ _ _ _ -> warn (notLinked<FramebufferTexture1D>()))
let glFramebufferTexture1D target attachment textureTarget texture level =
  _glFramebufferTexture1D.Invoke(target, attachment, textureTarget, texture, level)

type private FramebufferTexture2D = delegate of uint * uint * uint * uint * int -> unit
let mutable private _glFramebufferTexture2D = FramebufferTexture2D(fun _ _ _ _ _ -> warn (notLinked<FramebufferTexture2D>()))
let glFramebufferTexture2D target attachment textureTarget texture level =
  _glFramebufferTexture2D.Invoke(target, attachment, textureTarget, texture, level)

type private FramebufferTexture3D = delegate of uint * uint * uint * uint * int * int -> unit
let mutable private _glFramebufferTexture3D = FramebufferTexture3D(fun _ _ _ _ _ _ -> warn (notLinked<FramebufferTexture3D>()))
let glFramebufferTexture3D target attachment textureTarget texture level zOffset =
  _glFramebufferTexture3D.Invoke(target, attachment, textureTarget, texture, level, zOffset)

type private FramebufferRenderbuffer = delegate of uint * uint * uint * uint -> unit
let mutable private _glFramebufferRenderbuffer = FramebufferRenderbuffer(fun _ _ _ _ -> warn (notLinked<FramebufferRenderbuffer>()))
let glFramebufferRenderbuffer target attachment renderBufferTarget renderBuffer =
  _glFramebufferRenderbuffer.Invoke(target, attachment, renderBufferTarget, renderBuffer)

type private GetFramebufferAttachmentParameteriv = delegate of uint * uint * uint * nativeptr<int> -> unit
let mutable private _glGetFramebufferAttachmentParameteriv = GetFramebufferAttachmentParameteriv(fun _ _ _ _ -> warn (notLinked<GetFramebufferAttachmentParameteriv>()))
let glGetFramebufferAttachmentParameteriv target attachment parameterName parameters =
  _glGetFramebufferAttachmentParameteriv.Invoke(target, attachment, parameterName, parameters)

type private GenerateMipmap = delegate of uint -> unit
let mutable private _glGenerateMipmap = GenerateMipmap(fun _ -> warn (notLinked<GenerateMipmap>()))
let glGenerateMipmap target = _glGenerateMipmap.Invoke(target)

type private BlitFramebuffer = delegate of int * int * int * int * int * int * int * int * uint * uint -> unit
let mutable private _glBlitFramebuffer = BlitFramebuffer(fun _ _ _ _ _ _ _ _ _ _ -> warn (notLinked<BlitFramebuffer>()))
let glBlitFramebuffer srcX0 srcY0 srcX1 srcY1 dstX0 dstY0 dstX1 dstY1 mask filter =
  _glBlitFramebuffer.Invoke(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter)

type private RenderbufferStorageMultisample = delegate of uint * int * uint * int * int -> unit
let mutable private _glRenderbufferStorageMultisample = RenderbufferStorageMultisample(fun _ _ _ _ _ -> warn (notLinked<RenderbufferStorageMultisample>()))
let glRenderbufferStorageMultisample target samples internalFormat width height =
  _glRenderbufferStorageMultisample.Invoke(target, samples, internalFormat, width, height)

type private FramebufferTextureLayer = delegate of uint * uint * uint * int * int -> unit
let mutable private _glFramebufferTextureLayer = FramebufferTextureLayer(fun _ _ _ _ _ -> warn (notLinked<FramebufferTextureLayer>()))
let glFramebufferTextureLayer target attachment texture level layer =
  _glFramebufferTextureLayer.Invoke(target, attachment, texture, level, layer)

type private MapBufferRange = delegate of uint * nativeptr<int> * unativeint * uint -> voidptr
let mutable private _glMapBufferRange = MapBufferRange(fun _ _ _ _ -> warn (notLinked<MapBufferRange>()); GL_NULL; )
let glMapBufferRange target offset length access = _glMapBufferRange.Invoke(target, offset, length, access)

type private FlushMappedBufferRange = delegate of uint * nativeptr<int> * unativeint -> unit
let mutable private _glFlushMappedBufferRange = FlushMappedBufferRange(fun _ _ _ -> warn (notLinked<FlushMappedBufferRange>()))
let glFlushMappedBufferRange target offset length = _glFlushMappedBufferRange.Invoke(target, offset, length)

type private BindVertexArray = delegate of uint -> unit
let mutable private _glBindVertexArray = BindVertexArray(fun _ -> warn (notLinked<BindVertexArray>()))
let glBindVertexArray arr = _glBindVertexArray.Invoke(arr)

type private DeleteVertexArrays = delegate of int * nativeptr<uint> -> unit
let mutable private _glDeleteVertexArrays = DeleteVertexArrays(fun _ _ -> warn (notLinked<DeleteVertexArrays>()))
let glDeleteVertexArrays n arrays = _glDeleteVertexArrays.Invoke(n, arrays)

type private GenVertexArrays = delegate of int * nativeptr<uint> -> unit
let mutable private _glGenVertexArrays = GenVertexArrays(fun _ _ -> warn (notLinked<GenVertexArrays>()))
let glGenVertexArrays n arrays = _glGenVertexArrays.Invoke(n, arrays)
let glGenVertexArray() =
  let ptr = NativePtr.stackalloc<uint> 1
  _glGenVertexArrays.Invoke(1, ptr)
  NativePtr.get ptr 0

type private IsVertexArray = delegate of uint -> bool
let mutable private _glIsVertexArray = IsVertexArray(fun _ -> warn (notLinked<IsVertexArray>()); false; )
let glIsVertexArray arr = _glIsVertexArray.Invoke(arr)


let internal setup handler =
  _glColorMaski <- commonSetup handler _glColorMaski
  _glGetBooleani_v <- commonSetup handler _glGetBooleani_v
  _glGetIntegeri_v <- commonSetup handler _glGetIntegeri_v
  _glEnablei <- commonSetup handler _glEnablei
  _glDisablei <- commonSetup handler _glDisablei
  _glIsEnabledi <- commonSetup handler _glIsEnabledi
  _glBeginTransformFeedback <- commonSetup handler _glBeginTransformFeedback
  _glEndTransformFeedback <- commonSetup handler _glEndTransformFeedback
  _glBindBufferRange <- commonSetup handler _glBindBufferRange
  _glBindBufferBase <- commonSetup handler _glBindBufferBase
  _glTransformFeedbackVaryings <- commonSetup handler _glTransformFeedbackVaryings
  _glGetTransformFeedbackVarying <- commonSetup handler _glGetTransformFeedbackVarying
  _glClampColor <- commonSetup handler _glClampColor
  _glBeginConditionalRender <- commonSetup handler _glBeginConditionalRender
  _glEndConditionalRender <- commonSetup handler _glEndConditionalRender
  _glVertexAttribIPointer <- commonSetup handler _glVertexAttribIPointer
  _glGetVertexAttribIiv <- commonSetup handler _glGetVertexAttribIiv
  _glGetVertexAttribIuiv <- commonSetup handler _glGetVertexAttribIuiv
  _glVertexAttribI1i <- commonSetup handler _glVertexAttribI1i
  _glVertexAttribI2i <- commonSetup handler _glVertexAttribI2i
  _glVertexAttribI3i <- commonSetup handler _glVertexAttribI3i
  _glVertexAttribI4i <- commonSetup handler _glVertexAttribI4i
  _glVertexAttribI1ui <- commonSetup handler _glVertexAttribI1ui
  _glVertexAttribI2ui <- commonSetup handler _glVertexAttribI2ui
  _glVertexAttribI3ui <- commonSetup handler _glVertexAttribI3ui
  _glVertexAttribI4ui <- commonSetup handler _glVertexAttribI4ui
  _glVertexAttribI1iv <- commonSetup handler _glVertexAttribI1iv
  _glVertexAttribI2iv <- commonSetup handler _glVertexAttribI2iv
  _glVertexAttribI3iv <- commonSetup handler _glVertexAttribI3iv
  _glVertexAttribI4iv <- commonSetup handler _glVertexAttribI4iv
  _glVertexAttribI1uiv <- commonSetup handler _glVertexAttribI1uiv
  _glVertexAttribI2uiv <- commonSetup handler _glVertexAttribI2uiv
  _glVertexAttribI3uiv <- commonSetup handler _glVertexAttribI3uiv
  _glVertexAttribI4uiv <- commonSetup handler _glVertexAttribI4uiv
  _glVertexAttribI4bv <- commonSetup handler _glVertexAttribI4bv
  _glVertexAttribI4sv <- commonSetup handler _glVertexAttribI4sv
  _glVertexAttribI4ubv <- commonSetup handler _glVertexAttribI4ubv
  _glVertexAttribI4usv <- commonSetup handler _glVertexAttribI4usv
  _glGetUniformuiv <- commonSetup handler _glGetUniformuiv
  _glBindFragDataLocation <- commonSetup handler _glBindFragDataLocation
  _glGetFragDataLocation <- commonSetup handler _glGetFragDataLocation
  _glUniform1ui <- commonSetup handler _glUniform1ui
  _glUniform2ui <- commonSetup handler _glUniform2ui
  _glUniform3ui <- commonSetup handler _glUniform3ui
  _glUniform4ui <- commonSetup handler _glUniform4ui
  _glUniform1uiv <- commonSetup handler _glUniform1uiv
  _glUniform2uiv <- commonSetup handler _glUniform2uiv
  _glUniform3uiv <- commonSetup handler _glUniform3uiv
  _glUniform4uiv <- commonSetup handler _glUniform4uiv
  _glTexParameterIiv <- commonSetup handler _glTexParameterIiv
  _glTexParameterIuiv <- commonSetup handler _glTexParameterIuiv
  _glGetTexParameterIiv <- commonSetup handler _glGetTexParameterIiv
  _glGetTexParameterIuiv <- commonSetup handler _glGetTexParameterIuiv
  _glClearBufferiv <- commonSetup handler _glClearBufferiv
  _glClearBufferuiv <- commonSetup handler _glClearBufferuiv
  _glClearBufferfv <- commonSetup handler _glClearBufferfv
  _glClearBufferfi <- commonSetup handler _glClearBufferfi
  _glGetStringi <- commonSetup handler _glGetStringi
  _glIsRenderbuffer <- commonSetup handler _glIsRenderbuffer
  _glBindRenderbuffer <- commonSetup handler _glBindRenderbuffer
  _glDeleteRenderbuffers <- commonSetup handler _glDeleteRenderbuffers
  _glGenRenderbuffers <- commonSetup handler _glGenRenderbuffers
  _glRenderbufferStorage <- commonSetup handler _glRenderbufferStorage
  _glGetRenderbufferParameteriv <- commonSetup handler _glGetRenderbufferParameteriv
  _glIsFramebuffer <- commonSetup handler _glIsFramebuffer
  _glBindFramebuffer <- commonSetup handler _glBindFramebuffer
  _glDeleteFramebuffers <- commonSetup handler _glDeleteFramebuffers
  _glGenFramebuffers <- commonSetup handler _glGenFramebuffers
  _glCheckFramebufferStatus <- commonSetup handler _glCheckFramebufferStatus
  _glFramebufferTexture1D <- commonSetup handler _glFramebufferTexture1D
  _glFramebufferTexture2D <- commonSetup handler _glFramebufferTexture2D
  _glFramebufferTexture3D <- commonSetup handler _glFramebufferTexture3D
  _glFramebufferRenderbuffer <- commonSetup handler _glFramebufferRenderbuffer
  _glGetFramebufferAttachmentParameteriv <- commonSetup handler _glGetFramebufferAttachmentParameteriv
  _glGenerateMipmap <- commonSetup handler _glGenerateMipmap
  _glBlitFramebuffer <- commonSetup handler _glBlitFramebuffer
  _glRenderbufferStorageMultisample <- commonSetup handler _glRenderbufferStorageMultisample
  _glFramebufferTextureLayer <- commonSetup handler _glFramebufferTextureLayer
  _glMapBufferRange <- commonSetup handler _glMapBufferRange
  _glFlushMappedBufferRange <- commonSetup handler _glFlushMappedBufferRange
  _glBindVertexArray <- commonSetup handler _glBindVertexArray
  _glDeleteVertexArrays <- commonSetup handler _glDeleteVertexArrays
  _glGenVertexArrays <- commonSetup handler _glGenVertexArrays
  _glIsVertexArray <- commonSetup handler _glIsVertexArray
