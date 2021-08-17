[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.OpenGL1_0

#nowarn "9" // unverifiable IL due to NativePtr library usage

open Komodo.Backends.OpenGL.Api.Constants
open Komodo.Backends.OpenGL.Api.Common
open Komodo.Logging
open Microsoft.FSharp.NativeInterop
open System

type private CullFace = delegate of uint -> unit
let mutable private _glCullFace =
  CullFace(fun _ -> warn (notLinked<CullFace>()))
let glCullFace mode = _glCullFace.Invoke(mode)

type private FrontFace = delegate of uint -> unit
let mutable private _glFrontFace =
  FrontFace(fun _ -> warn (notLinked<FrontFace>()))
let glFrontFace mode = _glFrontFace.Invoke(mode)

type private Hint = delegate of uint * uint -> unit
let mutable private _glHint =
  Hint(fun _ _ -> warn (notLinked<Hint>()))
let glHint target mode = _glHint.Invoke(target, mode)

type private LineWidth = delegate of single -> unit
let mutable private _glLineWidth =
  LineWidth(fun _ -> warn (notLinked<LineWidth>()))
let glLineWidth width = _glLineWidth.Invoke(width)

type private PointSize = delegate of single -> unit
let mutable private _glPointSize =
  PointSize(fun _ -> warn (notLinked<PointSize>()))
let glPointSize size = _glPointSize.Invoke(size)

type private PolygonMode = delegate of uint * uint -> unit
let mutable private _glPolygonMode =
  PolygonMode(fun _ _ -> warn (notLinked<PolygonMode>()))
let glPolygonMode face mode = _glPolygonMode.Invoke(face, mode)

type private Scissor = delegate of int * int * int * int -> unit
let mutable private _glScissor =
  Scissor(fun _ _ _ _ -> warn (notLinked<Scissor>()))
let glScissor x y width height = _glScissor.Invoke(x, y, width, height)

type private TexParameterf = delegate of uint * uint * single -> unit
let mutable private _glTexParameterf =
  TexParameterf(fun _ _ _ -> warn (notLinked<TexParameterf>()))
let glTexParameterf target parameterName parameter =
  _glTexParameterf.Invoke(target, parameterName, parameter)

type private TexParameterfv = delegate of uint * uint * nativeptr<single> -> unit
let mutable private _glTexParameterfv =
  TexParameterfv(fun _ _ _ -> warn (notLinked<TexParameterfv>()))
let glTexParameterfv target parameterName parameterPtr =
  _glTexParameterfv.Invoke(target, parameterName, parameterPtr)

type private TexParameteri = delegate of uint * uint * int -> unit
let mutable private _glTexParameteri =
  TexParameteri(fun _ _ _ -> warn (notLinked<TexParameteri>()))
let glTexParameteri target parameterName parameter =
  _glTexParameteri.Invoke(target, parameterName, parameter)

type private TexParameteriv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glTexParameteriv =
  TexParameteriv(fun _ _ _ -> warn (notLinked<TexParameteriv>()))
let glTexParameteriv target parameterName parameterPtr =
  _glTexParameteriv.Invoke(target, parameterName, parameterPtr)

type private TexImage1D = delegate of uint * int * int * int * int * uint * uint * voidptr -> unit
let mutable private _glTexImage1D =
  TexImage1D(fun _ _ _ _ _ _ _ _ -> warn (notLinked<TexImage1D>()))
let glTexImage1D target level internalFormat width border format ``type`` pixels =
  _glTexImage1D.Invoke(target, level, internalFormat, width, border, format, ``type``, pixels)

type private TexImage2D = delegate of uint * int * int * int * int * int * uint * uint * voidptr -> unit
let mutable private _glTexImage2D =
  TexImage2D(fun _ _ _ _ _ _ _ _ _ -> warn (notLinked<TexImage2D>()))
let glTexImage2D target level internalFormat width height border format ``type`` pixels =
  _glTexImage2D.Invoke(target, level, internalFormat, width, height, border, format, ``type``, pixels)

type private DrawBuffer = delegate of uint -> unit
let mutable private _glDrawBuffer =
  DrawBuffer(fun _ -> warn (notLinked<DrawBuffer>()))
let glDrawBuffer buffer = _glDrawBuffer.Invoke(buffer)

type private Clear = delegate of uint -> unit
let mutable private _glClear =
  Clear(fun _ -> warn (notLinked<Clear>()))
let glClear mask =
  _glClear.Invoke(mask)

type private ClearColor = delegate of single * single * single * single -> unit
let mutable private _glClearColor =
  ClearColor(fun _ _ _ _ -> warn (notLinked<ClearColor>()))
let glClearColor r g b a = _glClearColor.Invoke(r, g, b, a)

type private ClearStencil = delegate of int -> unit
let mutable private _glClearStencil =
  ClearStencil(fun _ -> warn (notLinked<ClearStencil>()))
let glClearStencil stencil = _glClearStencil.Invoke(stencil)

type private ClearDepth = delegate of single -> unit
let mutable private _glClearDepth =
  ClearDepth(fun _ -> warn (notLinked<ClearDepth>()))
let glClearDepth depth =
  _glClearDepth.Invoke(depth)

type private StencilMask = delegate of uint -> unit
let mutable private _glStencilMask =
  StencilMask(fun _ -> warn (notLinked<StencilMask>()))
let glStencilMask mask =
  _glStencilMask.Invoke(mask)

type private ColorMask = delegate of bool * bool * bool * bool -> unit
let mutable private _glColorMask =
  ColorMask(fun _ _ _ _ -> warn (notLinked<ColorMask>()))
let glColorMask rMask gMask bMask aMask = _glColorMask.Invoke(rMask, gMask, bMask, aMask)

type private DepthMask = delegate of bool -> unit
let mutable private _glDepthMask =
  DepthMask(fun _ -> warn (notLinked<DepthMask>()))
let glDepthMask maskFlag = _glDepthMask.Invoke(maskFlag)

type private Disable = delegate of uint -> unit
let mutable private _glDisable =
  Disable(fun _ -> warn (notLinked<Disable>()))
let glDisable cap = _glDisable.Invoke(cap)

type private Enable = delegate of uint -> unit
let mutable private _glEnable =
  Enable(fun _ -> warn (notLinked<Enable>()))
let glEnable cap = _glEnable.Invoke(cap)

type private Finish = delegate of unit -> unit
let mutable private _glFinish =
  Finish(fun _ -> warn (notLinked<Finish>()))
let glFinish() = _glFinish.Invoke()

type private Flush = delegate of unit -> unit
let mutable private _glFlush =
  Flush(fun _ -> warn (notLinked<Flush>()))
let glFlush() = _glFlush.Invoke()

type private BlendFunc = delegate of uint * uint -> unit
let mutable private _glBlendFunc =
  BlendFunc(fun _ _ -> warn (notLinked<BlendFunc>()))
let glBlendFunc stencilFactor depthFactor = _glBlendFunc.Invoke(stencilFactor, depthFactor)

type private LogicOp = delegate of uint -> unit
let mutable private _glLogicOp =
  LogicOp(fun _ -> warn (notLinked<LogicOp>()))
let glLogicOp opCode = _glLogicOp.Invoke(opCode)

type private StencilFunc = delegate of uint * int * uint -> unit
let mutable private _glStencilFunc =
  StencilFunc(fun _ _ _ -> warn (notLinked<StencilFunc>()))
let glStencilFunc func reference mask = _glStencilFunc.Invoke(func, reference, mask)

type private StencilOp = delegate of uint * uint * uint -> unit
let mutable private _glStencilOp =
  StencilOp(fun _ _ _ -> warn (notLinked<StencilOp>()))
let glStencilOp fail zFail zPass = _glStencilOp.Invoke(fail, zFail, zPass)

type private DepthFunc = delegate of uint -> unit
let mutable private _glDepthFunc =
  DepthFunc(fun _ -> warn (notLinked<DepthFunc>()))
let glDepthFunc func= _glDepthFunc.Invoke(func)

type private PixelStoref = delegate of uint * single -> unit
let mutable private _glPixelStoref =
  PixelStoref(fun _ _ -> warn (notLinked<PixelStoref>()))
let glPixelStoref parameterName parameter = _glPixelStoref.Invoke(parameterName, parameter)

type private PixelStorei = delegate of uint * int -> unit
let mutable private _glPixelStorei =
  PixelStorei(fun _ _ -> warn (notLinked<PixelStorei>()))
let glPixelStorei parameterName parameter = _glPixelStorei.Invoke(parameterName, parameter)

type private ReadBuffer = delegate of uint -> unit
let mutable private _glReadBuffer =
  ReadBuffer(fun _ -> warn (notLinked<ReadBuffer>()))
let glReadBuffer buffer= _glReadBuffer.Invoke(buffer)

type private ReadPixels = delegate of int * int * int * int * uint * uint * voidptr -> unit
let mutable private _glReadPixels =
  ReadPixels(fun _ _ _ _ _ _ _ -> warn (notLinked<ReadPixels>()))
let glReadPixels x y width height format ``type`` pixels =
  _glReadPixels.Invoke(x, y, width, height, format, ``type``, pixels)

type private GetBooleanv = delegate of uint * nativeptr<bool> -> unit
let mutable private _glGetBooleanv =
  GetBooleanv(fun _ _ -> warn (notLinked<GetBooleanv>()))
let glGetBooleanv parameterName data = _glGetBooleanv.Invoke(parameterName, data)

type private GetDoublev = delegate of uint * nativeptr<float> -> unit
let mutable private _glGetDoublev =
  GetDoublev(fun _ _ -> warn (notLinked<GetDoublev>()))
let glGetDoublev parameterName data = _glGetDoublev.Invoke(parameterName, data)

type private GetError = delegate of unit -> uint
let mutable private _glGetError = GetError(fun _ -> warn (notLinked<GetError>()); 0u;)
let glGetError () = _glGetError.Invoke()

type private GetFloatv = delegate of uint * nativeptr<single> -> unit
let mutable private _glGetFloatv =
  GetFloatv(fun _ _ -> warn (notLinked<GetFloatv>()))
let glGetFloatv parameterName data = _glGetFloatv.Invoke(parameterName, data)

type private GetIntegerv = delegate of uint * nativeptr<int> -> unit
let mutable private _glGetIntegerv =
  GetIntegerv(fun _ _ -> warn (notLinked<GetIntegerv>()))
let glGetIntegerv parameterName data = _glGetIntegerv.Invoke(parameterName, data)

type private GetString = delegate of uint -> nativeptr<byte>
let mutable private _glGetString =
   GetString(
    fun _ ->
      warn (notLinked<GetString>())
      NativePtr.ofVoidPtr<byte> GL_NULL )

let glGetString name =
  try
    _glGetString.Invoke(name)
    |> NativePtr.toNativeInt
    |> ptrToUtf8String
    |> Some
  with
    | :? AccessViolationException as ex ->
        fail "A memory violation error usually means there is not a current OpenGL context. Check if the OpenGL context is being initialized correctly."
        None

type private GetTexImage = delegate of uint * int * uint * uint * voidptr -> unit
let mutable private _glGetTexImage =
  GetTexImage(fun _ _ _ _ _ -> warn (notLinked<GetTexImage>()))
let glGetTexImage target level format ``type`` pixels = _glGetTexImage.Invoke(target, level, format, ``type``, pixels)

type private GetTexParameterfv = delegate of uint * uint * nativeptr<single> -> unit
let mutable private _glGetTexParameterfv =
  GetTexParameterfv(fun _ _ _ -> warn (notLinked<GetTexParameterfv>()))
let glGetTexParameterfv target parameterName parameterPtr =
  _glGetTexParameterfv.Invoke(target, parameterName, parameterPtr)

type private GetTexParameteriv = delegate of uint * uint * nativeptr<int> -> unit
let mutable private _glGetTexParameteriv =
  GetTexParameteriv(fun _ _ _ -> warn (notLinked<GetTexParameteriv>()))
let glGetTexParameteriv target parameterName parameterPtr =
  _glGetTexParameteriv.Invoke(target, parameterName, parameterPtr)

type private GetTexLevelParameterfv = delegate of uint * int * uint * nativeptr<single> -> unit
let mutable private _glGetTexLevelParameterfv =
  GetTexLevelParameterfv(fun _ _ _ _ -> warn (notLinked<GetTexLevelParameterfv>()))
let glGetTexLevelParameterfv target level parameterName parameterPtr =
  _glGetTexLevelParameterfv.Invoke(target, level, parameterName, parameterPtr)

type private GetTexLevelParameteriv = delegate of uint * int * uint * nativeptr<int> -> unit
let mutable private _glGetTexLevelParameteriv =
  GetTexLevelParameteriv(fun _ _ _ _ -> warn (notLinked<GetTexLevelParameteriv>()))
let glGetTexLevelParameteriv target level parameterName parameterPtr =
  _glGetTexLevelParameteriv.Invoke(target, level, parameterName, parameterPtr)

type private IsEnabled = delegate of uint -> bool
let mutable private _glIsEnabled =
  IsEnabled(
    fun _ ->
      warn (notLinked<IsEnabled>())
      false )
let glIsEnabled cap = _glIsEnabled.Invoke(cap)

type private DepthRange = delegate of float * float -> unit
let mutable private _glDepthRange =
  DepthRange(fun _ _ -> warn (notLinked<DepthRange>()))
let glDepthRange near far = _glDepthRange.Invoke(near, far)

type private Viewport = delegate of int * int * int * int -> unit
let mutable private _glViewport =
  Viewport(fun _ _ _ _ -> warn (notLinked<Viewport>()))
let glViewport x y width height =
  _glViewport.Invoke(x, y, width, height)

let internal setup handler =
  _glBlendFunc <- commonSetup handler _glBlendFunc
  _glClear <- commonSetup handler _glClear
  _glClearColor <- commonSetup handler _glClearColor
  _glClearDepth <- commonSetup handler _glClearDepth
  _glClearStencil <- commonSetup handler _glClearStencil
  _glColorMask <- commonSetup handler _glColorMask
  _glCullFace <- commonSetup handler _glCullFace
  _glDepthFunc <- commonSetup handler _glDepthFunc
  _glDepthMask <- commonSetup handler _glDepthMask
  _glDepthRange <- commonSetup handler _glDepthRange
  _glDisable <- commonSetup handler _glDisable
  _glDrawBuffer <- commonSetup handler _glDrawBuffer
  _glEnable <- commonSetup handler _glEnable
  _glFinish <- commonSetup handler _glFinish
  _glFlush <- commonSetup handler _glFlush
  _glFrontFace <- commonSetup handler _glFrontFace
  _glGetBooleanv <- commonSetup handler _glGetBooleanv
  _glGetDoublev <- commonSetup handler _glGetDoublev
  _glGetError <- commonSetup handler _glGetError
  _glGetFloatv <- commonSetup handler _glGetFloatv
  _glGetIntegerv <- commonSetup handler _glGetIntegerv
  _glGetString <- commonSetup handler _glGetString
  _glGetTexImage <- commonSetup handler _glGetTexImage
  _glGetTexLevelParameterfv <- commonSetup handler _glGetTexLevelParameterfv
  _glGetTexLevelParameteriv <- commonSetup handler _glGetTexLevelParameteriv
  _glGetTexParameterfv <- commonSetup handler _glGetTexParameterfv
  _glGetTexParameteriv <- commonSetup handler _glGetTexParameteriv
  _glHint <- commonSetup handler _glHint
  _glIsEnabled <- commonSetup handler _glIsEnabled
  _glLineWidth <- commonSetup handler _glLineWidth
  _glLogicOp <- commonSetup handler _glLogicOp
  _glPixelStoref <- commonSetup handler _glPixelStoref
  _glPixelStorei <- commonSetup handler _glPixelStorei
  _glPointSize <- commonSetup handler _glPointSize
  _glPolygonMode <- commonSetup handler _glPolygonMode
  _glReadBuffer <- commonSetup handler _glReadBuffer
  _glReadPixels <- commonSetup handler _glReadPixels
  _glScissor <- commonSetup handler _glScissor
  _glStencilFunc <- commonSetup handler _glStencilFunc
  _glStencilMask <- commonSetup handler _glStencilMask
  _glStencilOp <- commonSetup handler _glStencilOp
  _glTexImage1D <- commonSetup handler _glTexImage1D
  _glTexImage2D <- commonSetup handler _glTexImage2D
  _glTexParameterf <- commonSetup handler _glTexParameterf
  _glTexParameteri <- commonSetup handler _glTexParameteri
  _glTexParameteriv <- commonSetup handler _glTexParameteriv
  _glViewport <- commonSetup handler _glViewport
