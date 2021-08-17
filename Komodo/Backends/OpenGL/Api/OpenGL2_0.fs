[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL2_0

#nowarn "9" // Unverifiable IL due to fixed expression and NativePtr library usage

open Komodo.Logging
open Komodo.Backends.OpenGL.Api.Common
open Komodo.Backends.OpenGL.Api.Constants
open Microsoft.FSharp.NativeInterop

type private BlendEquationSeparate = delegate of uint * uint -> unit
let mutable private _glBlendEquationSeparate = BlendEquationSeparate(fun _ _ -> warn (notLinked<BlendEquationSeparate>()))
let glBlendEquationSeparate modeRGB modeAlpha = _glBlendEquationSeparate.Invoke(modeRGB, modeAlpha)

type private DrawBuffers = delegate of int * nativeptr<uint> -> unit
let mutable private _glDrawBuffers = DrawBuffers(fun _ _ -> warn (notLinked<DrawBuffers>()))
let glDrawBuffers n buffers = _glDrawBuffers.Invoke(n, buffers)

type private StencilOpSeparate = delegate of uint * uint * uint * uint -> unit
let mutable private _glStencilOpSeparate = StencilOpSeparate(fun _ _ _ _ -> warn (notLinked<StencilOpSeparate>()))
let glStencilOpSeparate face sFail dpFail dpPass = _glStencilOpSeparate.Invoke(face, sFail, dpFail, dpPass)

type private StencilFuncSeparate = delegate of uint * uint * int * uint -> unit
let mutable private _glStencilFuncSeparate = StencilFuncSeparate(fun _ _ _ _ -> warn (notLinked<StencilFuncSeparate>()))
let glStencilFuncSeparate face func reference mask = _glStencilFuncSeparate.Invoke(face, func, reference, mask)

type private StencilMaskSeparate = delegate of uint * uint -> unit
let mutable private _glStencilMaskSeparate = StencilMaskSeparate(fun _ _ -> warn (notLinked<StencilMaskSeparate>()))
let glStencilMaskSeparate face mask = _glStencilMaskSeparate.Invoke(face, mask)

type private AttachShader = delegate of uint * uint -> unit
let mutable private _glAttachShader = AttachShader(fun _ _ -> warn (notLinked<AttachShader>()))
let glAttachShader program shader = _glAttachShader.Invoke(program, shader)

type private BindAttribLocation = delegate of uint * uint * nativeptr<char> -> unit
let mutable private _glBindAttribLocation = BindAttribLocation(fun _ _ _ -> warn (notLinked<BindAttribLocation>()))
let glBindAttribLocation program index name = _glBindAttribLocation.Invoke(program, index, name)

type private CompileShader = delegate of uint -> unit
let mutable private _glCompileShader = CompileShader(fun _ -> warn (notLinked<CompileShader>()))
let glCompileShader shader = _glCompileShader.Invoke(shader)

type private CreateProgram = delegate of unit -> uint
let mutable private _glCreateProgram =
  CreateProgram(fun _ -> warn (notLinked<CreateProgram>()); 0u; )
let glCreateProgram() = _glCreateProgram.Invoke()

type private CreateShader = delegate of uint -> uint
let mutable private _glCreateShader = CreateShader(fun _ -> warn (notLinked<CreateShader>()); 0u; )
let glCreateShader ``type`` = _glCreateShader.Invoke(``type``)

type private DeleteProgram = delegate of uint -> unit
let mutable private _glDeleteProgram = DeleteProgram(fun _ -> warn (notLinked<DeleteProgram>()))
let glDeleteProgram program = _glDeleteProgram.Invoke(program)

type private DeleteShader = delegate of uint -> unit
let mutable private _glDeleteShader = DeleteShader(fun _ -> warn (notLinked<DeleteShader>()))
let glDeleteShader shader = _glDeleteShader.Invoke(shader)

type private DetachShader = delegate of uint * uint -> unit
let mutable private _glDetachShader = DetachShader(fun _ _ -> warn (notLinked<DetachShader>()))
let glDetachShader program shader = _glDetachShader.Invoke(program, shader)

type private DisableVertexAttribArray = delegate of uint -> unit
let mutable private _glDisableVertexAttribArray = DisableVertexAttribArray(fun _ -> warn (notLinked<DisableVertexAttribArray>()))
let glDisableVertexAttribArray index = _glDisableVertexAttribArray.Invoke(index)

type private EnableVertexAttribArray = delegate of uint -> unit
let mutable private _glEnableVertexAttribArray = EnableVertexAttribArray(fun _ -> warn (notLinked<EnableVertexAttribArray>()))
let glEnableVertexAttribArray index = _glEnableVertexAttribArray.Invoke(index)

type private GetActiveAttrib = delegate of uint * uint * int * unativeint * unativeint * nativeptr<int> * nativeptr<char> -> unit
let mutable private _glGetActiveAttrib = GetActiveAttrib(fun _ _ _ _ _ _ _ -> warn (notLinked<GetActiveAttrib>()))
let glGetActiveAttrib program index bufferSize length size ``type`` name =
  _glGetActiveAttrib.Invoke(program, index, bufferSize, length, size, ``type``, name)

type private GetActiveUniform = delegate of uint * uint * int * unativeint * unativeint * nativeptr<int> * nativeptr<char> -> unit
let mutable private _glGetActiveUniform = GetActiveUniform(fun _ _ _ _ _ _ _ -> warn (notLinked<GetActiveUniform>()))
let glGetActiveUniform program index bufferSize length size ``type`` name =
  _glGetActiveUniform.Invoke(program, index, bufferSize, length, size, ``type``, name)

type private GetAttachedShaders = delegate of uint * unativeint * unativeint * nativeptr<uint> -> unit
let mutable private _glGetAttachedShaders = GetAttachedShaders(fun _ _ _ _ -> warn (notLinked<GetAttachedShaders>()))
let glGetAttachedShaders program maxCount count shaders = _glGetAttachedShaders.Invoke(program, maxCount, count, shaders)

type private GetAttribLocation = delegate of uint * nativeptr<char> -> int
let mutable private _glGetAttribLocation = GetAttribLocation(fun _ _ -> warn (notLinked<GetAttribLocation>()); 0; )
let glGetAttribLocation program name = _glGetAttribLocation.Invoke(program, name)

type private GetProgramiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetProgramiv = GetProgramiv(fun _ _ _ -> warn (notLinked<GetProgramiv>()))
let glGetProgramiv program parameterName =
  getIv
    ( fun id parameterName ptr ->
      _glGetProgramiv.Invoke(
        id,
        parameterName,
        ptr )
      () )
    program
    parameterName

type private GetProgramInfoLog = delegate of uint * int * nativeptr<int> * nativeptr<byte> -> unit
let mutable private _glGetProgramInfoLog = GetProgramInfoLog(fun _ _ _ _ -> warn (notLinked<GetProgramInfoLog>()))
let glGetProgramInfoLog program =
  getInfoLog
    ( fun id bufSize lengthPtr bufferPtr ->
        _glGetProgramInfoLog.Invoke(
          id,
          bufSize, 
          lengthPtr,
          bufferPtr ))
    program

type private GetShaderiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetShaderiv = GetShaderiv(fun _ _ _ -> warn (notLinked<GetShaderiv>()))
let glGetShaderiv shader parameterName =
  getIv
    ( fun id parameterName ptr ->
      _glGetShaderiv.Invoke(
        id,
        parameterName,
        ptr )
      () )
    shader
    parameterName

type private GetShaderInfoLog = delegate of uint * int * nativeptr<int> * nativeptr<byte> -> unit
let mutable private _glGetShaderInfoLog = GetShaderInfoLog(fun _ _ _ _ -> warn (notLinked<GetShaderInfoLog>()))
let glGetShaderInfoLog shader =
  getInfoLog
    ( fun id bufSize lengthPtr bufferPtr ->
        _glGetShaderInfoLog.Invoke(
          id,
          bufSize, 
          lengthPtr,
          bufferPtr ))
    shader

type private GetShaderSource = delegate of uint * int * nativeptr<int> * nativeptr<char> -> unit
let mutable private _glGetShaderSource = GetShaderSource(fun _ _ _ _ -> warn (notLinked<GetShaderSource>()))
let glGetShaderSource shader bufferSize length source = _glGetShaderSource.Invoke(shader, bufferSize, length, source)

type private GetUniformLocation = delegate of uint * nativeptr<byte> -> int
let mutable private _glGetUniformLocation = GetUniformLocation(fun _ _ -> warn (notLinked<GetUniformLocation>()); 0; )
let glGetUniformLocation program name = _glGetUniformLocation.Invoke(program, name)

type private GetUniformfv = delegate of uint * int * nativeptr<single> -> unit
let mutable private _glGetUniformfv = GetUniformfv(fun _ _ _ -> warn (notLinked<GetUniformfv>()))
let glGetUniformfv program location parameters = _glGetUniformfv.Invoke(program, location, parameters)

type private GetUniformiv = delegate of uint * int * nativeptr<int> -> unit
let mutable private _glGetUniformiv = GetUniformiv(fun _ _ _ -> warn (notLinked<GetUniformiv>()))
let glGetUniformiv program location parameters = _glGetUniformiv.Invoke(program, location, parameters)

type private GetVertexAttribdv = delegate of uint * uint * nativeptr<double> -> unit
let mutable private _glGetVertexAttribdv = GetVertexAttribdv(fun _ _ _ -> warn (notLinked<GetVertexAttribdv>()))
let glGetVertexAttribdv index parameterName parameters = _glGetVertexAttribdv.Invoke(index, parameterName, parameters)

type private GetVertexAttribfv = delegate of uint * uint * nativeptr<single> -> unit
let mutable private _glGetVertexAttribfv = GetVertexAttribfv(fun _ _ _ -> warn (notLinked<GetVertexAttribfv>()))
let glGetVertexAttribfv index parameterName parameters = _glGetVertexAttribfv.Invoke(index, parameterName, parameters)

type private GetVertexAttribiv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetVertexAttribiv = GetVertexAttribiv(fun _ _ _ -> warn (notLinked<GetVertexAttribiv>()))
let glGetVertexAttribiv index parameterName parameters = _glGetVertexAttribiv.Invoke(index, parameterName, parameters)

type private GetVertexAttribPointerv = delegate of uint * uint * voidptr -> unit // Was void**
let mutable private _glGetVertexAttribPointerv = GetVertexAttribPointerv(fun _ _ _ -> warn (notLinked<GetVertexAttribPointerv>()))
let glGetVertexAttribPointerv index parameterName parameters = _glGetVertexAttribPointerv.Invoke(index, parameterName, parameters)

type private IsProgram = delegate of uint -> bool
let mutable private _glIsProgram = IsProgram(fun _ -> warn (notLinked<IsProgram>()); false; )
let glIsProgram program = _glIsProgram.Invoke(program)

type private IsShader = delegate of uint -> bool
let mutable private _glIsShader = IsShader(fun _ -> warn (notLinked<IsShader>()); false; )
let glIsShader shader = _glIsShader.Invoke(shader)

type private LinkProgram = delegate of uint -> unit
let mutable private _glLinkProgram = LinkProgram(fun _ -> warn (notLinked<LinkProgram>()))
let glLinkProgram program = _glLinkProgram.Invoke(program)

type private ShaderSource = delegate of uint * int * nativeptr<nativeptr<byte>> * nativeptr<int> -> unit
let mutable private _glShaderSource = ShaderSource(fun _ _ _ _ -> warn (notLinked<ShaderSource>()))
let glShaderSource shader (source:string) =
  let buffer = System.Text.Encoding.UTF8.GetBytes(source)
  let sourcesPtr = NativePtr.stackalloc<nativeptr<byte>> 1
  use ptr = fixed (&buffer.[0])
  NativePtr.set sourcesPtr 0 ptr
  let lengthPtr = NativePtr.stackalloc<int> 1
  NativePtr.set lengthPtr 0 (buffer.Length)
  _glShaderSource.Invoke(
    shader,
    1,
    sourcesPtr,
    lengthPtr )

type private UseProgram = delegate of uint -> unit
let mutable private _glUseProgram = UseProgram(fun _ -> warn (notLinked<UseProgram>()))
let glUseProgram program = _glUseProgram.Invoke(program)

type private Uniform1f = delegate of int * single -> unit
let mutable private _glUniform1f = Uniform1f(fun _ _ -> warn (notLinked<Uniform1f>()))
let glUniform1f location value = _glUniform1f.Invoke(location, value)

type private Uniform2f = delegate of int * single * single -> unit
let mutable private _glUniform2f = Uniform2f(fun _ _ _ -> warn (notLinked<Uniform2f>()))
let glUniform2f location value0 value1 = _glUniform2f.Invoke(location, value0, value1)

type private Uniform3f = delegate of int * single * single * single -> unit
let mutable private _glUniform3f = Uniform3f(fun _ _ _ _ -> warn (notLinked<Uniform3f>()))
let glUniform3f location value0 value1 value2 = _glUniform3f.Invoke(location, value0, value1, value2)

type private Uniform4f = delegate of int * single * single * single * single -> unit
let mutable private _glUniform4f = Uniform4f(fun _ _ _ _ _ -> warn (notLinked<Uniform4f>()))
let glUniform4f location value0 value1 value2 value3 = _glUniform4f.Invoke(location, value0, value1, value2, value3)

type private Uniform1i = delegate of int * int -> unit
let mutable private _glUniform1i = Uniform1i(fun _ _ -> warn (notLinked<Uniform1i>()))
let glUniform1i location value = _glUniform1i.Invoke(location, value)

type private Uniform2i = delegate of int * int * int -> unit
let mutable private _glUniform2i = Uniform2i(fun _ _ _ -> warn (notLinked<Uniform2i>()))
let glUniform2i location value0 value1 = _glUniform2i.Invoke(location, value0, value1)

type private Uniform3i = delegate of int * int * int * int -> unit
let mutable private _glUniform3i = Uniform3i(fun _ _ _ _ -> warn (notLinked<Uniform3i>()))
let glUniform3i location value0 value1 value2 = _glUniform3i.Invoke(location, value0, value1, value2)

type private Uniform4i = delegate of int * int * int * int * int -> int
let mutable private _glUniform4i = Uniform4i(fun _ _ _ _ _ -> warn (notLinked<Uniform4i>()); 0; )
let glUniform4i location value0 value1 value2 value3 = _glUniform4i.Invoke(location, value0, value1, value2, value3)

type private Uniform1fv = delegate of int * nativeptr<single> -> unit
let mutable private _glUniform1fv = Uniform1fv(fun _ _ -> warn (notLinked<Uniform1fv>()))
let glUniform1fv location values = _glUniform1fv.Invoke(location, values)

type private Uniform2fv = delegate of int * nativeptr<single> * nativeptr<single> -> unit
let mutable private _glUniform2fv = Uniform2fv(fun _ _ _ -> warn (notLinked<Uniform2fv>()))
let glUniform2fv location values0 values1 = _glUniform2fv.Invoke(location, values0, values1)

type private Uniform3fv = delegate of int * nativeptr<single> * nativeptr<single> * nativeptr<single> -> unit
let mutable private _glUniform3fv = Uniform3fv(fun _ _ _ _ -> warn (notLinked<Uniform3fv>()))
let glUniform3fv location values0 values1 values2 = _glUniform3fv.Invoke(location, values0, values1, values2)

type private Uniform4fv = delegate of int * nativeptr<single> * nativeptr<single> * nativeptr<single> * nativeptr<single> -> unit
let mutable private _glUniform4fv = Uniform4fv(fun _ _ _ _ _ -> warn (notLinked<Uniform4fv>()))
let glUniform4fv location values0 values1 values2 values3 = _glUniform4fv.Invoke(location, values0, values1, values2, values3)

type private Uniform1iv = delegate of int * nativeptr<int> -> unit
let mutable private _glUniform1iv = Uniform1iv(fun _ _ -> warn (notLinked<Uniform1iv>()))
let glUniform1iv location values = _glUniform1iv.Invoke(location, values)

type private Uniform2iv = delegate of int * nativeptr<int> * nativeptr<int> -> unit
let mutable private _glUniform2iv = Uniform2iv(fun _ _ _ -> warn (notLinked<Uniform2iv>()))
let glUniform2iv location values0 values1 = _glUniform2iv.Invoke(location, values0, values1)

type private Uniform3iv = delegate of int * nativeptr<int> * nativeptr<int> * nativeptr<int> -> unit
let mutable private _glUniform3iv = Uniform3iv(fun _ _ _ _ -> warn (notLinked<Uniform3iv>()))
let glUniform3iv location values0 values1 values2 = _glUniform3iv.Invoke(location, values0, values1, values2)

type private Uniform4iv = delegate of int * nativeptr<int> * nativeptr<int> * nativeptr<int> * nativeptr<int> -> unit
let mutable private _glUniform4iv = Uniform4iv(fun _ _ _ _ _ -> warn (notLinked<Uniform4iv>()))
let glUniform4iv location values0 values1 values2 values3 = _glUniform4iv.Invoke(location, values0, values1, values2, values3)

type private UniformMatrix2fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix2fv = UniformMatrix2fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix2fv>()))
let glUniformMatrix2fv location count transpose value = _glUniformMatrix2fv.Invoke(location, count, transpose, value)

