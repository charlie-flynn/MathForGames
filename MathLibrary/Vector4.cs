using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector4
    {
        public float x, y, z, w;

        public float Magnitude
        {
            get
            {
                return (float)Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2) + Math.Pow(w, 2)));
            }
        }
        public Vector4 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        public Vector4(float x = 0, float y = 0, float z = 0, float w = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Vector4 Normalize()
        {
            this = Normalized;
            return this;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ", " + w + ")";
        }

        /*
         * Ay Bz - Az By
         * Az Bx - Zx Bz
         * Ax By - Ay Bx
         * 
         * and just dont worry about the w
         */
        public Vector4 CrossProduct(Vector4 other)
        {
            return new Vector4((y * other.z) - (z * other.y), (z * other.x) - (x * other.z), (x * other.y) - (y * other.x), 0);
        }

        public static Vector4 CrossProduct(Vector4 a, Vector4 b)
        {
            return new Vector4((a.y * b.z) - (a.z * b.y), (a.z * b.x) - (a.x * b.z), (a.x * b.y) - (a.y * b.x), 0);
        }

        public float DotProduct(Vector4 other)
        {
            return (x * other.x) + (y * other.y) + (z * other.z) + (w * other.w);
        }

        public static float DotProduct(Vector4 a, Vector4 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w);
        }
        public float Distance(Vector4 other)
        {
            return (other - this).Magnitude;
        }

        public float Angle(Vector4 other)
        {
            return (float)Math.Acos(other.DotProduct(this));
        }

        // operator override for equal sign
        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return (left.x == right.x) && (left.y == right.y) && (left.z == right.z) && (left.w == right.w);
        }

        // legally required override for not equal sign
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !(left == right);
        }

        // operator override for addition
        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x + right.x, left.y + right.y, left.z + right.z, left.w + right.w);
        }

        // operator override for subtraction
        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return new Vector4(left.x - right.x, left.y - right.y, left.z - right.z, left.w - right.w);
        }

        // operator override for multiplication by a scalar
        public static Vector4 operator *(Vector4 left, float scalar)
        {
            return new Vector4(left.x * scalar, left.y * scalar, left.z * scalar, left.w * scalar);
        }

        public static Vector4 operator *(float scalar, Vector4 right)
        {
            return right * scalar;
        }

        // operator override for division in a polite manner (will not divide by zero)
        public static Vector4 operator /(Vector4 left, float scalar)
        {
            float resultX = 0;
            float resultY = 0;
            float resultZ = 0;
            float resultW = 0;

            if (scalar != 0)
            {
                if (left.x != 0)
                {
                    resultX = left.x / scalar;
                }
                if (left.y != 0)
                {
                    resultY = left.y / scalar;
                }
                if (left.z != 0)
                {
                    resultZ = left.z / scalar;
                }
                if (left.w != 0)
                {
                    resultW = left.w / scalar;
                }
            }
            return new Vector4(resultX, resultY, resultZ, resultW);
        }

        // implicit conversion from System.Numerics.Vector4 to our cooler Vector4
        public static implicit operator Vector4(System.Numerics.Vector4 vector)
        {
            return new Vector4(vector.X, vector.Y, vector.Z, vector.W);
        }

        // ^^^ that but the other way around
        public static implicit operator System.Numerics.Vector4(Vector4 vector)
        {
            return new System.Numerics.Vector4(vector.x, vector.y, vector.z, vector.w);
        }
    }
}
