using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public struct Matrix3
    {
        // every values in the matrix3
        public float
            m00, m01, m02,
            m10, m11, m12,
            m20, m21, m22;

        // constructor
        public Matrix3(
            float m00, float m01, float m02,
            float m10, float m11, float m12,
            float m20, float m21, float m22)
        {
            this.m00 = m00;
            this.m01 = m01;
            this.m02 = m02;
            this.m10 = m10;
            this.m11 = m11;
            this.m12 = m12;
            this.m20 = m20;
            this.m21 = m21;
            this.m22 = m22;
        }

        // identity matrix
        public static Matrix3 Identity
        {
            get
            {
                return new Matrix3(
                    1, 0, 0,
                    0, 1, 0,
                    0, 0, 1);
            }
        }

        // property for pretending that this is an array with indices
        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return m00;
                    case 1: return m01;
                    case 2: return m02;
                    case 3: return m10;
                    case 4: return m11;
                    case 5: return m12;
                    case 6: return m20;
                    case 7: return m21;
                    case 8: return m22;
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
                    case 3: m10 = value; break;
                    case 4: m11 = value; break;
                    case 5: m12 = value; break;
                    case 6: m20 = value; break;
                    case 7: m21 = value; break;
                    case 8: m22 = value; break;
                }
            }
        }
        
        // convert the matrix3 into a string
        public override string ToString()
        {
            return this[0] + " " + this[1] + " " + this[2] + "\n" + 
                this[3] + " " + this[4] + " " + this[5] + "\n" +
                this[6] + " " + this[7] + " " + this[8];
        }

        // create a translation to help you move things
        public static Matrix3 CreateTranslation(float x, float y)
        {
            return new Matrix3(
                1, 0, x,
                0, 1, y,
                0, 0, 1);
        }

        // roatation to roatation things
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3(
                (float)Math.Cos(radians), -(float)Math.Sin(radians), 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);
        }

        // create a scale type of matrix
        public static Matrix3 CreateScale(float x, float y)
        {
            return new Matrix3(
                x, 0, 0,
                0, y, 0,
                0, 0, 1);
        }

        // transpose the matrix
        public Matrix3 Transpose()
        {
            this = new Matrix3(
                m00, m10, m20,
                m01, m11, m21,
                m02, m12, m22);
            return this;
        }

        // override for addition
        public static Matrix3 operator +(Matrix3 a, Matrix3 b)
        {
            Matrix3 result = new Matrix3();
            for (int i = 0; i < 9; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }

        // override for subtraction
        public static Matrix3 operator -(Matrix3 a, Matrix3 b)
        {
            Matrix3 result = new Matrix3();
            for (int i = 0; i < 9; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }

        // override for multiplication that i really like how i did Σ:3c
        // basically it gets the row and column of the index it has,
        // then it uses that info and a little bit of math to find the indices of all of the numbers in the necessary row of matrix a
        // and all of the numbers in the necessary column of matrix b!
        // and it does that for every single number in a matrix3
        public static Matrix3 operator *(Matrix3 a, Matrix3 b)
        {
            Matrix3 result = new Matrix3();
            
            for (int i = 0; i < 9; i++)
            {
                byte row = (byte)(i / 3);
                byte column = (byte)(i % 3);

                result[i] =
                    (a[row * 3] * b[column]) +
                    (a[(row * 3) + 1] * b[column + 3]) +
                    (a[(row * 3) + 2] * b[column + 6]);
            }

            return result;
        }

        // override for multiplying a matrix by a vector
        public static Vector3 operator *(Matrix3 left, Vector3 right)
        {
            return left * new Matrix3(
                0, 0, right.x,
                0, 0, right.y,
                0, 0, right.z);
        }

        // conversion from matrix to vector
        public static implicit operator Vector3(Matrix3 matrix)
        {
            return new Vector3(matrix.m02, matrix.m12, matrix.m22);
        }
    }
}