type private UniformMatrix3fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix3fv = UniformMatrix3fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix3fv>()))
let glUniformMatrix3fv location count transpose value = _glUniformMatrix3fv.Invoke(location, count, transpose, value)

type private UniformMatrix4fv = delegate of int * int * bool * nativeptr<single> -> unit
let mutable private _glUniformMatrix4fv = UniformMatrix4fv(fun _ _ _ _ -> warn (notLinked<UniformMatrix4fv>()))
let glUniformMatrix4fv location count transpose value = _glUniformMatrix4fv.Invoke(location, count, transpose, value)

type private ValidateProgram = delegate of uint -> unit
let mutable private _glValidateProgram = ValidateProgram(fun _ -> warn (notLinked<ValidateProgram>()))
let glValidateProgram program = _glValidateProgram.Invoke(program)

type private VertexAttrib1d = delegate of uint * double -> unit
let mutable private _glVertexAttrib1d = VertexAttrib1d(fun _ _ -> warn (notLinked<VertexAttrib1d>()))
let glVertexAttrib1d index value = _glVertexAttrib1d.Invoke(index, value)

type private VertexAttrib1dv = delegate of uint * nativeptr<double> -> unit
let mutable private _glVertexAttrib1dv = VertexAttrib1dv(fun _ _ -> warn (notLinked<VertexAttrib1dv>()))
let glVertexAttrib1dv index values = _glVertexAttrib1dv.Invoke(index, values)

