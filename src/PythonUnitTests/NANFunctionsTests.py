import unittest
import numpy as np
from nptest import nptest


class NANFunctionsTests(unittest.TestCase):

    def test_nanprod_1(self):

        x = np.nanprod(1)
        print(x)

        y = np.nanprod([1])
        print(y)

        z = np.nanprod([1, np.nan])
        print(z)

        a = np.array([[1, 2], [3, np.nan]])
        b = np.nanprod(a)
        print(b)

        c = np.nanprod(a, axis=0)
        print(c)

        d = np.nanprod(a, axis=1)
        print(d)

        return

    def test_nansum_1(self):

        a = np.nansum(1)
        print(a)

        b = np.nansum([1])
        print(b)

        c = np.nansum([1, np.nan])
        print(c)

        a = np.array([[1, 1], [1, np.nan]])
        d = np.nansum(a)
        print(d)


        e = np.nansum(a, axis=0)
        print(e)

        f = np.nansum([1, np.nan, np.inf])
        print(f)

        g = np.nansum([1, np.nan, np.NINF])
        print(g)

        h = np.nansum([1, np.nan, np.inf, -np.inf]) # both +/- infinity present
        print(h)

        return

    def test_nancumproduct_1(self):

        x = np.nancumprod(1)
        print(x)

        y = np.nancumprod([1])
        print(y)

        z = np.nancumprod([1, np.nan])
        print(z)

        a = np.array([[1, 2], [3, np.nan]])
        b = np.nancumprod(a)
        print(b)

        c = np.nancumprod(a, axis=0)
        print(c)

        d = np.nancumprod(a, axis=1)
        print(d)

        return

    def test_nancumsum_1(self):

        a = np.nancumsum(1)
        print(a)

        b = np.nancumsum([1])
        print(b)

        c = np.nancumsum([1, np.nan])
        print(c)

        a = np.array([[1, 2], [3, np.nan]])
        d = np.nancumsum(a)
        print(d)


        e = np.nancumsum(a, axis=0)
        print(e)

        f = np.nancumsum([1, np.nan, np.inf])
        print(f)

        g = np.nancumsum([1, np.nan, np.NINF])
        print(g)

        h = np.nancumsum([1, np.nan, np.inf, -np.inf]) # both +/- infinity present
        print(h)

        return

    def test_nanpercentile_1(self):

        a = np.array([[10., 7., 4.], [3., 2., 1.]])
        a[0][1] = np.nan
        print(a)
        
        b = np.percentile(a, 50)
        print(b)

        c = np.nanpercentile(a, 50)
        print(c)

        d = np.nanpercentile(a, 50, axis=0)
        print(d)

        e = np.nanpercentile(a, 50, axis=1, keepdims=True)
        print(e)
        
        m = np.nanpercentile(a, 50, axis=0)
        out = np.zeros_like(m)
        f = np.nanpercentile(a, 50, axis=0, out=out)
        print(f)
        print(m)
 

        g = a.copy()
        h = np.nanpercentile(g, 50, axis=1, overwrite_input=True)
        print(h)
        assert not np.all(a==g)

        return

    def test_nanquantile_1(self):

        a = np.array([[10., 7., 4.], [3., 2., 1.]])
        a[0][1] = np.nan
        print(a)
        
        b = np.quantile(a, 0.5)
        print(b)

        print(np.source(np.nanquantile))

        c = np.nanquantile(a,  0.5)
        print(c)

        d = np.nanquantile(a,  0.5, axis=0)
        print(d)

        e = np.nanquantile(a,  0.5, axis=1, keepdims=True)
        print(e)
        
        m = np.nanquantile(a,  0.5, axis=0)
        out = np.zeros_like(m)
        f = np.nanquantile(a,  0.5, axis=0, out=out)
        print(f)
        print(m)
 

        g = a.copy()
        h = np.nanquantile(g,  0.5, axis=1, overwrite_input=True)
        print(h)
        assert not np.all(a==g)

        return

    def test_nanmedian_1(self):

        a = np.array([[10.0, 7, 4], [3, 2, 1]])
        a[0, 1] = np.nan
        print(a)

 
        b = np.median(a)
        print(b)

        c = np.nanmedian(a)
        print(c)

        d = np.nanmedian(a, axis=0)
        print(d)

        e = np.median(a, axis=1)
        print(e)

        f = a.copy()
        g = np.nanmedian(f, axis=1, overwrite_input=True)
        print(g)

        assert not np.all(a==f)
        h = a.copy()
        i = np.nanmedian(h, axis=None, overwrite_input=True)
        print(i)
        assert not np.all(a==h)  
        
        return

    def test_nanmean_1(self):

        a = np.array([[1, np.nan], [3, 4]])
        b = np.mean(a)
        print(b)

        c = np.nanmean(a)
        print(c)

        d = np.nanmean(a, axis=0)
        print(d)

        e = np.nanmean(a, axis=1)
        print(e)

        return

    def test_nanstd_1(self):

        a = np.array([[1, np.nan], [3, 4]])

        b = np.nanstd(a)
        print(b)

        c = np.nanstd(a, axis=0)
        print(c)

        d = np.nanstd(a, axis=1)
        print(d)

    def test_nanvar_1(self):

        a = np.array([[1, np.nan], [3, 4]])
        print(a)
    
        b = np.var(a)
        print(b)

        b = np.nanvar(a)
        print(b)

        c = np.nanvar(a, axis=0)
        print(c)

        d = np.nanvar(a, axis=1)
        print(d)

    def test_nanmin_1(self):

        a = np.array([[1, 2], [3, np.nan]])

        b = np.nanmin(a)
        print(b)
    
        c = np.nanmin(a, axis=0)
        print(c)

        d = np.nanmin(a, axis=1)
        print(d)

        # When positive infinity and negative infinity are present:

        e = np.nanmin([1, 2, np.nan, np.inf])
        print(e)

        f = np.nanmin([1, 2, np.nan, np.NINF])
        print(f)

        g = np.amin([1, 2, -3, np.NINF])
        print(g)

    def test_nanmin_2(self):

        a = np.array([[1, 2], [3, np.nan]], dtype=np.float64)

        b = np.nanmin(a)
        print(b)
    
        c = np.nanmin(a, axis=0)
        print(c)

        d = np.nanmin(a, axis=1)
        print(d)

        # When positive infinity and negative infinity are present:

        e = np.nanmin([1, 2, np.nan, np.inf])
        print(e)

        f = np.nanmin([1, 2, np.nan, np.NINF])
        print(f)

        g = np.amin([1, 2, -3, np.NINF])
        print(g)

        
    def test_nanmin_3(self):

        a = np.array([[1, 2], [3, -4]], dtype=np.int64)

        b = np.nanmin(a)
        print(b)
    
        c = np.nanmin(a, axis=0)
        print(c)

        d = np.nanmin(a, axis=1)
        print(d)

    def test_nanmin_4(self):

        a = np.array([[np.nan, np.nan], [np.nan, np.nan]])

        b = np.nanmin(a)
        print(b)
    
        c = np.nanmin(a, axis=0)
        print(c)

        d = np.nanmin(a, axis=1)
        print(d)
     

    def test_nanmax_1(self):

        a = np.array([[1, 2], [3, np.nan]])

        b = np.nanmax(a)
        print(b)
    
        c = np.nanmax(a, axis=0)
        print(c)

        d = np.nanmax(a, axis=1)
        print(d)

        # When positive infinity and negative infinity are present:

        e = np.nanmax([1, 2, np.nan, np.NINF])
        print(e)

        f = np.nanmax([1, 2, np.nan, np.inf])
        print(f)

        g = np.amax([1, 2, -3, np.inf])
        print(g)


    def test_nanargmin_1(self):

        a = np.array([[np.nan, 4], [2, 3]])
        b = np.argmin(a)
        print(b)

        c = np.nanargmin(a)
        print(c)

        d = np.argmin(a, axis=0)
        print(d)

        e = np.nanargmin(a, axis=0)
        print(e)

        f = np.argmin(a, axis=1)
        print(f)

        g = np.nanargmin(a, axis=1)
        print(g)

        try:

            a = np.array([[np.nan, np.nan], [np.nan, np.nan]])
            h = np.nanargmin(a, axis=1)
            print(h)
        except:
           return

    def test_nanargmax_1(self):

        a = np.array([[np.nan, 4], [2, 3]], dtype=np.float64)
        b = np.argmax(a)
        print(b)

        c = np.nanargmax(a)
        print(c)

        d = np.argmax(a, axis=0)
        print(d)

        e = np.nanargmax(a, axis=0)
        print(e)

        f = np.argmax(a, axis=1)
        print(f)

        g = np.nanargmax(a, axis=1)
        print(g)

        try:

            a = np.array([[np.nan, np.nan], [np.nan, np.nan]])
            h = np.nanargmax(a, axis=1)
            print(h)
        except:
           return

if __name__ == '__main__':
    unittest.main()
