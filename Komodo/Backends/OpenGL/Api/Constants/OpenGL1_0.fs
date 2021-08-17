[<AutoOpen>]
module Komodo.Backends.OpenGL.Api.Constants.OpenGL1_0

let GL_NULL = 0n.ToPointer()

[<Literal>]
let GL_DEPTH_BUFFER_BIT = 0x00000100u
[<Literal>]
let GL_STENCIL_BUFFER_BIT = 0x00000400u
[<Literal>]
let GL_COLOR_BUFFER_BIT = 0x00004000u
[<Literal>]
let GL_FALSE: uint = 0u
[<Literal>]
let GL_TRUE: uint = 1u
[<Literal>]
let GL_POINTS = 0x0000u
[<Literal>]
let GL_LINES = 0x0001u
[<Literal>]
let GL_LINE_LOOP = 0x0002u
[<Literal>]
let GL_LINE_STRIP = 0x0003u
[<Literal>]
let GL_TRIANGLES = 0x0004u
[<Literal>]
let GL_TRIANGLE_STRIP = 0x0005u
[<Literal>]
let GL_TRIANGLE_FAN = 0x0006u
[<Literal>]
let GL_QUADS = 0x0007u
[<Literal>]
let GL_NEVER = 0x0200u
[<Literal>]
let GL_LESS = 0x0201u
[<Literal>]
let GL_EQUAL = 0x0202u
[<Literal>]
let GL_LEQUAL = 0x0203u
[<Literal>]
let GL_GREATER = 0x0204u
[<Literal>]
let GL_NOTEQUAL = 0x0205u
[<Literal>]
let GL_GEQUAL = 0x0206u
[<Literal>]
let GL_ALWAYS = 0x0207u
[<Literal>]
let GL_ZERO: uint = 0u
[<Literal>]
let GL_ONE: uint = 1u
[<Literal>]
let GL_SRC_COLOR = 0x0300u
[<Literal>]
let GL_ONE_MINUS_SRC_COLOR = 0x0301u
[<Literal>]
let GL_SRC_ALPHA = 0x0302u
[<Literal>]
let GL_ONE_MINUS_SRC_ALPHA = 0x0303u
[<Literal>]
let GL_DST_ALPHA = 0x0304u
[<Literal>]
let GL_ONE_MINUS_DST_ALPHA = 0x0305u
[<Literal>]
let GL_DST_COLOR = 0x0306u
[<Literal>]
let GL_ONE_MINUS_DST_COLOR = 0x0307u
[<Literal>]
let GL_SRC_ALPHA_SATURATE = 0x0308u
[<Literal>]
let GL_NONE: uint = 0u
[<Literal>]
let GL_FRONT_LEFT = 0x0400u
[<Literal>]
let GL_FRONT_RIGHT = 0x0401u
[<Literal>]
let GL_BACK_LEFT = 0x0402u
[<Literal>]
let GL_BACK_RIGHT = 0x0403u
[<Literal>]
let GL_FRONT = 0x0404u
[<Literal>]
let GL_BACK = 0x0405u
[<Literal>]
let GL_LEFT = 0x0406u
[<Literal>]
let GL_RIGHT = 0x0407u
[<Literal>]
let GL_FRONT_AND_BACK = 0x0408u
[<Literal>]
let GL_NO_ERROR: uint = 0u
[<Literal>]
let GL_INVALID_ENUM = 0x0500u
[<Literal>]
let GL_INVALID_VALUE = 0x0501u
[<Literal>]
let GL_INVALID_OPERATION = 0x0502u
[<Literal>]
let GL_OUT_OF_MEMORY = 0x0505u
[<Literal>]
let GL_CW = 0x0900u
[<Literal>]
let GL_CCW = 0x0901u
[<Literal>]
let GL_POINT_SIZE = 0x0B11u
[<Literal>]
let GL_POINT_SIZE_RANGE = 0x0B12u
[<Literal>]
let GL_POINT_SIZE_GRANuARITY = 0x0B13u
[<Literal>]
let GL_LINE_SMOOTH = 0x0B20u
[<Literal>]
let GL_LINE_WIDTH = 0x0B21u
[<Literal>]
let GL_LINE_WIDTH_RANGE = 0x0B22u
[<Literal>]
let GL_LINE_WIDTH_GRANuARITY = 0x0B23u
[<Literal>]
let GL_POLYGON_MODE = 0x0B40u
[<Literal>]
let GL_POLYGON_SMOOTH = 0x0B41u
[<Literal>]
let GL_CuL_FACE = 0x0B44u
[<Literal>]
let GL_CuL_FACE_MODE = 0x0B45u
[<Literal>]
let GL_FRONT_FACE = 0x0B46u
[<Literal>]
let GL_DEPTH_RANGE = 0x0B70u
[<Literal>]
let GL_DEPTH_TEST = 0x0B71u
[<Literal>]
let GL_DEPTH_WRITEMASK = 0x0B72u
[<Literal>]
let GL_DEPTH_CLEAR_VALUE = 0x0B73u
[<Literal>]
let GL_DEPTH_FUNC = 0x0B74u
[<Literal>]
let GL_STENCIL_TEST = 0x0B90u
[<Literal>]
let GL_STENCIL_CLEAR_VALUE = 0x0B91u
[<Literal>]
let GL_STENCIL_FUNC = 0x0B92u
[<Literal>]
let GL_STENCIL_VALUE_MASK = 0x0B93u
[<Literal>]
let GL_STENCIL_FAIL = 0x0B94u
[<Literal>]
let GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95u
[<Literal>]
let GL_STENCIL_PASS_DEPTH_PASS = 0x0B96u
[<Literal>]
let GL_STENCIL_REF = 0x0B97u
[<Literal>]
let GL_STENCIL_WRITEMASK = 0x0B98u
[<Literal>]
let GL_VIEWPORT = 0x0BA2u
[<Literal>]
let GL_DITHER = 0x0BD0u
[<Literal>]
let GL_BLEND_DST = 0x0BE0u
[<Literal>]
let GL_BLEND_SRC = 0x0BE1u
[<Literal>]
let GL_BLEND = 0x0BE2u
[<Literal>]
let GL_LOGIC_OP_MODE = 0x0BF0u
[<Literal>]
let GL_DRAW_BUFFER = 0x0C01u
[<Literal>]
let GL_READ_BUFFER = 0x0C02u
[<Literal>]
let GL_SCISSOR_BOX = 0x0C10u
[<Literal>]
let GL_SCISSOR_TEST = 0x0C11u
[<Literal>]
let GL_COLOR_CLEAR_VALUE = 0x0C22u
[<Literal>]
let GL_COLOR_WRITEMASK = 0x0C23u
[<Literal>]
let GL_DOUBLEBUFFER = 0x0C32u
[<Literal>]
let GL_STEREO = 0x0C33u
[<Literal>]
let GL_LINE_SMOOTH_HINT = 0x0C52u
[<Literal>]
let GL_POLYGON_SMOOTH_HINT = 0x0C53u
[<Literal>]
let GL_UNPACK_SWAP_BYTES = 0x0CF0u
[<Literal>]
let GL_UNPACK_LSB_FIRST = 0x0CF1u
[<Literal>]
let GL_UNPACK_ROW_LENGTH = 0x0CF2u
[<Literal>]
let GL_UNPACK_SKIP_ROWS = 0x0CF3u
[<Literal>]
let GL_UNPACK_SKIP_PIXELS = 0x0CF4u
[<Literal>]
let GL_UNPACK_ALIGNMENT = 0x0CF5u
[<Literal>]
let GL_PACK_SWAP_BYTES = 0x0D00u
[<Literal>]
let GL_PACK_LSB_FIRST = 0x0D01u
[<Literal>]
let GL_PACK_ROW_LENGTH = 0x0D02u
[<Literal>]
let GL_PACK_SKIP_ROWS = 0x0D03u
[<Literal>]
let GL_PACK_SKIP_PIXELS = 0x0D04u
[<Literal>]
let GL_PACK_ALIGNMENT = 0x0D05u
[<Literal>]
let GL_MAX_TEXTURE_SIZE = 0x0D33u
[<Literal>]
let GL_MAX_VIEWPORT_DIMS = 0x0D3Au
[<Literal>]
let GL_SUBPIXEL_BITS = 0x0D50u
[<Literal>]
let GL_TEXTURE_1D = 0x0DE0u
[<Literal>]
let GL_TEXTURE_2D = 0x0DE1u
[<Literal>]
let GL_TEXTURE_WIDTH = 0x1000u
[<Literal>]
let GL_TEXTURE_HEIGHT = 0x1001u
[<Literal>]
let GL_TEXTURE_BORDER_COLOR = 0x1004u
[<Literal>]
let GL_DONT_CARE = 0x1100u
[<Literal>]
let GL_FASTEST = 0x1101u
[<Literal>]
let GL_NICEST = 0x1102u
[<Literal>]
let GL_BYTE = 0x1400u
[<Literal>]
let GL_UNSIGNED_BYTE = 0x1401u
[<Literal>]
let GL_SHORT = 0x1402u
[<Literal>]
let GL_UNSIGNED_SHORT = 0x1403u
[<Literal>]
let GL_INT = 0x1404u
[<Literal>]
let GL_UNSIGNED_INT = 0x1405u
[<Literal>]
let GL_FLOAT = 0x1406u
[<Literal>]
let GL_STACK_OVERFLOW = 0x0503u
[<Literal>]
let GL_STACK_UNDERFLOW = 0x0504u
[<Literal>]
let GL_CLEAR = 0x1500u
[<Literal>]
let GL_AND = 0x1501u
[<Literal>]
let GL_AND_REVERSE = 0x1502u
[<Literal>]
let GL_COPY = 0x1503u
[<Literal>]
let GL_AND_INVERTED = 0x1504u
[<Literal>]
let GL_NOOP = 0x1505u
[<Literal>]
let GL_XOR = 0x1506u
[<Literal>]
let GL_OR = 0x1507u
[<Literal>]
let GL_NOR = 0x1508u
[<Literal>]
let GL_EQUIV = 0x1509u
[<Literal>]
let GL_INVERT = 0x150Au
[<Literal>]
let GL_OR_REVERSE = 0x150Bu
[<Literal>]
let GL_COPY_INVERTED = 0x150Cu
[<Literal>]
let GL_OR_INVERTED = 0x150Du
[<Literal>]
let GL_NAND = 0x150Eu
[<Literal>]
let GL_SET = 0x150Fu
[<Literal>]
let GL_TEXTURE = 0x1702u
[<Literal>]
let GL_COLOR = 0x1800u
[<Literal>]
let GL_DEPTH = 0x1801u
[<Literal>]
let GL_STENCIL = 0x1802u
[<Literal>]
let GL_STENCIL_INDEX = 0x1901u
[<Literal>]
let GL_DEPTH_COMPONENT = 0x1902u
[<Literal>]
let GL_RED = 0x1903u
[<Literal>]
let GL_GREEN = 0x1904u
[<Literal>]
let GL_BLUE = 0x1905u
[<Literal>]
let GL_ALPHA = 0x1906u
[<Literal>]
let GL_RGB = 0x1907u
[<Literal>]
let GL_RGBA = 0x1908u
[<Literal>]
let GL_POINT = 0x1B00u
[<Literal>]
let GL_LINE = 0x1B01u
[<Literal>]
let GL_FILL = 0x1B02u
[<Literal>]
let GL_KEEP = 0x1E00u
[<Literal>]
let GL_REPLACE = 0x1E01u
[<Literal>]
let GL_INCR = 0x1E02u
[<Literal>]
let GL_DECR = 0x1E03u
[<Literal>]
let GL_VENDOR = 0x1F00u
[<Literal>]
let GL_RENDERER = 0x1F01u
[<Literal>]
let GL_VERSION = 0x1F02u
[<Literal>]
let GL_EXTENSIONS = 0x1F03u
[<Literal>]
let GL_NEAREST = 0x2600u
[<Literal>]
let GL_LINEAR = 0x2601u
[<Literal>]
let GL_NEAREST_MIPMAP_NEAREST = 0x2700u
[<Literal>]
let GL_LINEAR_MIPMAP_NEAREST = 0x2701u
[<Literal>]
let GL_NEAREST_MIPMAP_LINEAR = 0x2702u
[<Literal>]
let GL_LINEAR_MIPMAP_LINEAR = 0x2703u
[<Literal>]
let GL_TEXTURE_MAG_FILTER = 0x2800u
[<Literal>]
let GL_TEXTURE_MIN_FILTER = 0x2801u
[<Literal>]
let GL_TEXTURE_WRAP_S = 0x2802u
[<Literal>]
let GL_TEXTURE_WRAP_T = 0x2803u
[<Literal>]
let GL_REPEAT = 0x2901u