type private VertexAttrib1f = delegate of uint * single -> unit
let mutable private _glVertexAttrib1f = VertexAttrib1f(fun _ _ -> warn (notLinked<VertexAttrib1f>()))
let glVertexAttrib1f index value = _glVertexAttrib1f.Invoke(index, value)

type private VertexAttrib1fv = delegate of uint * nativeptr<single> -> unit
let mutable private _glVertexAttrib1fv = VertexAttrib1fv(fun _ _ -> warn (notLinked<VertexAttrib1fv>()))
let glVertexAttrib1fv index values = _glVertexAttrib1fv.Invoke(index, values)

type private VertexAttrib1s = delegate of uint * int16 -> unit
let mutable private _glVertexAttrib1s = VertexAttrib1s(fun _ _ -> warn (notLinked<VertexAttrib1s>()))
let glVertexAttrib1s index value = _glVertexAttrib1s.Invoke(index, value)

type private VertexAttrib1sv = delegate of uint * nativeptr<int16> -> unit
let mutable private _glVertexAttrib1sv = VertexAttrib1sv(fun _ _ -> warn (notLinked<VertexAttrib1sv>()))
let glVertexAttrib1sv index values = _glVertexAttrib1sv.Invoke(index, values)

type private VertexAttrib2d = delegate of uint * double * double -> unit
let mutable private _glVertexAttrib2d = VertexAttrib2d(fun _ _ _ -> warn (notLinked<VertexAttrib2d>()))
let glVertexAttrib2d index value0 value1 = _glVertexAttrib2d.Invoke(index, value0, value1)

