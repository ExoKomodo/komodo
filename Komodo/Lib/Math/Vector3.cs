using System;

using Matrix = Microsoft.Xna.Framework.Matrix;

namespace Komodo.Lib.Math
{
    public readonly struct Vector3 : IEquatable<Vector3>
    {
        #region Constructors
        public Vector3(Microsoft.Xna.Framework.Vector3 vector) : this(vector.X, vector.Y, vector.Z)
        {
        }

        public Vector3(Vector3 vector) : this(vector.X, vector.Y, vector.Z)
        {
        }

        public Vector3(float x = 0f, float y = 0f, float z = 0f)
        {
            MonoGameVector = new Microsoft.Xna.Framework.Vector3(x, y, z);
        }
        #endregion Constructors

        #region Members

        #region Public Members
        public Microsoft.Xna.Framework.Vector3 MonoGameVector { get; }
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

        public float Z
        {
            get
            {
                return MonoGameVector.Z;
            }
        }

        #region Swizzling
        public Vector2 XY
        {
            get
            {
                return new Vector2(X, Y);
            }
        }

        public Vector2 XZ
        {
            get
            {
                return new Vector2(X, Z);
            }
        }

        public Vector2 YX
        {
            get
            {
                return new Vector2(Y, X);
            }
        }

        public Vector2 YZ
        {
            get
            {
                return new Vector2(Y, Z);
            }
        }

        public Vector2 ZX
        {
            get
            {
                return new Vector2(Z, X);
            }
        }

        public Vector2 ZY
        {
            get
            {
                return new Vector2(Z, Y);
            }
        }

        public Vector3 XYZ
        {
            get
            {
                return new Vector3(X, Y, Z);
            }
        }

        public Vector3 XZY
        {
            get
            {
                return new Vector3(X, Z, Y);
            }
        }

        public Vector3 YXZ
        {
            get
            {
                return new Vector3(Y, X, Z);
            }
        }

        public Vector3 YZX
        {
            get
            {
                return new Vector3(Y, Z, X);
            }
        }

        public Vector3 ZXY
        {
            get
            {
                return new Vector3(Z, X, Y);
            }
        }

        public Vector3 ZYX
        {
            get
            {
                return new Vector3(Z, Y, X);
            }
        }
        #endregion Swizzling

        #endregion Public Members

        #endregion Members

        #region Static Members

        #region Public Static Members
        public static Vector3 One => new Vector3(1f, 1f, 1f);
        public static Vector3 Zero => new Vector3();
        public static Vector3 Up => new Vector3(0f, 1f, 0f);
        public static Vector3 Down => -Up;
        public static Vector3 Right => new Vector3(1f, 0f, 0f);
        public static Vector3 Left => -Right;
        public static Vector3 Back => new Vector3(0f, 0f, 1f);
        public static Vector3 Forward => -Back;
        public static Vector3 Max(Vector3 left, Vector3 right)
        {
            return new Vector3(Microsoft.Xna.Framework.Vector3.Max(left.MonoGameVector, right.MonoGameVector));
        }
        public static Vector3 Min(Vector3 left, Vector3 right)
        {
            return new Vector3(Microsoft.Xna.Framework.Vector3.Min(left.MonoGameVector, right.MonoGameVector));
        }
        #endregion Public Static Members

        #endregion Static Members

        #region Member Methods

        #region Public Member Methods
        public override bool Equals(object obj)
        {
            if (obj is Vector3 other)
            {
                return Equals(other);
            }
            return false;
        }
        public bool Equals(Vector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }
        #endregion Public Member Methods

        #endregion Member Methods

        #region Static Methods

        #region Public Static Methods
        public static Vector3 operator +(Vector3 vector) => vector;
        public static Vector3 operator -(Vector3 vector) => new Vector3(-vector.X, -vector.Y, -vector.Z);

        public static Vector3 Add(Vector3 left, Vector3 right)
        {
            var result = Microsoft.Xna.Framework.Vector3.Add(left.MonoGameVector, right.MonoGameVector);
            return new Vector3(result);
        }
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return Add(left, right);
        }

        public static Vector3 Divide(Vector3 vector, float scale)
        {
            var result = Microsoft.Xna.Framework.Vector3.Divide(vector.MonoGameVector, scale);
            return new Vector3(result);
        }
        public static Vector3 operator /(Vector3 left, float scale)
        {
            return Divide(left, scale);
        }

        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !(left == right);
        }

        public static Vector3 Multiply(Vector3 left, float scale)
        {
            var result = Microsoft.Xna.Framework.Vector3.Multiply(left.MonoGameVector, scale);
            return new Vector3(result);
        }
        public static Vector3 operator *(Vector3 left, float scale)
        {
            return Multiply(left, scale);
        }

        public static Vector3 Multiply(Vector3 left, Vector3 right)
        {
            var result = Microsoft.Xna.Framework.Vector3.Multiply(left.MonoGameVector, right.MonoGameVector);
            return new Vector3(result);
        }
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return Multiply(left, right);
        }

        public static Vector3 Subtract(Vector3 left, Vector3 right)
        {
            var result = Microsoft.Xna.Framework.Vector3.Subtract(left.MonoGameVector, right.MonoGameVector);
            return new Vector3(result);
        }
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return Subtract(left, right);
        }

        public static Vector3 Normalize(Vector3 vectorToNormalize)
        {
            vectorToNormalize.MonoGameVector.Normalize();
            return new Vector3(vectorToNormalize.X, vectorToNormalize.Y, vectorToNormalize.Z);
        }

        public static Vector3 Transform(Vector3 vector, Matrix transform)
        {
            return new Vector3(
                Microsoft.Xna.Framework.Vector3.Transform(vector.MonoGameVector, transform)
            );
        }

        public static float Distance(Vector3 a, Vector3 b)
        {
            return Microsoft.Xna.Framework.Vector3.Distance(a.MonoGameVector, b.MonoGameVector);
        }

        public static float DistanceSquared(Vector3 a, Vector3 b)
        {
            return Microsoft.Xna.Framework.Vector3.DistanceSquared(a.MonoGameVector, b.MonoGameVector);
        }
        #endregion Public Static Methods

        #endregion Static Methods
    }
}