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
    /// Логика взаимодействия для WardsPage.xaml
    /// </summary>
    public partial class WardsPage : Page
    {
        readonly Core db = new Core();
        public WardsPage(int idDepartment)
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
            DepartmensComboBox.SelectedValue = idDepartment;
            UpdateList();
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            Button activeElement = (Button)sender;
            HospitalWards activeWard = (HospitalWards)activeElement.DataContext;
            this.NavigationService.Navigate(new PatientsPage(activeWard.IdWard, 0));
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
            List<HospitalWards> wards = new List<HospitalWards>();
            if (DepartmensComboBox.SelectedIndex != 0) wards = db.context.HospitalWards.Where(x => x.DepartmentId == DepartmensComboBox.SelectedIndex).ToList();
            else wards = db.context.HospitalWards.ToList();
            wards = wards.Where(x => x.NameWard.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            WardsListView.ItemsSource = wards;
        }

        private void AddDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddWardPage());
        }

        private void EditDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalWards selectedWard = (HospitalWards)WardsListView.SelectedItem;
            if (selectedWard == null)
            {
                MessageBox.Show("Вы не выбрали палату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            NavigationService.Navigate(new EditWardPage(selectedWard.IdWard));
        }

        private void DeleteDataButton_Click(object sender, MouseButtonEventArgs e)
        {
            HospitalWards selectedWard = (HospitalWards)WardsListView.SelectedItem;
            if (selectedWard == null)
            {
                MessageBox.Show("Вы не выбрали палату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult messageBox = MessageBox.Show($"Вы уверены что хотите удалить палату \"{selectedWard.NameWardAdd}\"? Будет удалена вся информация о пациентах данной палаты.", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBox == MessageBoxResult.Yes)
            {
                try
                {
                    if (HospitalWardsViewModel.DeleteWards(selectedWard.IdWard))
                    {
                        MessageBox.Show("Данные удалены");
                        NavigationService.Navigate(new WardsPage(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
