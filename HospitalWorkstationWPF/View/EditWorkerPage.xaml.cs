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
    /// Логика взаимодействия для EditWorkerPage.xaml
    /// </summary>
    public partial class EditWorkerPage : Page
    {
        readonly Core db = new Core();
        int idWorker;
        List<HospitalWards> freeWards = new List<HospitalWards>();
        List<HospitalWards> selectedWards = new List<HospitalWards>();
        public EditWorkerPage(int idWorker)
        {
            InitializeComponent();
            this.idWorker = idWorker;
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
            foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == idWorker))
            {
                selectedWards.Add(db.context.HospitalWards.FirstOrDefault(x => x.IdWard == workerInWards.WardId));
            }
            BirthdayDatePicker.SelectedDate = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).BirthdayWorker;
            PostsComboBox.ItemsSource = db.context.HospitalPosts.ToList();
            PostsComboBox.SelectedValuePath = "IdPost";
            PostsComboBox.DisplayMemberPath = "NamePost";
            PostsComboBox.SelectedValue = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).PostId;
            WardsListView.ItemsSource = freeWards.OrderBy(x => x.NameWard);
            WorkerWardsListView.ItemsSource = selectedWards.OrderBy(x => x.NameWard);
            NameTextBox.Text = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).NameWorker;
            SurnameTextBox.Text = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).SurnameWorker;
            PatronymicTextBox.Text = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).PatronymicWorker;
            if (db.context.Users.FirstOrDefault(x => x.WorkerId == idWorker).RoleId == 1) Role1RadioButton.IsChecked = true;
            else Role2RadioButton.IsChecked = true;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WorkersPage());
        }

        private void EditWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int idRole;
                if (Role1RadioButton.IsChecked == true) idRole = 1;
                else idRole = 2;
                List<int> idWards = new List<int>();
                foreach (HospitalWards selectedWard in selectedWards) idWards.Add(selectedWard.IdWard);
                string pass = "";
                if (ChangePassword.IsChecked == true) 
                {
                    if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
                    {
                        MessageBox.Show("Заполните поле для пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    pass = PasswordTextBox.Text;
                }
                if (HospitalWorkersViewModel.UpdateWorker(NameTextBox.Text, SurnameTextBox.Text, PatronymicTextBox.Text, (int)PostsComboBox.SelectedValue, (DateTime)BirthdayDatePicker.SelectedDate, idRole, idWards, idWorker, pass))
                {
                    MessageBox.Show("Данные сохранены");
                    NavigationService.Navigate(new WorkersPage());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
        private void DeleteWardButton_Click(object sender, RoutedEventArgs e)
        {
            Button activeButton = (Button)sender;
            HospitalWards activeWard = (HospitalWards)activeButton.DataContext;
            selectedWards.Remove(activeWard);
            freeWards.Add(activeWard);
            WardsListView.ItemsSource = freeWards.OrderBy(x => x.NameWard);
            WorkerWardsListView.ItemsSource = selectedWards.OrderBy(x => x.NameWard);
        }

        private void ChangePasswordCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (ChangePassword.IsChecked == true) PasswordPanel.Visibility = Visibility.Visible;
            else PasswordPanel.Visibility = Visibility.Collapsed;
        }
    }
}
