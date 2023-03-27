using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Biletn5YD;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double a = 100;
            double b = 100;
            double x = 0;
            double result = Biletn5YD.SUSL.USL(a,b,x);
            Assert.AreEqual(1000, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            double a = 2.2;
            double b = 1.1;
            double x = 2;
            double result = Biletn5YD.SUSL.USL(a, b, x);
            Assert.AreEqual(0.726, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            double a = -100;
            double b = -100;
            double x = 0;
            double result = Biletn5YD.SUSL.USL(a, b, x);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void TestMethod4()
        {
            double a = Convert.ToDouble(" ");
            double b = Convert.ToDouble(" ");
            double x = 0;
            double result = Biletn5YD.SUSL.USL(a, b, x);
            Assert.AreEqual(false, result);
        }
    }
}