type private VertexAttrib2dv = delegate of uint * nativeptr<double> -> unit
let mutable private _glVertexAttrib2dv = VertexAttrib2dv(fun _ _ -> warn (notLinked<VertexAttrib2dv>()))
let glVertexAttrib2dv index values = _glVertexAttrib2dv.Invoke(index, values)

type private VertexAttrib2f = delegate of uint * single * single -> unit
let mutable private _glVertexAttrib2f = VertexAttrib2f(fun _ _ _ -> warn (notLinked<VertexAttrib2f>()))
let glVertexAttrib2f index value0 value1 = _glVertexAttrib2f.Invoke(index, value0, value1)

type private VertexAttrib2fv = delegate of uint * nativeptr<single> -> unit
let mutable private _glVertexAttrib2fv = VertexAttrib2fv(fun _ _ -> warn (notLinked<VertexAttrib2fv>()))
let glVertexAttrib2fv index values = _glVertexAttrib2fv.Invoke(index, values)

type private VertexAttrib2s = delegate of uint * int16 * int16 -> unit
let mutable private _glVertexAttrib2s = VertexAttrib2s(fun _ _ _ -> warn (notLinked<VertexAttrib2s>()))
let glVertexAttrib2s index value0 value1 = _glVertexAttrib2s.Invoke(index, value0, value1)

