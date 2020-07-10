using System;

using Matrix = Microsoft.Xna.Framework.Matrix;
using Quaternion = Microsoft.Xna.Framework.Quaternion;
using MonoGameVector2 = Microsoft.Xna.Framework.Vector2;

namespace Komodo.Lib.Math
{
    public readonly struct Vector2 : IEquatable<Vector2>
    {
        #region Public

        #region Constructors
        public Vector2(MonoGameVector2 vector) : this(vector.X, vector.Y)
        {
        }

        public Vector2(Vector2 vector) : this(vector.X, vector.Y)
        {
        }

        public Vector2(float x = 0f, float y = 0f)
        {
            MonoGameVector = new MonoGameVector2(x, y);
        }
        #endregion

        #region Members
        public MonoGameVector2 MonoGameVector { get; }
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
        #endregion
        
        #endregion

        #region Member Methods
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

        public float Length()
        {
            return MonoGameVector.Length();
        }
        #endregion

        #region Static Members
        public static Vector2 One => new Vector2(1f, 1f);
        public static Vector2 Down => new Vector2(0f, -1f);
        public static Vector2 Left => new Vector2(-1f, 0f);
        public static Vector2 Right => new Vector2(1f, 0f);
        public static Vector2 Up => new Vector2(0f, 1f);
        public static Vector2 Zero => new Vector2();
        #endregion

        #region Static Methods
        public static Vector2 operator +(Vector2 vector) => vector;
        public static Vector2 operator -(Vector2 vector) => new Vector2(-vector.X, -vector.Y);

        public static Vector2 Add(Vector2 left, Vector2 right)
        {
            var result = MonoGameVector2.Add(left.MonoGameVector, right.MonoGameVector);
            return new Vector2(result);
        }
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return Add(left, right);
        }

        public static Vector2 Divide(Vector2 vector, float scale)
        {
            var result = MonoGameVector2.Divide(vector.MonoGameVector, scale);
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
            var result = MonoGameVector2.Multiply(vector.MonoGameVector, scale);
            return new Vector2(result);
        }
        public static Vector2 operator *(Vector2 left, float scale)
        {
            return Multiply(left, scale);
        }

        public static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            var result = MonoGameVector2.Subtract(left.MonoGameVector, right.MonoGameVector);
            return new Vector2(result);
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return Subtract(left, right);
        }

        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            var result = MonoGameVector2.Clamp(value.MonoGameVector, min.MonoGameVector, max.MonoGameVector);
            return new Vector2(result);
        }

        public static Vector2 Transform(Vector2 vector, Matrix transform)
        {
            return new Vector2(
                MonoGameVector2.Transform(vector.MonoGameVector, transform)
            );
        }

        public static Vector2 Transform(Vector2 vector, Quaternion transform)
        {
            return new Vector2(
                MonoGameVector2.Transform(vector.MonoGameVector, transform)
            );
        }

        public static Vector2 Normalize(Vector2 vectorToNormalize)
        {
            var normalizedVector = MonoGameVector2.Normalize(vectorToNormalize.MonoGameVector);
            return new Vector2(normalizedVector);
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return MonoGameVector2.Distance(a.MonoGameVector, b.MonoGameVector);
        }

        public static float DistanceSquared(Vector2 a, Vector2 b)
        {
            return MonoGameVector2.DistanceSquared(a.MonoGameVector, b.MonoGameVector);
        }

        public static float Dot(Vector2 a, Vector2 b)
        {
            return MonoGameVector2.Dot(a.MonoGameVector, b.MonoGameVector);
        }

        /// <summary>
        /// Returns the reflection of a vector over a given normal.
        /// </summary>
        /// <param name="vectorToReflect">Vector to reflect over the normal.</param>
        /// <param name="normal">Normal to reflect the vector over.</param>
        /// <returns>Reflected vector over the the normal.</returns>
        public static Vector2 Reflect(Vector2 vectorToReflect, Vector2 normal)
        {
            var reflection = MonoGameVector2.Reflect(vectorToReflect.MonoGameVector, normal.MonoGameVector);
            return new Vector2(reflection);
        }
        #endregion

        #endregion
    }
}