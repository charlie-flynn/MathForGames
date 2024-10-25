using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Vector3
    {
        public float x, y, z;

        public float Magnitude
        {
            get
            {
                return (float)Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)));
            }
        }
        public Vector3 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        public Vector3(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 Normalize()
        {
            this = Normalized;
            return this;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }

        /*
         * Ay Bz - Az By
         * Az Bx - Zx Bz
         * Ax By - Ay Bx
         */
        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3((y * other.z) - (z * other.y), (z * other.x) - (x * other.z), (x * other.y) - (y * other.x));
        }

        public static Vector3 CrossProduct(Vector3 a, Vector3 b)
        {
            return new Vector3((a.y * b.z) - (a.z * b.y), (a.z * b.x) - (a.x * b.z), (a.x * b.y) - (a.y * b.x));
        }

        // get the dot product between two vectors
        public float DotProduct(Vector3 other)
        {
            return (x * other.x) + (y * other.y) + (z * other.z);
        }
        public static float DotProduct(Vector3 a, Vector3 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }

        // get the distance between two points
        public float Distance(Vector3 other)
        {
            return (other - this).Magnitude;
        }
        public static float Distance(Vector3 a, Vector3 b)
        {
            return (a - b).Magnitude;
        }

        // get the angle of two vectors
        public float Angle(Vector3 other)
        {
            return (float)Math.Acos(other.DotProduct(this));
        }
        public static float Angle(Vector3 a, Vector3 b)
        {
            return (float)Math.Acos(DotProduct(a, b));
        }

        // operator override for equal sign
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return (left.x == right.x) && (left.y == right.y) && (left.z == right.z);
        }

        // legally required override for not equal sign
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !(left == right);
        }

        // operator override for addition
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x + right.x, left.y + right.y, left.z + right.z);
        }

        // operator override for subtraction
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.x - right.x, left.y - right.y, left.z - right.z);
        }

        // operator override for multiplication by a scalar
        public static Vector3 operator *(Vector3 left, float scalar)
        {
            return new Vector3(left.x * scalar, left.y * scalar, left.z * scalar);
        }

        public static Vector3 operator *(float scalar, Vector3 right)
        {
            return right * scalar;
        }

        // operator override for division in a polite manner (will not divide by zero)
        public static Vector3 operator /(Vector3 left, float scalar)
        {
            float resultX = 0;
            float resultY = 0;
            float resultZ = 0;

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
            }
            return new Vector3(resultX, resultY, resultZ);
        }

        // implicit conversion from System.Numerics.Vector3 to our cooler Vector3
        public static implicit operator Vector3(System.Numerics.Vector3 vector)
        {
            return new Vector3(vector.X, vector.Y, vector.Z);
        }

        // ^^^ that but the other way around
        public static implicit operator System.Numerics.Vector3(Vector3 vector)
        {
            return new System.Numerics.Vector3(vector.x, vector.y, vector.z);
        }
    }
}
