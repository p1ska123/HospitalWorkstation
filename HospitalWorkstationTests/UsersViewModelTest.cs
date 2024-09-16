using HospitalWorkstationWPF.Classes;
using HospitalWorkstationWPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HospitalWorkstationTests
{
    [TestClass]
    public class UsersViewModelTest
    {
        /// <summary>
        /// ввод пустого пароля и логина
        /// </summary>
        [TestMethod]
        public void CheckAuth_empty_exceptionReturn()
        {
            //arrange
            string login = "";
            string pass = "";
            //act
            Action actual = () => UsersViewModel.CheckAuth(login, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод пустого пароля но верного логина
        /// </summary>
        [TestMethod]
        public void CheckAuth_emptyPassword_exceptionReturn()
        {
            //arrange
            string login = "maenko123";
            string pass = "";
            //act
            Action actual = () => UsersViewModel.CheckAuth(login, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод пустого логина но верного пароля
        /// </summary>
        [TestMethod]
        public void CheckAuth_emptyLogin_exceptionReturn()
        {
            //arrange
            string login = "";
            string pass = "123";
            //act
            Action actual = () => UsersViewModel.CheckAuth(login, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод невуществующего логина
        /// </summary>
        [TestMethod]
        public void CheckAuth_nonexistentLogin_exceptionReturn()
        {
            //arrange
            string login = "1ва12в12в12в21в21";
            string pass = "123";
            //act
            Action actual = () => UsersViewModel.CheckAuth(login, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод верного логина но неправильного пароля
        /// </summary>
        [TestMethod]
        public void CheckAuth_uncorrectPass_exceptionReturn()
        {
            //arrange
            string login = "1ва12в12в12в21в21";
            string pass = "123";
            //act
            Action actual = () => UsersViewModel.CheckAuth(login, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод верного корректных существующих логина и пароля
        /// </summary>
        [TestMethod]
        public void CheckAuth_correctData_trueReturn()
        {
            //arrange
            string login = "AntoninaPlatonova283";
            string pass = "AntoninaPlatonova283";
            //act
            bool actual = UsersViewModel.CheckAuth(login, pass);
            //assert
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// ввод id существующего пользователя
        /// </summary>
        [TestMethod]
        public void GetFullUserName_correctData_trueReturn()
        {
            //arrange
            int idWorker = 1;
            int idRole = 1;
            //act
            string actual = UsersViewModel.GetFullUserName(idWorker, idRole);
            string expected = "Платонова Антонина Олеговна, врач, терапевт";
            //assert
            Assert.AreEqual(actual, expected);
        }
    }
}
