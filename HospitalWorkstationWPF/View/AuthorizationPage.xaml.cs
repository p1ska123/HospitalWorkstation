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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalWorkstationWPF.View
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        readonly Core db = new Core();
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsersViewModel.CheckAuth(LoginTextBox.Text, PasswordTextBox.Password))
                {
                    Properties.Settings.Default.idWorker = db.context.Users.FirstOrDefault(x => x.Login == LoginTextBox.Text).WorkerId;
                    Properties.Settings.Default.idRole = db.context.Users.FirstOrDefault(x => x.Login == LoginTextBox.Text).RoleId;
                    Properties.Settings.Default.Save();
                    if (Properties.Settings.Default.idRole == 3) this.NavigationService.Navigate(new DepartmentsPage());
                    else this.NavigationService.Navigate(new MainPage());
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
    }
}
