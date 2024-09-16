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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalWorkstationWPF.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        readonly Core db = new Core();
        public MainPage()
        {
            InitializeComponent();
            List<HospitalDepartments> departments = new List<HospitalDepartments>();
            foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == Properties.Settings.Default.idWorker).ToList())
            {
                foreach (HospitalWards wards in db.context.HospitalWards.Where(x => x.IdWard == workerInWards.WardId).ToList())
                {
                    departments.Add(db.context.HospitalDepartments.FirstOrDefault(x => x.IdDepartment == wards.DepartmentId));
                }
            }
            departments.Distinct().OrderBy(x => x.IdDepartment);
            HospitalDepartments department = new HospitalDepartments()
            {
                IdDepartment = 0,
                NameDepartment = "Все"
            };
            departments.Insert(0, department);
            DepartmensComboBox.ItemsSource = departments;
            DepartmensComboBox.DisplayMemberPath = "NameDepartmentAdd";
            DepartmensComboBox.SelectedValuePath = "IdDepartment";
            DepartmensComboBox.SelectedIndex = 0;

            UpdateWardComboBox();
            UpdateList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }

        private void WardsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void DepartmensComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
            UpdateWardComboBox();
        }
        private void UpdateList()
        {
            List<HospitalPatients> patients = new List<HospitalPatients>();
            foreach (WorkerInWards myWard in db.context.WorkerInWards.Where(x => x.WorkerId == Properties.Settings.Default.idWorker).ToList())
            {
                foreach (HospitalPatients patientMyWard in db.context.HospitalPatients.Where(x => x.WardId == myWard.WardId))
                {
                    patients.Add(patientMyWard);
                }
            }
            if (DepartmensComboBox.SelectedIndex != 0) patients = patients.Where(x => x.IdDepartment == (int)DepartmensComboBox.SelectedValue).ToList();
            if (WardsComboBox.SelectedValue != null)
            {
                if ((int)WardsComboBox.SelectedValue != 0) patients = patients.Where(x => x.WardId == (int)WardsComboBox.SelectedValue).ToList();
            }
            if (int.TryParse(SearchTextBox.Text, out int a)) patients = patients.Where(x => x.RegistrationNumber.Contains(SearchTextBox.Text)).ToList();
            else patients = patients.Where(x => x.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            MyPatientsListView.ItemsSource = patients;
        }
        private void UpdateWardComboBox()
        {
            List<HospitalWards> wards = new List<HospitalWards>();
            foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == Properties.Settings.Default.idWorker).ToList())
            {
                wards.Add(db.context.HospitalWards.FirstOrDefault(x => x.IdWard == workerInWards.WardId));
            }
            if (DepartmensComboBox.SelectedIndex != 0) wards = wards.Where(x => x.DepartmentId == (int)DepartmensComboBox.SelectedValue).ToList();
            wards.OrderBy(x => x.NameWard);
            HospitalWards ward = new HospitalWards()
            {
                IdWard = 0,
                NameWard = "Все",
            };
            wards.Insert(0, ward);
            WardsComboBox.ItemsSource = wards;
            WardsComboBox.DisplayMemberPath = "NameWardAdd";
            WardsComboBox.SelectedValuePath = "IdWard";
            WardsComboBox.SelectedIndex = 0;
        }


        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            Button activeElement = (Button)sender;
            HospitalPatients activePatient = (HospitalPatients)activeElement.DataContext;
            MessageBoxResult messageBox = MessageBox.Show($"Вы уверены что хотите удалить пациента \"{activePatient.FIO}\"?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                try
                {
                    if (HospitalPatientsViewModel.DeletePatient(activePatient.IdPatient)) this.NavigationService.Navigate(new MainPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } 
        }

        private void AddDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new AddPatientPage());
        }

        private void EditDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalPatients selectedPatient = (HospitalPatients)MyPatientsListView.SelectedItem;
            if (selectedPatient == null)
            {
                MessageBox.Show("Вы не выбрали пациента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NavigationService.Navigate(new EditPatientPage(selectedPatient.IdPatient));
        }

        private void DeleteDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalPatients selectedPatient = (HospitalPatients)MyPatientsListView.SelectedItem;
            if (selectedPatient == null)
            {
                MessageBox.Show("Вы не выбрали пациента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult messageBox = MessageBox.Show($"Вы уверены что хотите удалить пациента \"{selectedPatient.FIO}\"? Будет удалена вся информация о пациенте.", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                try
                {
                    if (HospitalPatientsViewModel.DeletePatient(selectedPatient.IdPatient))
                    {
                        MessageBox.Show("Данные удалены");
                        NavigationService.Navigate(new PatientsPage(0, 0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void FillListButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalPatients selectedPatient = (HospitalPatients)MyPatientsListView.SelectedItem;
            if (selectedPatient == null)
            {
                MessageBox.Show("Вы не выбрали пациента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<DateTime> dates = new List<DateTime>();
            foreach (TemperatureSheet sheet in db.context.TemperatureSheet.Where(x => x.PatientId == selectedPatient.IdPatient))
            {
                dates.Add(sheet.DateStaying);
            }
            if (dates.Distinct().Count() == 15)
            {
                MessageBox.Show("Данных, для выдачи температурного листа, достаточно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            NavigationService.Navigate(new FillTemperatureListPage(selectedPatient.IdPatient));
        }

        private void MoreButton_Click(object sender, MouseButtonEventArgs e)
        {
            Image selectedItem = (Image)sender;
            HospitalPatients selectedPatient = (HospitalPatients)selectedItem.DataContext;
            NavigationService.Navigate(new MoreInfoAboutPatient(selectedPatient.IdPatient));
        }
    }
}