type private VertexAttrib2sv = delegate of uint * nativeptr<int16> -> unit
let mutable private _glVertexAttrib2sv = VertexAttrib2sv(fun _ _ -> warn (notLinked<VertexAttrib2sv>()))
let glVertexAttrib12v index values = _glVertexAttrib2sv.Invoke(index, values)

type private VertexAttrib3d = delegate of uint * double * double * double -> unit
let mutable private _glVertexAttrib3d = VertexAttrib3d(fun _ _ _ _ -> warn (notLinked<VertexAttrib3d>()))
let glVertexAttrib3d index value0 value1 value2 = _glVertexAttrib3d.Invoke(index, value0, value1, value2)

type private VertexAttrib3dv = delegate of uint * nativeptr<double> -> unit
let mutable private _glVertexAttrib3dv = VertexAttrib3dv(fun _ _ -> warn (notLinked<VertexAttrib3dv>()))
let glVertexAttrib3dv index values = _glVertexAttrib3dv.Invoke(index, values)

type private VertexAttrib3f = delegate of uint * single * single * single -> unit
let mutable private _glVertexAttrib3f = VertexAttrib3f(fun _ _ _ _ -> warn (notLinked<VertexAttrib3f>()))
let glVertexAttrib3f index value0 value1 value2 = _glVertexAttrib3f.Invoke(index, value0, value1, value2)

type private VertexAttrib3fv = delegate of uint * nativeptr<single> -> unit
let mutable private _glVertexAttrib3fv = VertexAttrib3fv(fun _ _ -> warn (notLinked<VertexAttrib3fv>()))
let glVertexAttrib3fv index values = _glVertexAttrib3fv.Invoke(index, values)

type private VertexAttrib3s = delegate of uint * int16 * int16 * int16 -> unit
let mutable private _glVertexAttrib3s = VertexAttrib3s(fun _ _ _ _ -> warn (notLinked<VertexAttrib3s>()))
let glVertexAttrib3s index value0 value1 value2 = _glVertexAttrib3s.Invoke(index, value0, value1, value2)

type private VertexAttrib3sv = delegate of uint * nativeptr<int16> -> unit
let mutable private _glVertexAttrib3sv = VertexAttrib3sv(fun _ _ -> warn (notLinked<VertexAttrib3sv>()))
let glVertexAttrib13sv index values = _glVertexAttrib3sv.Invoke(index, values)

type private VertexAttrib4Nbv = delegate of uint * nativeptr<sbyte> -> unit
let mutable private _glVertexAttrib4Nbv = VertexAttrib4Nbv(fun _ _ -> warn (notLinked<VertexAttrib4Nbv>()))
let glVertexAttrib4Nbv index values = _glVertexAttrib4Nbv.Invoke(index, values)

