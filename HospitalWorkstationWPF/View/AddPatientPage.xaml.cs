using HospitalWorkstationWPF.Model;
using HospitalWorkstationWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AddPatientPage.xaml
    /// </summary>
    public partial class AddPatientPage : Page
    {
        readonly Core db = new Core();
        int idWard = 0;
        List<HospitalWards> wards = new List<HospitalWards>();
        public AddPatientPage()
        {
            InitializeComponent();
            BirthdayDatePicker.SelectedDate = DateTime.Today;
            ArrivalDatePicker.SelectedDate = DateTime.Today;
            DiagnosisComboBox.ItemsSource = db.context.Diagnoses.OrderBy(x => x.NameDiagnosis).ToList();
            DiagnosisComboBox.SelectedValuePath = "IdDiagnosis";
            DiagnosisComboBox.DisplayMemberPath = "NameDiagnosis";
            DiagnosisComboBox.SelectedIndex = 0;
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
            WardsListView.ItemsSource = wards.OrderBy(x => x.NameWard);
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HospitalPatientsViewModel.AddPatient(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text, idWard, (int)DiagnosisComboBox.SelectedValue, (DateTime)BirthdayDatePicker.SelectedDate, (DateTime)ArrivalDatePicker.SelectedDate, AppointmentTextBox.Text, BloodGroupTextBox.Text, RhesusTypeTextBox.Text, SideEffectTextBox.Text, NameOfDrugToSideEffectTextBox.Text, AdressTextBox.Text, PlaceWorkStudyTextBox.Text))
                {
                    MessageBox.Show("Пользователь добавлен");
                    if (Properties.Settings.Default.idRole != 3) this.NavigationService.Navigate(new MainPage());
                    else NavigationService.Navigate(new PatientsPage(0, 0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
