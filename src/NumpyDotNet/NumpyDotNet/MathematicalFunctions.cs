﻿/*
 * BSD 3-Clause License
 *
 * Copyright (c) 2018-2019
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice,
 *    this list of conditions and the following disclaimer.
 *
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution.
 *
 * 3. Neither the name of the copyright holder nor the names of its
 *    contributors may be used to endorse or promote products derived from
 *    this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
 * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using NumpyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#if NPY_INTP_64
using npy_intp = System.Int64;
using npy_ucs4 = System.Int64;
#else
using npy_intp = System.Int32;
using npy_ucs4 = System.Int32;
#endif


namespace NumpyDotNet
{
    public static partial class np
    {
        #region MathFunctionHelper
        class MathFunctionHelper
        {
            public ndarray a;
            private ndarray b;

            public long[] offsets = null;
            private long[] offsets2 = null;

            public double[] dd = null;
            public double[] x1 = null;
            public double[] x2 = null;

            public double[] s = null;


            public MathFunctionHelper(object x)
            {
                a = asanyarray(x);
                if (a.Dtype.TypeNum != NPY_TYPES.NPY_DOUBLE)
                {
                    a = a.astype(dtype: np.Float64);
                }

                offsets = NpyCoreApi.GetViewOffsets(a);
                dd = a.Array.data.datap as double[];
                s = new double[offsets.Length];
            }

            public MathFunctionHelper(object x1, object x2)
            {
                a = asanyarray(x1);
                b = asanyarray(x2);

                if (!broadcastable(a,b))
                {
                    throw new Exception(string.Format("operands could not be broadcast together with shapes ({0}),({1})", a.shape.ToString(), b.shape.ToString()));
                }

                if (NpyCoreApi.ArraySize(a) < NpyCoreApi.ArraySize(b))
                {
                    a = np.broadcast_to(a, b.shape);
                }

                if (a.Dtype.TypeNum != NPY_TYPES.NPY_DOUBLE)
                {
                    a = a.astype(dtype: np.Float64);
                }
                if (b.Dtype.TypeNum != NPY_TYPES.NPY_DOUBLE)
                {
                    b = b.astype(dtype: np.Float64);
                }

                offsets = NpyCoreApi.GetViewOffsets(a);
                offsets2 = NpyCoreApi.GetViewOffsets(b);

                this.x1 = a.Array.data.datap as double[];
                this.x2 = b.Array.data.datap as double[];

                s = new double[offsets.Length];
            }

            public long GetOffset(long index)
            {
                long j = index;
                if (index >= this.offsets.Length)
                {
                    j = index % this.offsets.Length;
                }

                return j;
            }

            public long GetOffsetX1(long index)
            {
                long j = index;
                if (index >= this.offsets.Length)
                {
                    j = index % this.offsets.Length;
                }

                return j;
            }

            public long GetOffsetX2(long index)
            {
                long j = index;
                if (index >= this.offsets2.Length)
                {
                    j = index % this.offsets2.Length;
                }

                return j;
            }
        }
        #endregion

        #region Trigonometric Functions

        public static ndarray sin(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);
            
            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Sin(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray cos(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Cos(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray tan(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Tan(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray arcsin(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Asin(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray arccos(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Acos(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray arctan(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Atan(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray hypot(object x1, object x2, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x1, x2);


            throw new NotImplementedException();

            //for (int i = 0; i < ch.offsets.Length; i++)
            //{
            //    ch.s[i] = Math.Asin(ch.dd[ch.offsets[i]]);
            //}

            //var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            //if (where != null)
            //{
            //    ret[np.invert(where)] = np.NaN;
            //}

            //return ret;
        }

        public static ndarray arctan2(object x1, object x2, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x1, x2);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Atan2(ch.x1[ch.GetOffsetX1(i)], ch.x2[ch.GetOffsetX2(i)]);
            }

            
            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray rad2deg(object x, object where = null)
        {
            return degrees(x, where);
        }

        public static ndarray degrees(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] =  ch.dd[ch.offsets[i]] * (180 / Math.PI);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray deg2rad(object x, object where = null)
        {
            return radians(x, where);
        }

        public static ndarray radians(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.PI * ch.dd[ch.offsets[i]] / 180;
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        #endregion

        #region Hyperbolic functions

        public static ndarray sinh(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Sinh(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray cosh(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Cosh(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray tanh(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Tanh(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray arcsinh(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {

                ch.s[i] = MathHelper.HArcsin(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray arccosh(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = MathHelper.HArccos(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }
 


        public static ndarray arctanh(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = MathHelper.HArctan(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }


        #endregion

        #region Rounding Functions

        public static ndarray rint(object x, object where = null)
        {
            var a = asanyarray(x);

            var ret = NpyCoreApi.PerformNumericOp(a, NpyArray_Ops.npy_op_rint, 0);
            ret = ret.reshape(new shape(a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray fix(object x)
        {
            var a = asanyarray(x);
            var y1 = np.floor(a);
            var y2 = np.ceil(a);

            y1["..."] = np.where(a >= 0, y1, y2);
            return y1;
        }

        public static ndarray ceil(object x, object where = null)
        {
            var a = asanyarray(x);

            var ret = NpyCoreApi.PerformNumericOp(a, NpyArray_Ops.npy_op_ceil, 0);
            ret = ret.reshape(new shape(a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray trunc(object x)
        {
            var a = asanyarray(x);
            var y1 = np.floor(a);
            var y2 = np.ceil(a);

            y1["..."] = np.where(a >= 0, y1, y2);
            return y1;
        }

        #endregion

        #region Exponents and logarithms

        public static ndarray exp(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Exp(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray expm1(object x, object where = null)
        {

            /* from numpy C code
            
            nc_expm1@c@(@ctype@ *x, @ctype@ *r)
            {
                @ftype@ a = npy_exp@c@(x->real);
                r->real = a*npy_cos@c@(x->imag) - 1.0@c@;
                r->imag = a*npy_sin@c@(x->imag);
                return;
            }
            */

            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Exp(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray exp2(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Pow(2, ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray log(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray log10(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log10(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray log2(object x, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log(ch.dd[ch.offsets[i]], 2);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray logn(object x, int n, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log(ch.dd[ch.offsets[i]], n);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray log1p(object x, object where = null)
        {
            /* from numpy C code
            static void
            nc_log1p@c@(@ctype@ *x, @ctype@ *r)
            {
                @ftype@ l = npy_hypot@c@(x->real + 1, x->imag);
                r->imag = npy_atan2@c@(x->imag, x->real + 1);
                r->real = npy_log@c@(l);
                return;
            }
            */


            MathFunctionHelper ch = new MathFunctionHelper(x);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log(ch.dd[ch.offsets[i]]);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray logaddexp(object x1, object x2, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x1, x2);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log(Math.Exp(ch.x1[ch.GetOffsetX1(i)]) + Math.Exp(ch.x2[ch.GetOffsetX2(i)]));
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray logaddexp2(object x1, object x2, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x1, x2);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log(Math.Pow(2, ch.x1[ch.GetOffsetX1(i)]) + Math.Pow(2, ch.x2[ch.GetOffsetX2(i)]), 2);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray logaddexpn(object x1, object x2, int n, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x1, x2);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = Math.Log(Math.Pow(n, ch.x1[ch.GetOffsetX1(i)]) + Math.Pow(n, ch.x2[ch.GetOffsetX2(i)]), 2);
            }

            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }


        #endregion

        #region Other special functions

        #endregion

        #region Floating point routines


        #endregion

        #region Rational routines

        private static double _gcd(double a, double b)
        {
            while (b != 0)
            {
                var tempb = b;
                b = a % b;
                a = tempb;
            }
            return a;
        }

        private static double _lcm(double a, double b)
        {
            return a / _gcd(a, b) * b;
        }

        public static ndarray lcm(object x1, object x2, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x1, x2);


            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = _lcm(ch.x1[ch.GetOffsetX1(i)], ch.x2[ch.GetOffsetX2(i)]);
            }


            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        public static ndarray gcd(object x1, object x2, object where = null)
        {
            MathFunctionHelper ch = new MathFunctionHelper(x1, x2);

            for (int i = 0; i < ch.offsets.Length; i++)
            {
                ch.s[i] = _gcd(ch.x1[ch.GetOffsetX1(i)], ch.x2[ch.GetOffsetX2(i)]);
            }


            var ret = np.array(ch.s).reshape(new shape(ch.a.dims));
            if (where != null)
            {
                ret[np.invert(where)] = np.NaN;
            }

            return ret;
        }

        #endregion

    }

    #region MathHelper
    // special thanks to David Relihan
    // derived from here: https://stackoverflow.com/posts/5790661/edit
    public static class MathHelper
    {
        // Secant 
        public static double Sec(double x)
        {
            return 1 / Math.Cos(x);
        }

        // Cosecant
        public static double Cosec(double x)
        {
            return 1 / Math.Sin(x);
        }

        // Cotangent 
        public static double Cotan(double x)
        {
            return 1 / Math.Tan(x);
        }

        // Inverse Sine 
        public static double Arcsin(double x)
        {
            return Math.Atan(x / Math.Sqrt(-x * x + 1));
        }

        // Inverse Cosine 
        public static double Arccos(double x)
        {
            return Math.Atan(-x / Math.Sqrt(-x * x + 1)) + 2 * Math.Atan(1);
        }


        // Inverse Secant 
        public static double Arcsec(double x)
        {
            return 2 * Math.Atan(1) - Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
        }

        // Inverse Cosecant 
        public static double Arccosec(double x)
        {
            return Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
        }

        // Inverse Cotangent 
        public static double Arccotan(double x)
        {
            return 2 * Math.Atan(1) - Math.Atan(x);
        }

        // Hyperbolic Sine 
        public static double HSin(double x)
        {
            return (Math.Exp(x) - Math.Exp(-x)) / 2;
        }

        // Hyperbolic Cosine 
        public static double HCos(double x)
        {
            return (Math.Exp(x) + Math.Exp(-x)) / 2;
        }

        // Hyperbolic Tangent 
        public static double HTan(double x)
        {
            return (Math.Exp(x) - Math.Exp(-x)) / (Math.Exp(x) + Math.Exp(-x));
        }

        // Hyperbolic Secant 
        public static double HSec(double x)
        {
            return 2 / (Math.Exp(x) + Math.Exp(-x));
        }

        // Hyperbolic Cosecant 
        public static double HCosec(double x)
        {
            return 2 / (Math.Exp(x) - Math.Exp(-x));
        }

        // Hyperbolic Cotangent 
        public static double HCotan(double x)
        {
            return (Math.Exp(x) + Math.Exp(-x)) / (Math.Exp(x) - Math.Exp(-x));
        }

        // Inverse Hyperbolic Sine 
        public static double HArcsin(double x)
        {
            return Math.Log(x + Math.Sqrt(x * x + 1));
        }

        // Inverse Hyperbolic Cosine 
        public static double HArccos(double x)
        {
            return Math.Log(x + Math.Sqrt(x * x - 1));
        }

        // Inverse Hyperbolic Tangent 
        public static double HArctan(double x)
        {
            return Math.Log((1 + x) / (1 - x)) / 2;
        }

        // Inverse Hyperbolic Secant 
        public static double HArcsec(double x)
        {
            return Math.Log((Math.Sqrt(-x * x + 1) + 1) / x);
        }

        // Inverse Hyperbolic Cosecant 
        public static double HArccosec(double x)
        {
            return Math.Log((Math.Sign(x) * Math.Sqrt(x * x + 1) + 1) / x);
        }

        // Inverse Hyperbolic Cotangent 
        public static double HArccotan(double x)
        {
            return Math.Log((x + 1) / (x - 1)) / 2;
        }

        // Logarithm to base N 
        public static double LogN(double x, double n)
        {
            return Math.Log(x) / Math.Log(n);
        }
    }
    #endregion
}