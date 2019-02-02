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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if NPY_INTP_64
using npy_intp = System.Int64;
#else
using npy_intp = System.Int32;
#endif

namespace NumpyDotNet
{
    public static partial class np
    {

        private static ndarray asarray(ndarray m)
        {
            return m;
        }

        public static ndarray asanyarray(ndarray a, dtype dtype = null)
        {
            //  Convert the input to a masked array, conserving subclasses.

            //  If `a` is a subclass of `MaskedArray`, its class is conserved.
            //  No copy is performed if the input is already an `ndarray`.

            //  Parameters
            //  ----------
            //  a : array_like
            //      Input data, in any form that can be converted to an array.
            //  dtype : dtype, optional
            //      By default, the data-type is inferred from the input data.
            //  order : {'C', 'F'}, optional
            //      Whether to use row-major('C') or column-major('FORTRAN') memory
            //    representation.Default is 'C'.
            //
            //  Returns
            //  -------
            //
            // out : MaskedArray
            //    MaskedArray interpretation of `a`.
            //
            //
            //See Also
            //  --------
            //
            //asarray : Similar to `asanyarray`, but does not conserve subclass.
            //
            //Examples
            //  --------
            //  >>> x = np.arange(10.).reshape(2, 5)
            //  >>> x
            //
            //array([[0., 1., 2., 3., 4.],
            //
            //       [5., 6., 7., 8., 9.]])
            //  >>> np.ma.asanyarray(x)
            //  masked_array(data =
            //   [[0.  1.  2.  3.  4.]
            //   [5.  6.  7.  8.  9.]],
            //               mask =
            //   False,
            //         fill_value = 1e+20)
            //  >>> type(np.ma.asanyarray(x))
            //  <class 'numpy.ma.core.MaskedArray'>

            //if (a is MaskedArray && (dtype == null || dtype == a.Dtype))
            //{
            //    return a;
            //}
            //return masked_array(a, dtype: dtype, copy: false, keep_mask: true, sub_ok: true);
            if (a is ndarray)
            {
                return a;
            }

            return a.Copy();
        }



        private static bool hasattr(ndarray m, string v)
        {
            return true;
        }



        private static npy_intp[] arange(int start, int end)
        {
            npy_intp[] a = new npy_intp[end - start];

            int index = 0;
            for (int i = start; i < end; i++)
            {
                a[index] = i;
                index++;
            }

            return a;
        }



    }
}