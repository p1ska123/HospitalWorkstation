using HospitalWorkstationWPF.Classes;
using HospitalWorkstationWPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HospitalWorkstationTests
{
    [TestClass]
    public class HospitalWardsViewModelTest
    {
        /// <summary>
        /// ввод пустых данных
        /// </summary>
        [TestMethod]
        public void AddWard_emptyData_exceptionReturn()
        {
            //arrange
            string name = "";
            //act
            Action actual = () => HospitalWardsViewModel.AddWard(name, 5 , 5);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод длинных данных
        /// </summary>
        [TestMethod]
        public void AddWard_longData_exceptionReturn()
        {
            //arrange
            string name = "owefpokfpkofkpofko";
            //act
            Action actual = () => HospitalWardsViewModel.AddWard(name, 5, 5);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод существующих данных
        /// </summary>
        [TestMethod]
        public void AddWard_uncorrectData_exceptionReturn()
        {
            //arrange
            string name = "25";
            //act
            Action actual = () => HospitalWardsViewModel.AddWard(name, 5, 5);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректных данных данных
        /// </summary>
        [TestMethod]
        public void AddWard_correctData_trueReturn()
        {
            //arrange
            string name = "25123";
            //act
            bool actual = HospitalWardsViewModel.AddWard(name, 5, 5);
            //assert
            Assert.IsTrue(actual);
        }


        /// <summary>
        /// ввод пустых данных
        /// </summary>
        [TestMethod]
        public void UpdateWard_emptyData_exceptionReturn()
        {
            //arrange
            string name = "";
            //act
            Action actual = () => HospitalWardsViewModel.UpdateWard(1, name, 5, 5);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод длинных данных
        /// </summary>
        [TestMethod]
        public void UpdateWard_longData_exceptionReturn()
        {
            //arrange
            string name = "2512312313123123131231231";
            //act
            Action actual = () => HospitalWardsViewModel.UpdateWard(1, name, 5, 5);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод существующих данных
        /// </summary>
        [TestMethod]
        public void UpdateWard_uncorrectData_exceptionReturn()
        {
            //arrange
            string name = "25";
            //act
            Action actual = () => HospitalWardsViewModel.UpdateWard(1, name, 5, 5);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректных данных данных
        /// </summary>
        [TestMethod]
        public void UpdateWard_correctData_trueReturn()
        {
            //arrange
            string name = "253";
            //act
            bool actual = HospitalWardsViewModel.UpdateWard(5, name, 5, 5);
            //assert
            Assert.IsTrue(actual);
        }



        /// <summary>
        /// ввод корректных данных данных
        /// </summary>
        [TestMethod]
        public void DeleteWards_correctData_trueReturn()
        {
            //arrange
            //act
            bool actual = HospitalWardsViewModel.DeleteWards(3);
            //assert
            Assert.IsTrue(actual);
        }
    }
}
