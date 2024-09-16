using HospitalWorkstationWPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HospitalWorkstationTests
{
    [TestClass]
    public class HospitalPatientsViewModelTest
    {
        /// <summary>
        /// ввод уникального кода
        /// </summary>
        [TestMethod]
        public void RegNumberIsUnique_uniqueNumber_trueReturn()
        {
            //arrange
            int num = 12345;
            //act
            bool actual = HospitalPatientsViewModel.RegNumberIsUnique(num);
            //assert
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// ввод существубщего кода
        /// </summary>
        [TestMethod]
        public void RegNumberIsUnique_notUniqueNumber_falseReturn()
        {
            //arrange
            int num = 23561;
            //act
            bool actual = HospitalPatientsViewModel.RegNumberIsUnique(num);
            //assert
            Assert.IsFalse(actual);
        }




        /// <summary>
        /// ввод пустых данных
        /// </summary>
        [TestMethod]
        public void AddPatient_emptyData_exceptionReturn()
        {
            //arrange
            string name = "";
            string surname = "";
            string patronymic = "";
            int idWard = 2;
            int idDiagnosis = 3;
            DateTime birthday = DateTime.Now.AddDays(-10);
            DateTime arrivalDate = DateTime.Now.AddDays(-5);
            string appointment = "d";
            string bloodGroup = "d";
            string rhesusType = "d";
            string sideEffect = "d";
            string drugForSideEffect = "d";
            string adress = "d";
            string placeWord = "d";
            //act
            Action actual = () => HospitalPatientsViewModel.AddPatient(name, surname, patronymic, idWard, idDiagnosis, birthday, arrivalDate, appointment, bloodGroup, rhesusType, sideEffect, drugForSideEffect, adress, placeWord);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод длинных данных
        /// </summary>
        [TestMethod]
        public void AddPatient_longData_exceptionReturn()
        {
            //arrange
            string name = "vwjef-029j3f9fj2039fj0923j9f293fj203f09j2039fj0923j9f293fj203f09j2039fj0923j9f293fj203f09j2039fj0923j9f293fj203f09j2039fj0923j9f293fj203f09";
            string surname = "f";
            string patronymic = "f";
            int idWard = 2;
            int idDiagnosis = 3;
            DateTime birthday = DateTime.Now.AddDays(-10);
            DateTime arrivalDate = DateTime.Now.AddDays(-5);
            string appointment = "d";
            string bloodGroup = "d";
            string rhesusType = "d";
            string sideEffect = "d";
            string drugForSideEffect = "d";
            string adress = "d";
            string placeWord = "d";
            //act
            Action actual = () => HospitalPatientsViewModel.AddPatient(name, surname, patronymic, idWard, idDiagnosis, birthday, arrivalDate, appointment, bloodGroup, rhesusType, sideEffect, drugForSideEffect, adress, placeWord);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод "пустой" палаты (idWard = 0)
        /// </summary>
        [TestMethod]
        public void AddPatient_uncorrectData_exceptionReturn()
        {
            //arrange
            string name = "9f293fj203f09";
            string surname = "f";
            string patronymic = "f";
            int idWard = 0;
            int idDiagnosis = 3;
            DateTime birthday = DateTime.Now.AddDays(-10);
            DateTime arrivalDate = DateTime.Now.AddDays(-5);
            string appointment = "d";
            string bloodGroup = "d";
            string rhesusType = "d";
            string sideEffect = "d";
            string drugForSideEffect = "d";
            string adress = "d";
            string placeWord = "d";
            //act
            Action actual = () => HospitalPatientsViewModel.AddPatient(name, surname, patronymic, idWard, idDiagnosis, birthday, arrivalDate, appointment, bloodGroup, rhesusType, sideEffect, drugForSideEffect, adress, placeWord);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод человека из "будущего"
        /// </summary>
        [TestMethod]
        public void AddPatient_uncorrectData1_exceptionReturn()
        {
            //arrange
            string name = "9f293fj203f09";
            string surname = "f";
            string patronymic = "f";
            int idWard = 5;
            int idDiagnosis = 3;
            DateTime birthday = DateTime.Now.AddDays(10);
            DateTime arrivalDate = DateTime.Now.AddDays(-5);
            string appointment = "d";
            string bloodGroup = "d";
            string rhesusType = "d";
            string sideEffect = "d";
            string drugForSideEffect = "d";
            string adress = "d";
            string placeWord = "d";
            //act
            Action actual = () => HospitalPatientsViewModel.AddPatient(name, surname, patronymic, idWard, idDiagnosis, birthday, arrivalDate, appointment, bloodGroup, rhesusType, sideEffect, drugForSideEffect, adress, placeWord);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректных данных
        /// </summary>
        [TestMethod]
        public void AddPatient_correctData_trueReturn()
        {
            //arrange
            string name = "9f293fj203f09";
            string surname = "ff";
            string patronymic = "п";
            int idWard = 5;
            int idDiagnosis = 3;
            DateTime birthday = DateTime.Now.AddDays(-10);
            DateTime arrivalDate = DateTime.Now.AddDays(-5);
            string appointment = "d";
            string bloodGroup = "d";
            string rhesusType = "d";
            string sideEffect = "d";
            string drugForSideEffect = "d";
            string adress = "d";
            string placeWord = "d";
            //act
            bool actual = HospitalPatientsViewModel.AddPatient(name, surname, patronymic, idWard, idDiagnosis, birthday, arrivalDate, appointment, bloodGroup, rhesusType, sideEffect, drugForSideEffect, adress, placeWord);
            //assert
            Assert.IsTrue(actual);
        }
        /// <summary>
        /// ввод корректных данных
        /// </summary>
        [TestMethod]
        public void DeletePatient_correctData_trueReturn()
        {
            //arrange
            //act
            bool actual = HospitalPatientsViewModel.DeletePatient(79);
            //assert
            Assert.IsTrue(actual);
        }
    }
}
