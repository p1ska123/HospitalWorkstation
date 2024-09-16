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
    /// Логика взаимодействия для EditWardPage.xaml
    /// </summary>
    public partial class EditWardPage : Page
    {
        static readonly Core db = new Core();
        HospitalWorkers worker = new HospitalWorkers();
        int idWorker = 0;
        int idWard;
        List<HospitalWorkers> allWorkers = db.context.HospitalWorkers.ToList();
        public EditWardPage(int idWard)
        {
            InitializeComponent();
            this.idWard = idWard;
            WardNameTextBox.Text = db.context.HospitalWards.FirstOrDefault(x => x.IdWard == idWard).NameWard;
            DepartmentsComboBox.ItemsSource = db.context.HospitalDepartments.ToList();
            DepartmentsComboBox.DisplayMemberPath = "NameDepartmentAdd";
            DepartmentsComboBox.SelectedValuePath = "IdDepartment";
            DepartmentsComboBox.SelectedValue = db.context.HospitalWards.FirstOrDefault(x => x.IdWard == idWard).DepartmentId;
            allWorkers.Remove(db.context.HospitalWorkers.FirstOrDefault(y => y.IdWorker == db.context.WorkerInWards.FirstOrDefault(x => x.WardId == idWard).WorkerId));
            allWorkers.Remove(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == Properties.Settings.Default.idWorker));
            WorkersListView.ItemsSource = allWorkers;
            if (db.context.WorkerInWards.FirstOrDefault(x => x.WardId == idWard) != null)
            {
                AboutWorkerTextBlock.Text = db.context.HospitalWorkers.FirstOrDefault(y => y.IdWorker == db.context.WorkerInWards.FirstOrDefault(x => x.WardId == idWard).WorkerId).FIO;
                idWorker = db.context.WorkerInWards.FirstOrDefault(x => x.WardId == idWard).WorkerId;
            }
        }

        private void EditWard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HospitalWardsViewModel.UpdateWard(idWard, WardNameTextBox.Text, (int)DepartmentsComboBox.SelectedValue, idWorker))
                {
                    MessageBox.Show("Данные изменены");
                    NavigationService.Navigate(new WardsPage(0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void SetEmptyButton_Click(object sender, RoutedEventArgs e)
        {
            idWorker = 0;
            AboutWorkerTextBlock.Text = "без работника";
            allWorkers = db.context.HospitalWorkers.ToList();
            allWorkers.Remove(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == Properties.Settings.Default.idWorker));
            WorkersListView.ItemsSource = allWorkers;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WardsPage(0));
        }
    }
}