type private VertexAttrib4Niv = delegate of uint * nativeptr<int> -> unit
let mutable private _glVertexAttrib4Niv = VertexAttrib4Niv(fun _ _ -> warn (notLinked<VertexAttrib4Niv>()))
let glVertexAttrib4Niv index values = _glVertexAttrib4Niv.Invoke(index, values)

type private VertexAttrib4Nsv = delegate of uint * nativeptr<int16> -> unit
let mutable private _glVertexAttrib4Nsv = VertexAttrib4Nsv(fun _ _ -> warn (notLinked<VertexAttrib4Nsv>()))
let glVertexAttrib4Nsv index values = _glVertexAttrib4Nsv.Invoke(index, values)

type private VertexAttrib4Nub = delegate of uint * byte * byte * byte * byte -> unit
let mutable private _glVertexAttrib4Nub = VertexAttrib4Nub(fun _ _ _ _ _ -> warn (notLinked<VertexAttrib4Nub>()))
let glVertexAttrib4Nub index x y z w = _glVertexAttrib4Nub.Invoke(index, x, y, z, w)

type private VertexAttrib4Nubv = delegate of uint * nativeptr<byte> -> unit
let mutable private _glVertexAttrib4Nubv = VertexAttrib4Nubv(fun _ _ -> warn (notLinked<VertexAttrib4Nubv>()))
let glVertexAttrib4Nubv index values = _glVertexAttrib4Nubv.Invoke(index, values)

type private VertexAttrib4Nuiv = delegate of  uint * nativeptr<uint> -> unit
let mutable private _glVertexAttrib4Nuiv = VertexAttrib4Nuiv(fun _ _ -> warn (notLinked<VertexAttrib4Nuiv>()))
let glVertexAttrib4Nuiv index values = _glVertexAttrib4Nuiv.Invoke(index, values)

type private VertexAttrib4Nusv = delegate of uint * nativeptr<uint16> -> unit
let mutable private _glVertexAttrib4Nusv = VertexAttrib4Nusv(fun _ _ -> warn (notLinked<VertexAttrib4Nusv>()))
let glVertexAttrib4Nusv index values = _glVertexAttrib4Nusv.Invoke(index, values)

type private VertexAttrib4bv = delegate of uint * nativeptr<sbyte> -> unit
let mutable private _glVertexAttrib4bv = VertexAttrib4bv(fun _ _ -> warn (notLinked<VertexAttrib4bv>()))
let glVertexAttrib4bv index values = _glVertexAttrib4bv.Invoke(index, values)

type private VertexAttrib4d = delegate of uint * double * double * double * double -> unit
let mutable private _glVertexAttrib4d = VertexAttrib4d(fun _ _ _ _ _ -> warn (notLinked<VertexAttrib4d>()))
let glVertexAttrib4d index x y z w = _glVertexAttrib4d.Invoke(index, x, y, z, w)

type private VertexAttrib4dv = delegate of uint * nativeptr<double> -> unit
let mutable private _glVertexAttrib4dv = VertexAttrib4dv(fun _ _ -> warn (notLinked<VertexAttrib4dv>()))
let glVertexAttrib4dv index values = _glVertexAttrib4dv.Invoke(index, values)

type private VertexAttrib4f = delegate of uint * single * single * single * single -> unit
let mutable private _glVertexAttrib4f = VertexAttrib4f(fun _ _ _ _ _ -> warn (notLinked<VertexAttrib4f>()))
let glVertexAttrib4f index x y z w = _glVertexAttrib4f.Invoke(index, x, y, z, w)

type private VertexAttrib4fv = delegate of uint * nativeptr<single> -> unit
let mutable private _glVertexAttrib4fv = VertexAttrib4fv(fun _ _ -> warn (notLinked<VertexAttrib4fv>()))
let glVertexAttrib4fv index values = _glVertexAttrib4fv.Invoke(index, values)

type private VertexAttrib4iv = delegate of uint * nativeptr<int> -> unit
let mutable private _glVertexAttrib4iv = VertexAttrib4iv(fun _ _ -> warn (notLinked<VertexAttrib4iv>()))
let glVertexAttrib4iv index values = _glVertexAttrib4iv.Invoke(index, values)

type private VertexAttrib4s = delegate of uint * int16 * int16 * int16 * int16 -> unit
let mutable private _glVertexAttrib4s = VertexAttrib4s(fun _ _ _ _ _ -> warn (notLinked<VertexAttrib4s>()))
let glVertexAttrib4s index x y z w = _glVertexAttrib4s.Invoke(index, x, y, z, w)

type private VertexAttrib4sv = delegate of uint * nativeptr<int16> -> unit
let mutable private _glVertexAttrib4sv = VertexAttrib4sv(fun _ _ -> warn (notLinked<VertexAttrib4sv>()))
let glVertexAttrib4sv index values = _glVertexAttrib4sv.Invoke(index, values)

