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
    /// Логика взаимодействия для DepartmentsPage.xaml
    /// </summary>
    public partial class DepartmentsPage : Page
    {
        readonly Core db = new Core();
        public DepartmentsPage()
        {
            InitializeComponent();
            DepartmentsListView.ItemsSource = db.context.HospitalDepartments.ToList();
            if (Properties.Settings.Default.idRole == 3) ButtonsMenu.Visibility = Visibility.Visible;
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            Button activeElement = (Button)sender;
            HospitalDepartments activeDepartment = (HospitalDepartments)activeElement.DataContext;
            this.NavigationService.Navigate(new WardsPage(activeDepartment.IdDepartment));
        }

        private void AddDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new AddDepartmentPage());
        }

        private void EditDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalDepartments selectedDepartment =  (HospitalDepartments)DepartmentsListView.SelectedItem;
            if (selectedDepartment == null)
            {
                System.Windows.MessageBox.Show("Вы не выбрали отделение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NavigationService.Navigate(new EditDepartmentPage(selectedDepartment.IdDepartment));
        }

        private void DeleteDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalDepartments selectedDepartment = (HospitalDepartments)DepartmentsListView.SelectedItem;
            if (selectedDepartment == null)
            {
                MessageBox.Show("Вы не выбрали отделение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult messageBox = MessageBox.Show($"Вы уверены что хотите удалить \"{selectedDepartment.NameDepartment}\" отделение? Будет удалена вся информация о палатах и пациентах данного отделения.", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                try
                {
                    if (HospitalDepartmentsViewModel.DeleteDepartment(selectedDepartment.IdDepartment))
                    {
                        MessageBox.Show("Данные удалены");
                        NavigationService.Navigate(new DepartmentsPage());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
