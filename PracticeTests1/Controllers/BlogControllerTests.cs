using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Controllers.Tests
{
    [TestClass()]
    public class BlogControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            BlogController target = new BlogController();
            int firstNumber = 1;
            int secondNumber = 2;
            int expected = 3;
            int actual;
            actual = target.Add(firstNumber, secondNumber);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Minus_Input_First_3_Second_2_Return_1()
        {
            BlogController target = new BlogController();
            int firstNumber = 3;
            int secondNumber = 2;
            int expected = 1;
            int actual;
            actual = target.Minus(firstNumber, secondNumber);
            Assert.AreEqual(expected, actual);
        }
    }
}