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
    /// Логика взаимодействия для EditPatientPage.xaml
    /// </summary>
    public partial class EditPatientPage : Page
    {
        readonly Core db = new Core(); 
        List<HospitalWards> wards = new List<HospitalWards>();
        int idPatient;
        int idWard;
        public EditPatientPage(int idPatient)
        {
            InitializeComponent();
            this.idPatient = idPatient;
            BirthdayDatePicker.SelectedDate = DateTime.Today;
            ArrivalDatePicker.SelectedDate = DateTime.Today;
            DiagnosisComboBox.ItemsSource = db.context.Diagnoses.OrderBy(x => x.NameDiagnosis).ToList();
            DiagnosisComboBox.SelectedValuePath = "IdDiagnosis";
            DiagnosisComboBox.DisplayMemberPath = "NameDiagnosis";
            if (Properties.Settings.Default.idRole == 3)
            {
                wards = db.context.HospitalWards.ToList();
            }
            else
            {
                List<HospitalWards> wards1 = new List<HospitalWards>();
                foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == Properties.Settings.Default.idWorker).ToList())
                {
                    foreach (HospitalWards myWard in db.context.HospitalWards.Where(x => x.IdWard == workerInWards.WardId).ToList())
                    {
                        wards1.Add(myWard);
                    }
                }
                wards = wards1;
            }
            NameTextBox.Text = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).NamePatient;
            SurnameTextBox.Text = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).SurnamePatient;
            PatronymicTextBox.Text = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).PatronymicPatient;
            DiagnosisComboBox.SelectedValue = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).IdDiagnosis;
            BirthdayDatePicker.SelectedDate = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).BirthdayPatient;
            ArrivalDatePicker.SelectedDate = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).ArrivalDate;
            if (db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == idPatient) != null) AppointmentTextBox.Text = db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == idPatient).Description;
            idWard = (int)db.context.HospitalPatients.FirstOrDefault(y => y.IdPatient == idPatient).WardId;
            AboutWardTextBlock.Text = db.context.HospitalWards.FirstOrDefault(x => x.IdWard == idWard).NameWardAdd;
            wards.Remove(db.context.HospitalWards.FirstOrDefault(x => x.IdWard == idWard));
            WardsListView.ItemsSource = wards.OrderBy(x => x.NameWard);
            if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient) != null)
            {
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).BloodGroup != null) BloodGroupTextBox.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).BloodGroup;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient) != null) RhesusTypeTextBox.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).RhesusType;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).SideEffect != null) SideEffectTextBox.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).SideEffect;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).DrugNameOfSideEffect != null)
                    NameOfDrugToSideEffectTextBox.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).DrugNameOfSideEffect;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).Adress != null)
                    AdressTextBox.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).Adress;
                if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).PlaceOfWork_Study != null)
                    PlaceWorkStudyTextBox.Text = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).PlaceOfWork_Study;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.idRole != 3) this.NavigationService.Navigate(new MainPage());
            else NavigationService.Navigate(new PatientsPage(0, 0));
        }

        private void SelectWardButton_Click(object sender, RoutedEventArgs e)
        {
            wards.Clear();
            if (Properties.Settings.Default.idRole == 3)
            {
                wards = db.context.HospitalWards.ToList();
            }
            else
            {
                List<HospitalWards> wards1 = new List<HospitalWards>();
                foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == Properties.Settings.Default.idWorker).ToList())
                {
                    foreach (HospitalWards myWard in db.context.HospitalWards.Where(x => x.IdWard == workerInWards.WardId).ToList())
                    {
                        wards1.Add(myWard);
                    }
                }
                wards = wards1;
            }
            Button activeButton = (Button)sender;
            HospitalWards activeWard = (HospitalWards)activeButton.DataContext;
            idWard = activeWard.IdWard;
            AboutWardTextBlock.Text = activeWard.NameWardAdd;
            wards.Remove(activeWard);
            WardsListView.ItemsSource = wards.OrderBy(x => x.NameWard);
        }

        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HospitalPatientsViewModel.UpdatePatient(idPatient, NameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text, idWard, (int)DiagnosisComboBox.SelectedValue, (DateTime)BirthdayDatePicker.SelectedDate, (DateTime)ArrivalDatePicker.SelectedDate, AppointmentTextBox.Text, BloodGroupTextBox.Text, RhesusTypeTextBox.Text, SideEffectTextBox.Text, NameOfDrugToSideEffectTextBox.Text, AdressTextBox.Text, PlaceWorkStudyTextBox.Text))
                {
                    MessageBox.Show("Данные сохранены");
                    if (Properties.Settings.Default.idRole != 3) this.NavigationService.Navigate(new MainPage());
                    else NavigationService.Navigate(new PatientsPage(0, 0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
