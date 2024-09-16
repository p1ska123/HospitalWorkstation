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
    /// Логика взаимодействия для AddWardPage.xaml
    /// </summary>
    public partial class AddWardPage : Page
    {
        static readonly Core db = new Core();
        HospitalWorkers worker = new HospitalWorkers();
        int idWorker = 0;
        List<HospitalWorkers> allWorkers = db.context.HospitalWorkers.ToList();
        public AddWardPage()
        {
            InitializeComponent();
            DepartmentsComboBox.ItemsSource = db.context.HospitalDepartments.ToList();
            DepartmentsComboBox.DisplayMemberPath = "NameDepartmentAdd";
            DepartmentsComboBox.SelectedValuePath = "IdDepartment";
            DepartmentsComboBox.SelectedIndex = 0;
            allWorkers.Remove(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == Properties.Settings.Default.idWorker));
            WorkersListView.ItemsSource = allWorkers;
        }

        private void AddWard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HospitalWardsViewModel.AddWard(WardNameTextBox.Text, (int)DepartmentsComboBox.SelectedValue, idWorker))
                {
                    MessageBox.Show("Палата добавлена");
                    NavigationService.Navigate(new WardsPage(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WardsPage(0));
        }

        private void SelectWorkerButton_Click(object sender, RoutedEventArgs e)
        {
           allWorkers = db.context.HospitalWorkers.ToList();
            allWorkers.Remove(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == Properties.Settings.Default.idWorker));
            Button activeButton = (Button)sender;
            HospitalWorkers activeWorker = (HospitalWorkers)activeButton.DataContext;
            worker = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == activeWorker.IdWorker);
            AboutWorkerTextBlock.Text = worker.FIO;
            allWorkers.Remove(worker);
            WorkersListView.ItemsSource = allWorkers;
            idWorker = worker.IdWorker;
        }
    }
}
