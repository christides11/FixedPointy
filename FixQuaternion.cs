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

        public override bool Equals(object obj)
        {
            return (obj is FixQuaternion && ((FixQuaternion)obj) == this);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2 ^ w.GetHashCode() >> 1;
        }

        //https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
        public static FixVec3 ToEuler(FixQuaternion q)
        {
            FixVec3 result;

            Fix t0 = 2 * (q.w * q.z + q.x * q.y);
            Fix t1 = Fix.One - (2 * (q.y * q.y + q.z * q.z));
            result._z = FixMath.Atan2(t0, t1);

            Fix t2 = 2 * (q.w * q.y - q.z * q.x);
            if (t2 >= Fix.One)
            {
                result._y = FixMath.PI / 2;
            }
            else if (t2 <= -Fix.One)
            {
                result._y = -(FixMath.PI / 2);
            }
            else
            {
                result._y = FixMath.Asin(t2);
            }

            Fix t3 = 2 * (q.w * q.x + q.y * q.z);
            Fix t4 = Fix.One - (2 * (q.x * q.x + q.y * q.y));
            result._x = FixMath.Atan2(t3, t4);
            return result;
        }

        public FixQuaternion(Fix x, Fix y, Fix z, Fix w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        //https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
        public FixQuaternion(FixVec3 e)
        {
            w = FixMath.Cos(e._z / 2) * FixMath.Cos(e._y / 2) * FixMath.Cos(e._x / 2) + FixMath.Sin(e._z / 2) * FixMath.Sin(e._y / 2) * FixMath.Sin(e._x / 2);
            x = FixMath.Cos(e._z / 2) * FixMath.Cos(e._y / 2) * FixMath.Sin(e._x / 2) - FixMath.Sin(e._z / 2) * FixMath.Sin(e._y / 2) * FixMath.Cos(e._x / 2);
            y = FixMath.Sin(e._z / 2) * FixMath.Cos(e._y / 2) * FixMath.Sin(e._x / 2) + FixMath.Cos(e._z / 2) * FixMath.Sin(e._y / 2) * FixMath.Cos(e._x / 2);
            z = FixMath.Sin(e._z / 2) * FixMath.Cos(e._y / 2) * FixMath.Cos(e._x / 2) - FixMath.Cos(e._z / 2) * FixMath.Sin(e._y / 2) * FixMath.Sin(e._x / 2);
        }

        public Fix Magnitude()
        {
            return FixMath.Sqrt(x * x + y * y + z * z + w * w);
        }

        public Fix sqrMagnitude()
        {
            return x * x + y * y + z * z + w * w;
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