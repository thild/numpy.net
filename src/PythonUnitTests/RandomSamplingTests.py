import unittest
import numpy as np
from nptest import nptest


class Test_test1(unittest.TestCase):

    def test_rand_1(self):

        np.random.seed(8765);

        f = np.random.rand()
        print(f)

        arr = np.random.rand(5000000);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));

    def test_randn_1(self):

        np.random.seed(1234);

        f = np.random.randn()
        print(f)

        arr = np.random.randn(5000000);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));

    def test_randbool_1(self):

        np.random.seed(8188);

        f = np.random.randint(False,True+1,4, dtype=np.bool)
        print(f)

        arr = np.random.randint(False,True+1,5000000, dtype=np.bool);
        cnt = arr == True
        print(cnt.size);

    def test_randint8_1(self):

        np.random.seed(9292);

        f = np.random.randint(2,3,4, dtype=np.int8)
        print(f)

        arr = np.random.randint(2,8,5000000, dtype=np.int8);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.randint(-2,3,5000000, dtype=np.int8);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_randuint8_1(self):

        np.random.seed(1313);

        f = np.random.randint(2,3,4, dtype=np.uint8)
        print(f)

        arr = np.random.randint(2,128,5000000, dtype=np.uint8);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));

        first10 = arr[0:10:1]
        print(first10)

    def test_randint16_1(self):

        np.random.seed(8381);

        f = np.random.randint(2,3,4, dtype=np.int8)
        print(f)

        arr = np.random.randint(2,2478,5000000, dtype=np.int16);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.randint(-2067,3000,5000000, dtype=np.int16);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_randuint16_1(self):

        np.random.seed(5555);

        f = np.random.randint(2,3,4, dtype=np.uint16)
        print(f)

        arr = np.random.randint(23,12801,5000000, dtype=np.uint16);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));

        first10 = arr[0:10:1]
        print(first10)

    def test_randint_1(self):

        np.random.seed(701);

        f = np.random.randint(2,3,4, dtype=np.int32)
        print(f)

        arr = np.random.randint(9,128000,5000000, dtype=np.int32);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.randint(-20000,300000,5000000, dtype=np.int32);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_randuint_1(self):

        np.random.seed(8357);

        f = np.random.randint(2,3,4, dtype=np.uint32)
        print(f)

        arr = np.random.randint(29,13000,5000000, dtype=np.uint32);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));

        first10 = arr[0:10:1]
        print(first10)

    def test_randint64_1(self):

        np.random.seed(10987);

        f = np.random.randint(2,3,4, dtype=np.int64)
        print(f)

        arr = np.random.randint(20,9999999,5000000, dtype=np.int64);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.randint(-9999999,9999999,5000000, dtype=np.int64);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_randuint64_1(self):

        np.random.seed(1990);

        f = np.random.randint(2,3,4, dtype=np.uint64)
        print(f)

        arr = np.random.randint(64,64000,5000000, dtype=np.uint64);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));

        first10 = arr[0:10:1]
        print(first10)
    
    def test_rand_shuffle_1(self):

        np.random.seed(1964);

        arr = np.arange(10);
        np.random.shuffle(arr);
        print(arr);

        arr = np.arange(10).reshape((-1,1));
        print(arr);

        np.random.shuffle(arr);
        print(arr);

    def test_rand_permutation_1(self):

        np.random.seed(1963);

        arr = np.random.permutation(10);
        print(arr);

        arr = arr = np.random.permutation(np.arange(5));
        print(arr);


        
    def test_beta_1(self):

        np.random.seed(5566);

        a = np.arange(1,11, dtype=np.float64);
        b = np.arange(1,11, dtype= np.float64);

        arr = np.random.beta(b, b, 10);
        print(arr);

       
    def test_rand_binomial_1(self):

        np.random.seed(123)

        arr = np.random.binomial(9, 0.1, 20);
        s = np.sum(arr== 0);
        print(s);
        print(arr);

        arr = np.random.binomial(9, 0.1, 20000);
        s = np.sum(arr== 0);
        print(s)

    def test_rand_chisquare_1(self):

        np.random.seed(904)

        arr = np.random.chisquare(2, 40);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.chisquare(np.arange(1,(25*25)+1), 25*25);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_rand_dirichlet_1(self):

        np.random.seed(904)

        arr = np.random.dirichlet((2,20), 40);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.dirichlet((25,1,25), 25*25);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_rand_exponential_1(self):

        np.random.seed(914)

        arr = np.random.exponential(2.0, 40);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.exponential([1.75, 2.25, 3.5, 4.1], 4);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.exponential(1.75, 200000);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_rand_f_1(self):

        np.random.seed(94)

        arr = np.random.f(1, 48, 1000);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.f([1.75, 2.25, 3.5, 4.1], 48, 4);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.f(1.75, 53, 200000);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_gamma_f_1(self):

        np.random.seed(99)

        arr = np.random.gamma([4,4], 2);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.gamma([1.75, 2.25, 3.5, 4.1], 48, 4);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

        arr = np.random.gamma(1.75, 53, 200000);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));
        first10 = arr[0:10:1]
        print(first10)

    def test_rand_uniform_1(self):

        np.random.seed(5461);
        arr = np.random.uniform(-1, 1, 5000000);
        print(np.amax(arr));
        print(np.amin(arr));
        print(np.average(arr));

        first10 = arr[0:10:1]
        print(first10)


    def test_rand_standard_normal_1(self):

        np.random.seed(8877);
        arr = np.random.standard_normal(5000000);
        print(np.max(arr));
        print(np.min(arr));
        print(np.average(arr));

        first10 = arr[0:10:1]
        print(first10)

if __name__ == '__main__':
    unittest.main()