using HospitalWorkstationWPF.Model;
using HospitalWorkstationWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalWorkstationWPF.View
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoAboutPatient.xaml
    /// </summary>
    public partial class MoreInfoAboutPatient : Page
    {
        readonly Core db = new Core();
        int idPatient;
        public MoreInfoAboutPatient(int idPatient)
        {
            this.idPatient = idPatient;
            InitializeComponent();
            PatientName.Text = "Пациент: " + db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).FIO;
            List<DateTime> dates = new List<DateTime>();
            foreach (TemperatureSheet sheet in db.context.TemperatureSheet.Where(x => x.PatientId == idPatient))
            {
                dates.Add(sheet.DateStaying);
            }
            dates.Distinct();
            if (dates.Distinct().Count() != 0)
            {
                PatientsDatesDatePicker.DisplayDateStart = dates.First();
                PatientsDatesDatePicker.DisplayDateEnd = dates.Last();
                PatientsDatesDatePicker.SelectedDate = dates.First();
                UpdateTable();
            }
            else
            {
                PatientsDatesDatePicker.Visibility = Visibility.Collapsed;
            }
            if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient) != null) 
            {
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).BloodGroup != null) BloodGroupTextBlock.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).BloodGroup;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient) != null) RhesusTypeTextBlock.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).RhesusType;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).SideEffect != null) SideEffectTextBlock.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).SideEffect;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).DrugNameOfSideEffect != null)
                    DrugNameTextBlock.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).DrugNameOfSideEffect;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).Adress != null)
                    AdressTextBlock.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).Adress;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).PlaceOfWork_Study != null)
                    PlaceWorkStudyTextBlock.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).PlaceOfWork_Study;
            }
        }

        private void PatientsDatesDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTable();
        }
        private void UpdateTable()
        {
            List<TemperatureSheet> selectedDateSheet = db.context.TemperatureSheet.Where(x => x.PatientId == idPatient && x.DateStaying == (DateTime)PatientsDatesDatePicker.SelectedDate).ToList();
            Value1MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 1).Value;
            Value1EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 1).Value;
            Value2MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 2).Value;
            Value2EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 2).Value;
            Value3MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 3).Value;
            Value3EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 3).Value;
            Value4MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 4).Value;
            Value4EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 4).Value;
            Value5MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 5).Value;
            Value5EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 5).Value;
            Value6MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 6).Value;
            Value6EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 6).Value;
            Value7MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 7).Value;
            Value7EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 7).Value;
            Value8MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 8).Value;
            Value8EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 8).Value;
            Value9MorningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 1 && x.ParameterId == 9).Value;
            Value9EveningTextBlock.Text = selectedDateSheet.FirstOrDefault(x => x.TimeId == 2 && x.ParameterId == 9).Value;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void GetMedicialCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HospitalPatientsViewModel.CreateMedicialCard(idPatient);
                MessageBox.Show("Файл успешно создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTemperetureSheetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TemperatureSheetViewModel.CreateWordFile(idPatient);
                MessageBox.Show("Файл успешно создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
