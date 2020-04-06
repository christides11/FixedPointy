using System;

namespace FixedPointy
{
    /// <summary>
    /// Represents a 4x4 matrix.
    /// </summary>
    public struct FixMatrix4x4
    {
        // The first element of the first row.
        public Fix m00;
        // The second element of the first row.
        public Fix m01;
        // The third element of the first row.
        public Fix m02;
        // The fourth element of the first row.
        public Fix m03;
        // The first element of the second row.
        public Fix m10;
        // The second element of the second row.
        public Fix m11;
        // The third element of the second row.
        public Fix m12;
        // The fourth element of the second row.
        public Fix m13;
        // The first element of the third row.
        public Fix m20;
        // The second element of the third row.
        public Fix m21;
        // The third element of the third row.
        public Fix m22;
        // The fourth element of the third row.
        public Fix m23;
        // The first element of the fourth row.
        public Fix m30;
        // The second element of the fourth row.
        public Fix m31;
        // The third element of the fourth row.
        public Fix m32;
        // The fourth element of the fourth row.
        public Fix m33;

        /// <summary>
        /// Returns the multiplicative identity matrix.
        /// </summary>
        public static FixMatrix4x4 Identity { get; } = new FixMatrix4x4
        (
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
        );

        /// <summary>
        /// Constructs a 4x4 matrix from the given components.
        /// </summary>
        public FixMatrix4x4(Fix m00, Fix m01, Fix m02, Fix m03,
                         Fix m10, Fix m11, Fix m12, Fix m13,
                         Fix m20, Fix m21, Fix m22, Fix m23,
                         Fix m30, Fix m31, Fix m32, Fix m33)
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

        /// <summary>
        /// Creates a 4x4 matrix from the given rows.
        /// </summary>
        /// <param name="row0">00-03.</param>
        /// <param name="row1">10-13.</param>
        /// <param name="row2">20-23.</param>
        /// <param name="row3">30-33.</param>
        public FixMatrix4x4(FixVec4 row0, FixVec4 row1, FixVec4 row2, FixVec4 row3)
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
                return this[row * 4 + column];
            }
            set
            {
                this[row * 4 + column] = value;
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

        public static FixMatrix4x4 operator *(FixMatrix4x4 lhs, FixMatrix4x4 rhs)
        {
            FixMatrix4x4 mf = new FixMatrix4x4();

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

        public override string ToString()
        {
            string s = "";
            for(int i = 0; i < 4; i++)
            {
                 s += $"{this[i, 0]}, {this[i, 1]}, {this[i, 2]}, {this[i, 3]}";
            }
            return s;
        }
    }
}