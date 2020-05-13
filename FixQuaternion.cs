namespace FixedPointy
{
    /// <summary>
    /// A Quaternion is commonly used to represent 3D rotations.
    /// </summary>
    public struct FixQuaternion
    {
        public Fix x;
        public Fix y;
        public Fix z;
        public Fix w;

        public static FixQuaternion operator *(FixQuaternion lhs, FixQuaternion rhs)
        {
            Fix x = lhs.w * rhs.x + lhs.x * rhs.w
                + lhs.y * rhs.z - lhs.z * rhs.y;
            Fix y = lhs.w * rhs.y + lhs.y * rhs.w
                + lhs.z * rhs.x - lhs.x * rhs.z;
            Fix z = lhs.w * rhs.z + lhs.z * rhs.w
                + lhs.x * rhs.y - lhs.y * rhs.x;
            Fix w = lhs.w * rhs.w - lhs.x * rhs.x
                + lhs.y * rhs.y - lhs.z * rhs.z;
            return new FixQuaternion(x, y, z, w);
        }

        public static FixQuaternion operator *(FixQuaternion lhs, FixVec3 rhs)
        {
            Fix x = lhs.w * rhs.x + lhs.y * rhs.z - lhs.z * rhs.y;
            Fix y = lhs.w * rhs.y + lhs.z * rhs.x - lhs.x * rhs.z;
            Fix z = lhs.w * rhs.z + lhs.x * rhs.y - lhs.y * rhs.x;
            Fix w = -lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z;
            return new FixQuaternion(x, y, z, w);
        }

        public static bool operator ==(FixQuaternion lhs, FixQuaternion rhs)
        {
            return lhs.x == rhs.x
                && lhs.y == rhs.y
                && lhs.z == rhs.z
                && lhs.w == rhs.w;
        }

        public static bool operator !=(FixQuaternion lhs, FixQuaternion rhs)
        {
            return lhs.x != rhs.x
                || lhs.y != rhs.y
                || lhs.z != rhs.z
                || lhs.w != rhs.w;
        }

        public override bool Equals(object obj)
        {
            return (obj is FixQuaternion && ((FixQuaternion)obj) == this);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2 ^ w.GetHashCode() >> 1;
        }

        /// <summary>
        /// Converts a quaternion to a euler angle.
        /// https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
        /// </summary>
        /// <param name="quaternion">The quaternion to convert from.</param>
        /// <returns>An euler angle.</returns>
        public static FixVec3 ToEuler(FixQuaternion quaternion)
        {
            FixVec3 result;

            Fix t0 = 2 * (quaternion.w * quaternion.z + quaternion.x * quaternion.y);
            Fix t1 = Fix.one - (2 * (quaternion.y * quaternion.y + quaternion.z * quaternion.z));
            result.z = FixMath.Atan2(t0, t1);

            Fix t2 = 2 * (quaternion.w * quaternion.y - quaternion.z * quaternion.x);
            if (t2 >= Fix.one)
            {
                result.y = FixMath.PI / 2;
            }
            else if (t2 <= -Fix.one)
            {
                result.y = -(FixMath.PI / 2);
            }
            else
            {
                result.y = FixMath.Asin(t2);
            }

            Fix t3 = 2 * (quaternion.w * quaternion.x + quaternion.y * quaternion.z);
            Fix t4 = Fix.one - (2 * (quaternion.x * quaternion.x + quaternion.y * quaternion.y));
            result.x = FixMath.Atan2(t3, t4);
            return result;
        }

        /// <summary>
        /// Constructs a quaternion from the given x,y,z,w parameters.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public FixQuaternion(Fix x, Fix y, Fix z, Fix w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Constructs a quaternion from a vector3.
        /// https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
        /// </summary>
        /// <param name="vector">The vector3 being converted.</param>
        public FixQuaternion(FixVec3 vector)
        {
            w = FixMath.Cos(vector.z / 2) * FixMath.Cos(vector.y / 2) * FixMath.Cos(vector.x / 2)
              + FixMath.Sin(vector.z / 2) * FixMath.Sin(vector.y / 2) * FixMath.Sin(vector.x / 2);
            x = FixMath.Cos(vector.z / 2) * FixMath.Cos(vector.y / 2) * FixMath.Sin(vector.x / 2)
              - FixMath.Sin(vector.z / 2) * FixMath.Sin(vector.y / 2) * FixMath.Cos(vector.x / 2);
            y = FixMath.Sin(vector.z / 2) * FixMath.Cos(vector.y / 2) * FixMath.Sin(vector.x / 2)
              + FixMath.Cos(vector.z / 2) * FixMath.Sin(vector.y / 2) * FixMath.Cos(vector.x / 2);
            z = FixMath.Sin(vector.z / 2) * FixMath.Cos(vector.y / 2) * FixMath.Cos(vector.x / 2)
              - FixMath.Cos(vector.z / 2) * FixMath.Sin(vector.y / 2) * FixMath.Sin(vector.x / 2);
        }

        /// <summary>
        /// Returns the length of this quaternion.
        /// </summary>
        /// <returns>The length.</returns>
        public Fix Magnitude()
        {
            return FixMath.Sqrt(x * x + y * y + z * z + w * w);
        }

        /// <summary>
        /// Return the squared length of this quaternion.
        /// </summary>
        /// <returns>The squared length.</returns>
        public Fix sqrMagnitude()
        {
            return x * x + y * y + z * z + w * w;
        }

        /// <summary>
        /// Make this quaternion have a magnitude of 1.
        /// </summary>
        /// <returns>This quaternion.</returns>
        public FixQuaternion Normalize()
        {
            Fix magnitude = Magnitude();

            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
            w /= magnitude;
            return this;
        }
    }
}