FixedPointy
===========
A fork of FixedPointy adding features primarily for use in unity.

All standard math functions are implemented, with the exception of hyperbolic trig.
Precision can be configured by adjusting the FractionalBits constant in Fix.cs,
ranging from Q9.22 through Q23.8 formats.

Available under MIT license. See LICENSE.txt for details.

Current Issues
----
- FixQuaternion_Test's "EulerForwardBack" currently fails.
- FixTrans3_Test's "DecomposeTRSScale" and "DecomposeTRSEulerAngle" currently fails.
