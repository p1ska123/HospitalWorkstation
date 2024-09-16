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
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    public partial class WorkersPage : Page
    {
        readonly Core db = new Core();
        public WorkersPage()
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
            List<HospitalPosts> posts = db.context.HospitalPosts.ToList();
            HospitalPosts post = new HospitalPosts()
            {
                IdPost = 0,
                NamePost = "Все"
            };
            posts.Insert(0, post);
            PostsComboBox.ItemsSource = posts;
            PostsComboBox.DisplayMemberPath = "NamePost";
            PostsComboBox.SelectedValuePath = "IdPost";
            PostsComboBox.SelectedIndex = 0;
            UpdateList();
        }

        private void PostsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void DepartmensComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
        private void UpdateList()
        {
            List<HospitalWorkers> workers = new List<HospitalWorkers>();
            if (DepartmensComboBox.SelectedIndex != 0)
            {
                foreach (HospitalWards ward in db.context.HospitalWards.Where(x => x.DepartmentId == (int)DepartmensComboBox.SelectedValue).ToList())
                {
                    foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WardId == ward.IdWard).ToList())
                    {
                        workers.Add(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == workerInWards.WorkerId));
                    }
                }
            }
            else workers = db.context.HospitalWorkers.ToList();
            workers.Remove(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == Properties.Settings.Default.idWorker));
            if (PostsComboBox.SelectedValue != null)
            {
                if (PostsComboBox.SelectedIndex != 0) workers = workers.Where(x => x.PostId == (int)PostsComboBox.SelectedValue).ToList();
            }
            workers = workers.Where(x => x.FIO.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            WorkersListView.ItemsSource = workers;
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = (Button)sender;
            HospitalWorkers activeWorker = (HospitalWorkers)activeButton.DataContext;
            this.NavigationService.Navigate(new PatientsPage(0, activeWorker.IdWorker));
        }

        private void DeleteDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalWorkers selectedWorker = (HospitalWorkers)WorkersListView.SelectedItem;
            if (selectedWorker == null)
            {
                MessageBox.Show("Вы не выбрали работника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult messageBox = MessageBox.Show($"Вы уверены что хотите удалить работника \"{selectedWorker.FIO}\"?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                try
                {
                    if (HospitalWorkersViewModel.DeleteWorker(selectedWorker.IdWorker))
                    {
                        MessageBox.Show("Данные удалены");
                        NavigationService.Navigate(new WorkersPage());
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
            HospitalWorkers selectedWorker = (HospitalWorkers)WorkersListView.SelectedItem;
            if (selectedWorker == null)
            {
                MessageBox.Show("Вы не выбрали работника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NavigationService.Navigate(new EditWorkerPage(selectedWorker.IdWorker));
        }

        private void AddDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddWorkerPage());
        }
    }
}
