using System;

namespace FixedPointy
{
    /// <summary>
    /// Represents a 4x4 matrix.
    /// </summary>
    public struct FixMatrix4x4
    {
        // The first element of the first row.
        public Fix m11;
        // The second element of the first row.
        public Fix m12;
        // The third element of the first row.
        public Fix m13;
        // The fourth element of the first row.
        public Fix m14;
        // The first element of the second row.
        public Fix m21;
        // The second element of the second row.
        public Fix m22;
        // The third element of the second row.
        public Fix m23;
        // The fourth element of the second row.
        public Fix m24;
        // The first element of the third row.
        public Fix m31;
        // The second element of the third row.
        public Fix m32;
        // The third element of the third row.
        public Fix m33;
        // The fourth element of the third row.
        public Fix m34;
        // The first element of the fourth row.
        public Fix m41;
        // The second element of the fourth row.
        public Fix m42;
        // The third element of the fourth row.
        public Fix m43;
        // The fourth element of the fourth row.
        public Fix m44;

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
        public FixMatrix4x4(Fix m11, Fix m12, Fix m13, Fix m14,
                         Fix m21, Fix m22, Fix m23, Fix m24,
                         Fix m31, Fix m32, Fix m33, Fix m34,
                         Fix m41, Fix m42, Fix m43, Fix m44)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m24 = m24;
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
            this.m34 = m34;
            this.m41 = m41;
            this.m42 = m42;
            this.m43 = m43;
            this.m44 = m44;
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
            m11 = row0.x;
            m12 = row0.y;
            m13 = row0.z;
            m14 = row0.w;

            m21 = row1.x;
            m22 = row1.y;
            m23 = row1.z;
            m24 = row1.w;

            m31 = row2.x;
            m32 = row2.y;
            m33 = row2.z;
            m34 = row2.w;

            m41 = row3.x;
            m42 = row3.y;
            m43 = row3.z;
            m44 = row3.w;
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
                        return this.m11;
                    case 1:
                        return this.m12;
                    case 2:
                        return this.m13;
                    case 3:
                        return this.m14;
                    case 4:
                        return this.m21;
                    case 5:
                        return this.m22;
                    case 6:
                        return this.m23;
                    case 7:
                        return this.m24;
                    case 8:
                        return this.m31;
                    case 9:
                        return this.m32;
                    case 10:
                        return this.m33;
                    case 11:
                        return this.m34;
                    case 12:
                        return this.m41;
                    case 13:
                        return this.m42;
                    case 14:
                        return this.m43;
                    case 15:
                        return this.m44;
                    default:
                        throw new IndexOutOfRangeException("Invalid matrix index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.m11 = value;
                        break;
                    case 1:
                        this.m12 = value;
                        break;
                    case 2:
                        this.m13 = value;
                        break;
                    case 3:
                        this.m14 = value;
                        break;
                    case 4:
                        this.m21 = value;
                        break;
                    case 5:
                        this.m22 = value;
                        break;
                    case 6:
                        this.m23 = value;
                        break;
                    case 7:
                        this.m24 = value;
                        break;
                    case 8:
                        this.m31 = value;
                        break;
                    case 9:
                        this.m32 = value;
                        break;
                    case 10:
                        this.m33 = value;
                        break;
                    case 11:
                        this.m34 = value;
                        break;
                    case 12:
                        this.m41 = value;
                        break;
                    case 13:
                        this.m42 = value;
                        break;
                    case 14:
                        this.m43 = value;
                        break;
                    case 15:
                        this.m44 = value;
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