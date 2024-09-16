using HospitalWorkstationWPF.Model;
using HospitalWorkstationWPF.Properties;
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
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        readonly Core db = new Core();
        public PatientsPage(int idWard, int idWorker)
        {
            InitializeComponent();
            if (Properties.Settings.Default.idRole == 3) ButtonsStackPanel.Visibility = Visibility.Visible;
            List<HospitalDepartments> departments = db.context.HospitalDepartments.ToList();
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
            UpdateWorkersComboBox();
            UpdateWardComboBox();
            UpdateList();
            WardsComboBox.SelectedValue = idWard;
            WorekrsComboBox.SelectedValue = idWorker; 
        }

        private void DepartmensComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
            UpdateWardComboBox();
        }

        private void WardsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
            UpdateWorkersComboBox();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
        private void UpdateList()
        {
            List<HospitalPatients> patients = db.context.HospitalPatients.ToList();
            if (DepartmensComboBox.SelectedIndex != 0) patients = patients.Where(x => x.IdDepartment == DepartmensComboBox.SelectedIndex).ToList();
            if (WardsComboBox.SelectedValue != null)
            {
                if ((int)WardsComboBox.SelectedValue != 0) patients = patients.Where(x => x.WardId == (int)WardsComboBox.SelectedValue).ToList();
            }
            if (WorekrsComboBox.SelectedValue != null)
            {
                if ((int)WorekrsComboBox.SelectedValue != -1)
                {
                    if ((int)WorekrsComboBox.SelectedValue != 0)
                    {
                        List<HospitalPatients> patientsWorker = new List<HospitalPatients>();
                        foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == (int)WorekrsComboBox.SelectedValue).ToList())
                        {
                            foreach (HospitalPatients patient in db.context.HospitalPatients.Where(x => x.WardId == workerInWards.WardId).ToList())
                            {
                                patientsWorker.Add(patient);
                            }
                        }
                        patients = patients.Intersect(patientsWorker).ToList();
                    }
                }
                else
                {
                    List<int> wardsIdAll = new List<int>();
                    List<int> wardsIdHave = new List<int>();
                    List<HospitalPatients> patientsNull = new List<HospitalPatients>();
                    foreach (HospitalWards ward in db.context.HospitalWards.ToList())
                    {
                        wardsIdAll.Add(ward.IdWard);
                    }
                    foreach (WorkerInWards workerInWards in db.context.WorkerInWards.ToList())
                    {
                        wardsIdHave.Add(workerInWards.WardId);
                    }
                    foreach (int idNullWard in wardsIdAll.Except(wardsIdHave))
                    {
                        foreach (HospitalPatients patient in db.context.HospitalPatients.Where(x => x.WardId == idNullWard).ToList())
                        {
                            patientsNull.Add(patient);
                        }
                    }
                    patients = patients.Intersect(patientsNull).ToList();
                }
            }
            patients = patients.Distinct().ToList();
            if (int.TryParse(SearchTextBox.Text, out int a)) patients = patients.Where(x => x.RegistrationNumber.Contains(SearchTextBox.Text)).ToList();
            else patients = patients.Where(x => x.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            PatientsListView.ItemsSource = patients;
        }
        private void UpdateWardComboBox()
        {
            List<HospitalWards> wards = new List<HospitalWards>();
            if (DepartmensComboBox.SelectedIndex != 0) wards = db.context.HospitalWards.Where(x => x.DepartmentId == DepartmensComboBox.SelectedIndex).ToList();
            else wards = db.context.HospitalWards.ToList();
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
            UpdateWorkersComboBox();
        }
        private void UpdateWorkersComboBox()
        {
            List<HospitalWorkers> workers = new List<HospitalWorkers>();
            List<int> idWorkerUnique = new List<int>();
            if (DepartmensComboBox.SelectedIndex != 0 && WardsComboBox.SelectedIndex != 0) //оба выбраны
            {
                if (WardsComboBox.SelectedValue != null)
                {
                    foreach (HospitalWards ward in db.context.HospitalWards.Where(x => x.DepartmentId == (int)DepartmensComboBox.SelectedValue && x.IdWard == (int)WardsComboBox.SelectedValue).ToList())
                    {
                        foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WardId == ward.IdWard).ToList())
                        {
                            idWorkerUnique.Add(workerInWards.WorkerId);
                        }
                    }
                    foreach (int idWorker in idWorkerUnique.Distinct())
                    {
                        foreach (HospitalWorkers newWorker in db.context.HospitalWorkers.Where(x => x.IdWorker == idWorker).ToList())
                        {
                            workers.Add(newWorker);
                        }
                    }
                }
            }
            else
            {
                if (DepartmensComboBox.SelectedIndex != 0 && WardsComboBox.SelectedIndex == 0) //если выбрано отделение и палаты пусты
                {
                    foreach (HospitalWards ward in db.context.HospitalWards.Where(x => x.DepartmentId == (int)DepartmensComboBox.SelectedValue).ToList())
                    {
                        foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WardId == ward.IdWard).ToList())
                        {
                            idWorkerUnique.Add(workerInWards.WorkerId);
                        }
                    }
                    foreach (int idWorker in idWorkerUnique.Distinct())
                    {
                        foreach (HospitalWorkers newWorker in db.context.HospitalWorkers.Where(x => x.IdWorker == idWorker).ToList())
                        {
                            workers.Add(newWorker);
                        }
                    }
                }
                else
                {
                    if (DepartmensComboBox.SelectedIndex == 0 && WardsComboBox.SelectedIndex != 0)//если отделение пусто и палаты выбраны
                    {
                        if (WardsComboBox.SelectedValue != null)
                        {
                            if (db.context.WorkerInWards.FirstOrDefault(x => x.WardId == (int)WardsComboBox.SelectedValue) != null)
                            {
                                int idWorker = db.context.WorkerInWards.FirstOrDefault(x => x.WardId == (int)WardsComboBox.SelectedValue).WorkerId;
                                workers.Add(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker));
                            }
                        }
                    }
                    else
                    {
                        workers = db.context.HospitalWorkers.ToList();
                    }
                }
            }
            HospitalWorkers workerAll = new HospitalWorkers()
            {
                IdWorker = 0,
                NameWorker = "работники",
                SurnameWorker = "Все",
                PatronymicWorker = ""
            };
            HospitalWorkers workerNull = new HospitalWorkers()
            {
                IdWorker = -1,
                NameWorker = "работника",
                SurnameWorker = "Без",
                PatronymicWorker = ""
            };
            workers.Insert(0, workerNull);
            workers.Insert(0, workerAll);
            WorekrsComboBox.ItemsSource = workers;
            WorekrsComboBox.DisplayMemberPath = "FIO";
            WorekrsComboBox.SelectedValuePath = "IdWorker";
            WorekrsComboBox.SelectedIndex = 0;
        }

        private void WorkersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void DeleteDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalPatients selectedPatient = (HospitalPatients)PatientsListView.SelectedItem;
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

        private void EditDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalPatients selectedPatient = (HospitalPatients)PatientsListView.SelectedItem;
            if (selectedPatient == null)
            {
                MessageBox.Show("Вы не выбрали пациента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NavigationService.Navigate(new EditPatientPage(selectedPatient.IdPatient));
        }

        private void AddDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddPatientPage());
        }

        private void MoreButton_Click(object sender, MouseButtonEventArgs e)
        {
            Image selectedItem = (Image)sender;
            HospitalPatients selectedPatient = (HospitalPatients)selectedItem.DataContext;
            NavigationService.Navigate(new MoreInfoAboutPatient(selectedPatient.IdPatient));
        }

        private void FillListButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalPatients selectedPatient = (HospitalPatients)PatientsListView.SelectedItem;
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
                MessageBox.Show("Данных, для выдачи температурного листа, достаточно");
                return;
            }
            NavigationService.Navigate(new FillTemperatureListPage(selectedPatient.IdPatient));
        }
    }
}
