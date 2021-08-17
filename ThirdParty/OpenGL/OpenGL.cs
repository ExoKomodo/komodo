#region License
/*
	Copyright (c) 2013-2018 The Khronos Group Inc.

	Permission is hereby granted, free of charge, to any person obtaining a
	copy of this software and/or associated documentation files (the
	"Materials"), to deal in the Materials without restriction, including
	without limitation the rights to use, copy, modify, merge, publish,
	distribute, sublicense, and/or sell copies of the Materials, and to
	permit persons to whom the Materials are furnished to do so, subject to
	the following conditions:

	The above copyright notice and this permission notice shall be included
	in all copies or substantial portions of the Materials.

	THE MATERIALS ARE PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
	EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
	MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
	IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
	CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
	TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
	MATERIALS OR THE USE OR OTHER DEALINGS IN THE MATERIALS.
*/
#endregion

#region Defines
//#define GL_LEGACY_PIPELINE

#define GL_VERSION_1_0
#define GL_VERSION_1_1
#define GL_VERSION_1_2
#define GL_VERSION_1_3
#define GL_VERSION_1_4
#define GL_VERSION_1_5
#define GL_VERSION_2_0
#define GL_VERSION_2_1
#define GL_VERSION_3_0
#define GL_VERSION_3_1
#define GL_VERSION_3_2
#define GL_VERSION_3_3
#define GL_VERSION_4_0
#define GL_VERSION_4_1
#define GL_VERSION_4_2
#define GL_VERSION_4_3
#define GL_VERSION_4_4
#define GL_VERSION_4_5
#define GL_VERSION_4_6

#define GL_GLEXT_PROTOTYPES
#endregion

#region Using statements
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

using OpenGLBindings.Diagnostics;
#endregion

namespace OpenGLBindings
{
	public static unsafe class OpenGL_
	{
		#region Fields / Properties
		public static ushort Version { get; private set; }
		#endregion

		#region Binding
		#region OpenGL 1.0
#if GL_VERSION_1_0
		public const uint GL_DEPTH_BUFFER_BIT = 0x00000100;
		public const uint GL_STENCIL_BUFFER_BIT = 0x00000400;
		public const uint GL_COLOR_BUFFER_BIT = 0x00004000;
		public const uint GL_FALSE = 0;
		public const uint GL_TRUE = 1;
		public const uint GL_POINTS = 0x0000;
		public const uint GL_LINES = 0x0001;
		public const uint GL_LINE_LOOP = 0x0002;
		public const uint GL_LINE_STRIP = 0x0003;
		public const uint GL_TRIANGLES = 0x0004;
		public const uint GL_TRIANGLE_STRIP = 0x0005;
		public const uint GL_TRIANGLE_FAN = 0x0006;
		public const uint GL_QUADS = 0x0007;
		public const uint GL_NEVER = 0x0200;
		public const uint GL_LESS = 0x0201;
		public const uint GL_EQUAL = 0x0202;
		public const uint GL_LEQUAL = 0x0203;
		public const uint GL_GREATER = 0x0204;
		public const uint GL_NOTEQUAL = 0x0205;
		public const uint GL_GEQUAL = 0x0206;
		public const uint GL_ALWAYS = 0x0207;
		public const uint GL_ZERO = 0;
		public const uint GL_ONE = 1;
		public const uint GL_SRC_COLOR = 0x0300;
		public const uint GL_ONE_MINUS_SRC_COLOR = 0x0301;
		public const uint GL_SRC_ALPHA = 0x0302;
		public const uint GL_ONE_MINUS_SRC_ALPHA = 0x0303;
		public const uint GL_DST_ALPHA = 0x0304;
		public const uint GL_ONE_MINUS_DST_ALPHA = 0x0305;
		public const uint GL_DST_COLOR = 0x0306;
		public const uint GL_ONE_MINUS_DST_COLOR = 0x0307;
		public const uint GL_SRC_ALPHA_SATURATE = 0x0308;
		public const uint GL_NONE = 0;
		public const uint GL_FRONT_LEFT = 0x0400;
		public const uint GL_FRONT_RIGHT = 0x0401;
		public const uint GL_BACK_LEFT = 0x0402;
		public const uint GL_BACK_RIGHT = 0x0403;
		public const uint GL_FRONT = 0x0404;
		public const uint GL_BACK = 0x0405;
		public const uint GL_LEFT = 0x0406;
		public const uint GL_RIGHT = 0x0407;
		public const uint GL_FRONT_AND_BACK = 0x0408;
		public const uint GL_NO_ERROR = 0;
		public const uint GL_INVALID_ENUM = 0x0500;
		public const uint GL_INVALID_VALUE = 0x0501;
		public const uint GL_INVALID_OPERATION = 0x0502;
		public const uint GL_OUT_OF_MEMORY = 0x0505;
		public const uint GL_CW = 0x0900;
		public const uint GL_CCW = 0x0901;
		public const uint GL_POINT_SIZE = 0x0B11;
		public const uint GL_POINT_SIZE_RANGE = 0x0B12;
		public const uint GL_POINT_SIZE_GRANULARITY = 0x0B13;
		public const uint GL_LINE_SMOOTH = 0x0B20;
		public const uint GL_LINE_WIDTH = 0x0B21;
		public const uint GL_LINE_WIDTH_RANGE = 0x0B22;
		public const uint GL_LINE_WIDTH_GRANULARITY = 0x0B23;
		public const uint GL_POLYGON_MODE = 0x0B40;
		public const uint GL_POLYGON_SMOOTH = 0x0B41;
		public const uint GL_CULL_FACE = 0x0B44;
		public const uint GL_CULL_FACE_MODE = 0x0B45;
		public const uint GL_FRONT_FACE = 0x0B46;
		public const uint GL_DEPTH_RANGE = 0x0B70;
		public const uint GL_DEPTH_TEST = 0x0B71;
		public const uint GL_DEPTH_WRITEMASK = 0x0B72;
		public const uint GL_DEPTH_CLEAR_VALUE = 0x0B73;
		public const uint GL_DEPTH_FUNC = 0x0B74;
		public const uint GL_STENCIL_TEST = 0x0B90;
		public const uint GL_STENCIL_CLEAR_VALUE = 0x0B91;
		public const uint GL_STENCIL_FUNC = 0x0B92;
		public const uint GL_STENCIL_VALUE_MASK = 0x0B93;
		public const uint GL_STENCIL_FAIL = 0x0B94;
		public const uint GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95;
		public const uint GL_STENCIL_PASS_DEPTH_PASS = 0x0B96;
		public const uint GL_STENCIL_REF = 0x0B97;
		public const uint GL_STENCIL_WRITEMASK = 0x0B98;
		public const uint GL_VIEWPORT = 0x0BA2;
		public const uint GL_DITHER = 0x0BD0;
		public const uint GL_BLEND_DST = 0x0BE0;
		public const uint GL_BLEND_SRC = 0x0BE1;
		public const uint GL_BLEND = 0x0BE2;
		public const uint GL_LOGIC_OP_MODE = 0x0BF0;
		public const uint GL_DRAW_BUFFER = 0x0C01;
		public const uint GL_READ_BUFFER = 0x0C02;
		public const uint GL_SCISSOR_BOX = 0x0C10;
		public const uint GL_SCISSOR_TEST = 0x0C11;
		public const uint GL_COLOR_CLEAR_VALUE = 0x0C22;
		public const uint GL_COLOR_WRITEMASK = 0x0C23;
		public const uint GL_DOUBLEBUFFER = 0x0C32;
		public const uint GL_STEREO = 0x0C33;
		public const uint GL_LINE_SMOOTH_HINT = 0x0C52;
		public const uint GL_POLYGON_SMOOTH_HINT = 0x0C53;
		public const uint GL_UNPACK_SWAP_BYTES = 0x0CF0;
		public const uint GL_UNPACK_LSB_FIRST = 0x0CF1;
		public const uint GL_UNPACK_ROW_LENGTH = 0x0CF2;
		public const uint GL_UNPACK_SKIP_ROWS = 0x0CF3;
		public const uint GL_UNPACK_SKIP_PIXELS = 0x0CF4;
		public const uint GL_UNPACK_ALIGNMENT = 0x0CF5;
		public const uint GL_PACK_SWAP_BYTES = 0x0D00;
		public const uint GL_PACK_LSB_FIRST = 0x0D01;
		public const uint GL_PACK_ROW_LENGTH = 0x0D02;
		public const uint GL_PACK_SKIP_ROWS = 0x0D03;
		public const uint GL_PACK_SKIP_PIXELS = 0x0D04;
		public const uint GL_PACK_ALIGNMENT = 0x0D05;
		public const uint GL_MAX_TEXTURE_SIZE = 0x0D33;
		public const uint GL_MAX_VIEWPORT_DIMS = 0x0D3A;
		public const uint GL_SUBPIXEL_BITS = 0x0D50;
		public const uint GL_TEXTURE_1D = 0x0DE0;
		public const uint GL_TEXTURE_2D = 0x0DE1;
		public const uint GL_TEXTURE_WIDTH = 0x1000;
		public const uint GL_TEXTURE_HEIGHT = 0x1001;
		public const uint GL_TEXTURE_BORDER_COLOR = 0x1004;
		public const uint GL_DONT_CARE = 0x1100;
		public const uint GL_FASTEST = 0x1101;
		public const uint GL_NICEST = 0x1102;
		public const uint GL_BYTE = 0x1400;
		public const uint GL_UNSIGNED_BYTE = 0x1401;
		public const uint GL_SHORT = 0x1402;
		public const uint GL_UNSIGNED_SHORT = 0x1403;
		public const uint GL_INT = 0x1404;
		public const uint GL_UNSIGNED_INT = 0x1405;
		public const uint GL_FLOAT = 0x1406;
		public const uint GL_STACK_OVERFLOW = 0x0503;
		public const uint GL_STACK_UNDERFLOW = 0x0504;
		public const uint GL_CLEAR = 0x1500;
		public const uint GL_AND = 0x1501;
		public const uint GL_AND_REVERSE = 0x1502;
		public const uint GL_COPY = 0x1503;
		public const uint GL_AND_INVERTED = 0x1504;
		public const uint GL_NOOP = 0x1505;
		public const uint GL_XOR = 0x1506;
		public const uint GL_OR = 0x1507;
		public const uint GL_NOR = 0x1508;
		public const uint GL_EQUIV = 0x1509;
		public const uint GL_INVERT = 0x150A;
		public const uint GL_OR_REVERSE = 0x150B;
		public const uint GL_COPY_INVERTED = 0x150C;
		public const uint GL_OR_INVERTED = 0x150D;
		public const uint GL_NAND = 0x150E;
		public const uint GL_SET = 0x150F;
		public const uint GL_TEXTURE = 0x1702;
		public const uint GL_COLOR = 0x1800;
		public const uint GL_DEPTH = 0x1801;
		public const uint GL_STENCIL = 0x1802;
		public const uint GL_STENCIL_INDEX = 0x1901;
		public const uint GL_DEPTH_COMPONENT = 0x1902;
		public const uint GL_RED = 0x1903;
		public const uint GL_GREEN = 0x1904;
		public const uint GL_BLUE = 0x1905;
		public const uint GL_ALPHA = 0x1906;
		public const uint GL_RGB = 0x1907;
		public const uint GL_RGBA = 0x1908;
		public const uint GL_POINT = 0x1B00;
		public const uint GL_LINE = 0x1B01;
		public const uint GL_FILL = 0x1B02;
		public const uint GL_KEEP = 0x1E00;
		public const uint GL_REPLACE = 0x1E01;
		public const uint GL_INCR = 0x1E02;
		public const uint GL_DECR = 0x1E03;
		public const uint GL_VENDOR = 0x1F00;
		public const uint GL_RENDERER = 0x1F01;
		public const uint GL_VERSION = 0x1F02;
		public const uint GL_EXTENSIONS = 0x1F03;
		public const uint GL_NEAREST = 0x2600;
		public const uint GL_LINEAR = 0x2601;
		public const uint GL_NEAREST_MIPMAP_NEAREST = 0x2700;
		public const uint GL_LINEAR_MIPMAP_NEAREST = 0x2701;
		public const uint GL_NEAREST_MIPMAP_LINEAR = 0x2702;
		public const uint GL_LINEAR_MIPMAP_LINEAR = 0x2703;
		public const uint GL_TEXTURE_MAG_FILTER = 0x2800;
		public const uint GL_TEXTURE_MIN_FILTER = 0x2801;
		public const uint GL_TEXTURE_WRAP_S = 0x2802;
		public const uint GL_TEXTURE_WRAP_T = 0x2803;
		public const uint GL_REPEAT = 0x2901;

		public delegate void PFNGLCULLFACEPROC( uint mode );
		public delegate void PFNGLFRONTFACEPROC( uint mode );
		public delegate void PFNGLHINTPROC( uint target, uint mode );
		public delegate void PFNGLLINEWIDTHPROC( float width );
		public delegate void PFNGLPOINTSIZEPROC( float size );
		public delegate void PFNGLPOLYGONMODEPROC( uint face, uint mode );
		public delegate void PFNGLSCISSORPROC( int x, int y, int width, int height );
		public delegate void PFNGLTEXPARAMETERFPROC( uint target, uint pname, float param );
		public delegate void PFNGLTEXPARAMETERFVPROC( uint target, uint pname, float* @params );
		public delegate void PFNGLTEXPARAMETERIPROC( uint target, uint pname, int param );
		public delegate void PFNGLTEXPARAMETERIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLTEXIMAGE1DPROC( uint target, int level, int internalformat, int width, int border, uint format, uint type, void* pixels );
		public delegate void PFNGLTEXIMAGE2DPROC( uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, void* pixels );
		public delegate void PFNGLDRAWBUFFERPROC( uint buf );
		public delegate void PFNGLCLEARPROC( uint mask );
		public delegate void PFNGLCLEARCOLORPROC( float red, float green, float blue, float alpha );
		public delegate void PFNGLCLEARSTENCILPROC( int s );
		public delegate void PFNGLCLEARDEPTHPROC( double depth );
		public delegate void PFNGLSTENCILMASKPROC( uint mask );
		public delegate void PFNGLCOLORMASKPROC( bool red, bool green, bool blue, bool alpha );
		public delegate void PFNGLDEPTHMASKPROC( bool flag );
		public delegate void PFNGLDISABLEPROC( uint cap );
		public delegate void PFNGLENABLEPROC( uint cap );
		public delegate void PFNGLFINISHPROC();
		public delegate void PFNGLFLUSHPROC();
		public delegate void PFNGLBLENDFUNCPROC( uint sfactor, uint dfactor );
		public delegate void PFNGLLOGICOPPROC( uint opcode );
		public delegate void PFNGLSTENCILFUNCPROC( uint func, int @ref, uint mask );
		public delegate void PFNGLSTENCILOPPROC( uint fail, uint zfail, uint zpass );
		public delegate void PFNGLDEPTHFUNCPROC( uint func );
		public delegate void PFNGLPIXELSTOREFPROC( uint pname, float param );
		public delegate void PFNGLPIXELSTOREIPROC( uint pname, int param );
		public delegate void PFNGLREADBUFFERPROC( uint src );
		public delegate void PFNGLREADPIXELSPROC( int x, int y, int width, int height, uint format, uint type, void* pixels );
		public delegate void PFNGLGETBOOLEANVPROC( uint pname, bool* data );
		public delegate void PFNGLGETDOUBLEVPROC( uint pname, double* data );
		public delegate uint PFNGLGETERRORPROC();
		public delegate void PFNGLGETFLOATVPROC( uint pname, float* data );
		public delegate void PFNGLGETINTEGERVPROC( uint pname, IntPtr data );
		public delegate byte* PFNGLGETSTRINGPROC( uint name );
		public delegate void PFNGLGETTEXIMAGEPROC( uint target, int level, uint format, uint type, void* pixels );
		public delegate void PFNGLGETTEXPARAMETERFVPROC( uint target, uint pname, float* @params );
		public delegate void PFNGLGETTEXPARAMETERIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLGETTEXLEVELPARAMETERFVPROC( uint target, int level, uint pname, float* @params );
		public delegate void PFNGLGETTEXLEVELPARAMETERIVPROC( uint target, int level, uint pname, IntPtr @params );
		public delegate bool PFNGLISENABLEDPROC( uint cap );
		public delegate void PFNGLDEPTHRANGEPROC( double n, double f );
		public delegate void PFNGLVIEWPORTPROC( int x, int y, int width, int height );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLCULLFACEPROC glCullFace;
		public static PFNGLFRONTFACEPROC glFrontFace;
		public static PFNGLHINTPROC glHint;
		public static PFNGLLINEWIDTHPROC glLineWidth;
		public static PFNGLPOINTSIZEPROC glPointSize;
		public static PFNGLPOLYGONMODEPROC glPolygonMode;
		public static PFNGLSCISSORPROC glScissor;
		public static PFNGLTEXPARAMETERFPROC glTexParameterf;
		public static PFNGLTEXPARAMETERFVPROC glTexParameterfv;
		public static PFNGLTEXPARAMETERIPROC glTexParameteri;
		public static PFNGLTEXPARAMETERIVPROC glTexParameteriv;
		public static PFNGLTEXIMAGE1DPROC glTexImage1D;
		public static PFNGLTEXIMAGE2DPROC glTexImage2D;
		public static PFNGLDRAWBUFFERPROC glDrawBuffer;
		public static PFNGLCLEARPROC glClear;
		public static PFNGLCLEARCOLORPROC glClearColor;
		public static PFNGLCLEARSTENCILPROC glClearStencil;
		public static PFNGLCLEARDEPTHPROC glClearDepth;
		public static PFNGLSTENCILMASKPROC glStencilMask;
		public static PFNGLCOLORMASKPROC glColorMask;
		public static PFNGLDEPTHMASKPROC glDepthMask;
		public static PFNGLDISABLEPROC glDisable;
		public static PFNGLENABLEPROC glEnable;
		public static PFNGLFINISHPROC glFinish;
		public static PFNGLFLUSHPROC glFlush;
		public static PFNGLBLENDFUNCPROC glBlendFunc;
		public static PFNGLLOGICOPPROC glLogicOp;
		public static PFNGLSTENCILFUNCPROC glStencilFunc;
		public static PFNGLSTENCILOPPROC glStencilOp;
		public static PFNGLDEPTHFUNCPROC glDepthFunc;
		public static PFNGLPIXELSTOREFPROC glPixelStoref;
		public static PFNGLPIXELSTOREIPROC glPixelStorei;
		public static PFNGLREADBUFFERPROC glReadBuffer;
		public static PFNGLREADPIXELSPROC glReadPixels;
		public static PFNGLGETBOOLEANVPROC glGetBooleanv;
		public static PFNGLGETDOUBLEVPROC glGetDoublev;
		public static PFNGLGETERRORPROC glGetError;
		public static PFNGLGETFLOATVPROC glGetFloatv;
		public static PFNGLGETINTEGERVPROC glGetIntegerv;
		public static PFNGLGETSTRINGPROC glGetString;
		public static PFNGLGETTEXIMAGEPROC glGetTexImage;
		public static PFNGLGETTEXPARAMETERFVPROC glGetTexParameterfv;
		public static PFNGLGETTEXPARAMETERIVPROC glGetTexParameteriv;
		public static PFNGLGETTEXLEVELPARAMETERFVPROC glGetTexLevelParameterfv;
		public static PFNGLGETTEXLEVELPARAMETERIVPROC glGetTexLevelParameteriv;
		public static PFNGLISENABLEDPROC glIsEnabled;
		public static PFNGLDEPTHRANGEPROC glDepthRange;
		public static PFNGLVIEWPORTPROC glViewport;
#endif
#endif // GL_VERSION_1_0
		#endregion

		#region OpenGL 1.1
#if GL_VERSION_1_1
		public const uint GL_COLOR_LOGIC_OP = 0x0BF2;
		public const uint GL_POLYGON_OFFSET_UNITS = 0x2A00;
		public const uint GL_POLYGON_OFFSET_POINT = 0x2A01;
		public const uint GL_POLYGON_OFFSET_LINE = 0x2A02;
		public const uint GL_POLYGON_OFFSET_FILL = 0x8037;
		public const uint GL_POLYGON_OFFSET_FACTOR = 0x8038;
		public const uint GL_TEXTURE_BINDING_1D = 0x8068;
		public const uint GL_TEXTURE_BINDING_2D = 0x8069;
		public const uint GL_TEXTURE_INTERNAL_FORMAT = 0x1003;
		public const uint GL_TEXTURE_RED_SIZE = 0x805C;
		public const uint GL_TEXTURE_GREEN_SIZE = 0x805D;
		public const uint GL_TEXTURE_BLUE_SIZE = 0x805E;
		public const uint GL_TEXTURE_ALPHA_SIZE = 0x805F;
		public const uint GL_DOUBLE = 0x140A;
		public const uint GL_PROXY_TEXTURE_1D = 0x8063;
		public const uint GL_PROXY_TEXTURE_2D = 0x8064;
		public const uint GL_R3_G3_B2 = 0x2A10;
		public const uint GL_RGB4 = 0x804F;
		public const uint GL_RGB5 = 0x8050;
		public const uint GL_RGB8 = 0x8051;
		public const uint GL_RGB10 = 0x8052;
		public const uint GL_RGB12 = 0x8053;
		public const uint GL_RGB16 = 0x8054;
		public const uint GL_RGBA2 = 0x8055;
		public const uint GL_RGBA4 = 0x8056;
		public const uint GL_RGB5_A1 = 0x8057;
		public const uint GL_RGBA8 = 0x8058;
		public const uint GL_RGB10_A2 = 0x8059;
		public const uint GL_RGBA12 = 0x805A;
		public const uint GL_RGBA16 = 0x805B;
		public const uint GL_VERTEX_ARRAY = 0x8074;
		public delegate void PFNGLDRAWARRAYSPROC( uint mode, int first, int count );
		public delegate void PFNGLDRAWELEMENTSPROC( uint mode, int count, uint type, void* indices );
		public delegate void PFNGLGETPOINTERVPROC( uint pname, void** @params );
		public delegate void PFNGLPOLYGONOFFSETPROC( float factor, float units );
		public delegate void PFNGLCOPYTEXIMAGE1DPROC( uint target, int level, uint internalformat, int x, int y, int width, int border );
		public delegate void PFNGLCOPYTEXIMAGE2DPROC( uint target, int level, uint internalformat, int x, int y, int width, int height, int border );
		public delegate void PFNGLCOPYTEXSUBIMAGE1DPROC( uint target, int level, int xoffset, int x, int y, int width );
		public delegate void PFNGLCOPYTEXSUBIMAGE2DPROC( uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height );
		public delegate void PFNGLTEXSUBIMAGE1DPROC( uint target, int level, int xoffset, int width, uint format, uint type, void* pixels );
		public delegate void PFNGLTEXSUBIMAGE2DPROC( uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels );
		public delegate void PFNGLBINDTEXTUREPROC( uint target, uint texture );
		public delegate void PFNGLDELETETEXTURESPROC( int n, UIntPtr textures );
		public delegate void PFNGLGENTEXTURESPROC( int n, UIntPtr textures );
		public delegate bool PFNGLISTEXTUREPROC( uint texture );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLDRAWARRAYSPROC glDrawArrays;
		public static PFNGLDRAWELEMENTSPROC glDrawElements;
		public static PFNGLGETPOINTERVPROC glGetPointerv;
		public static PFNGLPOLYGONOFFSETPROC glPolygonOffset;
		public static PFNGLCOPYTEXIMAGE1DPROC glCopyTexImage1D;
		public static PFNGLCOPYTEXIMAGE2DPROC glCopyTexImage2D;
		public static PFNGLCOPYTEXSUBIMAGE1DPROC glCopyTexSubImage1D;
		public static PFNGLCOPYTEXSUBIMAGE2DPROC glCopyTexSubImage2D;
		public static PFNGLTEXSUBIMAGE1DPROC glTexSubImage1D;
		public static PFNGLTEXSUBIMAGE2DPROC glTexSubImage2D;
		public static PFNGLBINDTEXTUREPROC glBindTexture;
		public static PFNGLDELETETEXTURESPROC glDeleteTextures;
		public static PFNGLGENTEXTURESPROC glGenTextures;
		public static PFNGLISTEXTUREPROC glIsTexture;
#endif
#endif // GL_VERSION_1_1
		#endregion

