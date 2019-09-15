using System;

namespace FixedPointy
{
    [Serializable]
    public struct FixVec4
    {
        public static readonly FixVec4 Zero = new FixVec4();
        public static readonly FixVec4 One = new FixVec4(1, 1, 1, 1);

        public static implicit operator FixVec4(FixVec2 value)
        {
            return new FixVec4(value.X, value.Y, 0, 0);
        }

        public static FixVec4 operator +(FixVec4 rhs)
        {
            return rhs;
        }
        public static FixVec4 operator -(FixVec4 rhs)
        {
            return new FixVec4(-rhs.x, -rhs.y, -rhs.z, -rhs.w);
        }

        public static FixVec4 operator +(FixVec4 lhs, FixVec4 rhs)
        {
            return new FixVec4(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z, lhs.w + rhs.w);
        }
        public static FixVec4 operator -(FixVec4 lhs, FixVec4 rhs)
        {
            return new FixVec4(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z, lhs.w - rhs.w);
        }

        public static FixVec4 operator +(FixVec4 lhs, Fix rhs)
        {
            return lhs.ScalarAdd(rhs);
        }
        public static FixVec4 operator +(Fix lhs, FixVec4 rhs)
        {
            return rhs.ScalarAdd(lhs);
        }
        public static FixVec4 operator -(FixVec4 lhs, Fix rhs)
        {
            return new FixVec4(lhs.x - rhs, lhs.y - rhs, lhs.z - rhs, lhs.w - rhs);
        }
        public static FixVec4 operator *(FixVec4 lhs, Fix rhs)
        {
            return lhs.ScalarMultiply(rhs);
        }
        public static FixVec4 operator *(Fix lhs, FixVec4 rhs)
        {
            return rhs.ScalarMultiply(lhs);
        }
        public static FixVec4 operator /(FixVec4 lhs, Fix rhs)
        {
            return new FixVec4(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs, lhs.w / rhs);
        }

        public Fix x, y, z, w;

        public FixVec4(Fix x, Fix y, Fix z, Fix w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public Fix Dot(FixVec4 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w;
        }

        FixVec4 ScalarAdd(Fix value)
        {
            return new FixVec4(x + value, y + value, z + value, w + value);
        }
        FixVec4 ScalarMultiply(Fix value)
        {
            return new FixVec4(x * value, y * value, z * value, w * value);
        }

        public Fix GetMagnitude()
        {
            ulong N = (ulong)((long)x.raw * (long)x.raw + (long)y.raw * (long)y.raw + (long)z.raw * (long)z.raw + (long)w.raw * (long)w.raw);

            return new Fix((int)(FixMath.SqrtULong(N << 2) + 1) >> 1);
        }

        public FixVec4 Normalize()
        {
            if (x == 0 && y == 0 && z == 0 && w == 0)
                return FixVec4.Zero;

            var m = GetMagnitude();
            return new FixVec4(x / m, y / m, z / m, w / m);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2}, {3})", x, y, z, w);
        }
    }
}