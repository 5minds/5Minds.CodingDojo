import unittest
from faculty import *

class TestMethods(unittest.TestCase):

    def test_faculty_0(self):
        print ("0 : " + str(faculty(0)))

    def test_faculty_1(self):
        print ("1 : " + str(faculty(1)))

    def test_faculty_2(self):
        print ("2 : " + str(faculty(2)))

    def test_faculty_3(self):
        print ("3 : " + str(faculty(3)))

    def test_faculty_4(self):
        print ("4 : " + str(faculty(4)))

    def test_faculty_5(self):
        print ("5 : " + str(faculty(5)))

    def test_faculty_10(self):
        print ("10 : " + str(faculty(10)))

    def test_faculty_100(self):
        print ("100 : " + str(faculty(100)))

    def test_faculty_500(self):
        print ("500 : " + str(faculty(500)))

    def test_faculty_974(self):
        print ("974 : " + str(faculty(974)))

    #def test_faculty_975(self):
    #    print ("975 : " + str(faculty(975)))

if __name__ == '__main__':
    unittest.main()
