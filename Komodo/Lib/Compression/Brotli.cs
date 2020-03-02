using System.IO;
using System.IO.Compression;
using System.Text;

namespace Komodo.Lib.Compression
{
    public class Brotli
    {

        #region Static Methods

        #region Public Static Methods
        public static byte[] Compress(string data) => Compress(Encoding.ASCII.GetBytes(data));
        public static byte[] Compress(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            {
                using (var decompressedStream = new MemoryStream(data))
                {
                    using (
                        var brotli = new BrotliStream(
                            compressedStream,
                            CompressionMode.Compress
                        )
                    )
                    {
                        decompressedStream.CopyTo(brotli);
                    }
                }
                return compressedStream.ToArray();
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            using (var decompressedStream = new MemoryStream())
            {
                using (var compressedStream = new MemoryStream(data))
                {
                    using (
                        var brotli = new BrotliStream(
                            compressedStream,
                            CompressionMode.Decompress
                        )
                    )
                    {
                        brotli.CopyTo(decompressedStream);
                    }
                }
                return decompressedStream.ToArray();
            }
        }
        
        #endregion Public Static Methods

        #endregion Static Methods
    }
}