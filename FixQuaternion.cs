using System;

namespace FixedPointy
{
    public struct FixQuaternion
    {
        public Fix x;
        public Fix y;
        public Fix z;
        public Fix w;

        public static FixQuaternion operator *(FixQuaternion lhs, FixQuaternion rhs)
        {
            Fix x = lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y;
            Fix y = lhs.w * rhs.y + lhs.y * rhs.w + lhs.z * rhs.x - lhs.x * rhs.z;
            Fix z = lhs.w * rhs.z + lhs.z * rhs.w + lhs.x * rhs.y - lhs.y * rhs.x;
            Fix w = lhs.w * rhs.w - lhs.x * rhs.x + lhs.y * rhs.y - lhs.z * rhs.z;
            return new FixQuaternion(x, y, z, w);
        }

        public static FixQuaternion operator *(FixQuaternion lhs, FixVec3 rhs)
        {
            Fix x = lhs.w * rhs.X + lhs.y * rhs.Z - lhs.z * rhs.Y;
            Fix y = lhs.w * rhs.Y + lhs.z * rhs.X - lhs.x * rhs.Z;
            Fix z = lhs.w * rhs.Z + lhs.x * rhs.Y - lhs.y * rhs.X;
            Fix w = -lhs.x * rhs.X - lhs.y * rhs.Y - lhs.z * rhs.Z;
            return new FixQuaternion(x, y, z, w);
        }

        public static bool operator ==(FixQuaternion lhs, FixQuaternion rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z && lhs.w == rhs.w;
        }

        public static bool operator !=(FixQuaternion lhs, FixQuaternion rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y || lhs.z != rhs.z || lhs.w != rhs.w;
        }

        //https://answers.unity.com/questions/402280/how-to-decompose-a-trs-matrix.html
        public static FixVec3 ToEuler(FixQuaternion q)
        {
            FixVec3 result;

            Fix test = q.x * q.y + q.z * q.w;

            Fix rad2deg = 360 / (FixMath.PI * 2);

            if(test > (Fix.One / 2))
            {
                result._x = 0;
                result._y = 2 * FixMath.Atan2(q.x, q.w);
                result._z = FixMath.PI / 2;
            }else if(test < (Fix.One / 2))
            {
                result._x = 0;
                result._y = -2 * FixMath.Atan2(q.x, q.w);
                result._z = -FixMath.PI / 2;
            }
            else
            {
                result._x = rad2deg * FixMath.Atan2(2 * q.x * q.w - 2 * q.y * q.z, 1 - 2 * q.x * q.x - 2 * q.z * q.z);
                result._y = rad2deg * FixMath.Atan2(2 * q.y * q.w - 2 * q.x * q.z, 1 - 2 * q.y * q.y - 2 * q.z * q.z);
                result._z = rad2deg * FixMath.Asin(2 * q.x * q.y + 2 * q.z * q.w);
                if (result._x < 0) result._x += 360;
                if (result._y < 0) result._y += 360;
                if (result._z < 0) result._z += 360;
            }
            return result;
        }

        public FixQuaternion(Fix x, Fix y, Fix z, Fix w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Fix Magnitude()
        {
            return Fix.One;
        }

        public Fix sqrMagnitude()
        {
            return (x*x + y*y + z*z + w*w);
        }

        public FixQuaternion Normalize()
        {
            Fix magnitude = Magnitude();

            x /= magnitude;
            y /= magnitude;
            z /= magnitude;
            w /= magnitude;
            return this;
        }

        public FixQuaternion Conjugate()
        {
            return new FixQuaternion(-x, -y, -z, w);
        }
    }
}
