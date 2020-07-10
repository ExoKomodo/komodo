using System.IO;
using System.IO.Compression;
using System.Text;

namespace Komodo.Lib.Compression
{
    public static class GZIP
    {
        #region Public

        #region Static Methods
        public static byte[] Compress(string data) => Compress(Encoding.ASCII.GetBytes(data));
        public static byte[] Compress(byte[] data)
        {
            using var compressedStream = new MemoryStream();
            using (var decompressedStream = new MemoryStream(data))
            {
                using var gzip = new GZipStream(
                        compressedStream,
                        CompressionMode.Compress
                    );
                decompressedStream.CopyTo(gzip);
            }
            return compressedStream.ToArray();
        }

        public static byte[] Decompress(byte[] data)
        {
            using var decompressedStream = new MemoryStream();
            using (var compressedStream = new MemoryStream(data))
            {
                using var gzip = new GZipStream(
                        compressedStream,
                        CompressionMode.Decompress
                    );
                gzip.CopyTo(decompressedStream);
            }
            return decompressedStream.ToArray();
        }
        
        #endregion

        #endregion
    }
}