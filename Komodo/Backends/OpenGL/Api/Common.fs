module Komodo.Backends.OpenGL.Api.Common

#nowarn "9" // Unverifiable IL due to fixed expression and NativePtr library usage

open Komodo.Logging
open Microsoft.FSharp.NativeInterop
open System
open System.Runtime.InteropServices
open System.Text

let ptrToUtf8StringN (ptr:nativeint) length =
  let length = int length
  let bufferPtr = Marshal.AllocHGlobal(length)
  Buffer.MemoryCopy(
    (ptr.ToPointer()),
    (bufferPtr.ToPointer()),
    (int64 length),
    (int64 length) )
  let str =
    Encoding.UTF8.GetString(
      (NativePtr.ofNativeInt<byte> bufferPtr),
      length)
  Marshal.FreeHGlobal(bufferPtr)
  str

let ptrToUtf8String (ptr:nativeint) =
  let mutable length = 0
  while Marshal.ReadByte(ptr, length) <> byte 0 do
    length <- length + 1
  ptrToUtf8StringN ptr length

let toFunctionName<'T when 'T :> Delegate>() = 
  $"gl%s{typeof<'T>.Name}"

let internal notLinked<'T when 'T :> Delegate>() =
  $"%s{toFunctionName<'T>()} could not be linked. Check if you have the correct and most up-to-date OpenGL drivers."
  #if DEBUG
    + " Check the delegate type name for casing and spelling mistakes. A 'gl' prefix is attached to delegate Type names to generate the function name to link."
  #endif

type ProcAddressHandler = nativeint -> nativeint

let internal commonSetup
  (handler:ProcAddressHandler)
  (defaultDelegate: 'T)
  : 'T when 'T :> Delegate =
    use namePtr = fixed Encoding.ASCII.GetBytes(toFunctionName<'T>()) in
      match handler (NativePtr.toNativeInt namePtr) with
      | functionPtr when functionPtr <> IntPtr.Zero ->
          Marshal.GetDelegateForFunctionPointer<'T> functionPtr
      | _ ->
          #if DEBUG
          warn (notLinked<'T>())
          #endif
          #if TREAT_OPENGL_LINK_FAILURE_AS_ERROR
          notLinked<'T>()
            |> NotImplementedException
            |> raise
          #endif
          defaultDelegate

let internal getInfoLog
  infoLogHandler
  id =
    let bufferSize = 1024
    let bufferPtr = Marshal.AllocHGlobal(bufferSize)
    let lengthPtr = NativePtr.stackalloc<int> 1
    infoLogHandler
      id
      bufferSize 
      lengthPtr
      (NativePtr.ofNativeInt<byte> bufferPtr)
    let log =
      ptrToUtf8StringN
        bufferPtr
        (NativePtr.get lengthPtr 0)
    Marshal.FreeHGlobal(bufferPtr)
    log

let internal getIv
  getivHandler
  id
  parameterName =
    let ptr = NativePtr.stackalloc<int> 1
    getivHandler
      id
      parameterName
      ptr
    NativePtr.get ptr 0
