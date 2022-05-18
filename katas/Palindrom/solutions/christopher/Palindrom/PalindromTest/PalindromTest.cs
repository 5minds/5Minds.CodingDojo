using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromNamespace;
using System;
using System.Collections.Generic;

namespace PalindromTest {
    [TestClass]
    public class PalindromTest {
        String[] textToTestPositive = new String[] { "Abba", "Lagerregal", "Reliefpfeiler", "Rentner", "Dienstmannamtsneid", "Tarne nie deinen Rat!", "Eine güldne, gute Tugend: Lüge nie!", "Ein agiler Hit reizt sie. Geist ? !Biertrunk nur treibt sie. Geist ziert ihre Liga nie!" };
        String[] textToTestNegative = new String[] { "Adba", "Po!lliL", "cd" };

        [TestMethod]
        public void TestMethod_PalindromRecursionWithSymbols() {
            // Arrange
            Palindrom p = new Palindrom();

            // Act
            List<bool> results = new List<bool>();
            foreach (String s in textToTestPositive) {
                results.Add(p.PalindromRecursionWithSymbols(s.ToCharArray(), 0, s.Length - 1));
            }

            // Assert
            Assert.IsTrue(results.TrueForAll(x => x), "Recursive palindrom with symbols does not work");
        }

        [TestMethod]
        public void TestMethod_PalindromRecursion() {
            // Arrange
            Palindrom p = new Palindrom();

            // Act
            List<bool> results = new List<bool>();
            foreach (String s in textToTestPositive) {
                String tmp = p.RemoveSymbols(s.ToLower());
                results.Add(p.PalindromNoRecursion(tmp));
            }

            // Assert
            Assert.IsTrue(results.TrueForAll(x => x), "Recursive palindrom without symbols does not work");
        }

        [TestMethod]
        public void TestMethod_PalindromNoRecursion() {
            // Arrange
            Palindrom p = new Palindrom();

            // Act
            List<bool> results = new List<bool>();
            foreach (String s in textToTestPositive) {
                String tmp = p.RemoveSymbols(s.ToLower());
                results.Add(p.PalindromNoRecursion(tmp));
            }

            // Assert
            Assert.IsTrue(results.TrueForAll(x => x), "Iterative palindrom without symbols does not work");
        }

        [TestMethod]
        public void TestMethod_PalindromRecursionWithSymbols_WrongInputs() {
            // Arrange
            Palindrom p = new Palindrom();

            // Act
            List<bool> results = new List<bool>();
            foreach (String s in textToTestNegative) {
                results.Add(p.PalindromRecursionWithSymbols(s.ToCharArray(), 0, s.Length - 1));
            }

            // Assert
            Assert.IsTrue(results.TrueForAll(x => !x), "Recursive palindrom with symbols does not work");
        }

        [TestMethod]
        public void TestMethod_PalindromRecursion_WrongInputs() {
            // Arrange
            Palindrom p = new Palindrom();

            // Act
            List<bool> results = new List<bool>();
            foreach (String s in textToTestNegative) {
                String tmp = p.RemoveSymbols(s.ToLower());
                results.Add(p.PalindromNoRecursion(tmp));
            }

            // Assert
            Assert.IsTrue(results.TrueForAll(x => !x), "Recursive palindrom without symbols does not work");
        }

        [TestMethod]
        public void TestMethod_PalindromNoRecursion_WrongInputs() {
            // Arrange
            Palindrom p = new Palindrom();

            // Act
            List<bool> results = new List<bool>();
            foreach (String s in textToTestNegative) {
                String tmp = p.RemoveSymbols(s.ToLower());
                results.Add(p.PalindromNoRecursion(tmp));
            }

            // Assert
            Assert.IsTrue(results.TrueForAll(x => !x), "Iterative palindrom without symbols does not work");
        }
    }
}
