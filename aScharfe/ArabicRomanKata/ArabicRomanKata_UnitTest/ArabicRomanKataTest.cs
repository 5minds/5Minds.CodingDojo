using System;
using ArabicRomanKata.Converter;
using ArabicRomanKata.Enum;
using ArabicRomanKata.Helper;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArabicRomanKataUnitTest
{
    [TestClass]
    public class ArabicRomanKataTest
    {

        [TestMethod]
        public void TestCheckInputValue()
        {
            Assert.IsTrue("1".CheckValueIsValid());
            Assert.IsTrue("12".CheckValueIsValid());
            Assert.IsTrue("123".CheckValueIsValid());
            Assert.IsTrue("1234".CheckValueIsValid());
            Assert.IsTrue("I".CheckValueIsValid());
            Assert.IsTrue("XII".CheckValueIsValid());
            Assert.IsTrue("CXXIII".CheckValueIsValid());
            Assert.IsTrue("MCCXXXIV".CheckValueIsValid());
            Assert.IsTrue("MMMCMXCIX".CheckValueIsValid());

            Assert.IsFalse("".CheckValueIsValid());
            Assert.IsFalse("0".CheckValueIsValid());
            Assert.IsFalse("4000".CheckValueIsValid());
            Assert.IsFalse("12345".CheckValueIsValid());
            Assert.IsFalse("123d".CheckValueIsValid());
            Assert.IsFalse("d123".CheckValueIsValid());

            Assert.IsFalse("MMMMMM".CheckValueIsValid());
            Assert.IsFalse("P".CheckValueIsValid());
        }

        [TestMethod]
        public void TestArabicToRoman()
        {
            Assert.AreEqual("",0.ConvertArabicToRoman());
            Assert.AreEqual("I",1.ConvertArabicToRoman());
            Assert.AreEqual("MCMLXXIV", 1974.ConvertArabicToRoman());
            Assert.AreEqual("MMMCMXCIX", 3999.ConvertArabicToRoman());
        }

        [TestMethod]
        public void TestRomanToArabic()
        {
            Assert.AreEqual(0,"".ConvertRomanToArabic());
            Assert.AreEqual(1,"I".ConvertRomanToArabic());
            Assert.AreEqual(1974, "MCMLXXIV".ConvertRomanToArabic());
            Assert.AreEqual(3999, "MMMCMXCIX".ConvertRomanToArabic());
            Assert.AreEqual(1974, "mcmlxxiv".ConvertRomanToArabic());
        }

        [TestMethod]
        public void TestConversionDirection()
        {
            Assert.AreEqual(ConversionDirection.Unknown, "".GetConversionDirection());
            Assert.AreEqual(ConversionDirection.Unknown, "P".GetConversionDirection());
            Assert.AreEqual(ConversionDirection.ToArabic, "I".GetConversionDirection());
            Assert.AreEqual(ConversionDirection.ToRoman, "1".GetConversionDirection());
        }
    }
}
