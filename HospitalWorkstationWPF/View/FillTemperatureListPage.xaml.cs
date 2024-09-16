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
    /// Логика взаимодействия для FillTemperatureListPage.xaml
    /// </summary>
    public partial class FillTemperatureListPage : Page
    {
        int idPatient;
        DateTime dateObservation = new DateTime();
        readonly Core db = new Core();
        public FillTemperatureListPage(int idPatient)
        {
            InitializeComponent();
            this.idPatient = idPatient;
            NameTextBlock.Text = $"Пациент: {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).FIO}";
            ArriveDateTextBlock.Text = $"Дата прибытия: {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).ArrivalDate.ToShortDateString()}";
            if (db.context.TemperatureSheet.Where(x => x.PatientId == idPatient).Count() > 0)
            {
                dateObservation = db.context.TemperatureSheet.Where(x => x.PatientId == idPatient).OrderByDescending(x => x.IdRecord).FirstOrDefault().DateStaying.AddDays(1);
            }
            else
            {
                dateObservation = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).ArrivalDate;
            }
            ObservationDateTextBlock1.Text = $"Дата наблюдения: {dateObservation.ToShortDateString()}";
            ObservationDateTextBlock2.Text = $"Дата наблюдения: {dateObservation.ToShortDateString()}";
        }

        private void SetEveningButton_Click(object sender, RoutedEventArgs e)
        {
            MorningData.Visibility = Visibility.Collapsed;
            EveningData.Visibility = Visibility.Visible;
        }
        private void SetMorningButton_Click(object sender, RoutedEventArgs e)
        {
            MorningData.Visibility = Visibility.Visible;
            EveningData.Visibility = Visibility.Collapsed;
        }

        private void AddDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] valuesMorning = {
                    TextBoxId1Morning.Text, TextBoxId2Morning.Text, TextBoxId3Morning.Text, TextBoxId4Morning.Text, TextBoxId5Morning.Text, TextBoxId6Morning.Text, TextBoxId7Morning.Text, TextBoxId8Morning.Text, TextBoxId9Morning.Text
                };
                string[] valuesEvening = { 
                    TextBoxId1Evening.Text, TextBoxId2Evening.Text, TextBoxId3Evening.Text, TextBoxId4Evening.Text, TextBoxId5Evening.Text, TextBoxId6Evening.Text, TextBoxId7Evening.Text, TextBoxId8Evening.Text, TextBoxId9Evening.Text
                };
                if (TemperatureSheetViewModel.FillTemperatureSheet(idPatient, dateObservation, valuesMorning, valuesEvening))
                {
                    
                    List<DateTime> dates = new List<DateTime>();
                    foreach (TemperatureSheet sheet in db.context.TemperatureSheet.Where(x => x.PatientId == idPatient))
                    {
                        dates.Add(sheet.DateStaying);
                    }
                    if (dates.Distinct().Count() == 15)
                    {
                        MessageBox.Show($"Данные за {dateObservation.ToShortDateString()} заполнены");
                        NavigationService.Navigate(new MainPage());
                    }
                    else
                    {
                        MessageBox.Show($"Данные за {dateObservation.ToShortDateString()} заполнены");
                        NavigationService.Navigate(new FillTemperatureListPage(idPatient));
                    }
                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