type private VertexAttrib4ubv = delegate of uint * nativeptr<byte> -> unit
let mutable private _glVertexAttrib4ubv = VertexAttrib4ubv(fun _ _ -> warn (notLinked<VertexAttrib4ubv>()))
let glVertexAttrib4ubv index values = _glVertexAttrib4ubv.Invoke(index, values)

type private VertexAttrib4uiv = delegate of uint * nativeptr<uint> -> unit
let mutable private _glVertexAttrib4uiv = VertexAttrib4uiv(fun _ _ -> warn (notLinked<VertexAttrib4uiv>()))
let glVertexAttrib4uiv index values = _glVertexAttrib4uiv.Invoke(index, values)

type private VertexAttrib4usv = delegate of uint * nativeptr<uint16> -> unit
let mutable private _glVertexAttrib4usv = VertexAttrib4usv(fun _ _ -> warn (notLinked<VertexAttrib4usv>()))
let glVertexAttrib4usv index values = _glVertexAttrib4usv.Invoke(index, values)

type private VertexAttribPointer = delegate of uint * uint * uint * bool * int * voidptr -> unit
let mutable private _glVertexAttribPointer = VertexAttribPointer(fun _ _ _ _ _ _ -> warn (notLinked<VertexAttribPointer>()))
let private glVertexAttribPointerCommon<'T when 'T : unmanaged>
  index
  length
  attributeType
  normalized
  stride
  offset =
    _glVertexAttribPointer.Invoke(
      index,
      length,
      attributeType,
      normalized,
      stride * sizeof<single>,
      ((offset |> nativeint).ToPointer() ) )
let glVertexAttribPointer
  index
  length
  attributeType
  normalized
  stride
  offset =
    ( match attributeType with
      | x when x = GL_BYTE -> glVertexAttribPointerCommon<sbyte>
      | x when x = GL_UNSIGNED_BYTE -> glVertexAttribPointerCommon<byte>
      | x when x = GL_SHORT -> glVertexAttribPointerCommon<int16>
      | x when x = GL_UNSIGNED_SHORT -> glVertexAttribPointerCommon<uint16>
      | x when x = GL_INT -> glVertexAttribPointerCommon<int>
      | x when x = GL_UNSIGNED_INT -> glVertexAttribPointerCommon<uint>
      | x when x = GL_FLOAT -> glVertexAttribPointerCommon<single>
      | _ -> glVertexAttribPointerCommon<byte> ) // TODO: Make a hard failure case or return an option instead
        index
        length
        attributeType
        normalized
        stride
        offset

