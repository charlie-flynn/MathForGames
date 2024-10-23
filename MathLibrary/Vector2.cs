using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MathLibrary
{
    public struct Vector2
    {
        public float x, y;

        public float Magnitude
        {
            get
            {
                return (float)Math.Abs(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
            }
        }
        public Vector2 Normalized
        {
            get
            {
                return this / Magnitude;
            }
        }

        public Vector2(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2 Normalize()
        {
            this = Normalized;
            return this;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";  
        }

        // get the dot product of two vectors
        public float DotProduct(Vector2 other)
        {
            return (x * other.x) + (y * other.y);
        }
        public static float DotProduct(Vector2 a, Vector2 b)
        {
            return (a.x * b.x) + (a.y * b.y);
        }

        // get the distance between two points
        public float Distance(Vector2 other)
        {
            return (other - this).Magnitude;
        }

        // get the angle between two vectors
        public float Angle(Vector2 other)
        {
            return (float)Math.Acos(other.DotProduct(this));
        }

        // operator override for equal sign
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return (left.x == right.x) && (left.y == right.y);
        }

        // legally required override for not equal sign
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        // operator override for addition
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x + right.x, left.y + right.y);
        }

        // operator override for subtraction
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x - right.x, left.y - right.y);
        }

        // operator override for multiplication by a scalar
        public static Vector2 operator *(Vector2 left, float scalar)
        {
            return new Vector2(left.x * scalar, left.y * scalar);
        }

        public static Vector2 operator *(float scalar, Vector2 right)
        {
            return new Vector2(scalar * right.x, scalar * right.y);
        }

        // operator override for division in a polite manner (will not divide by zero)
        public static Vector2 operator /(Vector2 left, float scalar)
        {
            float resultX = 0;
            float resultY = 0;
            if (scalar != 0)
            {
                if (left.x != 0 && scalar != 0)
                {
                    resultX = left.x / scalar;
                }
                if (left.y != 0 && scalar != 0)
                {
                    resultY = left.y / scalar;
                }
            }
            return new Vector2(resultX, resultY);
        }

        // implicit conversion from System.Numerics.Vector2 to our cooler Vector2
        public static implicit operator Vector2(System.Numerics.Vector2 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        // ^^^ that but the other way around
        public static implicit operator System.Numerics.Vector2(Vector2 vector)
        {
            return new System.Numerics.Vector2(vector.x, vector.y);
        }
    }
}
