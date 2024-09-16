using HospitalWorkstationWPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HospitalWorkstationTests
{
    [TestClass]
    public class HospitalWorkersViewModelTest
    {
        /// <summary>
        /// ввод пустых строк
        /// </summary>
        [TestMethod]
        public void AddWorker_emptyData_exceptionReturn()
        {
            //arrange
            string name = "";
            string surname = "";
            string patronymic = "";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(-10);
            string login = "";
            string pass = "";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            Action actual = () => HospitalWorkersViewModel.AddWorker(name, surname, patronymic, idPost, birthday, login, pass, idRole, idWards);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод длинных строк
        /// </summary>
        [TestMethod]
        public void AddWorker_longData_exceptionReturn()
        {
            //arrange
            string name = "weer09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9r09fjef023j0092fj9";
            string surname = "";
            string patronymic = "";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(-10);
            string login = "";
            string pass = "";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            Action actual = () => HospitalWorkersViewModel.AddWorker(name, surname, patronymic, idPost, birthday, login, pass, idRole, idWards);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод человека из "будующего" (дата больше сегодняшней)
        /// </summary>
        [TestMethod]
        public void AddWorker_uncorrectData_exceptionReturn()
        {
            //arrange
            string name = "f23j0092fj9";
            string surname = "wefwe";
            string patronymic = "wefwefw";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(1);
            string login = "wefwefw";
            string pass = "wefwefw";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            Action actual = () => HospitalWorkersViewModel.AddWorker(name, surname, patronymic, idPost, birthday, login, pass, idRole, idWards);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод сущесвующего логина
        /// </summary>
        [TestMethod]
        public void AddWorker_uncorrectData1_exceptionReturn()
        {
            //arrange
            string name = "f23j0092fj9";
            string surname = "wefwe";
            string patronymic = "wefwefw";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(1);
            string login = "maenko123";
            string pass = "wefwefw";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            Action actual = () => HospitalWorkersViewModel.AddWorker(name, surname, patronymic, idPost, birthday, login, pass, idRole, idWards);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректных данных
        /// </summary>
        [TestMethod]
        public void AddWorker_correctData_trueReturn()
        {
            //arrange
            string name = "f23j0092fj9";
            string surname = "wefwe";
            string patronymic = "wefwefw";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(-10);
            string login = "maenk12231231231";
            string pass = "wefwefw";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            bool actual =  HospitalWorkersViewModel.AddWorker(name, surname, patronymic, idPost, birthday, login, pass, idRole, idWards);
            //assert
            Assert.IsTrue(actual);
        }


        /// <summary>
        /// ввод пустых строк
        /// </summary>
        [TestMethod]
        public void UpdateWorker_emptyData_exceptionReturn()
        {
            //arrange
            string name = "";
            string surname = "";
            string patronymic = "";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(-10);
            string login = "";
            string pass = "";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            Action actual = () => HospitalWorkersViewModel.UpdateWorker(name, surname, patronymic, idPost, birthday, idRole, idWards, 2, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод длинных строк
        /// </summary>
        [TestMethod]
        public void UpdateWorker_longData_exceptionReturn()
        {
            //arrange
            string name = "weer09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9er09fjef023j0092fj9r09fjef023j0092fj9";
            string surname = "";
            string patronymic = "";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(-10);
            string login = "";
            string pass = "";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            Action actual = () => HospitalWorkersViewModel.UpdateWorker(name, surname, patronymic, idPost, birthday, idRole, idWards, 2, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод человека из "будующего" (дата больше сегодняшней)
        /// </summary>
        [TestMethod]
        public void UpdateWorker_uncorrectData_exceptionReturn()
        {
            //arrange
            string name = "ау";
            string surname = "ау";
            string patronymic = "ау";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(1);
            string login = "ау";
            string pass = "уа";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            Action actual = () => HospitalWorkersViewModel.UpdateWorker(name, surname, patronymic, idPost, birthday, idRole, idWards, 2, pass);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректны данных
        /// </summary>
        [TestMethod]
        public void UpdateWorker_correctData_trueReturn()
        {
            //arrange
            string name = "ау";
            string surname = "ау";
            string patronymic = "ау";
            int idPost = 1;
            DateTime birthday = DateTime.Now.AddDays(1);
            string pass = "уа";
            int idRole = 1;
            List<int> idWards = new List<int> { 1, 2 };
            //act
            bool actual = HospitalWorkersViewModel.UpdateWorker(name, surname, patronymic, idPost, birthday, idRole, idWards, 2, pass);
            //assert
            Assert.IsTrue(actual);
        }


        /// <summary>
        /// ввод корректных данных
        /// </summary>
        [TestMethod]
        public void DeleteWorker_correctData_trueReturn()
        {
            //arrange
            //act
            bool actual = HospitalWorkersViewModel.DeleteWorker(4);
            //assert
            Assert.IsTrue(actual);
        }
    }
}
