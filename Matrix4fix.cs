using System;

namespace FixedPointy
{
    public struct Matrix4fix
    {
        public Fix m00, m01, m02, m03;
        public Fix m10, m11, m12, m13;
        public Fix m20, m21, m22, m23;
        public Fix m30, m31, m32, m33;

        public Matrix4fix(FixVec4 row0, FixVec4 row1, FixVec4 row2, FixVec4 row3)
        {
            m00 = row0.x;
            m01 = row0.y;
            m02 = row0.z;
            m03 = row0.w;
            m10 = row1.x;
            m11 = row1.y;
            m12 = row1.z;
            m13 = row1.w;
            m20 = row2.x;
            m21 = row2.y;
            m22 = row2.z;
            m23 = row2.w;
            m30 = row3.x;
            m31 = row3.y;
            m32 = row3.z;
            m33 = row3.w;
        }

        public Fix this[int row, int column] {
            get
            {
                return this[row + column * 4];
            }
            set
            {
                this[row + column * 4] = value;
            }
        }

        public Fix this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.m00;
                    case 1:
                        return this.m01;
                    case 2:
                        return this.m02;
                    case 3:
                        return this.m03;
                    case 4:
                        return this.m10;
                    case 5:
                        return this.m11;
                    case 6:
                        return this.m12;
                    case 7:
                        return this.m13;
                    case 8:
                        return this.m20;
                    case 9:
                        return this.m21;
                    case 10:
                        return this.m22;
                    case 11:
                        return this.m23;
                    case 12:
                        return this.m30;
                    case 13:
                        return this.m31;
                    case 14:
                        return this.m32;
                    case 15:
                        return this.m33;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.m00 = value;
                        break;
                    case 1:
                        this.m01 = value;
                        break;
                    case 2:
                        this.m02 = value;
                        break;
                    case 3:
                        this.m03 = value;
                        break;
                    case 4:
                        this.m10 = value;
                        break;
                    case 5:
                        this.m11 = value;
                        break;
                    case 6:
                        this.m12 = value;
                        break;
                    case 7:
                        this.m13 = value;
                        break;
                    case 8:
                        this.m20 = value;
                        break;
                    case 9:
                        this.m21 = value;
                        break;
                    case 10:
                        this.m22 = value;
                        break;
                    case 11:
                        this.m23 = value;
                        break;
                    case 12:
                        this.m30 = value;
                        break;
                    case 13:
                        this.m31 = value;
                        break;
                    case 14:
                        this.m32 = value;
                        break;
                    case 15:
                        this.m33 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
        }

        public static Matrix4fix identity()
        {
            return new Matrix4fix(
                new FixVec4(1, 0, 0, 0),
                new FixVec4(0, 1, 0, 0),
                new FixVec4(0, 0, 1, 0),
                new FixVec4(0, 0, 0, 1));
        }

        public static Matrix4fix operator *(Matrix4fix lhs, Matrix4fix rhs)
        {
            Matrix4fix mf = new Matrix4fix();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mf[i, j] = (
                        lhs[i,0] * rhs[0, j] +
                        lhs[i,1] * rhs[1, j] +
                        lhs[i,2] * rhs[2, j] +
                        lhs[i,3] * rhs[3, j]);
                }
            }

            return mf;
        }
    }
}