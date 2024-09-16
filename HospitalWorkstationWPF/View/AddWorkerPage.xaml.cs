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
    /// Логика взаимодействия для AddWorkerPage.xaml
    /// </summary>
    public partial class AddWorkerPage : Page
    {
        readonly Core db = new Core();
        List<HospitalWards> freeWards = new List<HospitalWards>();
        List<HospitalWards> selectedWards = new List<HospitalWards>();
        public AddWorkerPage()
        {
            InitializeComponent();
            List<int> wardsIdAll = new List<int>();
            List<int> wardsIdHave = new List<int>();
            List<HospitalWards> wardsNull = new List<HospitalWards>();
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
                wardsNull.Add(db.context.HospitalWards.FirstOrDefault(x => x.IdWard == idNullWard));
            }
            freeWards = wardsNull;
            BirthdayDatePicker.SelectedDate = DateTime.Today;
            PostsComboBox.ItemsSource = db.context.HospitalPosts.ToList();
            PostsComboBox.SelectedValuePath = "IdPost";
            PostsComboBox.DisplayMemberPath = "NamePost";
            PostsComboBox.SelectedIndex = 0;
            WardsListView.ItemsSource = freeWards.OrderBy(x => x.NameWard);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkersPage());
        }

        private void SelectWardButton_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = (Button)sender;
            HospitalWards activeWard = (HospitalWards)activeButton.DataContext;
            freeWards.Remove(activeWard);
            selectedWards.Add(activeWard);
            WardsListView.ItemsSource = freeWards.OrderBy(x => x.NameWard);
            WorkerWardsListView.ItemsSource = selectedWards.OrderBy(x => x.NameWard);
        }

        private void AddWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idRole = 1;
                if (Role1RadioButton.IsChecked != true) idRole = 2;
                List<int> idWards = new List<int>();
                foreach (HospitalWards selectedWard in selectedWards) idWards.Add(selectedWard.IdWard);
                if (HospitalWorkersViewModel.AddWorker(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text, (int)PostsComboBox.SelectedValue, (DateTime)BirthdayDatePicker.SelectedDate, LoginTextBox.Text, PasswordTextBox.Text, idRole, idWards))
                {
                    MessageBox.Show("Работник добавлен");
                    NavigationService.Navigate(new WorkersPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteWardButton_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = (Button)sender;
            HospitalWards activeWard = (HospitalWards)activeButton.DataContext;
            selectedWards.Remove(activeWard);
            freeWards.Add(activeWard);
            WardsListView.ItemsSource = freeWards.OrderBy(x => x.NameWard);
            WorkerWardsListView.ItemsSource = selectedWards.OrderBy(x => x.NameWard);
        }
    }
}
