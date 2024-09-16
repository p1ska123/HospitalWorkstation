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
    /// Логика взаимодействия для EditDepartmentPage.xaml
    /// </summary>
    public partial class EditDepartmentPage : Page
    {
        readonly Core db = new Core();
        int idDepartment;
        public EditDepartmentPage(int idDepartment)
        {
            InitializeComponent();
            this.idDepartment = idDepartment;
            DepartmentNameTextBox.Text = db.context.HospitalDepartments.FirstOrDefault(x => x.IdDepartment == idDepartment).NameDepartment;
        }

        private void EditDepartment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (HospitalDepartmentsViewModel.UdpateDepartment(idDepartment, DepartmentNameTextBox.Text))
                {
                    MessageBox.Show("Данные сохранены");
                    NavigationService.Navigate(new DepartmentsPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
