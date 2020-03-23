using System;

namespace Komodo.Lib.Math
{
    public readonly struct Vector2 : IEquatable<Vector2>
    {
        #region Constructors
        public Vector2(Microsoft.Xna.Framework.Vector2 vector) : this(vector.X, vector.Y)
        {
        }

        public Vector2(Vector2 vector) : this(vector.X, vector.Y)
        {
        }

        public Vector2(float x = 0f, float y = 0f)
        {
            MonoGameVector = new Microsoft.Xna.Framework.Vector2(x, y);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Microsoft.Xna.Framework.Vector2 MonoGameVector { get; }
        public float X
        {
            get
            {
                return MonoGameVector.X;
            }
        }

        public float Y
        {
            get
            {
                return MonoGameVector.Y;
            }
        }

        #region Swizzling
        public Vector2 XY
        {
            get
            {
                return new Vector2(this);
            }
        }

        public Vector2 YX
        {
            get
            {
                return new Vector2(Y, X);
            }
        }
        #endregion Swizzling
        #endregion Public Members

        #endregion Members

        #region Static Members

        #region Public Static Members
        public static Vector2 One => new Vector2(1f, 1f);
        public static Vector2 Down => new Vector2(0f, -1f);
        public static Vector2 Left => new Vector2(-1f, 0f);
        public static Vector2 Right => new Vector2(1f, 0f);
        public static Vector2 Up => new Vector2(0f, 1f);
        public static Vector2 Zero => new Vector2();
        #endregion Public Static Members

        #endregion Static Members

        #region Member Methods

        #region Public Member Methods
        public override bool Equals(object obj)
        {
            if (obj is Vector2 other)
            {
                return Equals(other);
            }
            return false;
        }
        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
        #endregion Public Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        public static Vector2 operator +(Vector2 vector) => vector;
        public static Vector2 operator -(Vector2 vector) => new Vector2(-vector.X, -vector.Y);

        public static Vector2 Add(Vector2 left, Vector2 right)
        {
            var result = Microsoft.Xna.Framework.Vector2.Add(left.MonoGameVector, right.MonoGameVector);
            return new Vector2(result);
        }
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return Add(left, right);
        }

        public static Vector2 Divide(Vector2 vector, float scale)
        {
            var result = Microsoft.Xna.Framework.Vector2.Divide(vector.MonoGameVector, scale);
            return new Vector2(result);
        }
        public static Vector2 operator /(Vector2 left, float scale)
        {
            return Divide(left, scale);
        }

        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        public static Vector2 Multiply(Vector2 vector, float scale)
        {
            var result = Microsoft.Xna.Framework.Vector2.Multiply(vector.MonoGameVector, scale);
            return new Vector2(result);
        }
        public static Vector2 operator *(Vector2 left, float scale)
        {
            return Multiply(left, scale);
        }

        public static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            var result = Microsoft.Xna.Framework.Vector2.Subtract(left.MonoGameVector, right.MonoGameVector);
            return new Vector2(result);
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return Subtract(left, right);
        }

        public static Vector2 Normalize(Vector2 vectorToNormalize)
        {
            vectorToNormalize.MonoGameVector.Normalize();
            return new Vector2(vectorToNormalize.X, vectorToNormalize.Y);
        }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}