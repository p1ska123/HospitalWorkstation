using HospitalWorkstationWPF.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HospitalWorkstationTests
{
    [TestClass]
    public class TemperatureSheetViewModelTest
    {
        /// <summary>
        /// ввод пустых данных
        /// </summary>
        [TestMethod]
        public void FillTemperatureSheet_someDataEmpty_exceptionReturn()
        {
            //arrange
            int idPatient = 84;
            DateTime dateStaying = DateTime.Today;
            string[] valuesMorning = { "", "", "", "", "", "", "", "", ""};
            string[] valuesEvening = { "", "", "", "", "", "", "", "", ""};
            //act
            Action actual = () => TemperatureSheetViewModel.FillTemperatureSheet(idPatient, dateStaying, valuesMorning, valuesEvening);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод слишком длинных строк (более 50 символов)
        /// </summary>
        [TestMethod]
        public void FillTemperatureSheet_longData_exceptionReturn()
        {
            //arrange
            int idPatient = 84;
            DateTime dateStaying = DateTime.Today;
            string[] valuesMorning = { "", "", "", "", "", "", "", "", "" };
            string[] valuesEvening = { "", "", "", "", "", "", "", "", "kefofkeofefiefjeifjiejfeiejfiejifjeifjeifwofefiefjeifjiejfeiejfiejifjeifjeifwjeifjwoeifjofefiefjeifjiejfeiejfiejifjeifjeifwjeifjwoeifjjeifjwoeifjwoeijfwoi" };
            //act
            Action actual = () => TemperatureSheetViewModel.FillTemperatureSheet(idPatient, dateStaying, valuesMorning, valuesEvening);
            //assert
            Assert.ThrowsException<Exception>(actual);
        }
        /// <summary>
        /// ввод корректных данных
        /// </summary>
        [TestMethod]
        public void FillTemperatureSheet_correctData_trueReturn()
        {
            //arrange
            int idPatient = 84;
            DateTime dateStaying = DateTime.Today;
            string[] valuesMorning = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] valuesEvening = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //act
            bool actual = TemperatureSheetViewModel.FillTemperatureSheet(idPatient, dateStaying, valuesMorning, valuesEvening);
            //assert
            Assert.IsTrue(actual);
        }
    }
}