		#region OpenGL 1.2
#if GL_VERSION_1_2
		public const uint GL_UNSIGNED_BYTE_3_3_2 = 0x8032;
		public const uint GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;
		public const uint GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;
		public const uint GL_UNSIGNED_INT_8_8_8_8 = 0x8035;
		public const uint GL_UNSIGNED_INT_10_10_10_2 = 0x8036;
		public const uint GL_TEXTURE_BINDING_3D = 0x806A;
		public const uint GL_PACK_SKIP_IMAGES = 0x806B;
		public const uint GL_PACK_IMAGE_HEIGHT = 0x806C;
		public const uint GL_UNPACK_SKIP_IMAGES = 0x806D;
		public const uint GL_UNPACK_IMAGE_HEIGHT = 0x806E;
		public const uint GL_TEXTURE_3D = 0x806F;
		public const uint GL_PROXY_TEXTURE_3D = 0x8070;
		public const uint GL_TEXTURE_DEPTH = 0x8071;
		public const uint GL_TEXTURE_WRAP_R = 0x8072;
		public const uint GL_MAX_3D_TEXTURE_SIZE = 0x8073;
		public const uint GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362;
		public const uint GL_UNSIGNED_SHORT_5_6_5 = 0x8363;
		public const uint GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364;
		public const uint GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;
		public const uint GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;
		public const uint GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367;
		public const uint GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;
		public const uint GL_BGR = 0x80E0;
		public const uint GL_BGRA = 0x80E1;
		public const uint GL_MAX_ELEMENTS_VERTICES = 0x80E8;
		public const uint GL_MAX_ELEMENTS_INDICES = 0x80E9;
		public const uint GL_CLAMP_TO_EDGE = 0x812F;
		public const uint GL_TEXTURE_MIN_LOD = 0x813A;
		public const uint GL_TEXTURE_MAX_LOD = 0x813B;
		public const uint GL_TEXTURE_BASE_LEVEL = 0x813C;
		public const uint GL_TEXTURE_MAX_LEVEL = 0x813D;
		public const uint GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12;
		public const uint GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;
		public const uint GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22;
		public const uint GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;
		public const uint GL_ALIASED_LINE_WIDTH_RANGE = 0x846E;
		public delegate void PFNGLDRAWRANGEELEMENTSPROC( uint mode, uint start, uint end, int count, uint type, void* indices );
		public delegate void PFNGLTEXIMAGE3DPROC( uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, void* pixels );
		public delegate void PFNGLTEXSUBIMAGE3DPROC( uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* pixels );
		public delegate void PFNGLCOPYTEXSUBIMAGE3DPROC( uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLDRAWRANGEELEMENTSPROC glDrawRangeElements;
		public static PFNGLTEXIMAGE3DPROC glTexImage3D;
		public static PFNGLTEXSUBIMAGE3DPROC glTexSubImage3D;
		public static PFNGLCOPYTEXSUBIMAGE3DPROC glCopyTexSubImage3D;
#endif
#endif // GL_VERSION_1_2
		#endregion

		#region OpenGL 1.3
#if GL_VERSION_1_3
		public const uint GL_TEXTURE0 = 0x84C0;
		public const uint GL_TEXTURE1 = 0x84C1;
		public const uint GL_TEXTURE2 = 0x84C2;
		public const uint GL_TEXTURE3 = 0x84C3;
		public const uint GL_TEXTURE4 = 0x84C4;
		public const uint GL_TEXTURE5 = 0x84C5;
		public const uint GL_TEXTURE6 = 0x84C6;
		public const uint GL_TEXTURE7 = 0x84C7;
		public const uint GL_TEXTURE8 = 0x84C8;
		public const uint GL_TEXTURE9 = 0x84C9;
		public const uint GL_TEXTURE10 = 0x84CA;
		public const uint GL_TEXTURE11 = 0x84CB;
		public const uint GL_TEXTURE12 = 0x84CC;
		public const uint GL_TEXTURE13 = 0x84CD;
		public const uint GL_TEXTURE14 = 0x84CE;
		public const uint GL_TEXTURE15 = 0x84CF;
		public const uint GL_TEXTURE16 = 0x84D0;
		public const uint GL_TEXTURE17 = 0x84D1;
		public const uint GL_TEXTURE18 = 0x84D2;
		public const uint GL_TEXTURE19 = 0x84D3;
		public const uint GL_TEXTURE20 = 0x84D4;
		public const uint GL_TEXTURE21 = 0x84D5;
		public const uint GL_TEXTURE22 = 0x84D6;
		public const uint GL_TEXTURE23 = 0x84D7;
		public const uint GL_TEXTURE24 = 0x84D8;
		public const uint GL_TEXTURE25 = 0x84D9;
		public const uint GL_TEXTURE26 = 0x84DA;
		public const uint GL_TEXTURE27 = 0x84DB;
		public const uint GL_TEXTURE28 = 0x84DC;
		public const uint GL_TEXTURE29 = 0x84DD;
		public const uint GL_TEXTURE30 = 0x84DE;
		public const uint GL_TEXTURE31 = 0x84DF;
		public const uint GL_ACTIVE_TEXTURE = 0x84E0;
		public const uint GL_MULTISAMPLE = 0x809D;
		public const uint GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;
		public const uint GL_SAMPLE_ALPHA_TO_ONE = 0x809F;
		public const uint GL_SAMPLE_COVERAGE = 0x80A0;
		public const uint GL_SAMPLE_BUFFERS = 0x80A8;
		public const uint GL_SAMPLES = 0x80A9;
		public const uint GL_SAMPLE_COVERAGE_VALUE = 0x80AA;
		public const uint GL_SAMPLE_COVERAGE_INVERT = 0x80AB;
		public const uint GL_TEXTURE_CUBE_MAP = 0x8513;
		public const uint GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;
		public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;
		public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;
		public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;
		public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;
		public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;
		public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;
		public const uint GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;
		public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;
		public const uint GL_COMPRESSED_RGB = 0x84ED;
		public const uint GL_COMPRESSED_RGBA = 0x84EE;
		public const uint GL_TEXTURE_COMPRESSION_HINT = 0x84EF;
		public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;
		public const uint GL_TEXTURE_COMPRESSED = 0x86A1;
		public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;
		public const uint GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;
		public const uint GL_CLAMP_TO_BORDER = 0x812D;
		public delegate void PFNGLACTIVETEXTUREPROC( uint texture );
		public delegate void PFNGLSAMPLECOVERAGEPROC( float value, bool invert );
		public delegate void PFNGLCOMPRESSEDTEXIMAGE3DPROC( uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, void* data );
		public delegate void PFNGLCOMPRESSEDTEXIMAGE2DPROC( uint target, int level, uint internalformat, int width, int height, int border, int imageSize, void* data );
		public delegate void PFNGLCOMPRESSEDTEXIMAGE1DPROC( uint target, int level, uint internalformat, int width, int border, int imageSize, void* data );
		public delegate void PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC( uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, void* data );
		public delegate void PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC( uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, void* data );
		public delegate void PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC( uint target, int level, int xoffset, int width, uint format, int imageSize, void* data );
		public delegate void PFNGLGETCOMPRESSEDTEXIMAGEPROC( uint target, int level, void* img );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLACTIVETEXTUREPROC glActiveTexture;
		public static PFNGLSAMPLECOVERAGEPROC glSampleCoverage;
		public static PFNGLCOMPRESSEDTEXIMAGE3DPROC glCompressedTexImage3D;
		public static PFNGLCOMPRESSEDTEXIMAGE2DPROC glCompressedTexImage2D;
		public static PFNGLCOMPRESSEDTEXIMAGE1DPROC glCompressedTexImage1D;
		public static PFNGLCOMPRESSEDTEXSUBIMAGE3DPROC glCompressedTexSubImage3D;
		public static PFNGLCOMPRESSEDTEXSUBIMAGE2DPROC glCompressedTexSubImage2D;
		public static PFNGLCOMPRESSEDTEXSUBIMAGE1DPROC glCompressedTexSubImage1D;
		public static PFNGLGETCOMPRESSEDTEXIMAGEPROC glGetCompressedTexImage;
#endif
#endif // GL_VERSION_1_3
		#endregion

		#region OpenGL 1.4
#if GL_VERSION_1_4
		public const uint GL_BLEND_DST_RGB = 0x80C8;
		public const uint GL_BLEND_SRC_RGB = 0x80C9;
		public const uint GL_BLEND_DST_ALPHA = 0x80CA;
		public const uint GL_BLEND_SRC_ALPHA = 0x80CB;
		public const uint GL_POINT_FADE_THRESHOLD_SIZE = 0x8128;
		public const uint GL_DEPTH_COMPONENT16 = 0x81A5;
		public const uint GL_DEPTH_COMPONENT24 = 0x81A6;
		public const uint GL_DEPTH_COMPONENT32 = 0x81A7;
		public const uint GL_MIRRORED_REPEAT = 0x8370;
		public const uint GL_MAX_TEXTURE_LOD_BIAS = 0x84FD;
		public const uint GL_TEXTURE_LOD_BIAS = 0x8501;
		public const uint GL_INCR_WRAP = 0x8507;
		public const uint GL_DECR_WRAP = 0x8508;
		public const uint GL_TEXTURE_DEPTH_SIZE = 0x884A;
		public const uint GL_TEXTURE_COMPARE_MODE = 0x884C;
		public const uint GL_TEXTURE_COMPARE_FUNC = 0x884D;
		public const uint GL_BLEND_COLOR = 0x8005;
		public const uint GL_BLEND_EQUATION = 0x8009;
		public const uint GL_CONSTANT_COLOR = 0x8001;
		public const uint GL_ONE_MINUS_CONSTANT_COLOR = 0x8002;
		public const uint GL_CONSTANT_ALPHA = 0x8003;
		public const uint GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004;
		public const uint GL_FUNC_ADD = 0x8006;
		public const uint GL_FUNC_REVERSE_SUBTRACT = 0x800B;
		public const uint GL_FUNC_SUBTRACT = 0x800A;
		public const uint GL_MIN = 0x8007;
		public const uint GL_MAX = 0x8008;
		public delegate void PFNGLBLENDFUNCSEPARATEPROC( uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha );
		public delegate void PFNGLMULTIDRAWARRAYSPROC( uint mode, IntPtr first, IntPtr count, int drawcount );
		public delegate void PFNGLMULTIDRAWELEMENTSPROC( uint mode, IntPtr count, uint type, void* indices, int drawcount );
		public delegate void PFNGLPOINTPARAMETERFPROC( uint pname, float param );
		public delegate void PFNGLPOINTPARAMETERFVPROC( uint pname, float* @params );
		public delegate void PFNGLPOINTPARAMETERIPROC( uint pname, int param );
		public delegate void PFNGLPOINTPARAMETERIVPROC( uint pname, IntPtr @params );
		public delegate void PFNGLBLENDCOLORPROC( float red, float green, float blue, float alpha );
		public delegate void PFNGLBLENDEQUATIONPROC( uint mode );
#if GL_GLEXT_PROTOTYPES

		public static PFNGLBLENDFUNCSEPARATEPROC glBlendFuncSeparate;
		public static PFNGLMULTIDRAWARRAYSPROC glMultiDrawArrays;
		public static PFNGLMULTIDRAWELEMENTSPROC glMultiDrawElements;
		public static PFNGLPOINTPARAMETERFPROC glPointParameterf;
		public static PFNGLPOINTPARAMETERFVPROC glPointParameterfv;
		public static PFNGLPOINTPARAMETERIPROC glPointParameteri;
		public static PFNGLPOINTPARAMETERIVPROC glPointParameteriv;
		public static PFNGLBLENDCOLORPROC glBlendColor;
		public static PFNGLBLENDEQUATIONPROC glBlendEquation;
#endif
#endif // GL_VERSION_1_4
		#endregion

		#region OpenGL 1.5
#if GL_VERSION_1_5
		public const uint GL_BUFFER_SIZE = 0x8764;
		public const uint GL_BUFFER_USAGE = 0x8765;
		public const uint GL_QUERY_COUNTER_BITS = 0x8864;
		public const uint GL_CURRENT_QUERY = 0x8865;
		public const uint GL_QUERY_RESULT = 0x8866;
		public const uint GL_QUERY_RESULT_AVAILABLE = 0x8867;
		public const uint GL_ARRAY_BUFFER = 0x8892;
		public const uint GL_ELEMENT_ARRAY_BUFFER = 0x8893;
		public const uint GL_ARRAY_BUFFER_BINDING = 0x8894;
		public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
		public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
		public const uint GL_READ_ONLY = 0x88B8;
		public const uint GL_WRITE_ONLY = 0x88B9;
		public const uint GL_READ_WRITE = 0x88BA;
		public const uint GL_BUFFER_ACCESS = 0x88BB;
		public const uint GL_BUFFER_MAPPED = 0x88BC;
		public const uint GL_BUFFER_MAP_POINTER = 0x88BD;
		public const uint GL_STREAM_DRAW = 0x88E0;
		public const uint GL_STREAM_READ = 0x88E1;
		public const uint GL_STREAM_COPY = 0x88E2;
		public const uint GL_STATIC_DRAW = 0x88E4;
		public const uint GL_STATIC_READ = 0x88E5;
		public const uint GL_STATIC_COPY = 0x88E6;
		public const uint GL_DYNAMIC_DRAW = 0x88E8;
		public const uint GL_DYNAMIC_READ = 0x88E9;
		public const uint GL_DYNAMIC_COPY = 0x88EA;
		public const uint GL_SAMPLES_PASSED = 0x8914;
		public const uint GL_SRC1_ALPHA = 0x8589;
		public delegate void PFNGLGENQUERIESPROC( int n, IntPtr ids );
		public delegate void PFNGLDELETEQUERIESPROC( int n, IntPtr ids );
		public delegate bool PFNGLISQUERYPROC( uint id );
		public delegate void PFNGLBEGINQUERYPROC( uint target, uint id );
		public delegate void PFNGLENDQUERYPROC( uint target );
		public delegate void PFNGLGETQUERYIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLGETQUERYOBJECTIVPROC( uint id, uint pname, IntPtr @params );
		public delegate void PFNGLGETQUERYOBJECTUIVPROC( uint id, uint pname, IntPtr @params );
		public delegate void PFNGLBINDBUFFERPROC( uint target, uint buffer );
		public delegate void PFNGLDELETEBUFFERSPROC( int n, UIntPtr buffers );
		public delegate void PFNGLGENBUFFERSPROC( int n, UIntPtr buffers );
		public delegate bool PFNGLISBUFFERPROC( uint buffer );
		public delegate void PFNGLBUFFERDATAPROC( uint target, IntPtr size, void* data, uint usage );
		public delegate void PFNGLBUFFERSUBDATAPROC( uint target, IntPtr offset, IntPtr size, void* data );
		public delegate void PFNGLGETBUFFERSUBDATAPROC( uint target, IntPtr offset, IntPtr size, void* data );
		public delegate void* PFNGLMAPBUFFERPROC( uint target, uint access );
		public delegate bool PFNGLUNMAPBUFFERPROC( uint target );
		public delegate void PFNGLGETBUFFERPARAMETERIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLGETBUFFERPOINTERVPROC( uint target, uint pname, void** @params );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLGENQUERIESPROC glGenQueries;
		public static PFNGLDELETEQUERIESPROC glDeleteQueries;
		public static PFNGLISQUERYPROC glIsQuery;
		public static PFNGLBEGINQUERYPROC glBeginQuery;
		public static PFNGLENDQUERYPROC glEndQuery;
		public static PFNGLGETQUERYIVPROC glGetQueryiv;
		public static PFNGLGETQUERYOBJECTIVPROC glGetQueryObjectiv;
		public static PFNGLGETQUERYOBJECTUIVPROC glGetQueryObjectuiv;
		public static PFNGLBINDBUFFERPROC glBindBuffer;
		public static PFNGLDELETEBUFFERSPROC glDeleteBuffers;
		public static PFNGLGENBUFFERSPROC glGenBuffers;
		public static PFNGLISBUFFERPROC glIsBuffer;
		public static PFNGLBUFFERDATAPROC glBufferData;
		public static PFNGLBUFFERSUBDATAPROC glBufferSubData;
		public static PFNGLGETBUFFERSUBDATAPROC glGetBufferSubData;
		public static PFNGLMAPBUFFERPROC glMapBuffer;
		public static PFNGLUNMAPBUFFERPROC glUnmapBuffer;
		public static PFNGLGETBUFFERPARAMETERIVPROC glGetBufferParameteriv;
		public static PFNGLGETBUFFERPOINTERVPROC glGetBufferPointerv;
#endif
#endif // GL_VERSION_1_5
		#endregion

		#region OpenGL 2.0
#if GL_VERSION_2_0
		public const uint GL_BLEND_EQUATION_RGB = 0x8009;
		public const uint GL_VERTEX_ATTRIB_ARRAY_ENABLED = 0x8622;
		public const uint GL_VERTEX_ATTRIB_ARRAY_SIZE = 0x8623;
		public const uint GL_VERTEX_ATTRIB_ARRAY_STRIDE = 0x8624;
		public const uint GL_VERTEX_ATTRIB_ARRAY_TYPE = 0x8625;
		public const uint GL_CURRENT_VERTEX_ATTRIB = 0x8626;
		public const uint GL_VERTEX_PROGRAM_POINT_SIZE = 0x8642;
		public const uint GL_VERTEX_ATTRIB_ARRAY_POINTER = 0x8645;
		public const uint GL_STENCIL_BACK_FUNC = 0x8800;
		public const uint GL_STENCIL_BACK_FAIL = 0x8801;
		public const uint GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802;
		public const uint GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803;
		public const uint GL_MAX_DRAW_BUFFERS = 0x8824;
		public const uint GL_DRAW_BUFFER0 = 0x8825;
		public const uint GL_DRAW_BUFFER1 = 0x8826;
		public const uint GL_DRAW_BUFFER2 = 0x8827;
		public const uint GL_DRAW_BUFFER3 = 0x8828;
		public const uint GL_DRAW_BUFFER4 = 0x8829;
		public const uint GL_DRAW_BUFFER5 = 0x882A;
		public const uint GL_DRAW_BUFFER6 = 0x882B;
		public const uint GL_DRAW_BUFFER7 = 0x882C;
		public const uint GL_DRAW_BUFFER8 = 0x882D;
		public const uint GL_DRAW_BUFFER9 = 0x882E;
		public const uint GL_DRAW_BUFFER10 = 0x882F;
		public const uint GL_DRAW_BUFFER11 = 0x8830;
		public const uint GL_DRAW_BUFFER12 = 0x8831;
		public const uint GL_DRAW_BUFFER13 = 0x8832;
		public const uint GL_DRAW_BUFFER14 = 0x8833;
		public const uint GL_DRAW_BUFFER15 = 0x8834;
		public const uint GL_BLEND_EQUATION_ALPHA = 0x883D;
		public const uint GL_MAX_VERTEX_ATTRIBS = 0x8869;
		public const uint GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 0x886A;
		public const uint GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872;
		public const uint GL_FRAGMENT_SHADER = 0x8B30;
		public const uint GL_VERTEX_SHADER = 0x8B31;
		public const uint GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49;
		public const uint GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A;
		public const uint GL_MAX_VARYING_FLOATS = 0x8B4B;
		public const uint GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C;
		public const uint GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D;
		public const uint GL_SHADER_TYPE = 0x8B4F;
		public const uint GL_FLOAT_VEC2 = 0x8B50;
		public const uint GL_FLOAT_VEC3 = 0x8B51;
		public const uint GL_FLOAT_VEC4 = 0x8B52;
		public const uint GL_INT_VEC2 = 0x8B53;
		public const uint GL_INT_VEC3 = 0x8B54;
		public const uint GL_INT_VEC4 = 0x8B55;
		public const uint GL_BOOL = 0x8B56;
		public const uint GL_BOOL_VEC2 = 0x8B57;
		public const uint GL_BOOL_VEC3 = 0x8B58;
		public const uint GL_BOOL_VEC4 = 0x8B59;
		public const uint GL_FLOAT_MAT2 = 0x8B5A;
		public const uint GL_FLOAT_MAT3 = 0x8B5B;
		public const uint GL_FLOAT_MAT4 = 0x8B5C;
		public const uint GL_SAMPLER_1D = 0x8B5D;
		public const uint GL_SAMPLER_2D = 0x8B5E;
		public const uint GL_SAMPLER_3D = 0x8B5F;
		public const uint GL_SAMPLER_CUBE = 0x8B60;
		public const uint GL_SAMPLER_1D_SHADOW = 0x8B61;
		public const uint GL_SAMPLER_2D_SHADOW = 0x8B62;
		public const uint GL_DELETE_STATUS = 0x8B80;
		public const uint GL_COMPILE_STATUS = 0x8B81;
		public const uint GL_LINK_STATUS = 0x8B82;
		public const uint GL_VALIDATE_STATUS = 0x8B83;
		public const uint GL_INFO_LOG_LENGTH = 0x8B84;
		public const uint GL_ATTACHED_SHADERS = 0x8B85;
		public const uint GL_ACTIVE_UNIFORMS = 0x8B86;
		public const uint GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87;
		public const uint GL_SHADER_SOURCE_LENGTH = 0x8B88;
		public const uint GL_ACTIVE_ATTRIBUTES = 0x8B89;
		public const uint GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A;
		public const uint GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B;
		public const uint GL_SHADING_LANGUAGE_VERSION = 0x8B8C;
		public const uint GL_CURRENT_PROGRAM = 0x8B8D;
		public const uint GL_POINT_SPRITE_COORD_ORIGIN = 0x8CA0;
		public const uint GL_LOWER_LEFT = 0x8CA1;
		public const uint GL_UPPER_LEFT = 0x8CA2;
		public const uint GL_STENCIL_BACK_REF = 0x8CA3;
		public const uint GL_STENCIL_BACK_VALUE_MASK = 0x8CA4;
		public const uint GL_STENCIL_BACK_WRITEMASK = 0x8CA5;
		public delegate void PFNGLBLENDEQUATIONSEPARATEPROC( uint modeRGB, uint modeAlpha );
		public delegate void PFNGLDRAWBUFFERSPROC( int n, IntPtr bufs );
		public delegate void PFNGLSTENCILOPSEPARATEPROC( uint face, uint sfail, uint dpfail, uint dppass );
		public delegate void PFNGLSTENCILFUNCSEPARATEPROC( uint face, uint func, int @ref, uint mask );
		public delegate void PFNGLSTENCILMASKSEPARATEPROC( uint face, uint mask );
		public delegate void PFNGLATTACHSHADERPROC( uint program, uint shader );
		public delegate void PFNGLBINDATTRIBLOCATIONPROC( uint program, uint index, char* name );
		public delegate void PFNGLCOMPILESHADERPROC( uint shader );
		public delegate uint PFNGLCREATEPROGRAMPROC();
		public delegate uint PFNGLCREATESHADERPROC( uint type );
		public delegate void PFNGLDELETEPROGRAMPROC( uint program );
		public delegate void PFNGLDELETESHADERPROC( uint shader );
		public delegate void PFNGLDETACHSHADERPROC( uint program, uint shader );
		public delegate void PFNGLDISABLEVERTEXATTRIBARRAYPROC( uint index );
		public delegate void PFNGLENABLEVERTEXATTRIBARRAYPROC( uint index );
		public delegate void PFNGLGETACTIVEATTRIBPROC( uint program, uint index, int bufSize, IntPtr length, IntPtr size, IntPtr type, char* name );
		public delegate void PFNGLGETACTIVEUNIFORMPROC( uint program, uint index, int bufSize, IntPtr length, IntPtr size, IntPtr type, char* name );
		public delegate void PFNGLGETATTACHEDSHADERSPROC( uint program, int maxCount, IntPtr count, IntPtr shaders );
		public delegate int PFNGLGETATTRIBLOCATIONPROC( uint program, char* name );
		public delegate void PFNGLGETPROGRAMIVPROC( uint program, uint pname, IntPtr @params );
		public delegate void PFNGLGETPROGRAMINFOLOGPROC( uint program, int bufSize, IntPtr length, byte* infoLog );
		public delegate void PFNGLGETSHADERIVPROC( uint shader, uint pname, IntPtr @params );
		public delegate void PFNGLGETSHADERINFOLOGPROC( uint shader, int bufSize, IntPtr length, byte* infoLog );
		public delegate void PFNGLGETSHADERSOURCEPROC( uint shader, int bufSize, IntPtr length, char* source );
		public delegate int PFNGLGETUNIFORMLOCATIONPROC( uint program, byte* name );
		public delegate void PFNGLGETUNIFORMFVPROC( uint program, int location, float* @params );
		public delegate void PFNGLGETUNIFORMIVPROC( uint program, int location, IntPtr @params );
		public delegate void PFNGLGETVERTEXATTRIBDVPROC( uint index, uint pname, double* @params );
		public delegate void PFNGLGETVERTEXATTRIBFVPROC( uint index, uint pname, float* @params );
		public delegate void PFNGLGETVERTEXATTRIBIVPROC( uint index, uint pname, IntPtr @params );
		public delegate void PFNGLGETVERTEXATTRIBPOINTERVPROC( uint index, uint pname, void** pointer );
		public delegate bool PFNGLISPROGRAMPROC( uint program );
		public delegate bool PFNGLISSHADERPROC( uint shader );
		public delegate void PFNGLLINKPROGRAMPROC( uint program );
		public delegate void PFNGLSHADERSOURCEPROC( uint shader, int count, byte** source, IntPtr length );
		public delegate void PFNGLUSEPROGRAMPROC( uint program );
		public delegate void PFNGLUNIFORM1FPROC( int location, float v0 );
		public delegate void PFNGLUNIFORM2FPROC( int location, float v0, float v1 );
		public delegate void PFNGLUNIFORM3FPROC( int location, float v0, float v1, float v2 );
		public delegate void PFNGLUNIFORM4FPROC( int location, float v0, float v1, float v2, float v3 );
		public delegate void PFNGLUNIFORM1IPROC( int location, int v0 );
		public delegate void PFNGLUNIFORM2IPROC( int location, int v0, int v1 );
		public delegate void PFNGLUNIFORM3IPROC( int location, int v0, int v1, int v2 );
		public delegate void PFNGLUNIFORM4IPROC( int location, int v0, int v1, int v2, int v3 );
		public delegate void PFNGLUNIFORM1FVPROC( int location, int count, float* value );
		public delegate void PFNGLUNIFORM2FVPROC( int location, int count, float* value );
		public delegate void PFNGLUNIFORM3FVPROC( int location, int count, float* value );
		public delegate void PFNGLUNIFORM4FVPROC( int location, int count, float* value );
		public delegate void PFNGLUNIFORM1IVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLUNIFORM2IVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLUNIFORM3IVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLUNIFORM4IVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLUNIFORMMATRIX2FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLUNIFORMMATRIX3FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLUNIFORMMATRIX4FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLVALIDATEPROGRAMPROC( uint program );
		public delegate void PFNGLVERTEXATTRIB1DPROC( uint index, double x );
		public delegate void PFNGLVERTEXATTRIB1DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIB1FPROC( uint index, float x );
		public delegate void PFNGLVERTEXATTRIB1FVPROC( uint index, float* v );
		public delegate void PFNGLVERTEXATTRIB1SPROC( uint index, short x );
		public delegate void PFNGLVERTEXATTRIB1SVPROC( uint index, short* v );
		public delegate void PFNGLVERTEXATTRIB2DPROC( uint index, double x, double y );
		public delegate void PFNGLVERTEXATTRIB2DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIB2FPROC( uint index, float x, float y );
		public delegate void PFNGLVERTEXATTRIB2FVPROC( uint index, float* v );
		public delegate void PFNGLVERTEXATTRIB2SPROC( uint index, short x, short y );
		public delegate void PFNGLVERTEXATTRIB2SVPROC( uint index, short* v );
		public delegate void PFNGLVERTEXATTRIB3DPROC( uint index, double x, double y, double z );
		public delegate void PFNGLVERTEXATTRIB3DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIB3FPROC( uint index, float x, float y, float z );
		public delegate void PFNGLVERTEXATTRIB3FVPROC( uint index, float* v );
		public delegate void PFNGLVERTEXATTRIB3SPROC( uint index, short x, short y, short z );
		public delegate void PFNGLVERTEXATTRIB3SVPROC( uint index, short* v );
		public delegate void PFNGLVERTEXATTRIB4NBVPROC( uint index, sbyte* v );
		public delegate void PFNGLVERTEXATTRIB4NIVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIB4NSVPROC( uint index, short* v );
		public delegate void PFNGLVERTEXATTRIB4NUBPROC( uint index, byte x, byte y, byte z, byte w );
		public delegate void PFNGLVERTEXATTRIB4NUBVPROC( uint index, byte* v );
		public delegate void PFNGLVERTEXATTRIB4NUIVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIB4NUSVPROC( uint index, ushort* v );
		public delegate void PFNGLVERTEXATTRIB4BVPROC( uint index, sbyte* v );
		public delegate void PFNGLVERTEXATTRIB4DPROC( uint index, double x, double y, double z, double w );
		public delegate void PFNGLVERTEXATTRIB4DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIB4FPROC( uint index, float x, float y, float z, float w );
		public delegate void PFNGLVERTEXATTRIB4FVPROC( uint index, float* v );
		public delegate void PFNGLVERTEXATTRIB4IVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIB4SPROC( uint index, short x, short y, short z, short w );
		public delegate void PFNGLVERTEXATTRIB4SVPROC( uint index, short* v );
		public delegate void PFNGLVERTEXATTRIB4UBVPROC( uint index, byte* v );
		public delegate void PFNGLVERTEXATTRIB4UIVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIB4USVPROC( uint index, ushort* v );
		public delegate void PFNGLVERTEXATTRIBPOINTERPROC( uint index, uint size, uint type, bool normalized, int stride, void* pointer );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLBLENDEQUATIONSEPARATEPROC glBlendEquationSeparate;
		public static PFNGLDRAWBUFFERSPROC glDrawBuffers;
		public static PFNGLSTENCILOPSEPARATEPROC glStencilOpSeparate;
		public static PFNGLSTENCILFUNCSEPARATEPROC glStencilFuncSeparate;
		public static PFNGLSTENCILMASKSEPARATEPROC glStencilMaskSeparate;
		public static PFNGLATTACHSHADERPROC glAttachShader;
		public static PFNGLBINDATTRIBLOCATIONPROC glBindAttribLocation;
		public static PFNGLCOMPILESHADERPROC glCompileShader;
		public static PFNGLCREATEPROGRAMPROC glCreateProgram;
		public static PFNGLCREATESHADERPROC glCreateShader;
		public static PFNGLDELETEPROGRAMPROC glDeleteProgram;
		public static PFNGLDELETESHADERPROC glDeleteShader;
		public static PFNGLDETACHSHADERPROC glDetachShader;
		public static PFNGLDISABLEVERTEXATTRIBARRAYPROC glDisableVertexAttribArray;
		public static PFNGLENABLEVERTEXATTRIBARRAYPROC glEnableVertexAttribArray;
		public static PFNGLGETACTIVEATTRIBPROC glGetActiveAttrib;
		public static PFNGLGETACTIVEUNIFORMPROC glGetActiveUniform;
		public static PFNGLGETATTACHEDSHADERSPROC glGetAttachedShaders;
		public static PFNGLGETATTRIBLOCATIONPROC glGetAttribLocation;
		public static PFNGLGETPROGRAMIVPROC glGetProgramiv;
		public static PFNGLGETPROGRAMINFOLOGPROC glGetProgramInfoLog;
		public static PFNGLGETSHADERIVPROC glGetShaderiv;
		public static PFNGLGETSHADERINFOLOGPROC glGetShaderInfoLog;
		public static PFNGLGETSHADERSOURCEPROC glGetShaderSource;
		public static PFNGLGETUNIFORMLOCATIONPROC glGetUniformLocation;
		public static PFNGLGETUNIFORMFVPROC glGetUniformfv;
		public static PFNGLGETUNIFORMIVPROC glGetUniformiv;
		public static PFNGLGETVERTEXATTRIBDVPROC glGetVertexAttribdv;
		public static PFNGLGETVERTEXATTRIBFVPROC glGetVertexAttribfv;
		public static PFNGLGETVERTEXATTRIBIVPROC glGetVertexAttribiv;
		public static PFNGLGETVERTEXATTRIBPOINTERVPROC glGetVertexAttribPointerv;
		public static PFNGLISPROGRAMPROC glIsProgram;
		public static PFNGLISSHADERPROC glIsShader;
		public static PFNGLLINKPROGRAMPROC glLinkProgram;
		public static PFNGLSHADERSOURCEPROC glShaderSource;
		public static PFNGLUSEPROGRAMPROC glUseProgram;
		public static PFNGLUNIFORM1FPROC glUniform1f;
		public static PFNGLUNIFORM2FPROC glUniform2f;
		public static PFNGLUNIFORM3FPROC glUniform3f;
		public static PFNGLUNIFORM4FPROC glUniform4f;
		public static PFNGLUNIFORM1IPROC glUniform1i;
		public static PFNGLUNIFORM2IPROC glUniform2i;
		public static PFNGLUNIFORM3IPROC glUniform3i;
		public static PFNGLUNIFORM4IPROC glUniform4i;
		public static PFNGLUNIFORM1FVPROC glUniform1fv;
		public static PFNGLUNIFORM2FVPROC glUniform2fv;
		public static PFNGLUNIFORM3FVPROC glUniform3fv;
		public static PFNGLUNIFORM4FVPROC glUniform4fv;
		public static PFNGLUNIFORM1IVPROC glUniform1iv;
		public static PFNGLUNIFORM2IVPROC glUniform2iv;
		public static PFNGLUNIFORM3IVPROC glUniform3iv;
		public static PFNGLUNIFORM4IVPROC glUniform4iv;
		public static PFNGLUNIFORMMATRIX2FVPROC glUniformMatrix2fv;
		public static PFNGLUNIFORMMATRIX3FVPROC glUniformMatrix3fv;
		public static PFNGLUNIFORMMATRIX4FVPROC glUniformMatrix4fv;
		public static PFNGLVALIDATEPROGRAMPROC glValidateProgram;
		public static PFNGLVERTEXATTRIB1DPROC glVertexAttrib1d;
		public static PFNGLVERTEXATTRIB1DVPROC glVertexAttrib1dv;
		public static PFNGLVERTEXATTRIB1FPROC glVertexAttrib1f;
		public static PFNGLVERTEXATTRIB1FVPROC glVertexAttrib1fv;
		public static PFNGLVERTEXATTRIB1SPROC glVertexAttrib1s;
		public static PFNGLVERTEXATTRIB1SVPROC glVertexAttrib1sv;
		public static PFNGLVERTEXATTRIB2DPROC glVertexAttrib2d;
		public static PFNGLVERTEXATTRIB2DVPROC glVertexAttrib2dv;
		public static PFNGLVERTEXATTRIB2FPROC glVertexAttrib2f;
		public static PFNGLVERTEXATTRIB2FVPROC glVertexAttrib2fv;
		public static PFNGLVERTEXATTRIB2SPROC glVertexAttrib2s;
		public static PFNGLVERTEXATTRIB2SVPROC glVertexAttrib2sv;
		public static PFNGLVERTEXATTRIB3DPROC glVertexAttrib3d;
		public static PFNGLVERTEXATTRIB3DVPROC glVertexAttrib3dv;
		public static PFNGLVERTEXATTRIB3FPROC glVertexAttrib3f;
		public static PFNGLVERTEXATTRIB3FVPROC glVertexAttrib3fv;
		public static PFNGLVERTEXATTRIB3SPROC glVertexAttrib3s;
		public static PFNGLVERTEXATTRIB3SVPROC glVertexAttrib3sv;
		public static PFNGLVERTEXATTRIB4NBVPROC glVertexAttrib4Nbv;
		public static PFNGLVERTEXATTRIB4NIVPROC glVertexAttrib4Niv;
		public static PFNGLVERTEXATTRIB4NSVPROC glVertexAttrib4Nsv;
		public static PFNGLVERTEXATTRIB4NUBPROC glVertexAttrib4Nub;
		public static PFNGLVERTEXATTRIB4NUBVPROC glVertexAttrib4Nubv;
		public static PFNGLVERTEXATTRIB4NUIVPROC glVertexAttrib4Nuiv;
		public static PFNGLVERTEXATTRIB4NUSVPROC glVertexAttrib4Nusv;
		public static PFNGLVERTEXATTRIB4BVPROC glVertexAttrib4bv;
		public static PFNGLVERTEXATTRIB4DPROC glVertexAttrib4d;
		public static PFNGLVERTEXATTRIB4DVPROC glVertexAttrib4dv;
		public static PFNGLVERTEXATTRIB4FPROC glVertexAttrib4f;
		public static PFNGLVERTEXATTRIB4FVPROC glVertexAttrib4fv;
		public static PFNGLVERTEXATTRIB4IVPROC glVertexAttrib4iv;
		public static PFNGLVERTEXATTRIB4SPROC glVertexAttrib4s;
		public static PFNGLVERTEXATTRIB4SVPROC glVertexAttrib4sv;
		public static PFNGLVERTEXATTRIB4UBVPROC glVertexAttrib4ubv;
		public static PFNGLVERTEXATTRIB4UIVPROC glVertexAttrib4uiv;
		public static PFNGLVERTEXATTRIB4USVPROC glVertexAttrib4usv;
		public static PFNGLVERTEXATTRIBPOINTERPROC glVertexAttribPointer;
#endif
#endif // GL_VERSION_2_0
		#endregion

		#region OpenGL 2.1
#if GL_VERSION_2_1
		public const uint GL_PIXEL_PACK_BUFFER = 0x88EB;
		public const uint GL_PIXEL_UNPACK_BUFFER = 0x88EC;
		public const uint GL_PIXEL_PACK_BUFFER_BINDING = 0x88ED;
		public const uint GL_PIXEL_UNPACK_BUFFER_BINDING = 0x88EF;
		public const uint GL_FLOAT_MAT2x3 = 0x8B65;
		public const uint GL_FLOAT_MAT2x4 = 0x8B66;
		public const uint GL_FLOAT_MAT3x2 = 0x8B67;
		public const uint GL_FLOAT_MAT3x4 = 0x8B68;
		public const uint GL_FLOAT_MAT4x2 = 0x8B69;
		public const uint GL_FLOAT_MAT4x3 = 0x8B6A;
		public const uint GL_SRGB = 0x8C40;
		public const uint GL_SRGB8 = 0x8C41;
		public const uint GL_SRGB_ALPHA = 0x8C42;
		public const uint GL_SRGB8_ALPHA8 = 0x8C43;
		public const uint GL_COMPRESSED_SRGB = 0x8C48;
		public const uint GL_COMPRESSED_SRGB_ALPHA = 0x8C49;
		public delegate void PFNGLUNIFORMMATRIX2X3FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLUNIFORMMATRIX3X2FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLUNIFORMMATRIX2X4FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLUNIFORMMATRIX4X2FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLUNIFORMMATRIX3X4FVPROC( int location, int count, bool transpose, float* value );
		public delegate void PFNGLUNIFORMMATRIX4X3FVPROC( int location, int count, bool transpose, float* value );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLUNIFORMMATRIX2X3FVPROC glUniformMatrix2x3fv;
		public static PFNGLUNIFORMMATRIX3X2FVPROC glUniformMatrix3x2fv;
		public static PFNGLUNIFORMMATRIX2X4FVPROC glUniformMatrix2x4fv;
		public static PFNGLUNIFORMMATRIX4X2FVPROC glUniformMatrix4x2fv;
		public static PFNGLUNIFORMMATRIX3X4FVPROC glUniformMatrix3x4fv;
		public static PFNGLUNIFORMMATRIX4X3FVPROC glUniformMatrix4x3fv;
#endif
#endif // GL_VERSION_2_1
		#endregion

		#region OpenGL 3.0
#if GL_VERSION_3_0
		public const uint GL_COMPARE_REF_TO_TEXTURE = 0x884E;
		public const uint GL_CLIP_DISTANCE0 = 0x3000;
		public const uint GL_CLIP_DISTANCE1 = 0x3001;
		public const uint GL_CLIP_DISTANCE2 = 0x3002;
		public const uint GL_CLIP_DISTANCE3 = 0x3003;
		public const uint GL_CLIP_DISTANCE4 = 0x3004;
		public const uint GL_CLIP_DISTANCE5 = 0x3005;
		public const uint GL_CLIP_DISTANCE6 = 0x3006;
		public const uint GL_CLIP_DISTANCE7 = 0x3007;
		public const uint GL_MAX_CLIP_DISTANCES = 0x0D32;
		public const uint GL_MAJOR_VERSION = 0x821B;
		public const uint GL_MINOR_VERSION = 0x821C;
		public const uint GL_NUM_EXTENSIONS = 0x821D;
		public const uint GL_CONTEXT_FLAGS = 0x821E;
		public const uint GL_COMPRESSED_RED = 0x8225;
		public const uint GL_COMPRESSED_RG = 0x8226;
		public const uint GL_CONTEXT_FLAG_FORWARD_COMPATIBLE_BIT = 0x00000001;
		public const uint GL_RGBA32F = 0x8814;
		public const uint GL_RGB32F = 0x8815;
		public const uint GL_RGBA16F = 0x881A;
		public const uint GL_RGB16F = 0x881B;
		public const uint GL_VERTEX_ATTRIB_ARRAY_INTEGER = 0x88FD;
		public const uint GL_MAX_ARRAY_TEXTURE_LAYERS = 0x88FF;
		public const uint GL_MIN_PROGRAM_TEXEL_OFFSET = 0x8904;
		public const uint GL_MAX_PROGRAM_TEXEL_OFFSET = 0x8905;
		public const uint GL_CLAMP_READ_COLOR = 0x891C;
		public const uint GL_FIXED_ONLY = 0x891D;
		public const uint GL_MAX_VARYING_COMPONENTS = 0x8B4B;
		public const uint GL_TEXTURE_1D_ARRAY = 0x8C18;
		public const uint GL_PROXY_TEXTURE_1D_ARRAY = 0x8C19;
		public const uint GL_TEXTURE_2D_ARRAY = 0x8C1A;
		public const uint GL_PROXY_TEXTURE_2D_ARRAY = 0x8C1B;
		public const uint GL_TEXTURE_BINDING_1D_ARRAY = 0x8C1C;
		public const uint GL_TEXTURE_BINDING_2D_ARRAY = 0x8C1D;
		public const uint GL_R11F_G11F_B10F = 0x8C3A;
		public const uint GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B;
		public const uint GL_RGB9_E5 = 0x8C3D;
		public const uint GL_UNSIGNED_INT_5_9_9_9_REV = 0x8C3E;
		public const uint GL_TEXTURE_SHARED_SIZE = 0x8C3F;
		public const uint GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F;
		public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 0x8C80;
		public const uint GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85;
		public const uint GL_PRIMITIVES_GENERATED = 0x8C87;
		public const uint GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 0x8C88;
		public const uint GL_RASTERIZER_DISCARD = 0x8C89;
		public const uint GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 0x8C8A;
		public const uint GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 0x8C8B;
		public const uint GL_INTERLEAVED_ATTRIBS = 0x8C8C;
		public const uint GL_SEPARATE_ATTRIBS = 0x8C8D;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F;
		public const uint GL_RGBA32UI = 0x8D70;
		public const uint GL_RGB32UI = 0x8D71;
		public const uint GL_RGBA16UI = 0x8D76;
		public const uint GL_RGB16UI = 0x8D77;
		public const uint GL_RGBA8UI = 0x8D7C;
		public const uint GL_RGB8UI = 0x8D7D;
		public const uint GL_RGBA32I = 0x8D82;
		public const uint GL_RGB32I = 0x8D83;
		public const uint GL_RGBA16I = 0x8D88;
		public const uint GL_RGB16I = 0x8D89;
		public const uint GL_RGBA8I = 0x8D8E;
		public const uint GL_RGB8I = 0x8D8F;
		public const uint GL_RED_INTEGER = 0x8D94;
		public const uint GL_GREEN_INTEGER = 0x8D95;
		public const uint GL_BLUE_INTEGER = 0x8D96;
		public const uint GL_RGB_INTEGER = 0x8D98;
		public const uint GL_RGBA_INTEGER = 0x8D99;
		public const uint GL_BGR_INTEGER = 0x8D9A;
		public const uint GL_BGRA_INTEGER = 0x8D9B;
		public const uint GL_SAMPLER_1D_ARRAY = 0x8DC0;
		public const uint GL_SAMPLER_2D_ARRAY = 0x8DC1;
		public const uint GL_SAMPLER_1D_ARRAY_SHADOW = 0x8DC3;
		public const uint GL_SAMPLER_2D_ARRAY_SHADOW = 0x8DC4;
		public const uint GL_SAMPLER_CUBE_SHADOW = 0x8DC5;
		public const uint GL_UNSIGNED_INT_VEC2 = 0x8DC6;
		public const uint GL_UNSIGNED_INT_VEC3 = 0x8DC7;
		public const uint GL_UNSIGNED_INT_VEC4 = 0x8DC8;
		public const uint GL_INT_SAMPLER_1D = 0x8DC9;
		public const uint GL_INT_SAMPLER_2D = 0x8DCA;
		public const uint GL_INT_SAMPLER_3D = 0x8DCB;
		public const uint GL_INT_SAMPLER_CUBE = 0x8DCC;
		public const uint GL_INT_SAMPLER_1D_ARRAY = 0x8DCE;
		public const uint GL_INT_SAMPLER_2D_ARRAY = 0x8DCF;
		public const uint GL_UNSIGNED_INT_SAMPLER_1D = 0x8DD1;
		public const uint GL_UNSIGNED_INT_SAMPLER_2D = 0x8DD2;
		public const uint GL_UNSIGNED_INT_SAMPLER_3D = 0x8DD3;
		public const uint GL_UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4;
		public const uint GL_UNSIGNED_INT_SAMPLER_1D_ARRAY = 0x8DD6;
		public const uint GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7;
		public const uint GL_QUERY_WAIT = 0x8E13;
		public const uint GL_QUERY_NO_WAIT = 0x8E14;
		public const uint GL_QUERY_BY_REGION_WAIT = 0x8E15;
		public const uint GL_QUERY_BY_REGION_NO_WAIT = 0x8E16;
		public const uint GL_BUFFER_ACCESS_FLAGS = 0x911F;
		public const uint GL_BUFFER_MAP_LENGTH = 0x9120;
		public const uint GL_BUFFER_MAP_OFFSET = 0x9121;
		public const uint GL_DEPTH_COMPONENT32F = 0x8CAC;
		public const uint GL_DEPTH32F_STENCIL8 = 0x8CAD;
		public const uint GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD;
		public const uint GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 0x8210;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 0x8211;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_RED_SIZE = 0x8212;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 0x8213;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 0x8214;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 0x8215;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 0x8216;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 0x8217;
		public const uint GL_FRAMEBUFFER_DEFAULT = 0x8218;
		public const uint GL_FRAMEBUFFER_UNDEFINED = 0x8219;
		public const uint GL_DEPTH_STENCIL_ATTACHMENT = 0x821A;
		public const uint GL_MAX_RENDERBUFFER_SIZE = 0x84E8;
		public const uint GL_DEPTH_STENCIL = 0x84F9;
		public const uint GL_UNSIGNED_INT_24_8 = 0x84FA;
		public const uint GL_DEPTH24_STENCIL8 = 0x88F0;
		public const uint GL_TEXTURE_STENCIL_SIZE = 0x88F1;
		public const uint GL_TEXTURE_RED_TYPE = 0x8C10;
		public const uint GL_TEXTURE_GREEN_TYPE = 0x8C11;
		public const uint GL_TEXTURE_BLUE_TYPE = 0x8C12;
		public const uint GL_TEXTURE_ALPHA_TYPE = 0x8C13;
		public const uint GL_TEXTURE_DEPTH_TYPE = 0x8C16;
		public const uint GL_UNSIGNED_NORMALIZED = 0x8C17;
		public const uint GL_FRAMEBUFFER_BINDING = 0x8CA6;
		public const uint GL_DRAW_FRAMEBUFFER_BINDING = 0x8CA6;
		public const uint GL_RENDERBUFFER_BINDING = 0x8CA7;
		public const uint GL_READ_FRAMEBUFFER = 0x8CA8;
		public const uint GL_DRAW_FRAMEBUFFER = 0x8CA9;
		public const uint GL_READ_FRAMEBUFFER_BINDING = 0x8CAA;
		public const uint GL_RENDERBUFFER_SAMPLES = 0x8CAB;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 0x8CD0;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 0x8CD1;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 0x8CD2;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 0x8CD3;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 0x8CD4;
		public const uint GL_FRAMEBUFFER_COMPLETE = 0x8CD5;
		public const uint GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6;
		public const uint GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7;
		public const uint GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = 0x8CDB;
		public const uint GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER = 0x8CDC;
		public const uint GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD;
		public const uint GL_MAX_COLOR_ATTACHMENTS = 0x8CDF;
		public const uint GL_COLOR_ATTACHMENT0 = 0x8CE0;
		public const uint GL_COLOR_ATTACHMENT1 = 0x8CE1;
		public const uint GL_COLOR_ATTACHMENT2 = 0x8CE2;
		public const uint GL_COLOR_ATTACHMENT3 = 0x8CE3;
		public const uint GL_COLOR_ATTACHMENT4 = 0x8CE4;
		public const uint GL_COLOR_ATTACHMENT5 = 0x8CE5;
		public const uint GL_COLOR_ATTACHMENT6 = 0x8CE6;
		public const uint GL_COLOR_ATTACHMENT7 = 0x8CE7;
		public const uint GL_COLOR_ATTACHMENT8 = 0x8CE8;
		public const uint GL_COLOR_ATTACHMENT9 = 0x8CE9;
		public const uint GL_COLOR_ATTACHMENT10 = 0x8CEA;
		public const uint GL_COLOR_ATTACHMENT11 = 0x8CEB;
		public const uint GL_COLOR_ATTACHMENT12 = 0x8CEC;
		public const uint GL_COLOR_ATTACHMENT13 = 0x8CED;
		public const uint GL_COLOR_ATTACHMENT14 = 0x8CEE;
		public const uint GL_COLOR_ATTACHMENT15 = 0x8CEF;
		public const uint GL_COLOR_ATTACHMENT16 = 0x8CF0;
		public const uint GL_COLOR_ATTACHMENT17 = 0x8CF1;
		public const uint GL_COLOR_ATTACHMENT18 = 0x8CF2;
		public const uint GL_COLOR_ATTACHMENT19 = 0x8CF3;
		public const uint GL_COLOR_ATTACHMENT20 = 0x8CF4;
		public const uint GL_COLOR_ATTACHMENT21 = 0x8CF5;
		public const uint GL_COLOR_ATTACHMENT22 = 0x8CF6;
		public const uint GL_COLOR_ATTACHMENT23 = 0x8CF7;
		public const uint GL_COLOR_ATTACHMENT24 = 0x8CF8;
		public const uint GL_COLOR_ATTACHMENT25 = 0x8CF9;
		public const uint GL_COLOR_ATTACHMENT26 = 0x8CFA;
		public const uint GL_COLOR_ATTACHMENT27 = 0x8CFB;
		public const uint GL_COLOR_ATTACHMENT28 = 0x8CFC;
		public const uint GL_COLOR_ATTACHMENT29 = 0x8CFD;
		public const uint GL_COLOR_ATTACHMENT30 = 0x8CFE;
		public const uint GL_COLOR_ATTACHMENT31 = 0x8CFF;
		public const uint GL_DEPTH_ATTACHMENT = 0x8D00;
		public const uint GL_STENCIL_ATTACHMENT = 0x8D20;
		public const uint GL_FRAMEBUFFER = 0x8D40;
		public const uint GL_RENDERBUFFER = 0x8D41;
		public const uint GL_RENDERBUFFER_WIDTH = 0x8D42;
		public const uint GL_RENDERBUFFER_HEIGHT = 0x8D43;
		public const uint GL_RENDERBUFFER_INTERNAL_FORMAT = 0x8D44;
		public const uint GL_STENCIL_INDEX1 = 0x8D46;
		public const uint GL_STENCIL_INDEX4 = 0x8D47;
		public const uint GL_STENCIL_INDEX8 = 0x8D48;
		public const uint GL_STENCIL_INDEX16 = 0x8D49;
		public const uint GL_RENDERBUFFER_RED_SIZE = 0x8D50;
		public const uint GL_RENDERBUFFER_GREEN_SIZE = 0x8D51;
		public const uint GL_RENDERBUFFER_BLUE_SIZE = 0x8D52;
		public const uint GL_RENDERBUFFER_ALPHA_SIZE = 0x8D53;
		public const uint GL_RENDERBUFFER_DEPTH_SIZE = 0x8D54;
		public const uint GL_RENDERBUFFER_STENCIL_SIZE = 0x8D55;
		public const uint GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56;
		public const uint GL_MAX_SAMPLES = 0x8D57;
		public const uint GL_FRAMEBUFFER_SRGB = 0x8DB9;
		public const uint GL_HALF_FLOAT = 0x140B;
		public const uint GL_MAP_READ_BIT = 0x0001;
		public const uint GL_MAP_WRITE_BIT = 0x0002;
		public const uint GL_MAP_INVALIDATE_RANGE_BIT = 0x0004;
		public const uint GL_MAP_INVALIDATE_BUFFER_BIT = 0x0008;
		public const uint GL_MAP_FLUSH_EXPLICIT_BIT = 0x0010;
		public const uint GL_MAP_UNSYNCHRONIZED_BIT = 0x0020;
		public const uint GL_COMPRESSED_RED_RGTC1 = 0x8DBB;
		public const uint GL_COMPRESSED_SIGNED_RED_RGTC1 = 0x8DBC;
		public const uint GL_COMPRESSED_RG_RGTC2 = 0x8DBD;
		public const uint GL_COMPRESSED_SIGNED_RG_RGTC2 = 0x8DBE;
		public const uint GL_RG = 0x8227;
		public const uint GL_RG_INTEGER = 0x8228;
		public const uint GL_R8 = 0x8229;
		public const uint GL_R16 = 0x822A;
		public const uint GL_RG8 = 0x822B;
		public const uint GL_RG16 = 0x822C;
		public const uint GL_R16F = 0x822D;
		public const uint GL_R32F = 0x822E;
		public const uint GL_RG16F = 0x822F;
		public const uint GL_RG32F = 0x8230;
		public const uint GL_R8I = 0x8231;
		public const uint GL_R8UI = 0x8232;
		public const uint GL_R16I = 0x8233;
		public const uint GL_R16UI = 0x8234;
		public const uint GL_R32I = 0x8235;
		public const uint GL_R32UI = 0x8236;
		public const uint GL_RG8I = 0x8237;
		public const uint GL_RG8UI = 0x8238;
		public const uint GL_RG16I = 0x8239;
		public const uint GL_RG16UI = 0x823A;
		public const uint GL_RG32I = 0x823B;
		public const uint GL_RG32UI = 0x823C;
		public const uint GL_VERTEX_ARRAY_BINDING = 0x85B5;
		public delegate void PFNGLCOLORMASKIPROC( uint index, bool r, bool g, bool b, bool a );
		public delegate void PFNGLGETBOOLEANI_VPROC( uint target, uint index, bool* data );
		public delegate void PFNGLGETINTEGERI_VPROC( uint target, uint index, IntPtr data );
		public delegate void PFNGLENABLEIPROC( uint target, uint index );
		public delegate void PFNGLDISABLEIPROC( uint target, uint index );
		public delegate bool PFNGLISENABLEDIPROC( uint target, uint index );
		public delegate void PFNGLBEGINTRANSFORMFEEDBACKPROC( uint primitiveMode );
		public delegate void PFNGLENDTRANSFORMFEEDBACKPROC();
		public delegate void PFNGLBINDBUFFERRANGEPROC( uint target, uint index, uint buffer, IntPtr offset, IntPtr size );
		public delegate void PFNGLBINDBUFFERBASEPROC( uint target, uint index, uint buffer );
		public delegate void PFNGLTRANSFORMFEEDBACKVARYINGSPROC( uint program, int count, char* varyings, uint bufferMode );
		public delegate void PFNGLGETTRANSFORMFEEDBACKVARYINGPROC( uint program, uint index, int bufSize, IntPtr length, IntPtr size, IntPtr type, char* name );
		public delegate void PFNGLCLAMPCOLORPROC( uint target, uint clamp );
		public delegate void PFNGLBEGINCONDITIONALRENDERPROC( uint id, uint mode );
		public delegate void PFNGLENDCONDITIONALRENDERPROC();
		public delegate void PFNGLVERTEXATTRIBIPOINTERPROC( uint index, int size, uint type, int stride, void* pointer );
		public delegate void PFNGLGETVERTEXATTRIBIIVPROC( uint index, uint pname, IntPtr @params );
		public delegate void PFNGLGETVERTEXATTRIBIUIVPROC( uint index, uint pname, IntPtr @params );
		public delegate void PFNGLVERTEXATTRIBI1IPROC( uint index, int x );
		public delegate void PFNGLVERTEXATTRIBI2IPROC( uint index, int x, int y );
		public delegate void PFNGLVERTEXATTRIBI3IPROC( uint index, int x, int y, int z );
		public delegate void PFNGLVERTEXATTRIBI4IPROC( uint index, int x, int y, int z, int w );
		public delegate void PFNGLVERTEXATTRIBI1UIPROC( uint index, uint x );
		public delegate void PFNGLVERTEXATTRIBI2UIPROC( uint index, uint x, uint y );
		public delegate void PFNGLVERTEXATTRIBI3UIPROC( uint index, uint x, uint y, uint z );
		public delegate void PFNGLVERTEXATTRIBI4UIPROC( uint index, uint x, uint y, uint z, uint w );
		public delegate void PFNGLVERTEXATTRIBI1IVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI2IVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI3IVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI4IVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI1UIVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI2UIVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI3UIVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI4UIVPROC( uint index, IntPtr v );
		public delegate void PFNGLVERTEXATTRIBI4BVPROC( uint index, sbyte* v );
		public delegate void PFNGLVERTEXATTRIBI4SVPROC( uint index, short* v );
		public delegate void PFNGLVERTEXATTRIBI4UBVPROC( uint index, byte* v );
		public delegate void PFNGLVERTEXATTRIBI4USVPROC( uint index, ushort* v );
		public delegate void PFNGLGETUNIFORMUIVPROC( uint program, int location, IntPtr @params );
		public delegate void PFNGLBINDFRAGDATALOCATIONPROC( uint program, uint color, char* name );
		public delegate int PFNGLGETFRAGDATALOCATIONPROC( uint program, char* name );
		public delegate void PFNGLUNIFORM1UIPROC( int location, uint v0 );
		public delegate void PFNGLUNIFORM2UIPROC( int location, uint v0, uint v1 );
		public delegate void PFNGLUNIFORM3UIPROC( int location, uint v0, uint v1, uint v2 );
		public delegate void PFNGLUNIFORM4UIPROC( int location, uint v0, uint v1, uint v2, uint v3 );
		public delegate void PFNGLUNIFORM1UIVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLUNIFORM2UIVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLUNIFORM3UIVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLUNIFORM4UIVPROC( int location, int count, IntPtr value );
		public delegate void PFNGLTEXPARAMETERIIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLTEXPARAMETERIUIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLGETTEXPARAMETERIIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLGETTEXPARAMETERIUIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLCLEARBUFFERIVPROC( uint buffer, int drawbuffer, IntPtr value );
		public delegate void PFNGLCLEARBUFFERUIVPROC( uint buffer, int drawbuffer, IntPtr value );
		public delegate void PFNGLCLEARBUFFERFVPROC( uint buffer, int drawbuffer, float* value );
		public delegate void PFNGLCLEARBUFFERFIPROC( uint buffer, int drawbuffer, float depth, int stencil );
		public delegate byte* PFNGLGETSTRINGIPROC( uint name, uint index );
		public delegate bool PFNGLISRENDERBUFFERPROC( uint renderbuffer );
		public delegate void PFNGLBINDRENDERBUFFERPROC( uint target, uint renderbuffer );
		public delegate void PFNGLDELETERENDERBUFFERSPROC( int n, IntPtr renderbuffers );
		public delegate void PFNGLGENRENDERBUFFERSPROC( int n, IntPtr renderbuffers );
		public delegate void PFNGLRENDERBUFFERSTORAGEPROC( uint target, uint internalformat, int width, int height );
		public delegate void PFNGLGETRENDERBUFFERPARAMETERIVPROC( uint target, uint pname, IntPtr @params );
		public delegate bool PFNGLISFRAMEBUFFERPROC( uint framebuffer );
		public delegate void PFNGLBINDFRAMEBUFFERPROC( uint target, uint framebuffer );
		public delegate void PFNGLDELETEFRAMEBUFFERSPROC( int n, IntPtr framebuffers );
		public delegate void PFNGLGENFRAMEBUFFERSPROC( int n, IntPtr framebuffers );
		public delegate uint PFNGLCHECKFRAMEBUFFERSTATUSPROC( uint target );
		public delegate void PFNGLFRAMEBUFFERTEXTURE1DPROC( uint target, uint attachment, uint textarget, uint texture, int level );
		public delegate void PFNGLFRAMEBUFFERTEXTURE2DPROC( uint target, uint attachment, uint textarget, uint texture, int level );
		public delegate void PFNGLFRAMEBUFFERTEXTURE3DPROC( uint target, uint attachment, uint textarget, uint texture, int level, int zoffset );
		public delegate void PFNGLFRAMEBUFFERRENDERBUFFERPROC( uint target, uint attachment, uint renderbuffertarget, uint renderbuffer );
		public delegate void PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC( uint target, uint attachment, uint pname, IntPtr @params );
		public delegate void PFNGLGENERATEMIPMAPPROC( uint target );
		public delegate void PFNGLBLITFRAMEBUFFERPROC( int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter );
		public delegate void PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC( uint target, int samples, uint internalformat, int width, int height );
		public delegate void PFNGLFRAMEBUFFERTEXTURELAYERPROC( uint target, uint attachment, uint texture, int level, int layer );
		public delegate void* PFNGLMAPBUFFERRANGEPROC( uint target, IntPtr offset, IntPtr length, uint access );
		public delegate void PFNGLFLUSHMAPPEDBUFFERRANGEPROC( uint target, IntPtr offset, IntPtr length );
		public delegate void PFNGLBINDVERTEXARRAYPROC( uint array );
		public delegate void PFNGLDELETEVERTEXARRAYSPROC( int n, uint* arrays );
		public delegate void PFNGLGENVERTEXARRAYSPROC( int n, uint* arrays );
		public delegate bool PFNGLISVERTEXARRAYPROC( uint array );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLCOLORMASKIPROC glColorMaski;
		public static PFNGLGETBOOLEANI_VPROC glGetBooleani_v;
		public static PFNGLGETINTEGERI_VPROC glGetIntegeri_v;
		public static PFNGLENABLEIPROC glEnablei;
		public static PFNGLDISABLEIPROC glDisablei;
		public static PFNGLISENABLEDIPROC glIsEnabledi;
		public static PFNGLBEGINTRANSFORMFEEDBACKPROC glBeginTransformFeedback;
		public static PFNGLENDTRANSFORMFEEDBACKPROC glEndTransformFeedback;
		public static PFNGLBINDBUFFERRANGEPROC glBindBufferRange;
		public static PFNGLBINDBUFFERBASEPROC glBindBufferBase;
		public static PFNGLTRANSFORMFEEDBACKVARYINGSPROC glTransformFeedbackVaryings;
		public static PFNGLGETTRANSFORMFEEDBACKVARYINGPROC glGetTransformFeedbackVarying;
		public static PFNGLCLAMPCOLORPROC glClampColor;
		public static PFNGLBEGINCONDITIONALRENDERPROC glBeginConditionalRender;
		public static PFNGLENDCONDITIONALRENDERPROC glEndConditionalRender;
		public static PFNGLVERTEXATTRIBIPOINTERPROC glVertexAttribIPointer;
		public static PFNGLGETVERTEXATTRIBIIVPROC glGetVertexAttribIiv;
		public static PFNGLGETVERTEXATTRIBIUIVPROC glGetVertexAttribIuiv;
		public static PFNGLVERTEXATTRIBI1IPROC glVertexAttribI1i;
		public static PFNGLVERTEXATTRIBI2IPROC glVertexAttribI2i;
		public static PFNGLVERTEXATTRIBI3IPROC glVertexAttribI3i;
		public static PFNGLVERTEXATTRIBI4IPROC glVertexAttribI4i;
		public static PFNGLVERTEXATTRIBI1UIPROC glVertexAttribI1ui;
		public static PFNGLVERTEXATTRIBI2UIPROC glVertexAttribI2ui;
		public static PFNGLVERTEXATTRIBI3UIPROC glVertexAttribI3ui;
		public static PFNGLVERTEXATTRIBI4UIPROC glVertexAttribI4ui;
		public static PFNGLVERTEXATTRIBI1IVPROC glVertexAttribI1iv;
		public static PFNGLVERTEXATTRIBI2IVPROC glVertexAttribI2iv;
		public static PFNGLVERTEXATTRIBI3IVPROC glVertexAttribI3iv;
		public static PFNGLVERTEXATTRIBI4IVPROC glVertexAttribI4iv;
		public static PFNGLVERTEXATTRIBI1UIVPROC glVertexAttribI1uiv;
		public static PFNGLVERTEXATTRIBI2UIVPROC glVertexAttribI2uiv;
		public static PFNGLVERTEXATTRIBI3UIVPROC glVertexAttribI3uiv;
		public static PFNGLVERTEXATTRIBI4UIVPROC glVertexAttribI4uiv;
		public static PFNGLVERTEXATTRIBI4BVPROC glVertexAttribI4bv;
		public static PFNGLVERTEXATTRIBI4SVPROC glVertexAttribI4sv;
		public static PFNGLVERTEXATTRIBI4UBVPROC glVertexAttribI4ubv;
		public static PFNGLVERTEXATTRIBI4USVPROC glVertexAttribI4usv;
		public static PFNGLGETUNIFORMUIVPROC glGetUniformuiv;
		public static PFNGLBINDFRAGDATALOCATIONPROC glBindFragDataLocation;
		public static PFNGLGETFRAGDATALOCATIONPROC glGetFragDataLocation;
		public static PFNGLUNIFORM1UIPROC glUniform1ui;
		public static PFNGLUNIFORM2UIPROC glUniform2ui;
		public static PFNGLUNIFORM3UIPROC glUniform3ui;
		public static PFNGLUNIFORM4UIPROC glUniform4ui;
		public static PFNGLUNIFORM1UIVPROC glUniform1uiv;
		public static PFNGLUNIFORM2UIVPROC glUniform2uiv;
		public static PFNGLUNIFORM3UIVPROC glUniform3uiv;
		public static PFNGLUNIFORM4UIVPROC glUniform4uiv;
		public static PFNGLTEXPARAMETERIIVPROC glTexParameterIiv;
		public static PFNGLTEXPARAMETERIUIVPROC glTexParameterIuiv;
		public static PFNGLGETTEXPARAMETERIIVPROC glGetTexParameterIiv;
		public static PFNGLGETTEXPARAMETERIUIVPROC glGetTexParameterIuiv;
		public static PFNGLCLEARBUFFERIVPROC glClearBufferiv;
		public static PFNGLCLEARBUFFERUIVPROC glClearBufferuiv;
		public static PFNGLCLEARBUFFERFVPROC glClearBufferfv;
		public static PFNGLCLEARBUFFERFIPROC glClearBufferfi;
		public static PFNGLGETSTRINGIPROC glGetStringi;
		public static PFNGLISRENDERBUFFERPROC glIsRenderbuffer;
		public static PFNGLBINDRENDERBUFFERPROC glBindRenderbuffer;
		public static PFNGLDELETERENDERBUFFERSPROC glDeleteRenderbuffers;
		public static PFNGLGENRENDERBUFFERSPROC glGenRenderbuffers;
		public static PFNGLRENDERBUFFERSTORAGEPROC glRenderbufferStorage;
		public static PFNGLGETRENDERBUFFERPARAMETERIVPROC glGetRenderbufferParameteriv;
		public static PFNGLISFRAMEBUFFERPROC glIsFramebuffer;
		public static PFNGLBINDFRAMEBUFFERPROC glBindFramebuffer;
		public static PFNGLDELETEFRAMEBUFFERSPROC glDeleteFramebuffers;
		public static PFNGLGENFRAMEBUFFERSPROC glGenFramebuffers;
		public static PFNGLCHECKFRAMEBUFFERSTATUSPROC glCheckFramebufferStatus;
		public static PFNGLFRAMEBUFFERTEXTURE1DPROC glFramebufferTexture1D;
		public static PFNGLFRAMEBUFFERTEXTURE2DPROC glFramebufferTexture2D;
		public static PFNGLFRAMEBUFFERTEXTURE3DPROC glFramebufferTexture3D;
		public static PFNGLFRAMEBUFFERRENDERBUFFERPROC glFramebufferRenderbuffer;
		public static PFNGLGETFRAMEBUFFERATTACHMENTPARAMETERIVPROC glGetFramebufferAttachmentParameteriv;
		public static PFNGLGENERATEMIPMAPPROC glGenerateMipmap;
		public static PFNGLBLITFRAMEBUFFERPROC glBlitFramebuffer;
		public static PFNGLRENDERBUFFERSTORAGEMULTISAMPLEPROC glRenderbufferStorageMultisample;
		public static PFNGLFRAMEBUFFERTEXTURELAYERPROC glFramebufferTextureLayer;
		public static PFNGLMAPBUFFERRANGEPROC glMapBufferRange;
		public static PFNGLFLUSHMAPPEDBUFFERRANGEPROC glFlushMappedBufferRange;
		public static PFNGLBINDVERTEXARRAYPROC glBindVertexArray;
		public static PFNGLDELETEVERTEXARRAYSPROC glDeleteVertexArrays;
		public static PFNGLGENVERTEXARRAYSPROC glGenVertexArrays;
		public static PFNGLISVERTEXARRAYPROC glIsVertexArray;
#endif
#endif // GL_VERSION_3_0
		#endregion

		#region OpenGL 3.1
#if GL_VERSION_3_1
		public const uint GL_SAMPLER_2D_RECT = 0x8B63;
		public const uint GL_SAMPLER_2D_RECT_SHADOW = 0x8B64;
		public const uint GL_SAMPLER_BUFFER = 0x8DC2;
		public const uint GL_INT_SAMPLER_2D_RECT = 0x8DCD;
		public const uint GL_INT_SAMPLER_BUFFER = 0x8DD0;
		public const uint GL_UNSIGNED_INT_SAMPLER_2D_RECT = 0x8DD5;
		public const uint GL_UNSIGNED_INT_SAMPLER_BUFFER = 0x8DD8;
		public const uint GL_TEXTURE_BUFFER = 0x8C2A;
		public const uint GL_MAX_TEXTURE_BUFFER_SIZE = 0x8C2B;
		public const uint GL_TEXTURE_BINDING_BUFFER = 0x8C2C;
		public const uint GL_TEXTURE_BUFFER_DATA_STORE_BINDING = 0x8C2D;
		public const uint GL_TEXTURE_RECTANGLE = 0x84F5;
		public const uint GL_TEXTURE_BINDING_RECTANGLE = 0x84F6;
		public const uint GL_PROXY_TEXTURE_RECTANGLE = 0x84F7;
		public const uint GL_MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8;
		public const uint GL_R8_SNORM = 0x8F94;
		public const uint GL_RG8_SNORM = 0x8F95;
		public const uint GL_RGB8_SNORM = 0x8F96;
		public const uint GL_RGBA8_SNORM = 0x8F97;
		public const uint GL_R16_SNORM = 0x8F98;
		public const uint GL_RG16_SNORM = 0x8F99;
		public const uint GL_RGB16_SNORM = 0x8F9A;
		public const uint GL_RGBA16_SNORM = 0x8F9B;
		public const uint GL_SIGNED_NORMALIZED = 0x8F9C;
		public const uint GL_PRIMITIVE_RESTART = 0x8F9D;
		public const uint GL_PRIMITIVE_RESTART_INDEX = 0x8F9E;
		public const uint GL_COPY_READ_BUFFER = 0x8F36;
		public const uint GL_COPY_WRITE_BUFFER = 0x8F37;
		public const uint GL_UNIFORM_BUFFER = 0x8A11;
		public const uint GL_UNIFORM_BUFFER_BINDING = 0x8A28;
		public const uint GL_UNIFORM_BUFFER_START = 0x8A29;
		public const uint GL_UNIFORM_BUFFER_SIZE = 0x8A2A;
		public const uint GL_MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B;
		public const uint GL_MAX_GEOMETRY_UNIFORM_BLOCKS = 0x8A2C;
		public const uint GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D;
		public const uint GL_MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E;
		public const uint GL_MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F;
		public const uint GL_MAX_UNIFORM_BLOCK_SIZE = 0x8A30;
		public const uint GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31;
		public const uint GL_MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = 0x8A32;
		public const uint GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33;
		public const uint GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34;
		public const uint GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35;
		public const uint GL_ACTIVE_UNIFORM_BLOCKS = 0x8A36;
		public const uint GL_UNIFORM_TYPE = 0x8A37;
		public const uint GL_UNIFORM_SIZE = 0x8A38;
		public const uint GL_UNIFORM_NAME_LENGTH = 0x8A39;
		public const uint GL_UNIFORM_BLOCK_INDEX = 0x8A3A;
		public const uint GL_UNIFORM_OFFSET = 0x8A3B;
		public const uint GL_UNIFORM_ARRAY_STRIDE = 0x8A3C;
		public const uint GL_UNIFORM_MATRIX_STRIDE = 0x8A3D;
		public const uint GL_UNIFORM_IS_ROW_MAJOR = 0x8A3E;
		public const uint GL_UNIFORM_BLOCK_BINDING = 0x8A3F;
		public const uint GL_UNIFORM_BLOCK_DATA_SIZE = 0x8A40;
		public const uint GL_UNIFORM_BLOCK_NAME_LENGTH = 0x8A41;
		public const uint GL_UNIFORM_BLOCK_ACTIVE_UNIFORMS = 0x8A42;
		public const uint GL_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 0x8A43;
		public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 0x8A44;
		public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_GEOMETRY_SHADER = 0x8A45;
		public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 0x8A46;
		public const uint GL_INVALID_INDEX = 0xFFFFFFFF;
		public delegate void PFNGLDRAWARRAYSINSTANCEDPROC( uint mode, int first, int count, int instancecount );
		public delegate void PFNGLDRAWELEMENTSINSTANCEDPROC( uint mode, int count, uint type, void* indices, int instancecount );
		public delegate void PFNGLTEXBUFFERPROC( uint target, uint internalformat, uint buffer );
		public delegate void PFNGLPRIMITIVERESTARTINDEXPROC( uint index );
		public delegate void PFNGLCOPYBUFFERSUBDATAPROC( uint readTarget, uint writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size );
		public delegate void PFNGLGETUNIFORMINDICESPROC( uint program, int uniformCount, char* uniformNames, IntPtr uniformIndices );
		public delegate void PFNGLGETACTIVEUNIFORMSIVPROC( uint program, int uniformCount, IntPtr uniformIndices, uint pname, IntPtr @params );
		public delegate void PFNGLGETACTIVEUNIFORMNAMEPROC( uint program, uint uniformIndex, int bufSize, IntPtr length, char* uniformName );
		public delegate uint PFNGLGETUNIFORMBLOCKINDEXPROC( uint program, char* uniformBlockName );
		public delegate void PFNGLGETACTIVEUNIFORMBLOCKIVPROC( uint program, uint uniformBlockIndex, uint pname, IntPtr @params );
		public delegate void PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC( uint program, uint uniformBlockIndex, int bufSize, IntPtr length, char* uniformBlockName );
		public delegate void PFNGLUNIFORMBLOCKBINDINGPROC( uint program, uint uniformBlockIndex, uint uniformBlockBinding );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLDRAWARRAYSINSTANCEDPROC glDrawArraysInstanced;
		public static PFNGLDRAWELEMENTSINSTANCEDPROC glDrawElementsInstanced;
		public static PFNGLTEXBUFFERPROC glTexBuffer;
		public static PFNGLPRIMITIVERESTARTINDEXPROC glPrimitiveRestartIndex;
		public static PFNGLCOPYBUFFERSUBDATAPROC glCopyBufferSubData;
		public static PFNGLGETUNIFORMINDICESPROC glGetUniformIndices;
		public static PFNGLGETACTIVEUNIFORMSIVPROC glGetActiveUniformsiv;
		public static PFNGLGETACTIVEUNIFORMNAMEPROC glGetActiveUniformName;
		public static PFNGLGETUNIFORMBLOCKINDEXPROC glGetUniformBlockIndex;
		public static PFNGLGETACTIVEUNIFORMBLOCKIVPROC glGetActiveUniformBlockiv;
		public static PFNGLGETACTIVEUNIFORMBLOCKNAMEPROC glGetActiveUniformBlockName;
		public static PFNGLUNIFORMBLOCKBINDINGPROC glUniformBlockBinding;
#endif
#endif // GL_VERSION_3_1
		#endregion

		#region OpenGL 3.2
#if GL_VERSION_3_2
		public const uint GL_CONTEXT_CORE_PROFILE_BIT = 0x00000001;
		public const uint GL_CONTEXT_COMPATIBILITY_PROFILE_BIT = 0x00000002;
		public const uint GL_LINES_ADJACENCY = 0x000A;
		public const uint GL_LINE_STRIP_ADJACENCY = 0x000B;
		public const uint GL_TRIANGLES_ADJACENCY = 0x000C;
		public const uint GL_TRIANGLE_STRIP_ADJACENCY = 0x000D;
		public const uint GL_PROGRAM_POINT_SIZE = 0x8642;
		public const uint GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29;
		public const uint GL_FRAMEBUFFER_ATTACHMENT_LAYERED = 0x8DA7;
		public const uint GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = 0x8DA8;
		public const uint GL_GEOMETRY_SHADER = 0x8DD9;
		public const uint GL_GEOMETRY_VERTICES_OUT = 0x8916;
		public const uint GL_GEOMETRY_INPUT_TYPE = 0x8917;
		public const uint GL_GEOMETRY_OUTPUT_TYPE = 0x8918;
		public const uint GL_MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF;
		public const uint GL_MAX_GEOMETRY_OUTPUT_VERTICES = 0x8DE0;
		public const uint GL_MAX_GEOMETRY_TOTAL_OUTPUT_COMPONENTS = 0x8DE1;
		public const uint GL_MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122;
		public const uint GL_MAX_GEOMETRY_INPUT_COMPONENTS = 0x9123;
		public const uint GL_MAX_GEOMETRY_OUTPUT_COMPONENTS = 0x9124;
		public const uint GL_MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125;
		public const uint GL_CONTEXT_PROFILE_MASK = 0x9126;
		public const uint GL_DEPTH_CLAMP = 0x864F;
		public const uint GL_QUADS_FOLLOW_PROVOKING_VERTEX_CONVENTION = 0x8E4C;
		public const uint GL_FIRST_VERTEX_CONVENTION = 0x8E4D;
		public const uint GL_LAST_VERTEX_CONVENTION = 0x8E4E;
		public const uint GL_PROVOKING_VERTEX = 0x8E4F;
		public const uint GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F;
		public const uint GL_MAX_SERVER_WAIT_TIMEOUT = 0x9111;
		public const uint GL_OBJECT_TYPE = 0x9112;
		public const uint GL_SYNC_CONDITION = 0x9113;
		public const uint GL_SYNC_STATUS = 0x9114;
		public const uint GL_SYNC_FLAGS = 0x9115;
		public const uint GL_SYNC_FENCE = 0x9116;
		public const uint GL_SYNC_GPU_COMMANDS_COMPLETE = 0x9117;
		public const uint GL_UNSIGNALED = 0x9118;
		public const uint GL_SIGNALED = 0x9119;
		public const uint GL_ALREADY_SIGNALED = 0x911A;
		public const uint GL_TIMEOUT_EXPIRED = 0x911B;
		public const uint GL_CONDITION_SATISFIED = 0x911C;
		public const uint GL_WAIT_FAILED = 0x911D;
		public const ulong GL_TIMEOUT_IGNORED = 0xFFFFFFFFFFFFFFFF;
		public const uint GL_SYNC_FLUSH_COMMANDS_BIT = 0x00000001;
		public const uint GL_SAMPLE_POSITION = 0x8E50;
		public const uint GL_SAMPLE_MASK = 0x8E51;
		public const uint GL_SAMPLE_MASK_VALUE = 0x8E52;
		public const uint GL_MAX_SAMPLE_MASK_WORDS = 0x8E59;
		public const uint GL_TEXTURE_2D_MULTISAMPLE = 0x9100;
		public const uint GL_PROXY_TEXTURE_2D_MULTISAMPLE = 0x9101;
		public const uint GL_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102;
		public const uint GL_PROXY_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9103;
		public const uint GL_TEXTURE_BINDING_2D_MULTISAMPLE = 0x9104;
		public const uint GL_TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = 0x9105;
		public const uint GL_TEXTURE_SAMPLES = 0x9106;
		public const uint GL_TEXTURE_FIXED_SAMPLE_LOCATIONS = 0x9107;
		public const uint GL_SAMPLER_2D_MULTISAMPLE = 0x9108;
		public const uint GL_INT_SAMPLER_2D_MULTISAMPLE = 0x9109;
		public const uint GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = 0x910A;
		public const uint GL_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910B;
		public const uint GL_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910C;
		public const uint GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910D;
		public const uint GL_MAX_COLOR_TEXTURE_SAMPLES = 0x910E;
		public const uint GL_MAX_DEPTH_TEXTURE_SAMPLES = 0x910F;
		public const uint GL_MAX_INTEGER_SAMPLES = 0x9110;
		public delegate void PFNGLDRAWELEMENTSBASEVERTEXPROC( uint mode, int count, uint type, void* indices, int basevertex );
		public delegate void PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC( uint mode, uint start, uint end, int count, uint type, void* indices, int basevertex );
		public delegate void PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC( uint mode, int count, uint type, void* indices, int instancecount, int basevertex );
		public delegate void PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC( uint mode, IntPtr count, uint type, void* indices, int drawcount, IntPtr basevertex );
		public delegate void PFNGLPROVOKINGVERTEXPROC( uint mode );
		public delegate IntPtr PFNGLFENCESYNCPROC( uint condition, uint flags );
		public delegate bool PFNGLISSYNCPROC( IntPtr sync );
		public delegate void PFNGLDELETESYNCPROC( IntPtr sync );
		public delegate uint PFNGLCLIENTWAITSYNCPROC( IntPtr sync, uint flags, ulong timeout );
		public delegate void PFNGLWAITSYNCPROC( IntPtr sync, uint flags, ulong timeout );
		public delegate void PFNGLGETINTEGER64VPROC( uint pname, long* data );
		public delegate void PFNGLGETSYNCIVPROC( IntPtr sync, uint pname, int count, IntPtr length, IntPtr values );
		public delegate void PFNGLGETINTEGER64I_VPROC( uint target, uint index, long* data );
		public delegate void PFNGLGETBUFFERPARAMETERI64VPROC( uint target, uint pname, long* @params );
		public delegate void PFNGLFRAMEBUFFERTEXTUREPROC( uint target, uint attachment, uint texture, int level );
		public delegate void PFNGLTEXIMAGE2DMULTISAMPLEPROC( uint target, int samples, uint internalformat, int width, int height, bool fixedsamplelocations );
		public delegate void PFNGLTEXIMAGE3DMULTISAMPLEPROC( uint target, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations );
		public delegate void PFNGLGETMULTISAMPLEFVPROC( uint pname, uint index, float* val );
		public delegate void PFNGLSAMPLEMASKIPROC( uint maskNumber, uint mask );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLDRAWELEMENTSBASEVERTEXPROC glDrawElementsBaseVertex;
		public static PFNGLDRAWRANGEELEMENTSBASEVERTEXPROC glDrawRangeElementsBaseVertex;
		public static PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXPROC glDrawElementsInstancedBaseVertex;
		public static PFNGLMULTIDRAWELEMENTSBASEVERTEXPROC glMultiDrawElementsBaseVertex;
		public static PFNGLPROVOKINGVERTEXPROC glProvokingVertex;
		public static PFNGLFENCESYNCPROC glFenceSync;
		public static PFNGLISSYNCPROC glIsSync;
		public static PFNGLDELETESYNCPROC glDeleteSync;
		public static PFNGLCLIENTWAITSYNCPROC glClientWaitSync;
		public static PFNGLWAITSYNCPROC glWaitSync;
		public static PFNGLGETINTEGER64VPROC glGetInteger64v;
		public static PFNGLGETSYNCIVPROC glGetSynciv;
		public static PFNGLGETINTEGER64I_VPROC glGetInteger64i_v;
		public static PFNGLGETBUFFERPARAMETERI64VPROC glGetBufferParameteri64v;
		public static PFNGLFRAMEBUFFERTEXTUREPROC glFramebufferTexture;
		public static PFNGLTEXIMAGE2DMULTISAMPLEPROC glTexImage2DMultisample;
		public static PFNGLTEXIMAGE3DMULTISAMPLEPROC glTexImage3DMultisample;
		public static PFNGLGETMULTISAMPLEFVPROC glGetMultisamplefv;
		public static PFNGLSAMPLEMASKIPROC glSampleMaski;
#endif
#endif // GL_VERSION_3_2
		#endregion

		#region OpenGL 3.3
#if GL_VERSION_3_3
		public const uint GL_VERTEX_ATTRIB_ARRAY_DIVISOR = 0x88FE;
		public const uint GL_SRC1_COLOR = 0x88F9;
		public const uint GL_ONE_MINUS_SRC1_COLOR = 0x88FA;
		public const uint GL_ONE_MINUS_SRC1_ALPHA = 0x88FB;
		public const uint GL_MAX_DUAL_SOURCE_DRAW_BUFFERS = 0x88FC;
		public const uint GL_ANY_SAMPLES_PASSED = 0x8C2F;
		public const uint GL_SAMPLER_BINDING = 0x8919;
		public const uint GL_RGB10_A2UI = 0x906F;
		public const uint GL_TEXTURE_SWIZZLE_R = 0x8E42;
		public const uint GL_TEXTURE_SWIZZLE_G = 0x8E43;
		public const uint GL_TEXTURE_SWIZZLE_B = 0x8E44;
		public const uint GL_TEXTURE_SWIZZLE_A = 0x8E45;
		public const uint GL_TEXTURE_SWIZZLE_RGBA = 0x8E46;
		public const uint GL_TIME_ELAPSED = 0x88BF;
		public const uint GL_TIMESTAMP = 0x8E28;
		public const uint GL_INT_2_10_10_10_REV = 0x8D9F;
		public delegate void PFNGLBINDFRAGDATALOCATIONINDEXEDPROC( uint program, uint colorNumber, uint index, char* name );
		public delegate int PFNGLGETFRAGDATAINDEXPROC( uint program, char* name );
		public delegate void PFNGLGENSAMPLERSPROC( int count, IntPtr samplers );
		public delegate void PFNGLDELETESAMPLERSPROC( int count, IntPtr samplers );
		public delegate bool PFNGLISSAMPLERPROC( uint sampler );
		public delegate void PFNGLBINDSAMPLERPROC( uint unit, uint sampler );
		public delegate void PFNGLSAMPLERPARAMETERIPROC( uint sampler, uint pname, int param );
		public delegate void PFNGLSAMPLERPARAMETERIVPROC( uint sampler, uint pname, IntPtr param );
		public delegate void PFNGLSAMPLERPARAMETERFPROC( uint sampler, uint pname, float param );
		public delegate void PFNGLSAMPLERPARAMETERFVPROC( uint sampler, uint pname, float* param );
		public delegate void PFNGLSAMPLERPARAMETERIIVPROC( uint sampler, uint pname, IntPtr param );
		public delegate void PFNGLSAMPLERPARAMETERIUIVPROC( uint sampler, uint pname, IntPtr param );
		public delegate void PFNGLGETSAMPLERPARAMETERIVPROC( uint sampler, uint pname, IntPtr @params );
		public delegate void PFNGLGETSAMPLERPARAMETERIIVPROC( uint sampler, uint pname, IntPtr @params );
		public delegate void PFNGLGETSAMPLERPARAMETERFVPROC( uint sampler, uint pname, float* @params );
		public delegate void PFNGLGETSAMPLERPARAMETERIUIVPROC( uint sampler, uint pname, IntPtr @params );
		public delegate void PFNGLQUERYCOUNTERPROC( uint id, uint target );
		public delegate void PFNGLGETQUERYOBJECTI64VPROC( uint id, uint pname, long* @params );
		public delegate void PFNGLGETQUERYOBJECTUI64VPROC( uint id, uint pname, ulong* @params );
		public delegate void PFNGLVERTEXATTRIBDIVISORPROC( uint index, uint divisor );
		public delegate void PFNGLVERTEXATTRIBP1UIPROC( uint index, uint type, bool normalized, uint value );
		public delegate void PFNGLVERTEXATTRIBP1UIVPROC( uint index, uint type, bool normalized, IntPtr value );
		public delegate void PFNGLVERTEXATTRIBP2UIPROC( uint index, uint type, bool normalized, uint value );
		public delegate void PFNGLVERTEXATTRIBP2UIVPROC( uint index, uint type, bool normalized, IntPtr value );
		public delegate void PFNGLVERTEXATTRIBP3UIPROC( uint index, uint type, bool normalized, uint value );
		public delegate void PFNGLVERTEXATTRIBP3UIVPROC( uint index, uint type, bool normalized, IntPtr value );
		public delegate void PFNGLVERTEXATTRIBP4UIPROC( uint index, uint type, bool normalized, uint value );
		public delegate void PFNGLVERTEXATTRIBP4UIVPROC( uint index, uint type, bool normalized, IntPtr value );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLBINDFRAGDATALOCATIONINDEXEDPROC glBindFragDataLocationIndexed;
		public static PFNGLGETFRAGDATAINDEXPROC glGetFragDataIndex;
		public static PFNGLGENSAMPLERSPROC glGenSamplers;
		public static PFNGLDELETESAMPLERSPROC glDeleteSamplers;
		public static PFNGLISSAMPLERPROC glIsSampler;
		public static PFNGLBINDSAMPLERPROC glBindSampler;
		public static PFNGLSAMPLERPARAMETERIPROC glSamplerParameteri;
		public static PFNGLSAMPLERPARAMETERIVPROC glSamplerParameteriv;
		public static PFNGLSAMPLERPARAMETERFPROC glSamplerParameterf;
		public static PFNGLSAMPLERPARAMETERFVPROC glSamplerParameterfv;
		public static PFNGLSAMPLERPARAMETERIIVPROC glSamplerParameterIiv;
		public static PFNGLSAMPLERPARAMETERIUIVPROC glSamplerParameterIuiv;
		public static PFNGLGETSAMPLERPARAMETERIVPROC glGetSamplerParameteriv;
		public static PFNGLGETSAMPLERPARAMETERIIVPROC glGetSamplerParameterIiv;
		public static PFNGLGETSAMPLERPARAMETERFVPROC glGetSamplerParameterfv;
		public static PFNGLGETSAMPLERPARAMETERIUIVPROC glGetSamplerParameterIuiv;
		public static PFNGLQUERYCOUNTERPROC glQueryCounter;
		public static PFNGLGETQUERYOBJECTI64VPROC glGetQueryObjecti64v;
		public static PFNGLGETQUERYOBJECTUI64VPROC glGetQueryObjectui64v;
		public static PFNGLVERTEXATTRIBDIVISORPROC glVertexAttribDivisor;
		public static PFNGLVERTEXATTRIBP1UIPROC glVertexAttribP1ui;
		public static PFNGLVERTEXATTRIBP1UIVPROC glVertexAttribP1uiv;
		public static PFNGLVERTEXATTRIBP2UIPROC glVertexAttribP2ui;
		public static PFNGLVERTEXATTRIBP2UIVPROC glVertexAttribP2uiv;
		public static PFNGLVERTEXATTRIBP3UIPROC glVertexAttribP3ui;
		public static PFNGLVERTEXATTRIBP3UIVPROC glVertexAttribP3uiv;
		public static PFNGLVERTEXATTRIBP4UIPROC glVertexAttribP4ui;
		public static PFNGLVERTEXATTRIBP4UIVPROC glVertexAttribP4uiv;
#endif
#endif // GL_VERSION_3_3
		#endregion

		#region OpenGL 4.0
#if GL_VERSION_4_0
		public const uint GL_SAMPLE_SHADING = 0x8C36;
		public const uint GL_MIN_SAMPLE_SHADING_VALUE = 0x8C37;
		public const uint GL_MIN_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5E;
		public const uint GL_MAX_PROGRAM_TEXTURE_GATHER_OFFSET = 0x8E5F;
		public const uint GL_TEXTURE_CUBE_MAP_ARRAY = 0x9009;
		public const uint GL_TEXTURE_BINDING_CUBE_MAP_ARRAY = 0x900A;
		public const uint GL_PROXY_TEXTURE_CUBE_MAP_ARRAY = 0x900B;
		public const uint GL_SAMPLER_CUBE_MAP_ARRAY = 0x900C;
		public const uint GL_SAMPLER_CUBE_MAP_ARRAY_SHADOW = 0x900D;
		public const uint GL_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900E;
		public const uint GL_UNSIGNED_INT_SAMPLER_CUBE_MAP_ARRAY = 0x900F;
		public const uint GL_DRAW_INDIRECT_BUFFER = 0x8F3F;
		public const uint GL_DRAW_INDIRECT_BUFFER_BINDING = 0x8F43;
		public const uint GL_GEOMETRY_SHADER_INVOCATIONS = 0x887F;
		public const uint GL_MAX_GEOMETRY_SHADER_INVOCATIONS = 0x8E5A;
		public const uint GL_MIN_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5B;
		public const uint GL_MAX_FRAGMENT_INTERPOLATION_OFFSET = 0x8E5C;
		public const uint GL_FRAGMENT_INTERPOLATION_OFFSET_BITS = 0x8E5D;
		public const uint GL_MAX_VERTEX_STREAMS = 0x8E71;
		public const uint GL_DOUBLE_VEC2 = 0x8FFC;
		public const uint GL_DOUBLE_VEC3 = 0x8FFD;
		public const uint GL_DOUBLE_VEC4 = 0x8FFE;
		public const uint GL_DOUBLE_MAT2 = 0x8F46;
		public const uint GL_DOUBLE_MAT3 = 0x8F47;
		public const uint GL_DOUBLE_MAT4 = 0x8F48;
		public const uint GL_DOUBLE_MAT2x3 = 0x8F49;
		public const uint GL_DOUBLE_MAT2x4 = 0x8F4A;
		public const uint GL_DOUBLE_MAT3x2 = 0x8F4B;
		public const uint GL_DOUBLE_MAT3x4 = 0x8F4C;
		public const uint GL_DOUBLE_MAT4x2 = 0x8F4D;
		public const uint GL_DOUBLE_MAT4x3 = 0x8F4E;
		public const uint GL_ACTIVE_SUBROUTINES = 0x8DE5;
		public const uint GL_ACTIVE_SUBROUTINE_UNIFORMS = 0x8DE6;
		public const uint GL_ACTIVE_SUBROUTINE_UNIFORM_LOCATIONS = 0x8E47;
		public const uint GL_ACTIVE_SUBROUTINE_MAX_LENGTH = 0x8E48;
		public const uint GL_ACTIVE_SUBROUTINE_UNIFORM_MAX_LENGTH = 0x8E49;
		public const uint GL_MAX_SUBROUTINES = 0x8DE7;
		public const uint GL_MAX_SUBROUTINE_UNIFORM_LOCATIONS = 0x8DE8;
		public const uint GL_NUM_COMPATIBLE_SUBROUTINES = 0x8E4A;
		public const uint GL_COMPATIBLE_SUBROUTINES = 0x8E4B;
		public const uint GL_PATCHES = 0x000E;
		public const uint GL_PATCH_VERTICES = 0x8E72;
		public const uint GL_PATCH_DEFAULT_INNER_LEVEL = 0x8E73;
		public const uint GL_PATCH_DEFAULT_OUTER_LEVEL = 0x8E74;
		public const uint GL_TESS_CONTROL_OUTPUT_VERTICES = 0x8E75;
		public const uint GL_TESS_GEN_MODE = 0x8E76;
		public const uint GL_TESS_GEN_SPACING = 0x8E77;
		public const uint GL_TESS_GEN_VERTEX_ORDER = 0x8E78;
		public const uint GL_TESS_GEN_POINT_MODE = 0x8E79;
		public const uint GL_ISOLINES = 0x8E7A;
		public const uint GL_FRACTIONAL_ODD = 0x8E7B;
		public const uint GL_FRACTIONAL_EVEN = 0x8E7C;
		public const uint GL_MAX_PATCH_VERTICES = 0x8E7D;
		public const uint GL_MAX_TESS_GEN_LEVEL = 0x8E7E;
		public const uint GL_MAX_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E7F;
		public const uint GL_MAX_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E80;
		public const uint GL_MAX_TESS_CONTROL_TEXTURE_IMAGE_UNITS = 0x8E81;
		public const uint GL_MAX_TESS_EVALUATION_TEXTURE_IMAGE_UNITS = 0x8E82;
		public const uint GL_MAX_TESS_CONTROL_OUTPUT_COMPONENTS = 0x8E83;
		public const uint GL_MAX_TESS_PATCH_COMPONENTS = 0x8E84;
		public const uint GL_MAX_TESS_CONTROL_TOTAL_OUTPUT_COMPONENTS = 0x8E85;
		public const uint GL_MAX_TESS_EVALUATION_OUTPUT_COMPONENTS = 0x8E86;
		public const uint GL_MAX_TESS_CONTROL_UNIFORM_BLOCKS = 0x8E89;
		public const uint GL_MAX_TESS_EVALUATION_UNIFORM_BLOCKS = 0x8E8A;
		public const uint GL_MAX_TESS_CONTROL_INPUT_COMPONENTS = 0x886C;
		public const uint GL_MAX_TESS_EVALUATION_INPUT_COMPONENTS = 0x886D;
		public const uint GL_MAX_COMBINED_TESS_CONTROL_UNIFORM_COMPONENTS = 0x8E1E;
		public const uint GL_MAX_COMBINED_TESS_EVALUATION_UNIFORM_COMPONENTS = 0x8E1F;
		public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_CONTROL_SHADER = 0x84F0;
		public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x84F1;
		public const uint GL_TESS_EVALUATION_SHADER = 0x8E87;
		public const uint GL_TESS_CONTROL_SHADER = 0x8E88;
		public const uint GL_TRANSFORM_FEEDBACK = 0x8E22;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_PAUSED = 0x8E23;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_ACTIVE = 0x8E24;
		public const uint GL_TRANSFORM_FEEDBACK_BINDING = 0x8E25;
		public const uint GL_MAX_TRANSFORM_FEEDBACK_BUFFERS = 0x8E70;
		public delegate void PFNGLMINSAMPLESHADINGPROC( float value );
		public delegate void PFNGLBLENDEQUATIONIPROC( uint buf, uint mode );
		public delegate void PFNGLBLENDEQUATIONSEPARATEIPROC( uint buf, uint modeRGB, uint modeAlpha );
		public delegate void PFNGLBLENDFUNCIPROC( uint buf, uint src, uint dst );
		public delegate void PFNGLBLENDFUNCSEPARATEIPROC( uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha );
		public delegate void PFNGLDRAWARRAYSINDIRECTPROC( uint mode, void* indirect );
		public delegate void PFNGLDRAWELEMENTSINDIRECTPROC( uint mode, uint type, void* indirect );
		public delegate void PFNGLUNIFORM1DPROC( int location, double x );
		public delegate void PFNGLUNIFORM2DPROC( int location, double x, double y );
		public delegate void PFNGLUNIFORM3DPROC( int location, double x, double y, double z );
		public delegate void PFNGLUNIFORM4DPROC( int location, double x, double y, double z, double w );
		public delegate void PFNGLUNIFORM1DVPROC( int location, int count, double* value );
		public delegate void PFNGLUNIFORM2DVPROC( int location, int count, double* value );
		public delegate void PFNGLUNIFORM3DVPROC( int location, int count, double* value );
		public delegate void PFNGLUNIFORM4DVPROC( int location, int count, double* value );
		public delegate void PFNGLUNIFORMMATRIX2DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX3DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX4DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX2X3DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX2X4DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX3X2DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX3X4DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX4X2DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLUNIFORMMATRIX4X3DVPROC( int location, int count, bool transpose, double* value );
		public delegate void PFNGLGETUNIFORMDVPROC( uint program, int location, double* @params );
		public delegate int PFNGLGETSUBROUTINEUNIFORMLOCATIONPROC( uint program, uint shadertype, char* name );
		public delegate uint PFNGLGETSUBROUTINEINDEXPROC( uint program, uint shadertype, char* name );
		public delegate void PFNGLGETACTIVESUBROUTINEUNIFORMIVPROC( uint program, uint shadertype, uint index, uint pname, IntPtr values );
		public delegate void PFNGLGETACTIVESUBROUTINEUNIFORMNAMEPROC( uint program, uint shadertype, uint index, int bufSize, IntPtr length, char* name );
		public delegate void PFNGLGETACTIVESUBROUTINENAMEPROC( uint program, uint shadertype, uint index, int bufSize, IntPtr length, char* name );
		public delegate void PFNGLUNIFORMSUBROUTINESUIVPROC( uint shadertype, int count, IntPtr indices );
		public delegate void PFNGLGETUNIFORMSUBROUTINEUIVPROC( uint shadertype, int location, IntPtr @params );
		public delegate void PFNGLGETPROGRAMSTAGEIVPROC( uint program, uint shadertype, uint pname, IntPtr values );
		public delegate void PFNGLPATCHPARAMETERIPROC( uint pname, int value );
		public delegate void PFNGLPATCHPARAMETERFVPROC( uint pname, float* values );
		public delegate void PFNGLBINDTRANSFORMFEEDBACKPROC( uint target, uint id );
		public delegate void PFNGLDELETETRANSFORMFEEDBACKSPROC( int n, IntPtr ids );
		public delegate void PFNGLGENTRANSFORMFEEDBACKSPROC( int n, IntPtr ids );
		public delegate bool PFNGLISTRANSFORMFEEDBACKPROC( uint id );
		public delegate void PFNGLPAUSETRANSFORMFEEDBACKPROC();
		public delegate void PFNGLRESUMETRANSFORMFEEDBACKPROC();
		public delegate void PFNGLDRAWTRANSFORMFEEDBACKPROC( uint mode, uint id );
		public delegate void PFNGLDRAWTRANSFORMFEEDBACKSTREAMPROC( uint mode, uint id, uint stream );
		public delegate void PFNGLBEGINQUERYINDEXEDPROC( uint target, uint index, uint id );
		public delegate void PFNGLENDQUERYINDEXEDPROC( uint target, uint index );
		public delegate void PFNGLGETQUERYINDEXEDIVPROC( uint target, uint index, uint pname, IntPtr @params );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLMINSAMPLESHADINGPROC glMinSampleShading;
		public static PFNGLBLENDEQUATIONIPROC glBlendEquationi;
		public static PFNGLBLENDEQUATIONSEPARATEIPROC glBlendEquationSeparatei;
		public static PFNGLBLENDFUNCIPROC glBlendFunci;
		public static PFNGLBLENDFUNCSEPARATEIPROC glBlendFuncSeparatei;
		public static PFNGLDRAWARRAYSINDIRECTPROC glDrawArraysIndirect;
		public static PFNGLDRAWELEMENTSINDIRECTPROC glDrawElementsIndirect;
		public static PFNGLUNIFORM1DPROC glUniform1d;
		public static PFNGLUNIFORM2DPROC glUniform2d;
		public static PFNGLUNIFORM3DPROC glUniform3d;
		public static PFNGLUNIFORM4DPROC glUniform4d;
		public static PFNGLUNIFORM1DVPROC glUniform1dv;
		public static PFNGLUNIFORM2DVPROC glUniform2dv;
		public static PFNGLUNIFORM3DVPROC glUniform3dv;
		public static PFNGLUNIFORM4DVPROC glUniform4dv;
		public static PFNGLUNIFORMMATRIX2DVPROC glUniformMatrix2dv;
		public static PFNGLUNIFORMMATRIX3DVPROC glUniformMatrix3dv;
		public static PFNGLUNIFORMMATRIX4DVPROC glUniformMatrix4dv;
		public static PFNGLUNIFORMMATRIX2X3DVPROC glUniformMatrix2x3dv;
		public static PFNGLUNIFORMMATRIX2X4DVPROC glUniformMatrix2x4dv;
		public static PFNGLUNIFORMMATRIX3X2DVPROC glUniformMatrix3x2dv;
		public static PFNGLUNIFORMMATRIX3X4DVPROC glUniformMatrix3x4dv;
		public static PFNGLUNIFORMMATRIX4X2DVPROC glUniformMatrix4x2dv;
		public static PFNGLUNIFORMMATRIX4X3DVPROC glUniformMatrix4x3dv;
		public static PFNGLGETUNIFORMDVPROC glGetUniformdv;
		public static PFNGLGETSUBROUTINEUNIFORMLOCATIONPROC glGetSubroutineUniformLocation;
		public static PFNGLGETSUBROUTINEINDEXPROC glGetSubroutineIndex;
		public static PFNGLGETACTIVESUBROUTINEUNIFORMIVPROC glGetActiveSubroutineUniformiv;
		public static PFNGLGETACTIVESUBROUTINEUNIFORMNAMEPROC glGetActiveSubroutineUniformName;
		public static PFNGLGETACTIVESUBROUTINENAMEPROC glGetActiveSubroutineName;
		public static PFNGLUNIFORMSUBROUTINESUIVPROC glUniformSubroutinesuiv;
		public static PFNGLGETUNIFORMSUBROUTINEUIVPROC glGetUniformSubroutineuiv;
		public static PFNGLGETPROGRAMSTAGEIVPROC glGetProgramStageiv;
		public static PFNGLPATCHPARAMETERIPROC glPatchParameteri;
		public static PFNGLPATCHPARAMETERFVPROC glPatchParameterfv;
		public static PFNGLBINDTRANSFORMFEEDBACKPROC glBindTransformFeedback;
		public static PFNGLDELETETRANSFORMFEEDBACKSPROC glDeleteTransformFeedbacks;
		public static PFNGLGENTRANSFORMFEEDBACKSPROC glGenTransformFeedbacks;
		public static PFNGLISTRANSFORMFEEDBACKPROC glIsTransformFeedback;
		public static PFNGLPAUSETRANSFORMFEEDBACKPROC glPauseTransformFeedback;
		public static PFNGLRESUMETRANSFORMFEEDBACKPROC glResumeTransformFeedback;
		public static PFNGLDRAWTRANSFORMFEEDBACKPROC glDrawTransformFeedback;
		public static PFNGLDRAWTRANSFORMFEEDBACKSTREAMPROC glDrawTransformFeedbackStream;
		public static PFNGLBEGINQUERYINDEXEDPROC glBeginQueryIndexed;
		public static PFNGLENDQUERYINDEXEDPROC glEndQueryIndexed;
		public static PFNGLGETQUERYINDEXEDIVPROC glGetQueryIndexediv;
#endif
#endif // GL_VERSION_4_0
		#endregion

		#region OpenGL 4.1
#if GL_VERSION_4_1
		public const uint GL_FIXED = 0x140C;
		public const uint GL_IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A;
		public const uint GL_IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B;
		public const uint GL_LOW_FLOAT = 0x8DF0;
		public const uint GL_MEDIUM_FLOAT = 0x8DF1;
		public const uint GL_HIGH_FLOAT = 0x8DF2;
		public const uint GL_LOW_INT = 0x8DF3;
		public const uint GL_MEDIUM_INT = 0x8DF4;
		public const uint GL_HIGH_INT = 0x8DF5;
		public const uint GL_SHADER_COMPILER = 0x8DFA;
		public const uint GL_SHADER_BINARY_FORMATS = 0x8DF8;
		public const uint GL_NUM_SHADER_BINARY_FORMATS = 0x8DF9;
		public const uint GL_MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB;
		public const uint GL_MAX_VARYING_VECTORS = 0x8DFC;
		public const uint GL_MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD;
		public const uint GL_RGB565 = 0x8D62;
		public const uint GL_PROGRAM_BINARY_RETRIEVABLE_HINT = 0x8257;
		public const uint GL_PROGRAM_BINARY_LENGTH = 0x8741;
		public const uint GL_NUM_PROGRAM_BINARY_FORMATS = 0x87FE;
		public const uint GL_PROGRAM_BINARY_FORMATS = 0x87FF;
		public const uint GL_VERTEX_SHADER_BIT = 0x00000001;
		public const uint GL_FRAGMENT_SHADER_BIT = 0x00000002;
		public const uint GL_GEOMETRY_SHADER_BIT = 0x00000004;
		public const uint GL_TESS_CONTROL_SHADER_BIT = 0x00000008;
		public const uint GL_TESS_EVALUATION_SHADER_BIT = 0x00000010;
		public const uint GL_ALL_SHADER_BITS = 0xFFFFFFFF;
		public const uint GL_PROGRAM_SEPARABLE = 0x8258;
		public const uint GL_ACTIVE_PROGRAM = 0x8259;
		public const uint GL_PROGRAM_PIPELINE_BINDING = 0x825A;
		public const uint GL_MAX_VIEWPORTS = 0x825B;
		public const uint GL_VIEWPORT_SUBPIXEL_BITS = 0x825C;
		public const uint GL_VIEWPORT_BOUNDS_RANGE = 0x825D;
		public const uint GL_LAYER_PROVOKING_VERTEX = 0x825E;
		public const uint GL_VIEWPORT_INDEX_PROVOKING_VERTEX = 0x825F;
		public const uint GL_UNDEFINED_VERTEX = 0x8260;
		public delegate void PFNGLRELEASESHADERCOMPILERPROC();
		public delegate void PFNGLSHADERBINARYPROC( int count, IntPtr shaders, uint binaryformat, void* binary, int length );
		public delegate void PFNGLGETSHADERPRECISIONFORMATPROC( uint shadertype, uint precisiontype, IntPtr range, IntPtr precision );
		public delegate void PFNGLDEPTHRANGEFPROC( float n, float f );
		public delegate void PFNGLCLEARDEPTHFPROC( float d );
		public delegate void PFNGLGETPROGRAMBINARYPROC( uint program, int bufSize, IntPtr length, IntPtr binaryFormat, void* binary );
		public delegate void PFNGLPROGRAMBINARYPROC( uint program, uint binaryFormat, void* binary, int length );
		public delegate void PFNGLPROGRAMPARAMETERIPROC( uint program, uint pname, int value );
		public delegate void PFNGLUSEPROGRAMSTAGESPROC( uint pipeline, uint stages, uint program );
		public delegate void PFNGLACTIVESHADERPROGRAMPROC( uint pipeline, uint program );
		public delegate uint PFNGLCREATESHADERPROGRAMVPROC( uint type, int count, char* strings );
		public delegate void PFNGLBINDPROGRAMPIPELINEPROC( uint pipeline );
		public delegate void PFNGLDELETEPROGRAMPIPELINESPROC( int n, IntPtr pipelines );
		public delegate void PFNGLGENPROGRAMPIPELINESPROC( int n, IntPtr pipelines );
		public delegate bool PFNGLISPROGRAMPIPELINEPROC( uint pipeline );
		public delegate void PFNGLGETPROGRAMPIPELINEIVPROC( uint pipeline, uint pname, IntPtr @params );
		public delegate void PFNGLPROGRAMUNIFORM1IPROC( uint program, int location, int v0 );
		public delegate void PFNGLPROGRAMUNIFORM1IVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORM1FPROC( uint program, int location, float v0 );
		public delegate void PFNGLPROGRAMUNIFORM1FVPROC( uint program, int location, int count, float* value );
		public delegate void PFNGLPROGRAMUNIFORM1DPROC( uint program, int location, double v0 );
		public delegate void PFNGLPROGRAMUNIFORM1DVPROC( uint program, int location, int count, double* value );
		public delegate void PFNGLPROGRAMUNIFORM1UIPROC( uint program, int location, uint v0 );
		public delegate void PFNGLPROGRAMUNIFORM1UIVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORM2IPROC( uint program, int location, int v0, int v1 );
		public delegate void PFNGLPROGRAMUNIFORM2IVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORM2FPROC( uint program, int location, float v0, float v1 );
		public delegate void PFNGLPROGRAMUNIFORM2FVPROC( uint program, int location, int count, float* value );
		public delegate void PFNGLPROGRAMUNIFORM2DPROC( uint program, int location, double v0, double v1 );
		public delegate void PFNGLPROGRAMUNIFORM2DVPROC( uint program, int location, int count, double* value );
		public delegate void PFNGLPROGRAMUNIFORM2UIPROC( uint program, int location, uint v0, uint v1 );
		public delegate void PFNGLPROGRAMUNIFORM2UIVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORM3IPROC( uint program, int location, int v0, int v1, int v2 );
		public delegate void PFNGLPROGRAMUNIFORM3IVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORM3FPROC( uint program, int location, float v0, float v1, float v2 );
		public delegate void PFNGLPROGRAMUNIFORM3FVPROC( uint program, int location, int count, float* value );
		public delegate void PFNGLPROGRAMUNIFORM3DPROC( uint program, int location, double v0, double v1, double v2 );
		public delegate void PFNGLPROGRAMUNIFORM3DVPROC( uint program, int location, int count, double* value );
		public delegate void PFNGLPROGRAMUNIFORM3UIPROC( uint program, int location, uint v0, uint v1, uint v2 );
		public delegate void PFNGLPROGRAMUNIFORM3UIVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORM4IPROC( uint program, int location, int v0, int v1, int v2, int v3 );
		public delegate void PFNGLPROGRAMUNIFORM4IVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORM4FPROC( uint program, int location, float v0, float v1, float v2, float v3 );
		public delegate void PFNGLPROGRAMUNIFORM4FVPROC( uint program, int location, int count, float* value );
		public delegate void PFNGLPROGRAMUNIFORM4DPROC( uint program, int location, double v0, double v1, double v2, double v3 );
		public delegate void PFNGLPROGRAMUNIFORM4DVPROC( uint program, int location, int count, double* value );
		public delegate void PFNGLPROGRAMUNIFORM4UIPROC( uint program, int location, uint v0, uint v1, uint v2, uint v3 );
		public delegate void PFNGLPROGRAMUNIFORM4UIVPROC( uint program, int location, int count, IntPtr value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX2FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX3FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX4FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX2DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX3DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX4DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX2X3FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX3X2FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX2X4FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX4X2FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX3X4FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX4X3FVPROC( uint program, int location, int count, bool transpose, float* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX2X3DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX3X2DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX2X4DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX4X2DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX3X4DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLPROGRAMUNIFORMMATRIX4X3DVPROC( uint program, int location, int count, bool transpose, double* value );
		public delegate void PFNGLVALIDATEPROGRAMPIPELINEPROC( uint pipeline );
		public delegate void PFNGLGETPROGRAMPIPELINEINFOLOGPROC( uint pipeline, int bufSize, IntPtr length, char* infoLog );
		public delegate void PFNGLVERTEXATTRIBL1DPROC( uint index, double x );
		public delegate void PFNGLVERTEXATTRIBL2DPROC( uint index, double x, double y );
		public delegate void PFNGLVERTEXATTRIBL3DPROC( uint index, double x, double y, double z );
		public delegate void PFNGLVERTEXATTRIBL4DPROC( uint index, double x, double y, double z, double w );
		public delegate void PFNGLVERTEXATTRIBL1DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIBL2DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIBL3DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIBL4DVPROC( uint index, double* v );
		public delegate void PFNGLVERTEXATTRIBLPOINTERPROC( uint index, int size, uint type, int stride, void* pointer );
		public delegate void PFNGLGETVERTEXATTRIBLDVPROC( uint index, uint pname, double* @params );
		public delegate void PFNGLVIEWPORTARRAYVPROC( uint first, int count, float* v );
		public delegate void PFNGLVIEWPORTINDEXEDFPROC( uint index, float x, float y, float w, float h );
		public delegate void PFNGLVIEWPORTINDEXEDFVPROC( uint index, float* v );
		public delegate void PFNGLSCISSORARRAYVPROC( uint first, int count, IntPtr v );
		public delegate void PFNGLSCISSORINDEXEDPROC( uint index, int left, int bottom, int width, int height );
		public delegate void PFNGLSCISSORINDEXEDVPROC( uint index, IntPtr v );
		public delegate void PFNGLDEPTHRANGEARRAYVPROC( uint first, int count, double* v );
		public delegate void PFNGLDEPTHRANGEINDEXEDPROC( uint index, double n, double f );
		public delegate void PFNGLGETFLOATI_VPROC( uint target, uint index, float* data );
		public delegate void PFNGLGETDOUBLEI_VPROC( uint target, uint index, double* data );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLRELEASESHADERCOMPILERPROC glReleaseShaderCompiler;
		public static PFNGLSHADERBINARYPROC glShaderBinary;
		public static PFNGLGETSHADERPRECISIONFORMATPROC glGetShaderPrecisionFormat;
		public static PFNGLDEPTHRANGEFPROC glDepthRangef;
		public static PFNGLCLEARDEPTHFPROC glClearDepthf;
		public static PFNGLGETPROGRAMBINARYPROC glGetProgramBinary;
		public static PFNGLPROGRAMBINARYPROC glProgramBinary;
		public static PFNGLPROGRAMPARAMETERIPROC glProgramParameteri;
		public static PFNGLUSEPROGRAMSTAGESPROC glUseProgramStages;
		public static PFNGLACTIVESHADERPROGRAMPROC glActiveShaderProgram;
		public static PFNGLCREATESHADERPROGRAMVPROC glCreateShaderProgramv;
		public static PFNGLBINDPROGRAMPIPELINEPROC glBindProgramPipeline;
		public static PFNGLDELETEPROGRAMPIPELINESPROC glDeleteProgramPipelines;
		public static PFNGLGENPROGRAMPIPELINESPROC glGenProgramPipelines;
		public static PFNGLISPROGRAMPIPELINEPROC glIsProgramPipeline;
		public static PFNGLGETPROGRAMPIPELINEIVPROC glGetProgramPipelineiv;
		public static PFNGLPROGRAMUNIFORM1IPROC glProgramUniform1i;
		public static PFNGLPROGRAMUNIFORM1IVPROC glProgramUniform1iv;
		public static PFNGLPROGRAMUNIFORM1FPROC glProgramUniform1f;
		public static PFNGLPROGRAMUNIFORM1FVPROC glProgramUniform1fv;
		public static PFNGLPROGRAMUNIFORM1DPROC glProgramUniform1d;
		public static PFNGLPROGRAMUNIFORM1DVPROC glProgramUniform1dv;
		public static PFNGLPROGRAMUNIFORM1UIPROC glProgramUniform1ui;
		public static PFNGLPROGRAMUNIFORM1UIVPROC glProgramUniform1uiv;
		public static PFNGLPROGRAMUNIFORM2IPROC glProgramUniform2i;
		public static PFNGLPROGRAMUNIFORM2IVPROC glProgramUniform2iv;
		public static PFNGLPROGRAMUNIFORM2FPROC glProgramUniform2f;
		public static PFNGLPROGRAMUNIFORM2FVPROC glProgramUniform2fv;
		public static PFNGLPROGRAMUNIFORM2DPROC glProgramUniform2d;
		public static PFNGLPROGRAMUNIFORM2DVPROC glProgramUniform2dv;
		public static PFNGLPROGRAMUNIFORM2UIPROC glProgramUniform2ui;
		public static PFNGLPROGRAMUNIFORM2UIVPROC glProgramUniform2uiv;
		public static PFNGLPROGRAMUNIFORM3IPROC glProgramUniform3i;
		public static PFNGLPROGRAMUNIFORM3IVPROC glProgramUniform3iv;
		public static PFNGLPROGRAMUNIFORM3FPROC glProgramUniform3f;
		public static PFNGLPROGRAMUNIFORM3FVPROC glProgramUniform3fv;
		public static PFNGLPROGRAMUNIFORM3DPROC glProgramUniform3d;
		public static PFNGLPROGRAMUNIFORM3DVPROC glProgramUniform3dv;
		public static PFNGLPROGRAMUNIFORM3UIPROC glProgramUniform3ui;
		public static PFNGLPROGRAMUNIFORM3UIVPROC glProgramUniform3uiv;
		public static PFNGLPROGRAMUNIFORM4IPROC glProgramUniform4i;
		public static PFNGLPROGRAMUNIFORM4IVPROC glProgramUniform4iv;
		public static PFNGLPROGRAMUNIFORM4FPROC glProgramUniform4f;
		public static PFNGLPROGRAMUNIFORM4FVPROC glProgramUniform4fv;
		public static PFNGLPROGRAMUNIFORM4DPROC glProgramUniform4d;
		public static PFNGLPROGRAMUNIFORM4DVPROC glProgramUniform4dv;
		public static PFNGLPROGRAMUNIFORM4UIPROC glProgramUniform4ui;
		public static PFNGLPROGRAMUNIFORM4UIVPROC glProgramUniform4uiv;
		public static PFNGLPROGRAMUNIFORMMATRIX2FVPROC glProgramUniformMatrix2fv;
		public static PFNGLPROGRAMUNIFORMMATRIX3FVPROC glProgramUniformMatrix3fv;
		public static PFNGLPROGRAMUNIFORMMATRIX4FVPROC glProgramUniformMatrix4fv;
		public static PFNGLPROGRAMUNIFORMMATRIX2DVPROC glProgramUniformMatrix2dv;
		public static PFNGLPROGRAMUNIFORMMATRIX3DVPROC glProgramUniformMatrix3dv;
		public static PFNGLPROGRAMUNIFORMMATRIX4DVPROC glProgramUniformMatrix4dv;
		public static PFNGLPROGRAMUNIFORMMATRIX2X3FVPROC glProgramUniformMatrix2x3fv;
		public static PFNGLPROGRAMUNIFORMMATRIX3X2FVPROC glProgramUniformMatrix3x2fv;
		public static PFNGLPROGRAMUNIFORMMATRIX2X4FVPROC glProgramUniformMatrix2x4fv;
		public static PFNGLPROGRAMUNIFORMMATRIX4X2FVPROC glProgramUniformMatrix4x2fv;
		public static PFNGLPROGRAMUNIFORMMATRIX3X4FVPROC glProgramUniformMatrix3x4fv;
		public static PFNGLPROGRAMUNIFORMMATRIX4X3FVPROC glProgramUniformMatrix4x3fv;
		public static PFNGLPROGRAMUNIFORMMATRIX2X3DVPROC glProgramUniformMatrix2x3dv;
		public static PFNGLPROGRAMUNIFORMMATRIX3X2DVPROC glProgramUniformMatrix3x2dv;
		public static PFNGLPROGRAMUNIFORMMATRIX2X4DVPROC glProgramUniformMatrix2x4dv;
		public static PFNGLPROGRAMUNIFORMMATRIX4X2DVPROC glProgramUniformMatrix4x2dv;
		public static PFNGLPROGRAMUNIFORMMATRIX3X4DVPROC glProgramUniformMatrix3x4dv;
		public static PFNGLPROGRAMUNIFORMMATRIX4X3DVPROC glProgramUniformMatrix4x3dv;
		public static PFNGLVALIDATEPROGRAMPIPELINEPROC glValidateProgramPipeline;
		public static PFNGLGETPROGRAMPIPELINEINFOLOGPROC glGetProgramPipelineInfoLog;
		public static PFNGLVERTEXATTRIBL1DPROC glVertexAttribL1d;
		public static PFNGLVERTEXATTRIBL2DPROC glVertexAttribL2d;
		public static PFNGLVERTEXATTRIBL3DPROC glVertexAttribL3d;
		public static PFNGLVERTEXATTRIBL4DPROC glVertexAttribL4d;
		public static PFNGLVERTEXATTRIBL1DVPROC glVertexAttribL1dv;
		public static PFNGLVERTEXATTRIBL2DVPROC glVertexAttribL2dv;
		public static PFNGLVERTEXATTRIBL3DVPROC glVertexAttribL3dv;
		public static PFNGLVERTEXATTRIBL4DVPROC glVertexAttribL4dv;
		public static PFNGLVERTEXATTRIBLPOINTERPROC glVertexAttribLPointer;
		public static PFNGLGETVERTEXATTRIBLDVPROC glGetVertexAttribLdv;
		public static PFNGLVIEWPORTARRAYVPROC glViewportArrayv;
		public static PFNGLVIEWPORTINDEXEDFPROC glViewportIndexedf;
		public static PFNGLVIEWPORTINDEXEDFVPROC glViewportIndexedfv;
		public static PFNGLSCISSORARRAYVPROC glScissorArrayv;
		public static PFNGLSCISSORINDEXEDPROC glScissorIndexed;
		public static PFNGLSCISSORINDEXEDVPROC glScissorIndexedv;
		public static PFNGLDEPTHRANGEARRAYVPROC glDepthRangeArrayv;
		public static PFNGLDEPTHRANGEINDEXEDPROC glDepthRangeIndexed;
		public static PFNGLGETFLOATI_VPROC glGetFloati_v;
		public static PFNGLGETDOUBLEI_VPROC glGetDoublei_v;
#endif
#endif // GL_VERSION_4_1
		#endregion

		#region OpenGL 4.2
#if GL_VERSION_4_2
		public const uint GL_COPY_READ_BUFFER_BINDING = 0x8F36;
		public const uint GL_COPY_WRITE_BUFFER_BINDING = 0x8F37;
		public const uint GL_TRANSFORM_FEEDBACK_ACTIVE = 0x8E24;
		public const uint GL_TRANSFORM_FEEDBACK_PAUSED = 0x8E23;
		public const uint GL_UNPACK_COMPRESSED_BLOCK_WIDTH = 0x9127;
		public const uint GL_UNPACK_COMPRESSED_BLOCK_HEIGHT = 0x9128;
		public const uint GL_UNPACK_COMPRESSED_BLOCK_DEPTH = 0x9129;
		public const uint GL_UNPACK_COMPRESSED_BLOCK_SIZE = 0x912A;
		public const uint GL_PACK_COMPRESSED_BLOCK_WIDTH = 0x912B;
		public const uint GL_PACK_COMPRESSED_BLOCK_HEIGHT = 0x912C;
		public const uint GL_PACK_COMPRESSED_BLOCK_DEPTH = 0x912D;
		public const uint GL_PACK_COMPRESSED_BLOCK_SIZE = 0x912E;
		public const uint GL_NUM_SAMPLE_COUNTS = 0x9380;
		public const uint GL_MIN_MAP_BUFFER_ALIGNMENT = 0x90BC;
		public const uint GL_ATOMIC_COUNTER_BUFFER = 0x92C0;
		public const uint GL_ATOMIC_COUNTER_BUFFER_BINDING = 0x92C1;
		public const uint GL_ATOMIC_COUNTER_BUFFER_START = 0x92C2;
		public const uint GL_ATOMIC_COUNTER_BUFFER_SIZE = 0x92C3;
		public const uint GL_ATOMIC_COUNTER_BUFFER_DATA_SIZE = 0x92C4;
		public const uint GL_ATOMIC_COUNTER_BUFFER_ACTIVE_ATOMIC_COUNTERS = 0x92C5;
		public const uint GL_ATOMIC_COUNTER_BUFFER_ACTIVE_ATOMIC_COUNTER_INDICES = 0x92C6;
		public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_VERTEX_SHADER = 0x92C7;
		public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_TESS_CONTROL_SHADER = 0x92C8;
		public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x92C9;
		public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_GEOMETRY_SHADER = 0x92CA;
		public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_FRAGMENT_SHADER = 0x92CB;
		public const uint GL_MAX_VERTEX_ATOMIC_COUNTER_BUFFERS = 0x92CC;
		public const uint GL_MAX_TESS_CONTROL_ATOMIC_COUNTER_BUFFERS = 0x92CD;
		public const uint GL_MAX_TESS_EVALUATION_ATOMIC_COUNTER_BUFFERS = 0x92CE;
		public const uint GL_MAX_GEOMETRY_ATOMIC_COUNTER_BUFFERS = 0x92CF;
		public const uint GL_MAX_FRAGMENT_ATOMIC_COUNTER_BUFFERS = 0x92D0;
		public const uint GL_MAX_COMBINED_ATOMIC_COUNTER_BUFFERS = 0x92D1;
		public const uint GL_MAX_VERTEX_ATOMIC_COUNTERS = 0x92D2;
		public const uint GL_MAX_TESS_CONTROL_ATOMIC_COUNTERS = 0x92D3;
		public const uint GL_MAX_TESS_EVALUATION_ATOMIC_COUNTERS = 0x92D4;
		public const uint GL_MAX_GEOMETRY_ATOMIC_COUNTERS = 0x92D5;
		public const uint GL_MAX_FRAGMENT_ATOMIC_COUNTERS = 0x92D6;
		public const uint GL_MAX_COMBINED_ATOMIC_COUNTERS = 0x92D7;
		public const uint GL_MAX_ATOMIC_COUNTER_BUFFER_SIZE = 0x92D8;
		public const uint GL_MAX_ATOMIC_COUNTER_BUFFER_BINDINGS = 0x92DC;
		public const uint GL_ACTIVE_ATOMIC_COUNTER_BUFFERS = 0x92D9;
		public const uint GL_UNIFORM_ATOMIC_COUNTER_BUFFER_INDEX = 0x92DA;
		public const uint GL_UNSIGNED_INT_ATOMIC_COUNTER = 0x92DB;
		public const uint GL_VERTEX_ATTRIB_ARRAY_BARRIER_BIT = 0x00000001;
		public const uint GL_ELEMENT_ARRAY_BARRIER_BIT = 0x00000002;
		public const uint GL_UNIFORM_BARRIER_BIT = 0x00000004;
		public const uint GL_TEXTURE_FETCH_BARRIER_BIT = 0x00000008;
		public const uint GL_SHADER_IMAGE_ACCESS_BARRIER_BIT = 0x00000020;
		public const uint GL_COMMAND_BARRIER_BIT = 0x00000040;
		public const uint GL_PIXEL_BUFFER_BARRIER_BIT = 0x00000080;
		public const uint GL_TEXTURE_UPDATE_BARRIER_BIT = 0x00000100;
		public const uint GL_BUFFER_UPDATE_BARRIER_BIT = 0x00000200;
		public const uint GL_FRAMEBUFFER_BARRIER_BIT = 0x00000400;
		public const uint GL_TRANSFORM_FEEDBACK_BARRIER_BIT = 0x00000800;
		public const uint GL_ATOMIC_COUNTER_BARRIER_BIT = 0x00001000;
		public const uint GL_ALL_BARRIER_BITS = 0xFFFFFFFF;
		public const uint GL_MAX_IMAGE_UNITS = 0x8F38;
		public const uint GL_MAX_COMBINED_IMAGE_UNITS_AND_FRAGMENT_OUTPUTS = 0x8F39;
		public const uint GL_IMAGE_BINDING_NAME = 0x8F3A;
		public const uint GL_IMAGE_BINDING_LEVEL = 0x8F3B;
		public const uint GL_IMAGE_BINDING_LAYERED = 0x8F3C;
		public const uint GL_IMAGE_BINDING_LAYER = 0x8F3D;
		public const uint GL_IMAGE_BINDING_ACCESS = 0x8F3E;
		public const uint GL_IMAGE_1D = 0x904C;
		public const uint GL_IMAGE_2D = 0x904D;
		public const uint GL_IMAGE_3D = 0x904E;
		public const uint GL_IMAGE_2D_RECT = 0x904F;
		public const uint GL_IMAGE_CUBE = 0x9050;
		public const uint GL_IMAGE_BUFFER = 0x9051;
		public const uint GL_IMAGE_1D_ARRAY = 0x9052;
		public const uint GL_IMAGE_2D_ARRAY = 0x9053;
		public const uint GL_IMAGE_CUBE_MAP_ARRAY = 0x9054;
		public const uint GL_IMAGE_2D_MULTISAMPLE = 0x9055;
		public const uint GL_IMAGE_2D_MULTISAMPLE_ARRAY = 0x9056;
		public const uint GL_INT_IMAGE_1D = 0x9057;
		public const uint GL_INT_IMAGE_2D = 0x9058;
		public const uint GL_INT_IMAGE_3D = 0x9059;
		public const uint GL_INT_IMAGE_2D_RECT = 0x905A;
		public const uint GL_INT_IMAGE_CUBE = 0x905B;
		public const uint GL_INT_IMAGE_BUFFER = 0x905C;
		public const uint GL_INT_IMAGE_1D_ARRAY = 0x905D;
		public const uint GL_INT_IMAGE_2D_ARRAY = 0x905E;
		public const uint GL_INT_IMAGE_CUBE_MAP_ARRAY = 0x905F;
		public const uint GL_INT_IMAGE_2D_MULTISAMPLE = 0x9060;
		public const uint GL_INT_IMAGE_2D_MULTISAMPLE_ARRAY = 0x9061;
		public const uint GL_UNSIGNED_INT_IMAGE_1D = 0x9062;
		public const uint GL_UNSIGNED_INT_IMAGE_2D = 0x9063;
		public const uint GL_UNSIGNED_INT_IMAGE_3D = 0x9064;
		public const uint GL_UNSIGNED_INT_IMAGE_2D_RECT = 0x9065;
		public const uint GL_UNSIGNED_INT_IMAGE_CUBE = 0x9066;
		public const uint GL_UNSIGNED_INT_IMAGE_BUFFER = 0x9067;
		public const uint GL_UNSIGNED_INT_IMAGE_1D_ARRAY = 0x9068;
		public const uint GL_UNSIGNED_INT_IMAGE_2D_ARRAY = 0x9069;
		public const uint GL_UNSIGNED_INT_IMAGE_CUBE_MAP_ARRAY = 0x906A;
		public const uint GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE = 0x906B;
		public const uint GL_UNSIGNED_INT_IMAGE_2D_MULTISAMPLE_ARRAY = 0x906C;
		public const uint GL_MAX_IMAGE_SAMPLES = 0x906D;
		public const uint GL_IMAGE_BINDING_FORMAT = 0x906E;
		public const uint GL_IMAGE_FORMAT_COMPATIBILITY_TYPE = 0x90C7;
		public const uint GL_IMAGE_FORMAT_COMPATIBILITY_BY_SIZE = 0x90C8;
		public const uint GL_IMAGE_FORMAT_COMPATIBILITY_BY_CLASS = 0x90C9;
		public const uint GL_MAX_VERTEX_IMAGE_UNIFORMS = 0x90CA;
		public const uint GL_MAX_TESS_CONTROL_IMAGE_UNIFORMS = 0x90CB;
		public const uint GL_MAX_TESS_EVALUATION_IMAGE_UNIFORMS = 0x90CC;
		public const uint GL_MAX_GEOMETRY_IMAGE_UNIFORMS = 0x90CD;
		public const uint GL_MAX_FRAGMENT_IMAGE_UNIFORMS = 0x90CE;
		public const uint GL_MAX_COMBINED_IMAGE_UNIFORMS = 0x90CF;
		public const uint GL_COMPRESSED_RGBA_BPTC_UNORM = 0x8E8C;
		public const uint GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM = 0x8E8D;
		public const uint GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT = 0x8E8E;
		public const uint GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT = 0x8E8F;
		public const uint GL_TEXTURE_IMMUTABLE_FORMAT = 0x912F;
		public delegate void PFNGLDRAWARRAYSINSTANCEDBASEINSTANCEPROC( uint mode, int first, int count, int instancecount, uint baseinstance );
		public delegate void PFNGLDRAWELEMENTSINSTANCEDBASEINSTANCEPROC( uint mode, int count, uint type, void* indices, int instancecount, uint baseinstance );
		public delegate void PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXBASEINSTANCEPROC( uint mode, int count, uint type, void* indices, int instancecount, int basevertex, uint baseinstance );
		public delegate void PFNGLGETINTERNALFORMATIVPROC( uint target, uint internalformat, uint pname, int count, IntPtr @params );
		public delegate void PFNGLGETACTIVEATOMICCOUNTERBUFFERIVPROC( uint program, uint bufferIndex, uint pname, IntPtr @params );
		public delegate void PFNGLBINDIMAGETEXTUREPROC( uint unit, uint texture, int level, bool layered, int layer, uint access, uint format );
		public delegate void PFNGLMEMORYBARRIERPROC( uint barriers );
		public delegate void PFNGLTEXSTORAGE1DPROC( uint target, int levels, uint internalformat, int width );
		public delegate void PFNGLTEXSTORAGE2DPROC( uint target, int levels, uint internalformat, int width, int height );
		public delegate void PFNGLTEXSTORAGE3DPROC( uint target, int levels, uint internalformat, int width, int height, int depth );
		public delegate void PFNGLDRAWTRANSFORMFEEDBACKINSTANCEDPROC( uint mode, uint id, int instancecount );
		public delegate void PFNGLDRAWTRANSFORMFEEDBACKSTREAMINSTANCEDPROC( uint mode, uint id, uint stream, int instancecount );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLDRAWARRAYSINSTANCEDBASEINSTANCEPROC glDrawArraysInstancedBaseInstance;
		public static PFNGLDRAWELEMENTSINSTANCEDBASEINSTANCEPROC glDrawElementsInstancedBaseInstance;
		public static PFNGLDRAWELEMENTSINSTANCEDBASEVERTEXBASEINSTANCEPROC glDrawElementsInstancedBaseVertexBaseInstance;
		public static PFNGLGETINTERNALFORMATIVPROC glGetInternalformativ;
		public static PFNGLGETACTIVEATOMICCOUNTERBUFFERIVPROC glGetActiveAtomicCounterBufferiv;
		public static PFNGLBINDIMAGETEXTUREPROC glBindImageTexture;
		public static PFNGLMEMORYBARRIERPROC glMemoryBarrier;
		public static PFNGLTEXSTORAGE1DPROC glTexStorage1D;
		public static PFNGLTEXSTORAGE2DPROC glTexStorage2D;
		public static PFNGLTEXSTORAGE3DPROC glTexStorage3D;
		public static PFNGLDRAWTRANSFORMFEEDBACKINSTANCEDPROC glDrawTransformFeedbackInstanced;
		public static PFNGLDRAWTRANSFORMFEEDBACKSTREAMINSTANCEDPROC glDrawTransformFeedbackStreamInstanced;
#endif
#endif // GL_VERSION_4_2
		#endregion

		#region OpenGL 4.3
#if GL_VERSION_4_3
		public delegate void* GLDEBUGPROC( uint source, uint type, uint id, uint severity, int length, char* message, void* userParam );
		public const uint GL_NUM_SHADING_LANGUAGE_VERSIONS = 0x82E9;
		public const uint GL_VERTEX_ATTRIB_ARRAY_LONG = 0x874E;
		public const uint GL_COMPRESSED_RGB8_ETC2 = 0x9274;
		public const uint GL_COMPRESSED_SRGB8_ETC2 = 0x9275;
		public const uint GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9276;
		public const uint GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9277;
		public const uint GL_COMPRESSED_RGBA8_ETC2_EAC = 0x9278;
		public const uint GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9279;
		public const uint GL_COMPRESSED_R11_EAC = 0x9270;
		public const uint GL_COMPRESSED_SIGNED_R11_EAC = 0x9271;
		public const uint GL_COMPRESSED_RG11_EAC = 0x9272;
		public const uint GL_COMPRESSED_SIGNED_RG11_EAC = 0x9273;
		public const uint GL_PRIMITIVE_RESTART_FIXED_INDEX = 0x8D69;
		public const uint GL_ANY_SAMPLES_PASSED_CONSERVATIVE = 0x8D6A;
		public const uint GL_MAX_ELEMENT_INDEX = 0x8D6B;
		public const uint GL_COMPUTE_SHADER = 0x91B9;
		public const uint GL_MAX_COMPUTE_UNIFORM_BLOCKS = 0x91BB;
		public const uint GL_MAX_COMPUTE_TEXTURE_IMAGE_UNITS = 0x91BC;
		public const uint GL_MAX_COMPUTE_IMAGE_UNIFORMS = 0x91BD;
		public const uint GL_MAX_COMPUTE_SHARED_MEMORY_SIZE = 0x8262;
		public const uint GL_MAX_COMPUTE_UNIFORM_COMPONENTS = 0x8263;
		public const uint GL_MAX_COMPUTE_ATOMIC_COUNTER_BUFFERS = 0x8264;
		public const uint GL_MAX_COMPUTE_ATOMIC_COUNTERS = 0x8265;
		public const uint GL_MAX_COMBINED_COMPUTE_UNIFORM_COMPONENTS = 0x8266;
		public const uint GL_MAX_COMPUTE_WORK_GROUP_INVOCATIONS = 0x90EB;
		public const uint GL_MAX_COMPUTE_WORK_GROUP_COUNT = 0x91BE;
		public const uint GL_MAX_COMPUTE_WORK_GROUP_SIZE = 0x91BF;
		public const uint GL_COMPUTE_WORK_GROUP_SIZE = 0x8267;
		public const uint GL_UNIFORM_BLOCK_REFERENCED_BY_COMPUTE_SHADER = 0x90EC;
		public const uint GL_ATOMIC_COUNTER_BUFFER_REFERENCED_BY_COMPUTE_SHADER = 0x90ED;
		public const uint GL_DISPATCH_INDIRECT_BUFFER = 0x90EE;
		public const uint GL_DISPATCH_INDIRECT_BUFFER_BINDING = 0x90EF;
		public const uint GL_COMPUTE_SHADER_BIT = 0x00000020;
		public const uint GL_DEBUG_OUTPUT_SYNCHRONOUS = 0x8242;
		public const uint GL_DEBUG_NEXT_LOGGED_MESSAGE_LENGTH = 0x8243;
		public const uint GL_DEBUG_CALLBACK_FUNCTION = 0x8244;
		public const uint GL_DEBUG_CALLBACK_USER_PARAM = 0x8245;
		public const uint GL_DEBUG_SOURCE_API = 0x8246;
		public const uint GL_DEBUG_SOURCE_WINDOW_SYSTEM = 0x8247;
		public const uint GL_DEBUG_SOURCE_SHADER_COMPILER = 0x8248;
		public const uint GL_DEBUG_SOURCE_THIRD_PARTY = 0x8249;
		public const uint GL_DEBUG_SOURCE_APPLICATION = 0x824A;
		public const uint GL_DEBUG_SOURCE_OTHER = 0x824B;
		public const uint GL_DEBUG_TYPE_ERROR = 0x824C;
		public const uint GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR = 0x824D;
		public const uint GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR = 0x824E;
		public const uint GL_DEBUG_TYPE_PORTABILITY = 0x824F;
		public const uint GL_DEBUG_TYPE_PERFORMANCE = 0x8250;
		public const uint GL_DEBUG_TYPE_OTHER = 0x8251;
		public const uint GL_MAX_DEBUG_MESSAGE_LENGTH = 0x9143;
		public const uint GL_MAX_DEBUG_LOGGED_MESSAGES = 0x9144;
		public const uint GL_DEBUG_LOGGED_MESSAGES = 0x9145;
		public const uint GL_DEBUG_SEVERITY_HIGH = 0x9146;
		public const uint GL_DEBUG_SEVERITY_MEDIUM = 0x9147;
		public const uint GL_DEBUG_SEVERITY_LOW = 0x9148;
		public const uint GL_DEBUG_TYPE_MARKER = 0x8268;
		public const uint GL_DEBUG_TYPE_PUSH_GROUP = 0x8269;
		public const uint GL_DEBUG_TYPE_POP_GROUP = 0x826A;
		public const uint GL_DEBUG_SEVERITY_NOTIFICATION = 0x826B;
		public const uint GL_MAX_DEBUG_GROUP_STACK_DEPTH = 0x826C;
		public const uint GL_DEBUG_GROUP_STACK_DEPTH = 0x826D;
		public const uint GL_BUFFER = 0x82E0;
		public const uint GL_SHADER = 0x82E1;
		public const uint GL_PROGRAM = 0x82E2;
		public const uint GL_QUERY = 0x82E3;
		public const uint GL_PROGRAM_PIPELINE = 0x82E4;
		public const uint GL_SAMPLER = 0x82E6;
		public const uint GL_MAX_LABEL_LENGTH = 0x82E8;
		public const uint GL_DEBUG_OUTPUT = 0x92E0;
		public const uint GL_CONTEXT_FLAG_DEBUG_BIT = 0x00000002;
		public const uint GL_MAX_UNIFORM_LOCATIONS = 0x826E;
		public const uint GL_FRAMEBUFFER_DEFAULT_WIDTH = 0x9310;
		public const uint GL_FRAMEBUFFER_DEFAULT_HEIGHT = 0x9311;
		public const uint GL_FRAMEBUFFER_DEFAULT_LAYERS = 0x9312;
		public const uint GL_FRAMEBUFFER_DEFAULT_SAMPLES = 0x9313;
		public const uint GL_FRAMEBUFFER_DEFAULT_FIXED_SAMPLE_LOCATIONS = 0x9314;
		public const uint GL_MAX_FRAMEBUFFER_WIDTH = 0x9315;
		public const uint GL_MAX_FRAMEBUFFER_HEIGHT = 0x9316;
		public const uint GL_MAX_FRAMEBUFFER_LAYERS = 0x9317;
		public const uint GL_MAX_FRAMEBUFFER_SAMPLES = 0x9318;
		public const uint GL_INTERNALFORMAT_SUPPORTED = 0x826F;
		public const uint GL_INTERNALFORMAT_PREFERRED = 0x8270;
		public const uint GL_INTERNALFORMAT_RED_SIZE = 0x8271;
		public const uint GL_INTERNALFORMAT_GREEN_SIZE = 0x8272;
		public const uint GL_INTERNALFORMAT_BLUE_SIZE = 0x8273;
		public const uint GL_INTERNALFORMAT_ALPHA_SIZE = 0x8274;
		public const uint GL_INTERNALFORMAT_DEPTH_SIZE = 0x8275;
		public const uint GL_INTERNALFORMAT_STENCIL_SIZE = 0x8276;
		public const uint GL_INTERNALFORMAT_SHARED_SIZE = 0x8277;
		public const uint GL_INTERNALFORMAT_RED_TYPE = 0x8278;
		public const uint GL_INTERNALFORMAT_GREEN_TYPE = 0x8279;
		public const uint GL_INTERNALFORMAT_BLUE_TYPE = 0x827A;
		public const uint GL_INTERNALFORMAT_ALPHA_TYPE = 0x827B;
		public const uint GL_INTERNALFORMAT_DEPTH_TYPE = 0x827C;
		public const uint GL_INTERNALFORMAT_STENCIL_TYPE = 0x827D;
		public const uint GL_MAX_WIDTH = 0x827E;
		public const uint GL_MAX_HEIGHT = 0x827F;
		public const uint GL_MAX_DEPTH = 0x8280;
		public const uint GL_MAX_LAYERS = 0x8281;
		public const uint GL_MAX_COMBINED_DIMENSIONS = 0x8282;
		public const uint GL_COLOR_COMPONENTS = 0x8283;
		public const uint GL_DEPTH_COMPONENTS = 0x8284;
		public const uint GL_STENCIL_COMPONENTS = 0x8285;
		public const uint GL_COLOR_RENDERABLE = 0x8286;
		public const uint GL_DEPTH_RENDERABLE = 0x8287;
		public const uint GL_STENCIL_RENDERABLE = 0x8288;
		public const uint GL_FRAMEBUFFER_RENDERABLE = 0x8289;
		public const uint GL_FRAMEBUFFER_RENDERABLE_LAYERED = 0x828A;
		public const uint GL_FRAMEBUFFER_BLEND = 0x828B;
		public const uint GL_READ_PIXELS = 0x828C;
		public const uint GL_READ_PIXELS_FORMAT = 0x828D;
		public const uint GL_READ_PIXELS_TYPE = 0x828E;
		public const uint GL_TEXTURE_IMAGE_FORMAT = 0x828F;
		public const uint GL_TEXTURE_IMAGE_TYPE = 0x8290;
		public const uint GL_GET_TEXTURE_IMAGE_FORMAT = 0x8291;
		public const uint GL_GET_TEXTURE_IMAGE_TYPE = 0x8292;
		public const uint GL_MIPMAP = 0x8293;
		public const uint GL_MANUAL_GENERATE_MIPMAP = 0x8294;
		public const uint GL_AUTO_GENERATE_MIPMAP = 0x8295;
		public const uint GL_COLOR_ENCODING = 0x8296;
		public const uint GL_SRGB_READ = 0x8297;
		public const uint GL_SRGB_WRITE = 0x8298;
		public const uint GL_FILTER = 0x829A;
		public const uint GL_VERTEX_TEXTURE = 0x829B;
		public const uint GL_TESS_CONTROL_TEXTURE = 0x829C;
		public const uint GL_TESS_EVALUATION_TEXTURE = 0x829D;
		public const uint GL_GEOMETRY_TEXTURE = 0x829E;
		public const uint GL_FRAGMENT_TEXTURE = 0x829F;
		public const uint GL_COMPUTE_TEXTURE = 0x82A0;
		public const uint GL_TEXTURE_SHADOW = 0x82A1;
		public const uint GL_TEXTURE_GATHER = 0x82A2;
		public const uint GL_TEXTURE_GATHER_SHADOW = 0x82A3;
		public const uint GL_SHADER_IMAGE_LOAD = 0x82A4;
		public const uint GL_SHADER_IMAGE_STORE = 0x82A5;
		public const uint GL_SHADER_IMAGE_ATOMIC = 0x82A6;
		public const uint GL_IMAGE_TEXEL_SIZE = 0x82A7;
		public const uint GL_IMAGE_COMPATIBILITY_CLASS = 0x82A8;
		public const uint GL_IMAGE_PIXEL_FORMAT = 0x82A9;
		public const uint GL_IMAGE_PIXEL_TYPE = 0x82AA;
		public const uint GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_TEST = 0x82AC;
		public const uint GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_TEST = 0x82AD;
		public const uint GL_SIMULTANEOUS_TEXTURE_AND_DEPTH_WRITE = 0x82AE;
		public const uint GL_SIMULTANEOUS_TEXTURE_AND_STENCIL_WRITE = 0x82AF;
		public const uint GL_TEXTURE_COMPRESSED_BLOCK_WIDTH = 0x82B1;
		public const uint GL_TEXTURE_COMPRESSED_BLOCK_HEIGHT = 0x82B2;
		public const uint GL_TEXTURE_COMPRESSED_BLOCK_SIZE = 0x82B3;
		public const uint GL_CLEAR_BUFFER = 0x82B4;
		public const uint GL_TEXTURE_VIEW = 0x82B5;
		public const uint GL_VIEW_COMPATIBILITY_CLASS = 0x82B6;
		public const uint GL_FULL_SUPPORT = 0x82B7;
		public const uint GL_CAVEAT_SUPPORT = 0x82B8;
		public const uint GL_IMAGE_CLASS_4_X_32 = 0x82B9;
		public const uint GL_IMAGE_CLASS_2_X_32 = 0x82BA;
		public const uint GL_IMAGE_CLASS_1_X_32 = 0x82BB;
		public const uint GL_IMAGE_CLASS_4_X_16 = 0x82BC;
		public const uint GL_IMAGE_CLASS_2_X_16 = 0x82BD;
		public const uint GL_IMAGE_CLASS_1_X_16 = 0x82BE;
		public const uint GL_IMAGE_CLASS_4_X_8 = 0x82BF;
		public const uint GL_IMAGE_CLASS_2_X_8 = 0x82C0;
		public const uint GL_IMAGE_CLASS_1_X_8 = 0x82C1;
		public const uint GL_IMAGE_CLASS_11_11_10 = 0x82C2;
		public const uint GL_IMAGE_CLASS_10_10_10_2 = 0x82C3;
		public const uint GL_VIEW_CLASS_128_BITS = 0x82C4;
		public const uint GL_VIEW_CLASS_96_BITS = 0x82C5;
		public const uint GL_VIEW_CLASS_64_BITS = 0x82C6;
		public const uint GL_VIEW_CLASS_48_BITS = 0x82C7;
		public const uint GL_VIEW_CLASS_32_BITS = 0x82C8;
		public const uint GL_VIEW_CLASS_24_BITS = 0x82C9;
		public const uint GL_VIEW_CLASS_16_BITS = 0x82CA;
		public const uint GL_VIEW_CLASS_8_BITS = 0x82CB;
		public const uint GL_VIEW_CLASS_S3TC_DXT1_RGB = 0x82CC;
		public const uint GL_VIEW_CLASS_S3TC_DXT1_RGBA = 0x82CD;
		public const uint GL_VIEW_CLASS_S3TC_DXT3_RGBA = 0x82CE;
		public const uint GL_VIEW_CLASS_S3TC_DXT5_RGBA = 0x82CF;
		public const uint GL_VIEW_CLASS_RGTC1_RED = 0x82D0;
		public const uint GL_VIEW_CLASS_RGTC2_RG = 0x82D1;
		public const uint GL_VIEW_CLASS_BPTC_UNORM = 0x82D2;
		public const uint GL_VIEW_CLASS_BPTC_FLOAT = 0x82D3;
		public const uint GL_UNIFORM = 0x92E1;
		public const uint GL_UNIFORM_BLOCK = 0x92E2;
		public const uint GL_PROGRAM_INPUT = 0x92E3;
		public const uint GL_PROGRAM_OUTPUT = 0x92E4;
		public const uint GL_BUFFER_VARIABLE = 0x92E5;
		public const uint GL_SHADER_STORAGE_BLOCK = 0x92E6;
		public const uint GL_VERTEX_SUBROUTINE = 0x92E8;
		public const uint GL_TESS_CONTROL_SUBROUTINE = 0x92E9;
		public const uint GL_TESS_EVALUATION_SUBROUTINE = 0x92EA;
		public const uint GL_GEOMETRY_SUBROUTINE = 0x92EB;
		public const uint GL_FRAGMENT_SUBROUTINE = 0x92EC;
		public const uint GL_COMPUTE_SUBROUTINE = 0x92ED;
		public const uint GL_VERTEX_SUBROUTINE_UNIFORM = 0x92EE;
		public const uint GL_TESS_CONTROL_SUBROUTINE_UNIFORM = 0x92EF;
		public const uint GL_TESS_EVALUATION_SUBROUTINE_UNIFORM = 0x92F0;
		public const uint GL_GEOMETRY_SUBROUTINE_UNIFORM = 0x92F1;
		public const uint GL_FRAGMENT_SUBROUTINE_UNIFORM = 0x92F2;
		public const uint GL_COMPUTE_SUBROUTINE_UNIFORM = 0x92F3;
		public const uint GL_TRANSFORM_FEEDBACK_VARYING = 0x92F4;
		public const uint GL_ACTIVE_RESOURCES = 0x92F5;
		public const uint GL_MAX_NAME_LENGTH = 0x92F6;
		public const uint GL_MAX_NUM_ACTIVE_VARIABLES = 0x92F7;
		public const uint GL_MAX_NUM_COMPATIBLE_SUBROUTINES = 0x92F8;
		public const uint GL_NAME_LENGTH = 0x92F9;
		public const uint GL_TYPE = 0x92FA;
		public const uint GL_ARRAY_SIZE = 0x92FB;
		public const uint GL_OFFSET = 0x92FC;
		public const uint GL_BLOCK_INDEX = 0x92FD;
		public const uint GL_ARRAY_STRIDE = 0x92FE;
		public const uint GL_MATRIX_STRIDE = 0x92FF;
		public const uint GL_IS_ROW_MAJOR = 0x9300;
		public const uint GL_ATOMIC_COUNTER_BUFFER_INDEX = 0x9301;
		public const uint GL_BUFFER_BINDING = 0x9302;
		public const uint GL_BUFFER_DATA_SIZE = 0x9303;
		public const uint GL_NUM_ACTIVE_VARIABLES = 0x9304;
		public const uint GL_ACTIVE_VARIABLES = 0x9305;
		public const uint GL_REFERENCED_BY_VERTEX_SHADER = 0x9306;
		public const uint GL_REFERENCED_BY_TESS_CONTROL_SHADER = 0x9307;
		public const uint GL_REFERENCED_BY_TESS_EVALUATION_SHADER = 0x9308;
		public const uint GL_REFERENCED_BY_GEOMETRY_SHADER = 0x9309;
		public const uint GL_REFERENCED_BY_FRAGMENT_SHADER = 0x930A;
		public const uint GL_REFERENCED_BY_COMPUTE_SHADER = 0x930B;
		public const uint GL_TOP_LEVEL_ARRAY_SIZE = 0x930C;
		public const uint GL_TOP_LEVEL_ARRAY_STRIDE = 0x930D;
		public const uint GL_LOCATION = 0x930E;
		public const uint GL_LOCATION_INDEX = 0x930F;
		public const uint GL_IS_PER_PATCH = 0x92E7;
		public const uint GL_SHADER_STORAGE_BUFFER = 0x90D2;
		public const uint GL_SHADER_STORAGE_BUFFER_BINDING = 0x90D3;
		public const uint GL_SHADER_STORAGE_BUFFER_START = 0x90D4;
		public const uint GL_SHADER_STORAGE_BUFFER_SIZE = 0x90D5;
		public const uint GL_MAX_VERTEX_SHADER_STORAGE_BLOCKS = 0x90D6;
		public const uint GL_MAX_GEOMETRY_SHADER_STORAGE_BLOCKS = 0x90D7;
		public const uint GL_MAX_TESS_CONTROL_SHADER_STORAGE_BLOCKS = 0x90D8;
		public const uint GL_MAX_TESS_EVALUATION_SHADER_STORAGE_BLOCKS = 0x90D9;
		public const uint GL_MAX_FRAGMENT_SHADER_STORAGE_BLOCKS = 0x90DA;
		public const uint GL_MAX_COMPUTE_SHADER_STORAGE_BLOCKS = 0x90DB;
		public const uint GL_MAX_COMBINED_SHADER_STORAGE_BLOCKS = 0x90DC;
		public const uint GL_MAX_SHADER_STORAGE_BUFFER_BINDINGS = 0x90DD;
		public const uint GL_MAX_SHADER_STORAGE_BLOCK_SIZE = 0x90DE;
		public const uint GL_SHADER_STORAGE_BUFFER_OFFSET_ALIGNMENT = 0x90DF;
		public const uint GL_SHADER_STORAGE_BARRIER_BIT = 0x00002000;
		public const uint GL_MAX_COMBINED_SHADER_OUTPUT_RESOURCES = 0x8F39;
		public const uint GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA;
		public const uint GL_TEXTURE_BUFFER_OFFSET = 0x919D;
		public const uint GL_TEXTURE_BUFFER_SIZE = 0x919E;
		public const uint GL_TEXTURE_BUFFER_OFFSET_ALIGNMENT = 0x919F;
		public const uint GL_TEXTURE_VIEW_MIN_LEVEL = 0x82DB;
		public const uint GL_TEXTURE_VIEW_NUM_LEVELS = 0x82DC;
		public const uint GL_TEXTURE_VIEW_MIN_LAYER = 0x82DD;
		public const uint GL_TEXTURE_VIEW_NUM_LAYERS = 0x82DE;
		public const uint GL_TEXTURE_IMMUTABLE_LEVELS = 0x82DF;
		public const uint GL_VERTEX_ATTRIB_BINDING = 0x82D4;
		public const uint GL_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D5;
		public const uint GL_VERTEX_BINDING_DIVISOR = 0x82D6;
		public const uint GL_VERTEX_BINDING_OFFSET = 0x82D7;
		public const uint GL_VERTEX_BINDING_STRIDE = 0x82D8;
		public const uint GL_MAX_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D9;
		public const uint GL_MAX_VERTEX_ATTRIB_BINDINGS = 0x82DA;
		public const uint GL_VERTEX_BINDING_BUFFER = 0x8F4F;
		public delegate void PFNGLCLEARBUFFERDATAPROC( uint target, uint internalformat, uint format, uint type, void* data );
		public delegate void PFNGLCLEARBUFFERSUBDATAPROC( uint target, uint internalformat, IntPtr offset, IntPtr size, uint format, uint type, void* data );
		public delegate void PFNGLDISPATCHCOMPUTEPROC( uint num_groups_x, uint num_groups_y, uint num_groups_z );
		public delegate void PFNGLDISPATCHCOMPUTEINDIRECTPROC( IntPtr indirect );
		public delegate void PFNGLCOPYIMAGESUBDATAPROC( uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth );
		public delegate void PFNGLFRAMEBUFFERPARAMETERIPROC( uint target, uint pname, int param );
		public delegate void PFNGLGETFRAMEBUFFERPARAMETERIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLGETINTERNALFORMATI64VPROC( uint target, uint internalformat, uint pname, int count, long* @params );
		public delegate void PFNGLINVALIDATETEXSUBIMAGEPROC( uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth );
		public delegate void PFNGLINVALIDATETEXIMAGEPROC( uint texture, int level );
		public delegate void PFNGLINVALIDATEBUFFERSUBDATAPROC( uint buffer, IntPtr offset, IntPtr length );
		public delegate void PFNGLINVALIDATEBUFFERDATAPROC( uint buffer );
		public delegate void PFNGLINVALIDATEFRAMEBUFFERPROC( uint target, int numAttachments, IntPtr attachments );
		public delegate void PFNGLINVALIDATESUBFRAMEBUFFERPROC( uint target, int numAttachments, IntPtr attachments, int x, int y, int width, int height );
		public delegate void PFNGLMULTIDRAWARRAYSINDIRECTPROC( uint mode, void* indirect, int drawcount, int stride );
		public delegate void PFNGLMULTIDRAWELEMENTSINDIRECTPROC( uint mode, uint type, void* indirect, int drawcount, int stride );
		public delegate void PFNGLGETPROGRAMINTERFACEIVPROC( uint program, uint programInterface, uint pname, IntPtr @params );
		public delegate uint PFNGLGETPROGRAMRESOURCEINDEXPROC( uint program, uint programInterface, char* name );
		public delegate void PFNGLGETPROGRAMRESOURCENAMEPROC( uint program, uint programInterface, uint index, int bufSize, IntPtr length, char* name );
		public delegate void PFNGLGETPROGRAMRESOURCEIVPROC( uint program, uint programInterface, uint index, int propCount, IntPtr props, int count, IntPtr length, IntPtr @params );
		public delegate int PFNGLGETPROGRAMRESOURCELOCATIONPROC( uint program, uint programInterface, char* name );
		public delegate int PFNGLGETPROGRAMRESOURCELOCATIONINDEXPROC( uint program, uint programInterface, char* name );
		public delegate void PFNGLSHADERSTORAGEBLOCKBINDINGPROC( uint program, uint storageBlockIndex, uint storageBlockBinding );
		public delegate void PFNGLTEXBUFFERRANGEPROC( uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size );
		public delegate void PFNGLTEXSTORAGE2DMULTISAMPLEPROC( uint target, int samples, uint internalformat, int width, int height, bool fixedsamplelocations );
		public delegate void PFNGLTEXSTORAGE3DMULTISAMPLEPROC( uint target, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations );
		public delegate void PFNGLTEXTUREVIEWPROC( uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers );
		public delegate void PFNGLBINDVERTEXBUFFERPROC( uint bindingindex, uint buffer, IntPtr offset, int stride );
		public delegate void PFNGLVERTEXATTRIBFORMATPROC( uint attribindex, int size, uint type, bool normalized, uint relativeoffset );
		public delegate void PFNGLVERTEXATTRIBIFORMATPROC( uint attribindex, int size, uint type, uint relativeoffset );
		public delegate void PFNGLVERTEXATTRIBLFORMATPROC( uint attribindex, int size, uint type, uint relativeoffset );
		public delegate void PFNGLVERTEXATTRIBBINDINGPROC( uint attribindex, uint bindingindex );
		public delegate void PFNGLVERTEXBINDINGDIVISORPROC( uint bindingindex, uint divisor );
		public delegate void PFNGLDEBUGMESSAGECONTROLPROC( uint source, uint type, uint severity, int count, IntPtr ids, bool enabled );
		public delegate void PFNGLDEBUGMESSAGEINSERTPROC( uint source, uint type, uint id, uint severity, int length, char* buf );
		public delegate void PFNGLDEBUGMESSAGECALLBACKPROC( GLDEBUGPROC callback, void* userParam );
		public delegate uint PFNGLGETDEBUGMESSAGELOGPROC( uint count, int bufSize, IntPtr sources, IntPtr types, IntPtr ids, IntPtr severities, IntPtr lengths, char* messageLog );
		public delegate void PFNGLPUSHDEBUGGROUPPROC( uint source, uint id, int length, char* message );
		public delegate void PFNGLPOPDEBUGGROUPPROC();
		public delegate void PFNGLOBJECTLABELPROC( uint identifier, uint name, int length, char* label );
		public delegate void PFNGLGETOBJECTLABELPROC( uint identifier, uint name, int bufSize, IntPtr length, char* label );
		public delegate void PFNGLOBJECTPTRLABELPROC( void* ptr, int length, char* label );
		public delegate void PFNGLGETOBJECTPTRLABELPROC( void* ptr, int bufSize, IntPtr length, char* label );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLCLEARBUFFERDATAPROC glClearBufferData;
		public static PFNGLCLEARBUFFERSUBDATAPROC glClearBufferSubData;
		public static PFNGLDISPATCHCOMPUTEPROC glDispatchCompute;
		public static PFNGLDISPATCHCOMPUTEINDIRECTPROC glDispatchComputeIndirect;
		public static PFNGLCOPYIMAGESUBDATAPROC glCopyImageSubData;
		public static PFNGLFRAMEBUFFERPARAMETERIPROC glFramebufferParameteri;
		public static PFNGLGETFRAMEBUFFERPARAMETERIVPROC glGetFramebufferParameteriv;
		public static PFNGLGETINTERNALFORMATI64VPROC glGetInternalformati64v;
		public static PFNGLINVALIDATETEXSUBIMAGEPROC glInvalidateTexSubImage;
		public static PFNGLINVALIDATETEXIMAGEPROC glInvalidateTexImage;
		public static PFNGLINVALIDATEBUFFERSUBDATAPROC glInvalidateBufferSubData;
		public static PFNGLINVALIDATEBUFFERDATAPROC glInvalidateBufferData;
		public static PFNGLINVALIDATEFRAMEBUFFERPROC glInvalidateFramebuffer;
		public static PFNGLINVALIDATESUBFRAMEBUFFERPROC glInvalidateSubFramebuffer;
		public static PFNGLMULTIDRAWARRAYSINDIRECTPROC glMultiDrawArraysIndirect;
		public static PFNGLMULTIDRAWELEMENTSINDIRECTPROC glMultiDrawElementsIndirect;
		public static PFNGLGETPROGRAMINTERFACEIVPROC glGetProgramInterfaceiv;
		public static PFNGLGETPROGRAMRESOURCEINDEXPROC glGetProgramResourceIndex;
		public static PFNGLGETPROGRAMRESOURCENAMEPROC glGetProgramResourceName;
		public static PFNGLGETPROGRAMRESOURCEIVPROC glGetProgramResourceiv;
		public static PFNGLGETPROGRAMRESOURCELOCATIONPROC glGetProgramResourceLocation;
		public static PFNGLGETPROGRAMRESOURCELOCATIONINDEXPROC glGetProgramResourceLocationIndex;
		public static PFNGLSHADERSTORAGEBLOCKBINDINGPROC glShaderStorageBlockBinding;
		public static PFNGLTEXBUFFERRANGEPROC glTexBufferRange;
		public static PFNGLTEXSTORAGE2DMULTISAMPLEPROC glTexStorage2DMultisample;
		public static PFNGLTEXSTORAGE3DMULTISAMPLEPROC glTexStorage3DMultisample;
		public static PFNGLTEXTUREVIEWPROC glTextureView;
		public static PFNGLBINDVERTEXBUFFERPROC glBindVertexBuffer;
		public static PFNGLVERTEXATTRIBFORMATPROC glVertexAttribFormat;
		public static PFNGLVERTEXATTRIBIFORMATPROC glVertexAttribIFormat;
		public static PFNGLVERTEXATTRIBLFORMATPROC glVertexAttribLFormat;
		public static PFNGLVERTEXATTRIBBINDINGPROC glVertexAttribBinding;
		public static PFNGLVERTEXBINDINGDIVISORPROC glVertexBindingDivisor;
		public static PFNGLDEBUGMESSAGECONTROLPROC glDebugMessageControl;
		public static PFNGLDEBUGMESSAGEINSERTPROC glDebugMessageInsert;
		public static PFNGLDEBUGMESSAGECALLBACKPROC glDebugMessageCallback;
		public static PFNGLGETDEBUGMESSAGELOGPROC glGetDebugMessageLog;
		public static PFNGLPUSHDEBUGGROUPPROC glPushDebugGroup;
		public static PFNGLPOPDEBUGGROUPPROC glPopDebugGroup;
		public static PFNGLOBJECTLABELPROC glObjectLabel;
		public static PFNGLGETOBJECTLABELPROC glGetObjectLabel;
		public static PFNGLOBJECTPTRLABELPROC glObjectPtrLabel;
		public static PFNGLGETOBJECTPTRLABELPROC glGetObjectPtrLabel;
#endif
#endif // GL_VERSION_4_3
		#endregion

		#region OpenGL 4.4
#if GL_VERSION_4_4
		public const uint GL_MAX_VERTEX_ATTRIB_STRIDE = 0x82E5;
		public const uint GL_PRIMITIVE_RESTART_FOR_PATCHES_SUPPORTED = 0x8221;
		public const uint GL_TEXTURE_BUFFER_BINDING = 0x8C2A;
		public const uint GL_MAP_PERSISTENT_BIT = 0x0040;
		public const uint GL_MAP_COHERENT_BIT = 0x0080;
		public const uint GL_DYNAMIC_STORAGE_BIT = 0x0100;
		public const uint GL_CLIENT_STORAGE_BIT = 0x0200;
		public const uint GL_CLIENT_MAPPED_BUFFER_BARRIER_BIT = 0x00004000;
		public const uint GL_BUFFER_IMMUTABLE_STORAGE = 0x821F;
		public const uint GL_BUFFER_STORAGE_FLAGS = 0x8220;
		public const uint GL_CLEAR_TEXTURE = 0x9365;
		public const uint GL_LOCATION_COMPONENT = 0x934A;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_INDEX = 0x934B;
		public const uint GL_TRANSFORM_FEEDBACK_BUFFER_STRIDE = 0x934C;
		public const uint GL_QUERY_BUFFER = 0x9192;
		public const uint GL_QUERY_BUFFER_BARRIER_BIT = 0x00008000;
		public const uint GL_QUERY_BUFFER_BINDING = 0x9193;
		public const uint GL_QUERY_RESULT_NO_WAIT = 0x9194;
		public const uint GL_MIRROR_CLAMP_TO_EDGE = 0x8743;
		public delegate void PFNGLBUFFERSTORAGEPROC( uint target, IntPtr size, void* data, uint flags );
		public delegate void PFNGLCLEARTEXIMAGEPROC( uint texture, int level, uint format, uint type, void* data );
		public delegate void PFNGLCLEARTEXSUBIMAGEPROC( uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* data );
		public delegate void PFNGLBINDBUFFERSBASEPROC( uint target, uint first, int count, IntPtr buffers );
		public delegate void PFNGLBINDBUFFERSRANGEPROC( uint target, uint first, int count, IntPtr buffers, int** offsets, int** sizes );
		public delegate void PFNGLBINDTEXTURESPROC( uint first, int count, IntPtr textures );
		public delegate void PFNGLBINDSAMPLERSPROC( uint first, int count, IntPtr samplers );
		public delegate void PFNGLBINDIMAGETEXTURESPROC( uint first, int count, IntPtr textures );
		public delegate void PFNGLBINDVERTEXBUFFERSPROC( uint first, int count, IntPtr buffers, int** offsets, IntPtr strides );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLBUFFERSTORAGEPROC glBufferStorage;
		public static PFNGLCLEARTEXIMAGEPROC glClearTexImage;
		public static PFNGLCLEARTEXSUBIMAGEPROC glClearTexSubImage;
		public static PFNGLBINDBUFFERSBASEPROC glBindBuffersBase;
		public static PFNGLBINDBUFFERSRANGEPROC glBindBuffersRange;
		public static PFNGLBINDTEXTURESPROC glBindTextures;
		public static PFNGLBINDSAMPLERSPROC glBindSamplers;
		public static PFNGLBINDIMAGETEXTURESPROC glBindImageTextures;
		public static PFNGLBINDVERTEXBUFFERSPROC glBindVertexBuffers;
#endif
#endif // GL_VERSION_4_4
		#endregion

		#region OpenGL 4.5
#if GL_VERSION_4_5
		public const uint GL_CONTEXT_LOST = 0x0507;
		public const uint GL_NEGATIVE_ONE_TO_ONE = 0x935E;
		public const uint GL_ZERO_TO_ONE = 0x935F;
		public const uint GL_CLIP_ORIGIN = 0x935C;
		public const uint GL_CLIP_DEPTH_MODE = 0x935D;
		public const uint GL_QUERY_WAIT_INVERTED = 0x8E17;
		public const uint GL_QUERY_NO_WAIT_INVERTED = 0x8E18;
		public const uint GL_QUERY_BY_REGION_WAIT_INVERTED = 0x8E19;
		public const uint GL_QUERY_BY_REGION_NO_WAIT_INVERTED = 0x8E1A;
		public const uint GL_MAX_CULL_DISTANCES = 0x82F9;
		public const uint GL_MAX_COMBINED_CLIP_AND_CULL_DISTANCES = 0x82FA;
		public const uint GL_TEXTURE_TARGET = 0x1006;
		public const uint GL_QUERY_TARGET = 0x82EA;
		public const uint GL_GUILTY_CONTEXT_RESET = 0x8253;
		public const uint GL_INNOCENT_CONTEXT_RESET = 0x8254;
		public const uint GL_UNKNOWN_CONTEXT_RESET = 0x8255;
		public const uint GL_RESET_NOTIFICATION_STRATEGY = 0x8256;
		public const uint GL_LOSE_CONTEXT_ON_RESET = 0x8252;
		public const uint GL_NO_RESET_NOTIFICATION = 0x8261;
		public const uint GL_CONTEXT_FLAG_ROBUST_ACCESS_BIT = 0x00000004;
		public const uint GL_CONTEXT_RELEASE_BEHAVIOR = 0x82FB;
		public const uint GL_CONTEXT_RELEASE_BEHAVIOR_FLUSH = 0x82FC;
		public delegate void PFNGLCLIPCONTROLPROC( uint origin, uint depth );
		public delegate void PFNGLCREATETRANSFORMFEEDBACKSPROC( int n, IntPtr ids );
		public delegate void PFNGLTRANSFORMFEEDBACKBUFFERBASEPROC( uint xfb, uint index, uint buffer );
		public delegate void PFNGLTRANSFORMFEEDBACKBUFFERRANGEPROC( uint xfb, uint index, uint buffer, IntPtr offset, IntPtr size );
		public delegate void PFNGLGETTRANSFORMFEEDBACKIVPROC( uint xfb, uint pname, IntPtr param );
		public delegate void PFNGLGETTRANSFORMFEEDBACKI_VPROC( uint xfb, uint pname, uint index, IntPtr param );
		public delegate void PFNGLGETTRANSFORMFEEDBACKI64_VPROC( uint xfb, uint pname, uint index, long* param );
		public delegate void PFNGLCREATEBUFFERSPROC( int n, IntPtr buffers );
		public delegate void PFNGLNAMEDBUFFERSTORAGEPROC( uint buffer, IntPtr size, void* data, uint flags );
		public delegate void PFNGLNAMEDBUFFERDATAPROC( uint buffer, IntPtr size, void* data, uint usage );
		public delegate void PFNGLNAMEDBUFFERSUBDATAPROC( uint buffer, IntPtr offset, IntPtr size, void* data );
		public delegate void PFNGLCOPYNAMEDBUFFERSUBDATAPROC( uint readBuffer, uint writeBuffer, IntPtr readOffset, IntPtr writeOffset, IntPtr size );
		public delegate void PFNGLCLEARNAMEDBUFFERDATAPROC( uint buffer, uint internalformat, uint format, uint type, void* data );
		public delegate void PFNGLCLEARNAMEDBUFFERSUBDATAPROC( uint buffer, uint internalformat, IntPtr offset, IntPtr size, uint format, uint type, void* data );
		public delegate void* PFNGLMAPNAMEDBUFFERPROC( uint buffer, uint access );
		public delegate void* PFNGLMAPNAMEDBUFFERRANGEPROC( uint buffer, IntPtr offset, IntPtr length, uint access );
		public delegate bool PFNGLUNMAPNAMEDBUFFERPROC( uint buffer );
		public delegate void PFNGLFLUSHMAPPEDNAMEDBUFFERRANGEPROC( uint buffer, IntPtr offset, IntPtr length );
		public delegate void PFNGLGETNAMEDBUFFERPARAMETERIVPROC( uint buffer, uint pname, IntPtr @params );
		public delegate void PFNGLGETNAMEDBUFFERPARAMETERI64VPROC( uint buffer, uint pname, long* @params );
		public delegate void PFNGLGETNAMEDBUFFERPOINTERVPROC( uint buffer, uint pname, void** @params );
		public delegate void PFNGLGETNAMEDBUFFERSUBDATAPROC( uint buffer, IntPtr offset, IntPtr size, void* data );
		public delegate void PFNGLCREATEFRAMEBUFFERSPROC( int n, IntPtr framebuffers );
		public delegate void PFNGLNAMEDFRAMEBUFFERRENDERBUFFERPROC( uint framebuffer, uint attachment, uint renderbuffertarget, uint renderbuffer );
		public delegate void PFNGLNAMEDFRAMEBUFFERPARAMETERIPROC( uint framebuffer, uint pname, int param );
		public delegate void PFNGLNAMEDFRAMEBUFFERTEXTUREPROC( uint framebuffer, uint attachment, uint texture, int level );
		public delegate void PFNGLNAMEDFRAMEBUFFERTEXTURELAYERPROC( uint framebuffer, uint attachment, uint texture, int level, int layer );
		public delegate void PFNGLNAMEDFRAMEBUFFERDRAWBUFFERPROC( uint framebuffer, uint buf );
		public delegate void PFNGLNAMEDFRAMEBUFFERDRAWBUFFERSPROC( uint framebuffer, int n, IntPtr bufs );
		public delegate void PFNGLNAMEDFRAMEBUFFERREADBUFFERPROC( uint framebuffer, uint src );
		public delegate void PFNGLINVALIDATENAMEDFRAMEBUFFERDATAPROC( uint framebuffer, int numAttachments, IntPtr attachments );
		public delegate void PFNGLINVALIDATENAMEDFRAMEBUFFERSUBDATAPROC( uint framebuffer, int numAttachments, IntPtr attachments, int x, int y, int width, int height );
		public delegate void PFNGLCLEARNAMEDFRAMEBUFFERIVPROC( uint framebuffer, uint buffer, int drawbuffer, IntPtr value );
		public delegate void PFNGLCLEARNAMEDFRAMEBUFFERUIVPROC( uint framebuffer, uint buffer, int drawbuffer, IntPtr value );
		public delegate void PFNGLCLEARNAMEDFRAMEBUFFERFVPROC( uint framebuffer, uint buffer, int drawbuffer, float* value );
		public delegate void PFNGLCLEARNAMEDFRAMEBUFFERFIPROC( uint framebuffer, uint buffer, int drawbuffer, float depth, int stencil );
		public delegate void PFNGLBLITNAMEDFRAMEBUFFERPROC( uint readFramebuffer, uint drawFramebuffer, int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter );
		public delegate uint PFNGLCHECKNAMEDFRAMEBUFFERSTATUSPROC( uint framebuffer, uint target );
		public delegate void PFNGLGETNAMEDFRAMEBUFFERPARAMETERIVPROC( uint framebuffer, uint pname, IntPtr param );
		public delegate void PFNGLGETNAMEDFRAMEBUFFERATTACHMENTPARAMETERIVPROC( uint framebuffer, uint attachment, uint pname, IntPtr @params );
		public delegate void PFNGLCREATERENDERBUFFERSPROC( int n, IntPtr renderbuffers );
		public delegate void PFNGLNAMEDRENDERBUFFERSTORAGEPROC( uint renderbuffer, uint internalformat, int width, int height );
		public delegate void PFNGLNAMEDRENDERBUFFERSTORAGEMULTISAMPLEPROC( uint renderbuffer, int samples, uint internalformat, int width, int height );
		public delegate void PFNGLGETNAMEDRENDERBUFFERPARAMETERIVPROC( uint renderbuffer, uint pname, IntPtr @params );
		public delegate void PFNGLCREATETEXTURESPROC( uint target, int n, IntPtr textures );
		public delegate void PFNGLTEXTUREBUFFERPROC( uint texture, uint internalformat, uint buffer );
		public delegate void PFNGLTEXTUREBUFFERRANGEPROC( uint texture, uint internalformat, uint buffer, IntPtr offset, IntPtr size );
		public delegate void PFNGLTEXTURESTORAGE1DPROC( uint texture, int levels, uint internalformat, int width );
		public delegate void PFNGLTEXTURESTORAGE2DPROC( uint texture, int levels, uint internalformat, int width, int height );
		public delegate void PFNGLTEXTURESTORAGE3DPROC( uint texture, int levels, uint internalformat, int width, int height, int depth );
		public delegate void PFNGLTEXTURESTORAGE2DMULTISAMPLEPROC( uint texture, int samples, uint internalformat, int width, int height, bool fixedsamplelocations );
		public delegate void PFNGLTEXTURESTORAGE3DMULTISAMPLEPROC( uint texture, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations );
		public delegate void PFNGLTEXTURESUBIMAGE1DPROC( uint texture, int level, int xoffset, int width, uint format, uint type, void* pixels );
		public delegate void PFNGLTEXTURESUBIMAGE2DPROC( uint texture, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, void* pixels );
		public delegate void PFNGLTEXTURESUBIMAGE3DPROC( uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, void* pixels );
		public delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE1DPROC( uint texture, int level, int xoffset, int width, uint format, int imageSize, void* data );
		public delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE2DPROC( uint texture, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, void* data );
		public delegate void PFNGLCOMPRESSEDTEXTURESUBIMAGE3DPROC( uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, void* data );
		public delegate void PFNGLCOPYTEXTURESUBIMAGE1DPROC( uint texture, int level, int xoffset, int x, int y, int width );
		public delegate void PFNGLCOPYTEXTURESUBIMAGE2DPROC( uint texture, int level, int xoffset, int yoffset, int x, int y, int width, int height );
		public delegate void PFNGLCOPYTEXTURESUBIMAGE3DPROC( uint texture, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height );
		public delegate void PFNGLTEXTUREPARAMETERFPROC( uint texture, uint pname, float param );
		public delegate void PFNGLTEXTUREPARAMETERFVPROC( uint texture, uint pname, float* param );
		public delegate void PFNGLTEXTUREPARAMETERIPROC( uint texture, uint pname, int param );
		public delegate void PFNGLTEXTUREPARAMETERIIVPROC( uint texture, uint pname, IntPtr @params );
		public delegate void PFNGLTEXTUREPARAMETERIUIVPROC( uint texture, uint pname, IntPtr @params );
		public delegate void PFNGLTEXTUREPARAMETERIVPROC( uint texture, uint pname, IntPtr param );
		public delegate void PFNGLGENERATETEXTUREMIPMAPPROC( uint texture );
		public delegate void PFNGLBINDTEXTUREUNITPROC( uint unit, uint texture );
		public delegate void PFNGLGETTEXTUREIMAGEPROC( uint texture, int level, uint format, uint type, int bufSize, void* pixels );
		public delegate void PFNGLGETCOMPRESSEDTEXTUREIMAGEPROC( uint texture, int level, int bufSize, void* pixels );
		public delegate void PFNGLGETTEXTURELEVELPARAMETERFVPROC( uint texture, int level, uint pname, float* @params );
		public delegate void PFNGLGETTEXTURELEVELPARAMETERIVPROC( uint texture, int level, uint pname, IntPtr @params );
		public delegate void PFNGLGETTEXTUREPARAMETERFVPROC( uint texture, uint pname, float* @params );
		public delegate void PFNGLGETTEXTUREPARAMETERIIVPROC( uint texture, uint pname, IntPtr @params );
		public delegate void PFNGLGETTEXTUREPARAMETERIUIVPROC( uint texture, uint pname, IntPtr @params );
		public delegate void PFNGLGETTEXTUREPARAMETERIVPROC( uint texture, uint pname, IntPtr @params );
		public delegate void PFNGLCREATEVERTEXARRAYSPROC( int n, IntPtr arrays );
		public delegate void PFNGLDISABLEVERTEXARRAYATTRIBPROC( uint vaobj, uint index );
		public delegate void PFNGLENABLEVERTEXARRAYATTRIBPROC( uint vaobj, uint index );
		public delegate void PFNGLVERTEXARRAYELEMENTBUFFERPROC( uint vaobj, uint buffer );
		public delegate void PFNGLVERTEXARRAYVERTEXBUFFERPROC( uint vaobj, uint bindingindex, uint buffer, IntPtr offset, int stride );
		public delegate void PFNGLVERTEXARRAYVERTEXBUFFERSPROC( uint vaobj, uint first, int count, IntPtr buffers, int** offsets, IntPtr strides );
		public delegate void PFNGLVERTEXARRAYATTRIBBINDINGPROC( uint vaobj, uint attribindex, uint bindingindex );
		public delegate void PFNGLVERTEXARRAYATTRIBFORMATPROC( uint vaobj, uint attribindex, int size, uint type, bool normalized, uint relativeoffset );
		public delegate void PFNGLVERTEXARRAYATTRIBIFORMATPROC( uint vaobj, uint attribindex, int size, uint type, uint relativeoffset );
		public delegate void PFNGLVERTEXARRAYATTRIBLFORMATPROC( uint vaobj, uint attribindex, int size, uint type, uint relativeoffset );
		public delegate void PFNGLVERTEXARRAYBINDINGDIVISORPROC( uint vaobj, uint bindingindex, uint divisor );
		public delegate void PFNGLGETVERTEXARRAYIVPROC( uint vaobj, uint pname, IntPtr param );
		public delegate void PFNGLGETVERTEXARRAYINDEXEDIVPROC( uint vaobj, uint index, uint pname, IntPtr param );
		public delegate void PFNGLGETVERTEXARRAYINDEXED64IVPROC( uint vaobj, uint index, uint pname, long* param );
		public delegate void PFNGLCREATESAMPLERSPROC( int n, IntPtr samplers );
		public delegate void PFNGLCREATEPROGRAMPIPELINESPROC( int n, IntPtr pipelines );
		public delegate void PFNGLCREATEQUERIESPROC( uint target, int n, IntPtr ids );
		public delegate void PFNGLGETQUERYBUFFEROBJECTI64VPROC( uint id, uint buffer, uint pname, IntPtr offset );
		public delegate void PFNGLGETQUERYBUFFEROBJECTIVPROC( uint id, uint buffer, uint pname, IntPtr offset );
		public delegate void PFNGLGETQUERYBUFFEROBJECTUI64VPROC( uint id, uint buffer, uint pname, IntPtr offset );
		public delegate void PFNGLGETQUERYBUFFEROBJECTUIVPROC( uint id, uint buffer, uint pname, IntPtr offset );
		public delegate void PFNGLMEMORYBARRIERBYREGIONPROC( uint barriers );
		public delegate void PFNGLGETTEXTURESUBIMAGEPROC( uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, int bufSize, void* pixels );
		public delegate void PFNGLGETCOMPRESSEDTEXTURESUBIMAGEPROC( uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, int bufSize, void* pixels );
		public delegate uint PFNGLGETGRAPHICSRESETSTATUSPROC();
		public delegate void PFNGLGETNCOMPRESSEDTEXIMAGEPROC( uint target, int lod, int bufSize, void* pixels );
		public delegate void PFNGLGETNTEXIMAGEPROC( uint target, int level, uint format, uint type, int bufSize, void* pixels );
		public delegate void PFNGLGETNUNIFORMDVPROC( uint program, int location, int bufSize, double* @params );
		public delegate void PFNGLGETNUNIFORMFVPROC( uint program, int location, int bufSize, float* @params );
		public delegate void PFNGLGETNUNIFORMIVPROC( uint program, int location, int bufSize, IntPtr @params );
		public delegate void PFNGLGETNUNIFORMUIVPROC( uint program, int location, int bufSize, IntPtr @params );
		public delegate void PFNGLREADNPIXELSPROC( int x, int y, int width, int height, uint format, uint type, int bufSize, void* data );
		public delegate void PFNGLTEXTUREBARRIERPROC();
#if GL_GLEXT_PROTOTYPES
		public static PFNGLCLIPCONTROLPROC glClipControl;
		public static PFNGLCREATETRANSFORMFEEDBACKSPROC glCreateTransformFeedbacks;
		public static PFNGLTRANSFORMFEEDBACKBUFFERBASEPROC glTransformFeedbackBufferBase;
		public static PFNGLTRANSFORMFEEDBACKBUFFERRANGEPROC glTransformFeedbackBufferRange;
		public static PFNGLGETTRANSFORMFEEDBACKIVPROC glGetTransformFeedbackiv;
		public static PFNGLGETTRANSFORMFEEDBACKI_VPROC glGetTransformFeedbacki_v;
		public static PFNGLGETTRANSFORMFEEDBACKI64_VPROC glGetTransformFeedbacki64_v;
		public static PFNGLCREATEBUFFERSPROC glCreateBuffers;
		public static PFNGLNAMEDBUFFERSTORAGEPROC glNamedBufferStorage;
		public static PFNGLNAMEDBUFFERDATAPROC glNamedBufferData;
		public static PFNGLNAMEDBUFFERSUBDATAPROC glNamedBufferSubData;
		public static PFNGLCOPYNAMEDBUFFERSUBDATAPROC glCopyNamedBufferSubData;
		public static PFNGLCLEARNAMEDBUFFERDATAPROC glClearNamedBufferData;
		public static PFNGLCLEARNAMEDBUFFERSUBDATAPROC glClearNamedBufferSubData;
		public static PFNGLMAPNAMEDBUFFERPROC glMapNamedBuffer;
		public static PFNGLMAPNAMEDBUFFERRANGEPROC glMapNamedBufferRange;
		public static PFNGLUNMAPNAMEDBUFFERPROC glUnmapNamedBuffer;
		public static PFNGLFLUSHMAPPEDNAMEDBUFFERRANGEPROC glFlushMappedNamedBufferRange;
		public static PFNGLGETNAMEDBUFFERPARAMETERIVPROC glGetNamedBufferParameteriv;
		public static PFNGLGETNAMEDBUFFERPARAMETERI64VPROC glGetNamedBufferParameteri64v;
		public static PFNGLGETNAMEDBUFFERPOINTERVPROC glGetNamedBufferPointerv;
		public static PFNGLGETNAMEDBUFFERSUBDATAPROC glGetNamedBufferSubData;
		public static PFNGLCREATEFRAMEBUFFERSPROC glCreateFramebuffers;
		public static PFNGLNAMEDFRAMEBUFFERRENDERBUFFERPROC glNamedFramebufferRenderbuffer;
		public static PFNGLNAMEDFRAMEBUFFERPARAMETERIPROC glNamedFramebufferParameteri;
		public static PFNGLNAMEDFRAMEBUFFERTEXTUREPROC glNamedFramebufferTexture;
		public static PFNGLNAMEDFRAMEBUFFERTEXTURELAYERPROC glNamedFramebufferTextureLayer;
		public static PFNGLNAMEDFRAMEBUFFERDRAWBUFFERPROC glNamedFramebufferDrawBuffer;
		public static PFNGLNAMEDFRAMEBUFFERDRAWBUFFERSPROC glNamedFramebufferDrawBuffers;
		public static PFNGLNAMEDFRAMEBUFFERREADBUFFERPROC glNamedFramebufferReadBuffer;
		public static PFNGLINVALIDATENAMEDFRAMEBUFFERDATAPROC glInvalidateNamedFramebufferData;
		public static PFNGLINVALIDATENAMEDFRAMEBUFFERSUBDATAPROC glInvalidateNamedFramebufferSubData;
		public static PFNGLCLEARNAMEDFRAMEBUFFERIVPROC glClearNamedFramebufferiv;
		public static PFNGLCLEARNAMEDFRAMEBUFFERUIVPROC glClearNamedFramebufferuiv;
		public static PFNGLCLEARNAMEDFRAMEBUFFERFVPROC glClearNamedFramebufferfv;
		public static PFNGLCLEARNAMEDFRAMEBUFFERFIPROC glClearNamedFramebufferfi;
		public static PFNGLBLITNAMEDFRAMEBUFFERPROC glBlitNamedFramebuffer;
		public static PFNGLCHECKNAMEDFRAMEBUFFERSTATUSPROC glCheckNamedFramebufferStatus;
		public static PFNGLGETNAMEDFRAMEBUFFERPARAMETERIVPROC glGetNamedFramebufferParameteriv;
		public static PFNGLGETNAMEDFRAMEBUFFERATTACHMENTPARAMETERIVPROC glGetNamedFramebufferAttachmentParameteriv;
		public static PFNGLCREATERENDERBUFFERSPROC glCreateRenderbuffers;
		public static PFNGLNAMEDRENDERBUFFERSTORAGEPROC glNamedRenderbufferStorage;
		public static PFNGLNAMEDRENDERBUFFERSTORAGEMULTISAMPLEPROC glNamedRenderbufferStorageMultisample;
		public static PFNGLGETNAMEDRENDERBUFFERPARAMETERIVPROC glGetNamedRenderbufferParameteriv;
		public static PFNGLCREATETEXTURESPROC glCreateTextures;
		public static PFNGLTEXTUREBUFFERPROC glTextureBuffer;
		public static PFNGLTEXTUREBUFFERRANGEPROC glTextureBufferRange;
		public static PFNGLTEXTURESTORAGE1DPROC glTextureStorage1D;
		public static PFNGLTEXTURESTORAGE2DPROC glTextureStorage2D;
		public static PFNGLTEXTURESTORAGE3DPROC glTextureStorage3D;
		public static PFNGLTEXTURESTORAGE2DMULTISAMPLEPROC glTextureStorage2DMultisample;
		public static PFNGLTEXTURESTORAGE3DMULTISAMPLEPROC glTextureStorage3DMultisample;
		public static PFNGLTEXTURESUBIMAGE1DPROC glTextureSubImage1D;
		public static PFNGLTEXTURESUBIMAGE2DPROC glTextureSubImage2D;
		public static PFNGLTEXTURESUBIMAGE3DPROC glTextureSubImage3D;
		public static PFNGLCOMPRESSEDTEXTURESUBIMAGE1DPROC glCompressedTextureSubImage1D;
		public static PFNGLCOMPRESSEDTEXTURESUBIMAGE2DPROC glCompressedTextureSubImage2D;
		public static PFNGLCOMPRESSEDTEXTURESUBIMAGE3DPROC glCompressedTextureSubImage3D;
		public static PFNGLCOPYTEXTURESUBIMAGE1DPROC glCopyTextureSubImage1D;
		public static PFNGLCOPYTEXTURESUBIMAGE2DPROC glCopyTextureSubImage2D;
		public static PFNGLCOPYTEXTURESUBIMAGE3DPROC glCopyTextureSubImage3D;
		public static PFNGLTEXTUREPARAMETERFPROC glTextureParameterf;
		public static PFNGLTEXTUREPARAMETERFVPROC glTextureParameterfv;
		public static PFNGLTEXTUREPARAMETERIPROC glTextureParameteri;
		public static PFNGLTEXTUREPARAMETERIIVPROC glTextureParameterIiv;
		public static PFNGLTEXTUREPARAMETERIUIVPROC glTextureParameterIuiv;
		public static PFNGLTEXTUREPARAMETERIVPROC glTextureParameteriv;
		public static PFNGLGENERATETEXTUREMIPMAPPROC glGenerateTextureMipmap;
		public static PFNGLBINDTEXTUREUNITPROC glBindTextureUnit;
		public static PFNGLGETTEXTUREIMAGEPROC glGetTextureImage;
		public static PFNGLGETCOMPRESSEDTEXTUREIMAGEPROC glGetCompressedTextureImage;
		public static PFNGLGETTEXTURELEVELPARAMETERFVPROC glGetTextureLevelParameterfv;
		public static PFNGLGETTEXTURELEVELPARAMETERIVPROC glGetTextureLevelParameteriv;
		public static PFNGLGETTEXTUREPARAMETERFVPROC glGetTextureParameterfv;
		public static PFNGLGETTEXTUREPARAMETERIIVPROC glGetTextureParameterIiv;
		public static PFNGLGETTEXTUREPARAMETERIUIVPROC glGetTextureParameterIuiv;
		public static PFNGLGETTEXTUREPARAMETERIVPROC glGetTextureParameteriv;
		public static PFNGLCREATEVERTEXARRAYSPROC glCreateVertexArrays;
		public static PFNGLDISABLEVERTEXARRAYATTRIBPROC glDisableVertexArrayAttrib;
		public static PFNGLENABLEVERTEXARRAYATTRIBPROC glEnableVertexArrayAttrib;
		public static PFNGLVERTEXARRAYELEMENTBUFFERPROC glVertexArrayElementBuffer;
		public static PFNGLVERTEXARRAYVERTEXBUFFERPROC glVertexArrayVertexBuffer;
		public static PFNGLVERTEXARRAYVERTEXBUFFERSPROC glVertexArrayVertexBuffers;
		public static PFNGLVERTEXARRAYATTRIBBINDINGPROC glVertexArrayAttribBinding;
		public static PFNGLVERTEXARRAYATTRIBFORMATPROC glVertexArrayAttribFormat;
		public static PFNGLVERTEXARRAYATTRIBIFORMATPROC glVertexArrayAttribIFormat;
		public static PFNGLVERTEXARRAYATTRIBLFORMATPROC glVertexArrayAttribLFormat;
		public static PFNGLVERTEXARRAYBINDINGDIVISORPROC glVertexArrayBindingDivisor;
		public static PFNGLGETVERTEXARRAYIVPROC glGetVertexArrayiv;
		public static PFNGLGETVERTEXARRAYINDEXEDIVPROC glGetVertexArrayIndexediv;
		public static PFNGLGETVERTEXARRAYINDEXED64IVPROC glGetVertexArrayIndexed64iv;
		public static PFNGLCREATESAMPLERSPROC glCreateSamplers;
		public static PFNGLCREATEPROGRAMPIPELINESPROC glCreateProgramPipelines;
		public static PFNGLCREATEQUERIESPROC glCreateQueries;
		public static PFNGLGETQUERYBUFFEROBJECTI64VPROC glGetQueryBufferObjecti64v;
		public static PFNGLGETQUERYBUFFEROBJECTIVPROC glGetQueryBufferObjectiv;
		public static PFNGLGETQUERYBUFFEROBJECTUI64VPROC glGetQueryBufferObjectui64v;
		public static PFNGLGETQUERYBUFFEROBJECTUIVPROC glGetQueryBufferObjectuiv;
		public static PFNGLMEMORYBARRIERBYREGIONPROC glMemoryBarrierByRegion;
		public static PFNGLGETTEXTURESUBIMAGEPROC glGetTextureSubImage;
		public static PFNGLGETCOMPRESSEDTEXTURESUBIMAGEPROC glGetCompressedTextureSubImage;
		public static PFNGLGETGRAPHICSRESETSTATUSPROC glGetGraphicsResetStatus;
		public static PFNGLGETNCOMPRESSEDTEXIMAGEPROC glGetnCompressedTexImage;
		public static PFNGLGETNTEXIMAGEPROC glGetnTexImage;
		public static PFNGLGETNUNIFORMDVPROC glGetnUniformdv;
		public static PFNGLGETNUNIFORMFVPROC glGetnUniformfv;
		public static PFNGLGETNUNIFORMIVPROC glGetnUniformiv;
		public static PFNGLGETNUNIFORMUIVPROC glGetnUniformuiv;
		public static PFNGLREADNPIXELSPROC glReadnPixels;
		public static PFNGLTEXTUREBARRIERPROC glTextureBarrier;
#endif
#endif // GL_VERSION_4_5
		#endregion

		#region OpenGL 4.6
#if GL_VERSION_4_6
		public const uint GL_SHADER_BINARY_FORMAT_SPIR_V = 0x9551;
		public const uint GL_SPIR_V_BINARY = 0x9552;
		public const uint GL_PARAMETER_BUFFER = 0x80EE;
		public const uint GL_PARAMETER_BUFFER_BINDING = 0x80EF;
		public const uint GL_CONTEXT_FLAG_NO_ERROR_BIT = 0x00000008;
		public const uint GL_VERTICES_SUBMITTED = 0x82EE;
		public const uint GL_PRIMITIVES_SUBMITTED = 0x82EF;
		public const uint GL_VERTEX_SHADER_INVOCATIONS = 0x82F0;
		public const uint GL_TESS_CONTROL_SHADER_PATCHES = 0x82F1;
		public const uint GL_TESS_EVALUATION_SHADER_INVOCATIONS = 0x82F2;
		public const uint GL_GEOMETRY_SHADER_PRIMITIVES_EMITTED = 0x82F3;
		public const uint GL_FRAGMENT_SHADER_INVOCATIONS = 0x82F4;
		public const uint GL_COMPUTE_SHADER_INVOCATIONS = 0x82F5;
		public const uint GL_CLIPPING_INPUT_PRIMITIVES = 0x82F6;
		public const uint GL_CLIPPING_OUTPUT_PRIMITIVES = 0x82F7;
		public const uint GL_POLYGON_OFFSET_CLAMP = 0x8E1B;
		public const uint GL_SPIR_V_EXTENSIONS = 0x9553;
		public const uint GL_NUM_SPIR_V_EXTENSIONS = 0x9554;
		public const uint GL_TEXTURE_MAX_ANISOTROPY = 0x84FE;
		public const uint GL_MAX_TEXTURE_MAX_ANISOTROPY = 0x84FF;
		public const uint GL_TRANSFORM_FEEDBACK_OVERFLOW = 0x82EC;
		public const uint GL_TRANSFORM_FEEDBACK_STREAM_OVERFLOW = 0x82ED;
		public delegate void PFNGLSPECIALIZESHADERPROC( uint shader, char* pEntryPoint, uint numSpecializationConstants, IntPtr pConstantIndex, IntPtr pConstantValue );
		public delegate void PFNGLMULTIDRAWARRAYSINDIRECTCOUNTPROC( uint mode, void* indirect, IntPtr drawcount, int maxdrawcount, int stride );
		public delegate void PFNGLMULTIDRAWELEMENTSINDIRECTCOUNTPROC( uint mode, uint type, void* indirect, IntPtr drawcount, int maxdrawcount, int stride );
		public delegate void PFNGLPOLYGONOFFSETCLAMPPROC( float factor, float units, float clamp );
#if GL_GLEXT_PROTOTYPES
		public static PFNGLSPECIALIZESHADERPROC glSpecializeShader;
		public static PFNGLMULTIDRAWARRAYSINDIRECTCOUNTPROC glMultiDrawArraysIndirectCount;
		public static PFNGLMULTIDRAWELEMENTSINDIRECTCOUNTPROC glMultiDrawElementsIndirectCount;
		public static PFNGLPOLYGONOFFSETCLAMPPROC glPolygonOffsetClamp;
#endif
#endif // GL_VERSION_4_6
		#endregion
		#endregion

		#region Legacy Binding
#if GL_LEGACY_PIPELINE
		public const uint GL_LIGHTING = 0x0B50;
		public const uint GL_ALPHA_TEST = 0x0BC0;
		public const uint GL_LIGHT0 = 0x4000;
		public const uint GL_LIGHT1 = 0x4001;
		public const uint GL_POINT_SMOOTH = 0x0B10;
		public const uint GL_LINE_STIPPLE = 0x0B24;
		public const uint GL_COLOR_MATERIAL = 0x0B57;
		public const uint GL_NORMALIZE = 0x0BA1;
		public const uint GL_RESCALE_NORMAL = 0x803A;
		public const uint GL_POLYGON_STIPPLE = 0x0B42;
		public const uint GL_NORMAL_ARRAY = 0x8075;
		public const uint GL_COLOR_ARRAY = 0x8076;
		public const uint GL_TEXTURE_COORD_ARRAY = 0x8078;
		public const uint GL_CURRENT_COLOR = 0x0B00;
		public const uint GL_CURRENT_NORMAL = 0x0B02;
		public const uint GL_CURRENT_TEXTURE_COORDS = 0x0B03;
		public const uint GL_CURRENT_RASTER_COLOR = 0x0B04;
		public const uint GL_CURRENT_RASTER_TEXTURE_COORDS = 0x0B06;
		public const uint GL_LIGHT_MODEL_AMBIENT = 0x0B53;
		public const uint GL_ALPHA_TEST_REF = 0x0BC2;
		public const uint GL_MATRIX_MODE = 0x0BA0;
		public const uint GL_MODELVIEW_STACK_DEPTH = 0x0BA3;
		public const uint GL_PROJECTION_STACK_DEPTH = 0x0BA4;
		public const uint GL_MODELVIEW_MATRIX = 0x0BA6;
		public const uint GL_PROJECTION_MATRIX = 0x0BA7;
		public const uint GL_LINE_STIPPLE_PATTERN = 0x0B25;
		public const uint GL_LINE_STIPPLE_REPEAT = 0x0B26;
		public const uint GL_MAX_LIST_NESTING = 0x0B31;
		public const uint GL_LIST_BASE = 0x0B32;
		public const uint GL_ALPHA_TEST_FUNC = 0x0BC1;
		public const uint GL_PERSPECTIVE_CORRECTION_HINT = 0x0C50;
		public const uint GL_POINT_SMOOTH_HINT = 0x0C51;
		public const uint GL_MAX_LIGHTS = 0x0D31;
		public const uint GL_MAX_MODELVIEW_STACK_DEPTH = 0x0D36;
		public const uint GL_MAX_PROJECTION_STACK_DEPTH = 0x0D38;
		public const uint GL_RED_BITS = 0x0D52;
		public const uint GL_GREEN_BITS = 0x0D53;
		public const uint GL_BLUE_BITS = 0x0D54;
		public const uint GL_ALPHA_BITS = 0x0D55;
		public const uint GL_DEPTH_BITS = 0x0D56;
		public const uint GL_STENCIL_BITS = 0x0D57;
		public const uint GL_VERTEX_ARRAY_SIZE = 0x807A;
		public const uint GL_VERTEX_ARRAY_TYPE = 0x807B;
		public const uint GL_VERTEX_ARRAY_STRIDE = 0x807C;
		public const uint GL_NORMAL_ARRAY_TYPE = 0x807E;
		public const uint GL_NORMAL_ARRAY_STRIDE = 0x807F;
		public const uint GL_COLOR_ARRAY_SIZE = 0x8081;
		public const uint GL_COLOR_ARRAY_TYPE = 0x8082;
		public const uint GL_COLOR_ARRAY_STRIDE = 0x8083;
		public const uint GL_TEXTURE_COORD_ARRAY_SIZE = 0x8088;
		public const uint GL_TEXTURE_COORD_ARRAY_TYPE = 0x8089;
		public const uint GL_TEXTURE_COORD_ARRAY_STRIDE = 0x808A;
		public const uint GL_SHADE_MODEL = 0x0B54;
		public const uint GL_CLIENT_ACTIVE_TEXTURE = 0x84E1;
		public const uint GL_MAX_TEXTURE_UNITS = 0x84E2;
		public const uint GL_AMBIENT = 0x1200;
		public const uint GL_DIFFUSE = 0x1201;
		public const uint GL_SPECULAR = 0x1202;
		public const uint GL_EMISSION = 0x1600;
		public const uint GL_SHININESS = 0x1601;
		public const uint GL_POSITION = 0x1203;
		public const uint GL_VERTEX_ARRAY_POINTER = 0x808E;
		public const uint GL_NORMAL_ARRAY_POINTER = 0x808F;
		public const uint GL_COLOR_ARRAY_POINTER = 0x8090;
		public const uint GL_TEXTURE_COORD_ARRAY_POINTER = 0x8092;
		public const uint GL_TEXTURE_ENV_MODE = 0x2200;
		public const uint GL_TEXTURE_ENV_COLOR = 0x2201;
		public const uint GL_MODELVIEW = 0x1700;
		public const uint GL_PROJECTION = 0x1701;
		public const uint GL_LUMINANCE = 0x1909;
		public const uint GL_LUMINANCE_ALPHA = 0x190A;
		public const uint GL_COLOR_INDEX = 0x1900;
		public const uint GL_FLAT = 0x1D00;
		public const uint GL_SMOOTH = 0x1D01;
		public const uint GL_VERSION = 0x1F02;
		public const uint GL_MODULATE = 0x2100;
		public const uint GL_DECAL = 0x2101;
		public const uint GL_ADD = 0x0104;
		public const uint GL_TEXTURE_ENV = 0x2300;

		public delegate void PFNGLALPHAFUNCPROC( uint func, float @ref );
		public delegate void PFNGLBEGINPROC( uint mode );
		public delegate void PFNGLBITMAPPROC( IntPtr width, IntPtr height, float xorig, float yorig, float xmove, float ymove, byte* bitmap );
		public delegate void PFNGLCALLLISTSPROC( IntPtr n, uint type, void* lists );
		public delegate void PFNGLCLIENTACTIVETEXTUREPROC( uint texture );
		public delegate void PFNGLCOLOR4FPROC( float red, float green, float blue, float alpha );
		public delegate void PFNGLCOLOR4FVPROC( float* v );
		public delegate void PFNGLCOLOR4UBPROC( byte red, byte green, byte blue, byte alpha );
		public delegate void PFNGLCOLORPOINTERPROC( int size, uint type, IntPtr stride, void* pointer );
		public delegate void PFNGLCOPYPIXELSPROC( int x, int y, IntPtr width, IntPtr height, uint type );
		public delegate void PFNGLDISABLECLIENTSTATEPROC( uint array );
		public delegate void PFNGLDRAWPIXELSPROC( IntPtr width, IntPtr height, uint format, uint type, void* pixels );
		public delegate void PFNGLENABLECLIENTSTATEPROC( uint array );
		public delegate void PFNGLENDPROC();
		public delegate void PFNGLENDLISTPROC();
		public delegate void PFNGLFRUSTUMFPROC( float left, float right, float bottom, float top, float zNear, float zFar );
		public delegate uint PFNGLGENLISTSPROC( IntPtr range );
		public delegate void PFNGLGETLIGHTFVPROC( uint light, uint pname, float* @params );
		public delegate void PFNGLGETMATERIALFVPROC( uint face, uint pname, float* @params );
		public delegate void PFNGLGETPOLYGONSTIPPLEPROC( byte* mask );
		public delegate void PFNGLGETTEXENVFVPROC( uint target, uint pname, float* @params );
		public delegate void PFNGLGETTEXENVIVPROC( uint target, uint pname, IntPtr @params );
		public delegate void PFNGLLIGHTFVPROC( uint light, uint pname, float* @params );
		public delegate void PFNGLLIGHTMODELFPROC( uint pname, float param );
		public delegate void PFNGLLIGHTMODELFVPROC( uint pname, float* @params );
		public delegate void PFNGLLINESTIPPLEPROC( int factor, ushort pattern );
		public delegate void PFNGLLISTBASEPROC( uint @base );
		public delegate void PFNGLLOADIDENTITYPROC();
		public delegate void PFNGLLOADMATRIXFPROC( float* m );
		public delegate void PFNGLMATERIALFPROC( uint face, uint pname, float param );
		public delegate void PFNGLMATERIALFVPROC( uint face, uint pname, float* @params );
		public delegate void PFNGLMATRIXMODEPROC( uint mode );
		public delegate void PFNGLMULTMATRIXFPROC( float* m );
		public delegate void PFNGLMULTITEXCOORD2FPROC( uint target, float s, float t );
		public delegate void PFNGLNEWLISTPROC( uint list, uint mode );
		public delegate void PFNGLNORMAL3FPROC( float nx, float ny, float nz );
		public delegate void PFNGLNORMAL3FVPROC( float* v );
		public delegate void PFNGLNORMALPOINTERPROC( uint type, IntPtr stride, void* pointer );
		public delegate void PFNGLORTHOFPROC( float left, float right, float bottom, float top, float zNear, float zFar );
		public delegate void PFNGLPOLYGONSTIPPLEPROC( byte* mask );
		public delegate void PFNGLPOPMATRIXPROC();
		public delegate void PFNGLPUSHMATRIXPROC();
		public delegate void PFNGLRASTERPOS3FPROC( float x, float y, float z );
		public delegate void PFNGLROTATEFPROC( float angle, float x, float y, float z );
		public delegate void PFNGLSCALEFPROC( float x, float y, float z );
		public delegate void PFNGLSHADEMODELPROC( uint mode );
		public delegate void PFNGLTEXCOORDPOINTERPROC( int size, uint type, IntPtr stride, void* pointer );
		public delegate void PFNGLTEXENVFVPROC( uint target, uint pname, float* @params );
		public delegate void PFNGLTEXENVIPROC( uint target, uint pname, int param );
		public delegate void PFNGLTRANSLATEFPROC( float x, float y, float z );
		public delegate void PFNGLVERTEX2FPROC( float x, float y );
		public delegate void PFNGLVERTEX2FVPROC( float* v );
		public delegate void PFNGLVERTEX3FPROC( float x, float y, float z );
		public delegate void PFNGLVERTEX3FVPROC( float* v );
		public delegate void PFNGLVERTEXPOINTERPROC( int size, uint type, IntPtr stride, void* pointer );

#if GL_GLEXT_PROTOTYPES
		[Obsolete]
		public static PFNGLALPHAFUNCPROC glAlphaFunc;
		[Obsolete]
		public static PFNGLBEGINPROC glBegin;
		[Obsolete]
		public static PFNGLBITMAPPROC glBitmap;
		[Obsolete]
		public static PFNGLCALLLISTSPROC glCallLists;
		[Obsolete]
		public static PFNGLCLIENTACTIVETEXTUREPROC glClientActiveTexture;
		[Obsolete]
		public static PFNGLCOLOR4FPROC glColor4f;
		[Obsolete]
		public static PFNGLCOLOR4FVPROC glColor4fv;
		[Obsolete]
		public static PFNGLCOLOR4UBPROC glColor4ub;
		[Obsolete]
		public static PFNGLCOLORPOINTERPROC glColorPointer;
		[Obsolete]
		public static PFNGLCOPYPIXELSPROC glCopyPixels;
		[Obsolete]
		public static PFNGLDISABLECLIENTSTATEPROC glDisableClientState;
		[Obsolete]
		public static PFNGLDRAWPIXELSPROC glDrawPixels;
		[Obsolete]
		public static PFNGLENABLECLIENTSTATEPROC glEnableClientState;
		[Obsolete]
		public static PFNGLENDPROC glEnd;
		[Obsolete]
		public static PFNGLENDLISTPROC glEndList;
		[Obsolete]
		public static PFNGLFRUSTUMFPROC glFrustumf;
		[Obsolete]
		public static PFNGLGENLISTSPROC glGenLists;
		[Obsolete]
		public static PFNGLGETLIGHTFVPROC glGetLightfv;
		[Obsolete]
		public static PFNGLGETMATERIALFVPROC glGetMaterialfv;
		[Obsolete]
		public static PFNGLGETPOLYGONSTIPPLEPROC glGetPolygonStipple;
		[Obsolete]
		public static PFNGLGETTEXENVFVPROC glGetTexEnvfv;
		[Obsolete]
		public static PFNGLGETTEXENVIVPROC glGetTexEnviv;
		[Obsolete]
		public static PFNGLLIGHTFVPROC glLightfv;
		[Obsolete]
		public static PFNGLLIGHTMODELFPROC glLightModelf;
		[Obsolete]
		public static PFNGLLIGHTMODELFVPROC glLightModelfv;
		[Obsolete]
		public static PFNGLLINESTIPPLEPROC glLineStipple;
		[Obsolete]
		public static PFNGLLISTBASEPROC glListBase;
		[Obsolete]
		public static PFNGLLOADIDENTITYPROC glLoadIdentity;
		[Obsolete]
		public static PFNGLLOADMATRIXFPROC glLoadMatrixf;
		[Obsolete]
		public static PFNGLMATERIALFPROC glMaterialf;
		[Obsolete]
		public static PFNGLMATERIALFVPROC glMaterialfv;
		[Obsolete]
		public static PFNGLMATRIXMODEPROC glMatrixMode;
		[Obsolete]
		public static PFNGLMULTMATRIXFPROC glMultMatrixf;
		[Obsolete]
		public static PFNGLMULTITEXCOORD2FPROC glMultiTexCoord2f;
		[Obsolete]
		public static PFNGLNEWLISTPROC glNewList;
		[Obsolete]
		public static PFNGLNORMAL3FPROC glNormal3f;
		[Obsolete]
		public static PFNGLNORMAL3FVPROC glNormal3fv;
		[Obsolete]
		public static PFNGLNORMALPOINTERPROC glNormalPointer;
		[Obsolete]
		public static PFNGLORTHOFPROC glOrthof;
		[Obsolete]
		public static PFNGLPOLYGONSTIPPLEPROC glPolygonStipple;
		[Obsolete]
		public static PFNGLPOPMATRIXPROC glPopMatrix;
		[Obsolete]
		public static PFNGLPUSHMATRIXPROC glPushMatrix;
		[Obsolete]
		public static PFNGLRASTERPOS3FPROC glRasterPos3f;
		[Obsolete]
		public static PFNGLROTATEFPROC glRotatef;
		[Obsolete]
		public static PFNGLSCALEFPROC glScalef;
		[Obsolete]
		public static PFNGLSHADEMODELPROC glShadeModel;
		[Obsolete]
		public static PFNGLTEXCOORDPOINTERPROC glTexCoordPointer;
		[Obsolete]
		public static PFNGLTEXENVFVPROC glTexEnvfv;
		[Obsolete]
		public static PFNGLTEXENVIPROC glTexEnvi;
		[Obsolete]
		public static PFNGLTRANSLATEFPROC glTranslatef;
		[Obsolete]
		public static PFNGLVERTEX2FPROC glVertex2f;
		[Obsolete]
		public static PFNGLVERTEX2FVPROC glVertex2fv;
		[Obsolete]
		public static PFNGLVERTEX3FPROC glVertex3f;
		[Obsolete]
		public static PFNGLVERTEX3FVPROC glVertex3fv;
		[Obsolete]
		public static PFNGLVERTEXPOINTERPROC glVertexPointer;
#endif
#endif
		#endregion

		public static void SetupVersion(Func<IntPtr, IntPtr> procAddressFn)
		{
			#region Link delegates
			Type delegateType = typeof( MulticastDelegate );
			FieldInfo[] fields = typeof( OpenGL_ ).GetFields( BindingFlags.Public | BindingFlags.Static );

			ulong linkableDelegates = 0;
			ulong linkedDelegates = 0;

			foreach( FieldInfo fi in fields )
			{
				if( fi.FieldType.BaseType == delegateType )
				{
					linkableDelegates++;

					byte[] fiName = Encoding.ASCII.GetBytes( fi.Name );

					fixed( byte* fiNamePtr = fiName )
					{
						var ptr = procAddressFn(new IntPtr(fiNamePtr));

						if( ptr != IntPtr.Zero )
						{
							fi.SetValue( null, Marshal.GetDelegateForFunctionPointer( ptr, fi.FieldType ) );
							linkedDelegates++;
						}
						else
						{
							// Debug.Warn( "Could not link '" + fi.Name + "'" );
						}
					}
				}
			}
			#endregion

			#region Detect version
			Version = 0;

			if( glCullFace != null )
				Version = 100;

			if( glDrawArrays != null )
				Version = 110;

			if( glDrawRangeElements != null )
				Version = 120;

			if( glActiveTexture != null )
				Version = 130;

			if( glBlendFuncSeparate != null )
				Version = 140;

			if( glGenQueries != null )
				Version = 150;

			if( glBlendEquationSeparate != null )
				Version = 200;

			if( glUniformMatrix2x3fv != null )
				Version = 210;

			if( glColorMaski != null )
				Version = 300;

			if( glDrawArraysInstanced != null )
				Version = 310;

			if( glDrawElementsBaseVertex != null )
				Version = 320;

			if( glBindFragDataLocationIndexed != null )
				Version = 330;

			if( glMinSampleShading != null )
				Version = 400;

			if( glReleaseShaderCompiler != null )
				Version = 410;

			if( glDrawArraysInstancedBaseInstance != null )
				Version = 420;

			if( glClearBufferData != null )
				Version = 430;

			if( glBufferStorage != null )
				Version = 440;

			if( glClipControl != null )
				Version = 450;

			if( glSpecializeShader != null )
				Version = 460;

			if( Version == 0 )
				throw new Exception( "Could not bind OpenGL" );
			#endregion

			#region Debug
			// Debug.Log( "Linked " + linkedDelegates + " out of " + linkableDelegates + " delegates" );
			// Debug.Log( "Detected version '" + Version + "'" );
			#endregion
		}
		
		public static int glGetUniformLocationEasy(uint program, string name)
		{
				var bytes = Encoding.UTF8.GetBytes(name);
				fixed (byte* b = &bytes[0])
				{
						return glGetUniformLocation(program, b);
				}
		}

		public static void* NULL = (void*) 0;
	}
}