let internal setup handler =
  _glBlendEquationSeparate <- commonSetup handler _glBlendEquationSeparate
  _glDrawBuffers <- commonSetup handler _glDrawBuffers
  _glStencilOpSeparate <- commonSetup handler _glStencilOpSeparate
  _glStencilFuncSeparate <- commonSetup handler _glStencilFuncSeparate
  _glStencilMaskSeparate <- commonSetup handler _glStencilMaskSeparate
  _glAttachShader <- commonSetup handler _glAttachShader
  _glBindAttribLocation <- commonSetup handler _glBindAttribLocation
  _glCompileShader <- commonSetup handler _glCompileShader
  _glCreateProgram <- commonSetup handler _glCreateProgram
  _glCreateShader <- commonSetup handler _glCreateShader
  _glDeleteProgram <- commonSetup handler _glDeleteProgram
  _glDeleteShader <- commonSetup handler _glDeleteShader
  _glDetachShader <- commonSetup handler _glDetachShader
  _glDisableVertexAttribArray <- commonSetup handler _glDisableVertexAttribArray
  _glEnableVertexAttribArray <- commonSetup handler _glEnableVertexAttribArray
  _glGetActiveAttrib <- commonSetup handler _glGetActiveAttrib
  _glGetActiveUniform <- commonSetup handler _glGetActiveUniform
  _glGetAttachedShaders <- commonSetup handler _glGetAttachedShaders
  _glGetAttribLocation <- commonSetup handler _glGetAttribLocation
  _glGetProgramiv <- commonSetup handler _glGetProgramiv
  _glGetProgramInfoLog <- commonSetup handler _glGetProgramInfoLog
  _glGetShaderiv <- commonSetup handler _glGetShaderiv
  _glGetShaderInfoLog <- commonSetup handler _glGetShaderInfoLog
  _glGetShaderSource <- commonSetup handler _glGetShaderSource
  _glGetUniformLocation <- commonSetup handler _glGetUniformLocation
  _glGetUniformfv <- commonSetup handler _glGetUniformfv
  _glGetUniformiv <- commonSetup handler _glGetUniformiv
  _glGetVertexAttribdv <- commonSetup handler _glGetVertexAttribdv
  _glGetVertexAttribfv <- commonSetup handler _glGetVertexAttribfv
  _glGetVertexAttribiv <- commonSetup handler _glGetVertexAttribiv
  _glGetVertexAttribPointerv <- commonSetup handler _glGetVertexAttribPointerv
  _glIsProgram <- commonSetup handler _glIsProgram
  _glIsShader <- commonSetup handler _glIsShader
  _glLinkProgram <- commonSetup handler _glLinkProgram
  _glShaderSource <- commonSetup handler _glShaderSource
  _glUseProgram <- commonSetup handler _glUseProgram
  _glUniform1f <- commonSetup handler _glUniform1f
  _glUniform2f <- commonSetup handler _glUniform2f
  _glUniform3f <- commonSetup handler _glUniform3f
  _glUniform4f <- commonSetup handler _glUniform4f
  _glUniform1i <- commonSetup handler _glUniform1i
  _glUniform2i <- commonSetup handler _glUniform2i
  _glUniform3i <- commonSetup handler _glUniform3i
  _glUniform4i <- commonSetup handler _glUniform4i
  _glUniform1fv <- commonSetup handler _glUniform1fv
  _glUniform2fv <- commonSetup handler _glUniform2fv
  _glUniform3fv <- commonSetup handler _glUniform3fv
  _glUniform4fv <- commonSetup handler _glUniform4fv
  _glUniform1iv <- commonSetup handler _glUniform1iv
  _glUniform2iv <- commonSetup handler _glUniform2iv
  _glUniform3iv <- commonSetup handler _glUniform3iv
  _glUniform4iv <- commonSetup handler _glUniform4iv
  _glUniformMatrix2fv <- commonSetup handler _glUniformMatrix2fv
  _glUniformMatrix3fv <- commonSetup handler _glUniformMatrix3fv
  _glUniformMatrix4fv <- commonSetup handler _glUniformMatrix4fv
  _glValidateProgram <- commonSetup handler _glValidateProgram
  _glVertexAttrib1d <- commonSetup handler _glVertexAttrib1d
  _glVertexAttrib1dv <- commonSetup handler _glVertexAttrib1dv
  _glVertexAttrib1f <- commonSetup handler _glVertexAttrib1f
  _glVertexAttrib1fv <- commonSetup handler _glVertexAttrib1fv
  _glVertexAttrib1s <- commonSetup handler _glVertexAttrib1s
  _glVertexAttrib1sv <- commonSetup handler _glVertexAttrib1sv
  _glVertexAttrib2d <- commonSetup handler _glVertexAttrib2d
  _glVertexAttrib2dv <- commonSetup handler _glVertexAttrib2dv
  _glVertexAttrib2f <- commonSetup handler _glVertexAttrib2f
  _glVertexAttrib2fv <- commonSetup handler _glVertexAttrib2fv
  _glVertexAttrib2s <- commonSetup handler _glVertexAttrib2s
  _glVertexAttrib2sv <- commonSetup handler _glVertexAttrib2sv
  _glVertexAttrib3d <- commonSetup handler _glVertexAttrib3d
  _glVertexAttrib3dv <- commonSetup handler _glVertexAttrib3dv
  _glVertexAttrib3f <- commonSetup handler _glVertexAttrib3f
  _glVertexAttrib3fv <- commonSetup handler _glVertexAttrib3fv
  _glVertexAttrib3s <- commonSetup handler _glVertexAttrib3s
  _glVertexAttrib3sv <- commonSetup handler _glVertexAttrib3sv
  _glVertexAttrib4Nbv <- commonSetup handler _glVertexAttrib4Nbv
  _glVertexAttrib4Niv <- commonSetup handler _glVertexAttrib4Niv
  _glVertexAttrib4Nsv <- commonSetup handler _glVertexAttrib4Nsv
  _glVertexAttrib4Nub <- commonSetup handler _glVertexAttrib4Nub
  _glVertexAttrib4Nubv <- commonSetup handler _glVertexAttrib4Nubv
  _glVertexAttrib4Nuiv <- commonSetup handler _glVertexAttrib4Nuiv
  _glVertexAttrib4Nusv <- commonSetup handler _glVertexAttrib4Nusv
  _glVertexAttrib4bv <- commonSetup handler _glVertexAttrib4bv
  _glVertexAttrib4d <- commonSetup handler _glVertexAttrib4d
  _glVertexAttrib4dv <- commonSetup handler _glVertexAttrib4dv
  _glVertexAttrib4f <- commonSetup handler _glVertexAttrib4f
  _glVertexAttrib4fv <- commonSetup handler _glVertexAttrib4fv
  _glVertexAttrib4iv <- commonSetup handler _glVertexAttrib4iv
  _glVertexAttrib4s <- commonSetup handler _glVertexAttrib4s
  _glVertexAttrib4sv <- commonSetup handler _glVertexAttrib4sv
  _glVertexAttrib4ubv <- commonSetup handler _glVertexAttrib4ubv
  _glVertexAttrib4uiv <- commonSetup handler _glVertexAttrib4uiv
  _glVertexAttrib4usv <- commonSetup handler _glVertexAttrib4usv
  _glVertexAttribPointer <- commonSetup handler _glVertexAttribPointer