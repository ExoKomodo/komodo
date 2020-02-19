using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Komodo.Core
{
    public readonly struct KomodoVector2 : IEquatable<KomodoVector2>
    {
        #region Constructors
        public KomodoVector2(Vector2 vector) : this(vector.X, vector.Y)
        {
        }

        public KomodoVector2(KomodoVector2 vector) : this(vector.X, vector.Y)
        {
        }

        public KomodoVector2(float x = 0f, float y = 0f)
        {
            MonoGameVector = new Vector2(x, y);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Vector2 MonoGameVector { get; }
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

        #region Swizzling
        public KomodoVector2 XY {
            get
            {
                return new KomodoVector2(this);
            }
        }

        public KomodoVector2 YX {
            get
            {
                return new KomodoVector2(Y, X);
            }
        }
        #endregion Swizzling
        #endregion Public Members

        #endregion Members

        #region Static Members
        
        #region Public Static Members
        public static KomodoVector2 One => new KomodoVector2(1f, 1f);
        public static KomodoVector2 Down => new KomodoVector2(0f, 1f);
        public static KomodoVector2 Left => new KomodoVector2(-1f, 0f);
        public static KomodoVector2 Right => new KomodoVector2(1f, 0f);
        public static KomodoVector2 Up => new KomodoVector2(0f, -1f);
        public static KomodoVector2 Zero => new KomodoVector2();
        #endregion Public Static Members
        
        #endregion Static Members

        #region Member Methods
        
        #region Public Member Methods
        public bool Equals([AllowNull] KomodoVector2 other)
        {
            throw new NotImplementedException();
        }
        #endregion Public Member Methods
        
        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        public static KomodoVector2 Add(KomodoVector2 left, KomodoVector2 right)
        {
            var addedVector = Vector2.Add(left.MonoGameVector, right.MonoGameVector);
            return new KomodoVector2(addedVector.X, addedVector.Y);
        }

        public static KomodoVector2 Multiply(KomodoVector2 vector, float scale)
        {
            var addedVector = Vector2.Multiply(vector.MonoGameVector, scale);
            return new KomodoVector2(addedVector.X, addedVector.Y);
        }
        
        public static KomodoVector2 Normalize(KomodoVector2 vectorToNormalize)
        {
            vectorToNormalize.MonoGameVector.Normalize();
            return new KomodoVector2(vectorToNormalize.X, vectorToNormalize.Y);
        }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}