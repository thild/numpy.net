import unittest
import numpy as np
from nptest import nptest

class WindowTests(unittest.TestCase):


    def test_bartlett_1(self):

        b = np.bartlett(5)
        print(b)

        b = np.bartlett(10)
        print(b)

        b = np.bartlett(12)
        print(b)

        return

    def test_blackman_1(self):

        b = np.blackman(5)
        print(b)

        b = np.blackman(10)
        print(b)

        b = np.blackman(12)
        print(b)

        return

if __name__ == '__main__':
    unittest.main()
