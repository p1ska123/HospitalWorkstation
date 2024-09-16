using HospitalWorkstationWPF.Model;
using HospitalWorkstationWPF.View;
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

namespace HospitalWorkstationWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthorizationPage());
        }

        private void ExitButton_Click(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.idWorker = 0;
            Properties.Settings.Default.idRole = 0;
            Properties.Settings.Default.Save();
            MainFrame.Navigate(new AuthorizationPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            switch (MainFrame.Content.GetType().Name)
            {
                case "MainPage":
                    MainButton.Background = (Brush)new BrushConverter().ConvertFrom("#F2F2F2");
                    DepartmentsButton.Background = Brushes.White;
                    WardsButton.Background = Brushes.White;
                    PatientsButton.Background = Brushes.White;
                    WorkersButton.Background = Brushes.White;
                    BackButton.Visibility = Visibility.Hidden;
                    break;
                case "DepartmentsPage":
                    MainButton.Background = Brushes.White;
                    DepartmentsButton.Background = (Brush)new BrushConverter().ConvertFrom("#F2F2F2");
                    WardsButton.Background = Brushes.White;
                    PatientsButton.Background = Brushes.White;
                    BackButton.Visibility = Visibility.Hidden;
                    WorkersButton.Background = Brushes.White;
                    break;
                case "WardsPage":
                    MainButton.Background = Brushes.White;
                    DepartmentsButton.Background = Brushes.White;
                    WardsButton.Background = (Brush)new BrushConverter().ConvertFrom("#F2F2F2");
                    PatientsButton.Background = Brushes.White;
                    WorkersButton.Background = Brushes.White;
                    BackButton.Visibility = Visibility.Hidden;
                    break;
                case "PatientsPage":
                    MainButton.Background = Brushes.White;
                    DepartmentsButton.Background = Brushes.White;
                    WardsButton.Background = Brushes.White;
                    PatientsButton.Background = (Brush)new BrushConverter().ConvertFrom("#F2F2F2");
                    WorkersButton.Background = Brushes.White;
                    BackButton.Visibility = Visibility.Hidden;
                    break;
                case "WorkersPage":
                    MainButton.Background = Brushes.White;
                    DepartmentsButton.Background = Brushes.White;
                    WardsButton.Background = Brushes.White;
                    PatientsButton.Background = Brushes.White;
                    WorkersButton.Background = (Brush)new BrushConverter().ConvertFrom("#F2F2F2");
                    BackButton.Visibility = Visibility.Hidden;
                    break;
                default:
                    BackButton.Visibility = Visibility.Visible;
                    break;

            }
            if (Properties.Settings.Default.idWorker != 0)
            {
                WorkerMenu.Visibility = Visibility.Visible;
                UserNamePanel.Visibility = Visibility.Visible;
                Interface.Background = (Brush)new BrushConverter().ConvertFrom("#62D0FF");
                Interface.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#38ADDF");
                UserNameTextBlock.Text = "Вы вошли как: " + UsersViewModel.GetFullUserName(Properties.Settings.Default.idWorker, Properties.Settings.Default.idRole);
            }
            else
            {
                WorkerMenu.Visibility = Visibility.Collapsed;
                UserNamePanel.Visibility = Visibility.Collapsed;
                Interface.Background = Brushes.White;
                Interface.BorderBrush = Brushes.White;
            }
            if (Properties.Settings.Default.idRole == 3)
            {
                MainButton.Visibility = Visibility.Hidden;
                MainButtonBorder.Visibility = Visibility.Hidden;
            }
            else
            {
                MainButton.Visibility = Visibility.Visible;
                MainButtonBorder.Visibility = Visibility.Visible;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.idWorker = 0;
            Properties.Settings.Default.idRole = 0;
            Properties.Settings.Default.Save();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void DepartmentsButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new DepartmentsPage());
        }

        private void WardsButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new WardsPage(0));
        }

        private void PatientsButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new PatientsPage(0, 0));
        }

        private void WorkersButton_Click(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new WorkersPage());
        }

        private void BackButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (MainFrame.CanGoBack) MainFrame.GoBack();
        }
    }
}
