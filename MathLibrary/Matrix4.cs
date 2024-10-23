using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix4
    {
        // every values in the Matrix4
        public float
            m00, m01, m02, m03,
            m10, m11, m12, m13,
            m20, m21, m22, m23,
            m30, m31, m32, m33;

        // constructor
        public Matrix4(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m03 = m03;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m20 = m20;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m30 = m30;
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
        }

        public static Matrix4 Identity
        {
            get
            {
                // return identity matrix
                return new Matrix4(
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1);
            }
        }

        // override for pretending that this is an array with indices
        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m02;
                    case 3: return m03;
                    case 4: return m10;
                    case 5: return m11;
                    case 6: return m12;
                    case 7: return m13;
                    case 8: return m20;
                    case 9: return m21;
                    case 10: return m22;
                    case 11: return m23;
                    case 12: return m30;
                    case 13: return m31;
                    case 14: return m32;
                    case 15: return m33;
                    default: return 0;
                }
            }
            set
            {
                switch (i)
                {
                    case 0: m00 = value; break;
                    case 1: m01 = value; break;
                    case 2: m02 = value; break;
                    case 3: m03 = value; break;
                    case 4: m10 = value; break;
                    case 5: m11 = value; break;
                    case 6: m12 = value; break;
                    case 7: m13 = value; break;
                    case 8: m20 = value; break;
                    case 9: m21 = value; break;
                    case 10: m22 = value; break;
                    case 11: m23 = value; break;
                    case 12: m30 = value; break;
                    case 13: m31 = value; break;
                    case 14: m32 = value; break;
                    case 15: m33 = value; break;

                }
            }
        }

        // convert the Matrix4 into a string
        public override string ToString()
        {
            return this[0] + " " + this[1] + " " + this[2] + " " + this[3] + "\n" +
                this[4] + " " + this[5] + " " + this[6] + " " + this[7] + "\n" +
                this[8] + " " + this[9] + " " + this[10] + " " + this[11] + "\n" +
                this[12] + " " + this[13] + " " + this[14] + " " + this[15];
        }

        public static Matrix4 CreateRotationX(float radians)
        {
            return Identity;
        }
        public static Matrix4 CreateRotationY(float radians)
        {
            return Identity;
        }
        public static Matrix4 CreateRotationZ(float radians)
        {
            return Identity;
        }

        // override for addition
        public static Matrix4 operator +(Matrix4 a, Matrix4 b)
        {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 16; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }

        // override for subtraction
        public static Matrix4 operator -(Matrix4 a, Matrix4 b)
        {
            Matrix4 result = new Matrix4();
            for (int i = 0; i < 16; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }

        // override for multiplication that i really like how i did Σ:3c
        // basically it gets the row and column of the index it has,
        // then it uses that info and a little bit of math to find the indices of all of the numbers in the necessary row of matrix a
        // and all of the numbers in the necessary column of matrix b!
        // and it does that for every single number in a matrix4
        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 result = new Matrix4();

            for (int i = 0; i < 16; i++)
            {
                byte row = (byte)(i / 4);
                byte column = (byte)(i % 4);

                result[i] =
                    (a[row * 4] * b[column]) +
                    (a[(row * 4) + 1] * b[column + 4]) +
                    (a[(row * 4) + 2] * b[column + 8]) +
                    (a[(row * 4) + 3] * b[column + 12]);
            }

            return result;
        }

        public static Vector4 operator *(Matrix4 left, Vector4 right)
        {
            return left * new Matrix4(
                0, 0, 0, right.x,
                0, 0, 0, right.y,
                0, 0, 0, right.z,
                0, 0, 0, right.w);
        }

        public static implicit operator Vector4(Matrix4 matrix)
        {
            return new Vector4(matrix[3], matrix[7], matrix[11], matrix[15]);
        }
    }
}
