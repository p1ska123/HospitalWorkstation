using HospitalWorkstationWPF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace HospitalWorkstationWPF.ViewModel
{
    public class TemperatureSheetViewModel
    {
        readonly static Core db = new Core();
        public static bool FillTemperatureSheet(int idPatient, DateTime dateStaying, string[] valuesMorning, string[] valuesEvening)
        {
            foreach (string value in valuesMorning)
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Заполните все поля");
                if (value.Length > 50) throw new Exception("Длина значения слишком большая");
            }
            foreach (string value in valuesEvening)
            {
                if (string.IsNullOrWhiteSpace(value)) throw new Exception("Заполните все поля");
                if (value.Length > 50) throw new Exception("Длина значения слишком большая");
            }
            for (int i = 0; i < 9; i++)
            {
                TemperatureSheet temperatureSheetRow = new TemperatureSheet()
                {
                    PatientId = idPatient,
                    DateStaying = dateStaying,
                    TimeId = 1,
                    ParameterId = i+1,
                    Value = valuesMorning[i]
                };
                db.context.TemperatureSheet.Add(temperatureSheetRow);
            }
            for (int i = 0; i < 9; i++)
            {
                TemperatureSheet temperatureSheetRow = new TemperatureSheet()
                {
                    PatientId = idPatient,
                    DateStaying = dateStaying,
                    TimeId = 2,
                    ParameterId = i + 1,
                    Value = valuesEvening[i]
                };
                db.context.TemperatureSheet.Add(temperatureSheetRow);
            }
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static void CreateWordFile(int idPatient)
        {
            Word.Application application = new Word.Application();
            Word.Document document = application.Documents.Add();
            //заголовок
            Word.Paragraph titleParagraph = document.Paragraphs.Add();
            Word.Range titleRange = titleParagraph.Range;
            titleRange.Text = "ТЕМПЕРАТУРНЫЙ ЛИСТ";
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleRange.Bold = 1;
            titleRange.Underline = Word.WdUnderline.wdUnderlineSingle;
            titleRange.InsertParagraphAfter();
            //мини таблица для подписей
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table titleTable = document.Tables.Add(tableRange, 2, 2);
            Word.Range cellRange;
            cellRange = titleTable.Cell(1, 1).Range;
            cellRange.Text = $"Карта № {db.context.TemperatureSheet.Select(x => x.PatientId).Distinct().Count()+1}";
            cellRange = titleTable.Cell(1, 2).Range;
            cellRange.Text = "Фамилия, имя, о. больного: " + db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).FIO;
            cellRange = titleTable.Cell(2, 1).Range;
            cellRange.Text = "Палата № " + db.context.HospitalWards.FirstOrDefault(x => x.IdWard == db.context.HospitalPatients.FirstOrDefault(y => y.IdPatient == idPatient).WardId).NameWard;
            //отступ
            Word.Paragraph emptyText = document.Paragraphs.Add();
            Word.Range emptyRange = titleParagraph.Range;
            emptyRange.Text = " ";
            emptyRange.InsertParagraphAfter();

            //главная таблица
            Word.Paragraph temperatureParagraph = document.Paragraphs.Add();
            Word.Range temperatureRange = temperatureParagraph.Range;
            Word.Table temperatureTable = document.Tables.Add(temperatureRange, 12, 31);
            temperatureTable.PreferredWidth = 250;
            Word.Range cellTemperature;
            temperatureTable.Columns[1].Cells.SetWidth(60, Word.WdRulerStyle.wdAdjustNone);
            temperatureTable.Borders.Enable = 1;
            cellTemperature = temperatureTable.Cell(1, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Дата";
            temperatureTable.Cell(2, 1).Merge(temperatureTable.Cell(3, 1));
            cellTemperature = temperatureTable.Cell(2, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "День пребывания в стационаре";
            cellTemperature = temperatureTable.Cell(4, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Пульс";
            cellTemperature = temperatureTable.Cell(5, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Артериальное давление";
            cellTemperature = temperatureTable.Cell(6, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Температура";
            cellTemperature = temperatureTable.Cell(7, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Дыхание";
            cellTemperature = temperatureTable.Cell(8, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Вес";
            cellTemperature = temperatureTable.Cell(9, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Выпито жидкости";
            cellTemperature = temperatureTable.Cell(10, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Суточное количество мочи";
            cellTemperature = temperatureTable.Cell(11, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Стул";
            cellTemperature = temperatureTable.Cell(12, 1).Range;
            cellTemperature.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            cellTemperature.Text = "Ванна";
            int n = 1;
            for (int i = 2; i < 17; i++)
            {
                temperatureTable.Cell(1, i).Merge(temperatureTable.Cell(1, i + 1));
                temperatureTable.Cell(2, i).Merge(temperatureTable.Cell(2, i + 1));
                temperatureTable.Cell(2, i).Range.Text = n.ToString();
                n++;
            }
            for (int i = 2; i < 31; i += 2)
            {
                temperatureTable.Cell(3, i).Range.Text = "у";
            }
            for (int i = 3; i <= 31; i += 2)
            {
                temperatureTable.Cell(3, i).Range.Text = "в";
            }
            //вставка дат
            List<DateTime> dates = new List<DateTime>();
            foreach (TemperatureSheet sheet in db.context.TemperatureSheet.Where(x => x.PatientId == idPatient).OrderBy(x => x.DateStaying))
            {
                dates.Add(sheet.DateStaying);
            }
            DateTime[] dateTimes = dates.Distinct().ToArray();
            for (int i = 0; i < dateTimes.Length; i++)
            {
                temperatureTable.Cell(1, i + 2).Range.Text = dateTimes[i].ToShortDateString();
            }
            //вставка значений параметров
            for (int i = 1; i <= db.context.TemperatureSheet.Where(x => x.PatientId == idPatient).Count()/2; i++)
            {
                TemperatureSheet[] sheetRow = db.context.TemperatureSheet.Where(x => x.PatientId == idPatient && x.ParameterId == i && x.TimeId == 1).ToArray();
                n = 2;
                foreach (TemperatureSheet row in sheetRow)
                {
                    temperatureTable.Cell(i+3, n).Range.Text = row.Value;
                    n += 2;
                }
                sheetRow = db.context.TemperatureSheet.Where(x => x.PatientId == idPatient && x.ParameterId == i && x.TimeId == 2).ToArray();
                n = 3;
                foreach (TemperatureSheet row in sheetRow)
                {
                    temperatureTable.Cell(i+3, n).Range.Text = row.Value;
                    n += 2;
                }
            }
            //получить путь
            string selectedPath = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedPath = folderBrowserDialog.SelectedPath;
                document.SaveAs2($"{selectedPath}\\Температурный лист пациента {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).FIO}.docx");
            }
            document.Close();
            application.Quit();
        }
    }
}
