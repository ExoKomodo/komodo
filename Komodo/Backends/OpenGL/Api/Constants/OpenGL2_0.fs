[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.Constants.OpenGL2_0

////////////////////
// GL_VERSION_2_0 //
////////////////////
[<Literal>]
let GL_BLEND_EQUATION_RGB = 0x8009u
[<Literal>]
let GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622u
[<Literal>]
let GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623u
[<Literal>]
let GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624u
[<Literal>]
let GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625u
[<Literal>]
let GL_CURRENT_VERTEX_ATTRIB = 0x8626u
[<Literal>]
let GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642u
[<Literal>]
let GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645u
[<Literal>]
let GL_STENCIL_BACK_FUNC = 0x8800u
[<Literal>]
let GL_STENCIL_BACK_FAIL = 0x8801u
[<Literal>]
let GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802u
[<Literal>]
let GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803u
[<Literal>]
let GL_MAX_DRAW_BUFFERS = 0x8824u
[<Literal>]
let GL_DRAW_BUFFER0 = 0x8825u
[<Literal>]
let GL_DRAW_BUFFER1 = 0x8826u
[<Literal>]
let GL_DRAW_BUFFER2 = 0x8827u
[<Literal>]
let GL_DRAW_BUFFER3 = 0x8828u
[<Literal>]
let GL_DRAW_BUFFER4 = 0x8829u
[<Literal>]
let GL_DRAW_BUFFER5 = 0x882Au
[<Literal>]
let GL_DRAW_BUFFER6 = 0x882Bu
[<Literal>]
let GL_DRAW_BUFFER7 = 0x882Cu
[<Literal>]
let GL_DRAW_BUFFER8 = 0x882Du
[<Literal>]
let GL_DRAW_BUFFER9 = 0x882Eu
[<Literal>]
let GL_DRAW_BUFFER10 = 0x882Fu
[<Literal>]
let GL_DRAW_BUFFER11 = 0x8830u
[<Literal>]
let GL_DRAW_BUFFER12 = 0x8831u
[<Literal>]
let GL_DRAW_BUFFER13 = 0x8832u
[<Literal>]
let GL_DRAW_BUFFER14 = 0x8833u
[<Literal>]
let GL_DRAW_BUFFER15 = 0x8834u
[<Literal>]
let GL_BLEND_EQUATION_ALPHA = 0x883Du
[<Literal>]
let GL_MAX_VERTEX_ATTRIBS = 0x8869u
[<Literal>]
let GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886Au
[<Literal>]
let GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872u
[<Literal>]
let GL_FRAGMENT_SHADER = 0x8B30u
[<Literal>]
let GL_VERTEX_SHADER = 0x8B31u
[<Literal>]
let GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49u
[<Literal>]
let GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4Au
[<Literal>]
let GL_MAX_VARYING_FLOATS = 0x8B4Bu
[<Literal>]
let GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4Cu
[<Literal>]
let GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4Du
[<Literal>]
let GL_SHADER_TYPE = 0x8B4Fu
[<Literal>]
let GL_FLOAT_VEC2 = 0x8B50u
[<Literal>]
let GL_FLOAT_VEC3 = 0x8B51u
[<Literal>]
let GL_FLOAT_VEC4 = 0x8B52u
[<Literal>]
let GL_INT_VEC2 = 0x8B53u
[<Literal>]
let GL_INT_VEC3 = 0x8B54u
[<Literal>]
let GL_INT_VEC4 = 0x8B55u
[<Literal>]
let GL_BOOL = 0x8B56u
[<Literal>]
let GL_BOOL_VEC2 = 0x8B57u
[<Literal>]
let GL_BOOL_VEC3 = 0x8B58u
[<Literal>]
let GL_BOOL_VEC4 = 0x8B59u
[<Literal>]
let GL_FLOAT_MAT2 = 0x8B5Au
[<Literal>]
let GL_FLOAT_MAT3 = 0x8B5Bu
[<Literal>]
let GL_FLOAT_MAT4 = 0x8B5Cu
[<Literal>]
let GL_SAMPLER_1D = 0x8B5Du
[<Literal>]
let GL_SAMPLER_2D = 0x8B5Eu
[<Literal>]
let GL_SAMPLER_3D = 0x8B5Fu
[<Literal>]
let GL_SAMPLER_CUBE = 0x8B60u
[<Literal>]
let GL_SAMPLER_1D_SHADOW = 0x8B61u
[<Literal>]
let GL_SAMPLER_2D_SHADOW = 0x8B62u
[<Literal>]
let GL_DELETE_STATUS = 0x8B80u
[<Literal>]
let GL_COMPILE_STATUS = 0x8B81u
[<Literal>]
let GL_LINK_STATUS = 0x8B82u
[<Literal>]
let GL_VALIDATE_STATUS = 0x8B83u
[<Literal>]
let GL_INFO_LOG_LENGTH = 0x8B84u
[<Literal>]
let GL_ATTACHED_SHADERS = 0x8B85u
[<Literal>]
let GL_ACTIVE_UNIFORMS = 0x8B86u
[<Literal>]
let GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87u
[<Literal>]
let GL_SHADER_SOURCE_LENGTH = 0x8B88u
[<Literal>]
let GL_ACTIVE_ATTRIBUTES = 0x8B89u
[<Literal>]
let GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8Au
[<Literal>]
let GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8Bu
[<Literal>]
let GL_SHADING_LANGUAGE_VERSION = 0x8B8Cu
[<Literal>]
let GL_CURRENT_PROGRAM = 0x8B8Du
[<Literal>]
let GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0u
[<Literal>]
let GL_LOWER_LEFT = 0x8CA1u
[<Literal>]
let GL_UPPER_LEFT = 0x8CA2u
[<Literal>]
let GL_STENCIL_BACK_REF = 0x8CA3u
[<Literal>]
let GL_STENCIL_BACK_VALUE_MASK = 0x8CA4u
[<Literal>]
let GL_STENCIL_BACK_WRITEMASK = 0x8CA5u