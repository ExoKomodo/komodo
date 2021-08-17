# Komodo

## Important Links
- [SDL Linux README](https://github.com/libsdl-org/SDL/blob/main/docs/README-linux.md)

TODO: Everything else

## Linux

### Caveats
If running in a Linux version which says it does not support GLSL 3.30, set these two environment variables which will tell the drivers to use a compatibility mode. This can also be done in code I believe but have not yet looked into both detection of the available GLSL versions and how best to handle use of compatibility modes.

```bash
export MESA_GL_VERSION_OVERRIDE=3.3
export MESA_GLSL_VERSION_OVERRIDE=330
```

## References
- [OpenCL Bindings Reference](https://github.com/FracturedCode/OpenCL.NetCore)
- [OpenGL Bindings Reference #1](https://github.com/latet-party/LTP.Interop.OpenGL)
- [OpenGL Bindings Reference #2](https://github.com/ForeverZer0/glfw-net/blob/46d262174d5d089b722c2d8cad0cc3e13c8b0b71/Examples/HelloTriangle/OpenGL.cs)
- [SDL2 Bindings Reference](https://github.com/flibitijibibo/SDL2-CS)
