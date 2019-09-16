/* FixedPointy - A simple fixed-point math library for C#.
 * 
 * Copyright (c) 2013 Jameson Ernst
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System;

namespace FixedPointy
{
    [Serializable]
    public struct FixTrans3
    {
        public static FixTrans3 operator *(FixTrans3 lhs, FixTrans3 rhs)
        {
            FixTrans3 t = new FixTrans3();
            t.m = lhs.m * rhs.m;
            return t;
        }

        public static FixVec3 operator *(FixTrans3 lhs, FixVec3 rhs)
        {
            return new FixVec3(
                lhs.m[0, 0] * rhs.X + lhs.m[0, 1] * rhs.Y + lhs.m[0, 2] * rhs.Z + lhs.m[0, 3],
                lhs.m[1, 0] * rhs.X + lhs.m[1, 1] * rhs.Y + lhs.m[1, 2] * rhs.Z + lhs.m[1, 3],
                lhs.m[2, 0] * rhs.X + lhs.m[2, 1] * rhs.Y + lhs.m[2, 2] * rhs.Z + lhs.m[2, 3]
            );
        }

        public static FixTrans3 MakeRotationZ(Fix degrees)
        {
            Fix cos = FixMath.Cos(degrees);
            Fix sin = FixMath.Sin(degrees);
            return new FixTrans3(
                cos, -sin, 0, 0,
                sin, cos, 0, 0,
                0, 0, 1, 0
            );
        }

        public static FixTrans3 MakeRotationY(Fix degrees)
        {
            Fix cos = FixMath.Cos(degrees);
            Fix sin = FixMath.Sin(degrees);
            return new FixTrans3(
                cos, 0, sin, 0,
                0, 1, 0, 0,
                -sin, 0, cos, 0
            );
        }

        public static FixTrans3 MakeRotationX(Fix degrees)
        {
            Fix cos = FixMath.Cos(degrees);
            Fix sin = FixMath.Sin(degrees);
            return new FixTrans3(
                1, 0, 0, 0,
                0, cos, -sin, 0,
                0, sin, cos, 0
            );
        }

        public static FixTrans3 MakeRotation(FixVec3 degrees)
        {
            return MakeRotationX(degrees.X)
                .RotateY(degrees.Y)
                .RotateZ(degrees.Z);
        }

        public static FixTrans3 MakeScale(FixVec3 scale)
        {
            return new FixTrans3(
                scale.X, 0, 0, 0,
                0, scale.Y, 0, 0,
                0, 0, scale.Z, 0
            );
        }

        public static FixTrans3 MakeTranslation(FixVec3 delta)
        {
            return new FixTrans3(
                1, 0, 0, delta.X,
                0, 1, 0, delta.Y,
                0, 0, 1, delta.Z
            );
        }


        public Matrix4fix m;

        public FixTrans3(
            Fix m00, Fix m01, Fix m02, Fix m03,
            Fix m10, Fix m11, Fix m12, Fix m13,
            Fix m20, Fix m21, Fix m22, Fix m23
        )
        {
            m = new Matrix4fix();
            m.m00 = m00;
            m.m01 = m01;
            m.m02 = m02;
            m.m03 = m03;
            m.m10 = m10;
            m.m11 = m11;
            m.m12 = m12;
            m.m13 = m13;
            m.m20 = m20;
            m.m21 = m21;
            m.m22 = m22;
            m.m23 = m23;
        }

        public FixTrans3(FixVec3 position, FixVec3 rotation, FixVec3 scale)
        {
            this = MakeRotationX(rotation.X)
                .RotateY(rotation.Y)
                .RotateZ(rotation.Z)
                .Scale(scale)
                .Translate(position);
        }

        public FixTrans3(Matrix4fix m)
        {
            this.m = m;
        }

        public FixTrans3 RotateZ(Fix degrees)
        {
            return MakeRotationZ(degrees) * this;
        }

        public FixTrans3 RotateY(Fix degrees)
        {
            return MakeRotationY(degrees) * this;
        }

        public FixTrans3 RotateX(Fix degrees)
        {
            return MakeRotationX(degrees) * this;
        }

        public FixTrans3 Rotate(FixVec3 degrees)
        {
            return MakeRotation(degrees);
        }

        public FixTrans3 Scale(FixVec3 scale)
        {
            return new FixTrans3(
                m[0, 0] * scale.X, m[0, 1] * scale.X, m[0, 2] * scale.X, m[0, 3] * scale.X,
                m[1, 0] * scale.Y, m[1, 1] * scale.Y, m[1, 2] * scale.Y, m[1, 3] * scale.Y,
                m[2, 0] * scale.Z, m[2, 1] * scale.Z, m[2, 2] * scale.Z, m[2, 3] * scale.Z
            );
        }

        public FixTrans3 Translate(FixVec3 delta)
        {
            FixTrans3 ft = new FixTrans3(m);
            ft.m[0, 3] += delta.X;
            ft.m[1, 3] += delta.Y;
            ft.m[2, 3] += delta.Z;
            return ft;
        }

        public FixVec3 Apply(FixVec3 vec)
        {
            return this * vec;
        }

        public FixVec3 Position()
        {
            return new FixVec3(m[0, 3], m[1, 3], m[2, 3]);
        }

        public FixVec3 Scale()
        {
            return new FixVec3(
                new FixVec3(m[0, 0], m[0, 1], m[0, 2]).GetMagnitude(),
                new FixVec3(m[1, 0], m[1, 1], m[1, 2]).GetMagnitude(),
                new FixVec3(m[2, 0], m[2, 1], m[2, 2]).GetMagnitude());
        }

        //https://gamedev.stackexchange.com/questions/50963/how-to-extract-euler-angles-from-transformation-matrix
        public FixVec3 EulerAngle()
        {
            FixVec3 ea = new FixVec3();

            ea._x = FixMath.Atan2(-m[1, 2], m[2, 2]);

            Fix cosYangle = FixMath.Sqrt(FixMath.Pow(m[0, 0], 2) + FixMath.Pow(m[0, 1], 2));
            ea._y = FixMath.Atan2(m[0, 2], cosYangle);

            Fix sinXangle = FixMath.Sin(ea._x);
            Fix cosXangle = FixMath.Cos(ea._x);
            ea._z = FixMath.Atan2((cosXangle * m[1, 0]) + (sinXangle * m[2, 0]), (cosXangle * m[1, 1]) + (sinXangle * m[2, 1]));
            return ea;
        }

        public override string ToString()
        {
            return $"Position: [{Position().ToString()}]\n"
                + $"Rotation: [{EulerAngle().ToString()}]\n"
                + $"Scale: {Scale().ToString()}\n";
        }
    }
}
