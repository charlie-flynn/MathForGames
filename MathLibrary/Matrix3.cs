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

        public static Matrix3 Indentity
        {
            get
            {
                // return identity matrix
                return new Matrix3(
                    1, 0, 0,
                    0, 1, 0,
                    0, 0, 1);
            }
        }

        // override for pretending that this is an array
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
                    default: m22 = value; break;
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
    }
}
