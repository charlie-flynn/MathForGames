using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MathLibrary
{
    public class Vector2
    {
        float x, y;

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
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

        // operator override for multiplication by another vector
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.x * right.x, left.y - right.y);
        }

        // operator override for multiplication by a scalar
        public static Vector2 operator *(Vector2 left, float right)
        {
            return new Vector2(left.x * right, left.y * right);
        }

        // operator override for division in a polite manner (will not divide by zero)
        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            float resultX = 0;
            float resultY = 0;

            if (left.x != 0 && right.x != 0)
            {
                resultX = left.x / right.x;
            }
            if (left.y != 0 && right.y != 0)
            {
                resultY = left.y / right.y;
            }

            return new Vector2(resultX, resultY);
        }

        // implicit conversion from System.Numerics.Vector2 to our cooler Vector2
        public static implicit operator Vector2(System.Numerics.Vector2 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        // that but the other way around
        public static implicit operator System.Numerics.Vector2(Vector2 vector)
        {
            return new System.Numerics.Vector2(vector.x, vector.y);
        }
    }
}
