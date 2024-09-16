using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HospitalWorkstationWPF;
using HospitalWorkstationWPF.Classes;

namespace HospitalWorkstationTests
{
    [TestClass]
    public class AdditionalMethodsTest
    {
        /// <summary>
        /// Ввод строки для кэширования
        /// </summary>
        [TestMethod]
        public void CachingPassword_string_CachingPassReturn()
        {
            //arrange
            string pass = "AntoninaPlatonova283";
            //act
            string actual = AdditionalMethods.CachingPassword(pass);
            string expected = "85eff7d87b0264feae5f9c562e9e19523bc38922c2a2b8ef51dd23c120caa26c";
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
