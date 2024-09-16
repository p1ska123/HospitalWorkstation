using HospitalWorkstationTests.Model;
using HospitalWorkstationWPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace HospitalWorkstationTests
{
    [TestClass]
    public class HospitalDepartmentsViewModelTest
    {
        /// <summary>
        /// ввод пустрй строки
        /// </summary>
        [TestMethod]
        public void AddDepartment_emptyData_exceptionReturn()
        {
            //arrange
            string departName = "";
            //act
            Action actual = () => HospitalDepartmentsViewModel.AddDepartment(departName);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод длинной строки
        /// </summary>
        [TestMethod]
        public void AddDepartment_longData_exceptionReturn()
        {
            //arrange
            string departName = "9j3409fj934f94j9f03409fj3409f309rjf934f94j9f03409fj3409f309rjf934f94j9f03409fj3409f309rjf934f94j9f03409fj3409f309rjf";
            //act
            Action actual = () => HospitalDepartmentsViewModel.AddDepartment(departName);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод cуществующего отделения
        /// </summary>
        [TestMethod]
        public void AddDepartment_uncorrectData_exceptionReturn()
        {
            //arrange
            string departName = "Терапевтическое";
            //act
            Action actual = () => HospitalDepartmentsViewModel.AddDepartment(departName);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректной строки
        /// </summary>
        [TestMethod]
        public void AddDepartment_correctData_trueReturn()
        {
            //arrange
            string departName = "для теста2";
            //act
            bool actual = HospitalDepartmentsViewModel.AddDepartment(departName);
            //assert
            Assert.IsTrue(actual);
        }


        /// <summary>
        /// ввод пустрй строки
        /// </summary>
        [TestMethod]
        public void UpddateDepartment_emptyData_exceptionReturn()
        {
            //arrange
            string departName = "";
            //act
            Action actual = () => HospitalDepartmentsViewModel.UdpateDepartment(1, departName);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод длинной строки
        /// </summary>
        [TestMethod]
        public void UpddateDepartment_longData_exceptionReturn()
        {
            //arrange
            string departName = "-п0л43ула-304уацщалцу-0лацщвлазцщлащц4уацщалцу-0лацщвлазцщлащц4уацщалцу-0лацщвлазцщлащц4уацщалцу-0лацщвлазцщлащц4уацщалцу-0лацщвлазцщлащц";
            //act
            Action actual = () => HospitalDepartmentsViewModel.UdpateDepartment(1, departName);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод cуществующего отделения
        /// </summary>
        [TestMethod]
        public void UpdateDepartment_uncorrectData_exceptionReturn()
        {
            //arrange
            string departName = "Терапевтическое";
            //act
            Action actual = () => HospitalDepartmentsViewModel.UdpateDepartment(1,departName);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректных данных
        /// </summary>
        [TestMethod]
        public void UpddateDepartment_correctData_trueReturn()
        {
            //arrange
            string departName = "для теста1";
            //act
            bool actual = HospitalDepartmentsViewModel.UdpateDepartment(1, departName);
            //assert
            Assert.IsTrue(actual);
        }


        /// <summary>
        /// ввод корректых данных
        /// </summary>
        [TestMethod]
        public void DeleteDepartment_correctData_trueReturn()
        {
            //arrange
            //act
            bool actual = HospitalDepartmentsViewModel.DeleteDepartment(11);
            //assert
            Assert.IsTrue(actual);
        }
    }
}
