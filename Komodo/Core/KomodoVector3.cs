using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Komodo.Core
{
    public readonly struct KomodoVector3 : IEquatable<KomodoVector3>
    {
        #region Constructors
        public KomodoVector3(Vector3 vector) : this(vector.X, vector.Y, vector.Z)
        {
        }

        public KomodoVector3(KomodoVector3 vector) : this(vector.X, vector.Y, vector.Z)
        {
        }

        public KomodoVector3(float x = 0f, float y = 0f, float z = 0f)
        {
            MonoGameVector = new Vector3(x, y, z);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Vector3 MonoGameVector { get; }
        public float X {
            get
            {
                return MonoGameVector.X;
            }
        }

        public float Y {
            get
            {
                return MonoGameVector.Y;
            }
        }

        public float Z {
            get
            {
                return MonoGameVector.Z;
            }
        }

        #region Swizzling
        public KomodoVector2 XY {
            get
            {
                return new KomodoVector2(X, Y);
            }
        }

        public KomodoVector2 XZ {
            get
            {
                return new KomodoVector2(X, Z);
            }
        }

        public KomodoVector2 YX {
            get
            {
                return new KomodoVector2(Y, X);
            }
        }

        public KomodoVector2 YZ {
            get
            {
                return new KomodoVector2(Y, Z);
            }
        }

        public KomodoVector2 ZX {
            get
            {
                return new KomodoVector2(Z, X);
            }
        }

        public KomodoVector2 ZY {
            get
            {
                return new KomodoVector2(Z, Y);
            }
        }

        public KomodoVector3 XYZ {
            get
            {
                return new KomodoVector3(X, Y, Z);
            }
        }

        public KomodoVector3 XZY {
            get
            {
                return new KomodoVector3(X, Z, Y);
            }
        }

        public KomodoVector3 YXZ {
            get
            {
                return new KomodoVector3(Y, X, Z);
            }
        }

        public KomodoVector3 YZX {
            get
            {
                return new KomodoVector3(Y, Z, X);
            }
        }

        public KomodoVector3 ZXY {
            get
            {
                return new KomodoVector3(Z, X, Y);
            }
        }

        public KomodoVector3 ZYX {
            get
            {
                return new KomodoVector3(Z, Y, X);
            }
        }
        #endregion Swizzling

        #endregion Public Members

        #endregion Members

        #region Static Members
        
        #region Public Static Members
        public static KomodoVector3 One => new KomodoVector3(1f, 1f, 1f);
        public static KomodoVector3 Zero => new KomodoVector3();
        #endregion Public Static Members
        
        #endregion Static Members

        #region Member Methods
        
        #region Public Member Methods
        public bool Equals([AllowNull] KomodoVector3 other)
        {
            throw new NotImplementedException();
        }
        #endregion Public Member Methods
        
        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        public static KomodoVector3 Add(KomodoVector3 left, KomodoVector3 right)
        {
            var addedVector = Vector3.Add(left.MonoGameVector, right.MonoGameVector);
            return new KomodoVector3(addedVector.X, addedVector.Y, addedVector.Z);
        }

        public static KomodoVector3 Multiply(KomodoVector3 vector, float scale)
        {
            var addedVector = Vector3.Multiply(vector.MonoGameVector, scale);
            return new KomodoVector3(addedVector.X, addedVector.Y, addedVector.Z);
        }

        public static KomodoVector3 Normalize(KomodoVector3 vectorToNormalize)
        {
            vectorToNormalize.MonoGameVector.Normalize();
            return new KomodoVector3(vectorToNormalize.X, vectorToNormalize.Y, vectorToNormalize.Z);
        }

        public static KomodoVector3 Subtract(KomodoVector3 left, KomodoVector3 right)
        {
            var subtractedVector = Vector3.Subtract(left.MonoGameVector, right.MonoGameVector);
            return new KomodoVector3(subtractedVector.X, subtractedVector.Y, subtractedVector.Z);
        }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}