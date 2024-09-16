using HospitalWorkstationWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HospitalWorkstationWPF.ViewModel
{
    public class HospitalPatientsViewModel
    {
        private static readonly Core db = new Core();
        public static bool AddPatient(string name, string surname, string patronymic, int idWard, int idDiagnosis, DateTime birthday, DateTime arrivalDate, string appointment, string bloodGroup, string rhesusType, string sideEffect, string drugForSideEffect, string adress, string placeWorkStudy)
        {
            if (appointment.Length >= 300 || name.Length > 50 || surname.Length > 50 || patronymic.Length > 50) throw new Exception("Длина текста поля слишком велика");
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(patronymic)) throw new Exception("Поля не заполнены");
            if (idWard == 0) throw new Exception("Пациента нельзя добавить, не выбрав палату");
            if (birthday > DateTime.Now) throw new Exception("Человек с такой датой еще не родился");
            Random rnd = new Random();
            int regNumber = rnd.Next(10000,100000);
            while (!RegNumberIsUnique(regNumber))
            {
                regNumber = rnd.Next(10000, 100000);
            }
            HospitalPatients newPatient = new HospitalPatients()
            {
                NamePatient = name,
                SurnamePatient = surname,
                PatronymicPatient = patronymic,
                WardId = idWard,
                RegistrationNumber = regNumber.ToString(),
                IdDiagnosis = idDiagnosis,
                BirthdayPatient = birthday,
                ArrivalDate = arrivalDate
            };
            db.context.HospitalPatients.Add(newPatient);
            PatientInfo newPatientInfo = new PatientInfo()
            {
                PatientId = newPatient.IdPatient,
                BloodGroup = bloodGroup,
                RhesusType = rhesusType,
                SideEffect = sideEffect,
                DrugNameOfSideEffect = drugForSideEffect,
                Adress = adress,
                PlaceOfWork_Study = placeWorkStudy
            };
            db.context.PatientInfo.Add(newPatientInfo);
            if (!string.IsNullOrWhiteSpace(appointment))
            {
                if (db.context.SaveChanges() > 0 && AddAppointment(newPatient.IdPatient, appointment)) return true;
                else throw new Exception("Ошибка");
            }
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool UpdatePatient(int idPatient, string name, string surname, string patronymic, int idWard, int idDiagnosis, DateTime birthday, DateTime arrivalDate, string appointment, string bloodGroup, string rhesusType, string sideEffect, string drugForSideEffect, string adress, string placeWorkStudy)
        {
            if (appointment.Length >= 300 || name.Length > 50 || surname.Length > 50 || patronymic.Length > 50) throw new Exception("Длина текста поля слишком велика");
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(patronymic)) throw new Exception("Поля не заполнены");
            if (birthday > DateTime.Now) throw new Exception("Человек с такой датой еще не родился");
            HospitalPatients newPatient = new HospitalPatients()
            {
                IdPatient = idPatient,
                NamePatient = name,
                SurnamePatient = surname,
                PatronymicPatient = patronymic,
                RegistrationNumber = db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).RegistrationNumber,
                WardId = idWard,
                IdDiagnosis = idDiagnosis,
                BirthdayPatient = birthday,
                ArrivalDate = arrivalDate
            };
            db.context.HospitalPatients.AddOrUpdate(newPatient);
            PatientInfo newPatientInfo = new PatientInfo();
            if (db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient) != null)
            {
                newPatientInfo = new PatientInfo()
                {
                    IdInfo = db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).IdInfo,
                    PatientId = idPatient,
                    BloodGroup = bloodGroup,
                    RhesusType = rhesusType,
                    SideEffect = sideEffect,
                    DrugNameOfSideEffect = drugForSideEffect,
                    Adress = adress,
                    PlaceOfWork_Study = placeWorkStudy
                };
            }
            else
            {
                newPatientInfo = new PatientInfo()
                {
                    PatientId = newPatient.IdPatient,
                    BloodGroup = bloodGroup,
                    RhesusType = rhesusType,
                    SideEffect = sideEffect,
                    DrugNameOfSideEffect = drugForSideEffect,
                    Adress = adress,
                    PlaceOfWork_Study = placeWorkStudy
                };
            }
            db.context.PatientInfo.AddOrUpdate(newPatientInfo);
            Doctor_s_Appointment newAppointment = new Doctor_s_Appointment();
            if (db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == idPatient) == null)
            {
                if (!string.IsNullOrWhiteSpace(appointment))
                {
                    newAppointment = new Doctor_s_Appointment()
                    {
                        Description = appointment,
                        PatientId = idPatient
                    };
                    db.context.Doctor_s_Appointment.AddOrUpdate(newAppointment);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(appointment))
                {
                    newAppointment = new Doctor_s_Appointment()
                    {
                        IdAppointment = db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == idPatient).IdAppointment,
                        Description = appointment,
                        PatientId = idPatient
                    };
                    db.context.Doctor_s_Appointment.AddOrUpdate(newAppointment);
                }
                else
                {
                    db.context.Doctor_s_Appointment.Remove(db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == idPatient));
                }
            }
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool AddAppointment(int idPatient, string appointment)
        {
            Doctor_s_Appointment newAppointment = new Doctor_s_Appointment()
            {
                Description = appointment,
                PatientId = idPatient
            };
            db.context.Doctor_s_Appointment.Add(newAppointment);
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool DeletePatient(int idPatient)
        {
            db.context.HospitalPatients.Remove(db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient));
            if (db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == idPatient) != null) db.context.Doctor_s_Appointment.Remove(db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == idPatient));
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool RegNumberIsUnique(int regNumber)
        {
            foreach (HospitalPatients patient in db.context.HospitalPatients.ToList())
            {
                if (regNumber == int.Parse(patient.RegistrationNumber)) return false;
            }
            return true;
        }

        public static void CreateMedicialCard(int idPatient)
        {
            Word.Application application = new Word.Application();
            Word.Document document = application.Documents.Add();
            //шапка
            Word.Paragraph headParagraph = document.Paragraphs.Add();
            Word.Range mainRange = headParagraph.Range;
            mainRange.Text = "Код формы по ОКУД ________";
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Код учреждения по ОКПО ______";
            mainRange = headParagraph.Range;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Медицинская документация";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "форма №003/у";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Утверждена Минздравом СССР";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "___________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "04.10.80 г. № 1030";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "наименование учреждения";
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"МЕДИЦИНСКАЯ КАРТА № {db.context.PatientInfo.Select(x => x.PatientId).Distinct().Count() + 1}";
            mainRange.Bold = 1;
            mainRange.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "стационарного больного";
            mainRange.Font.Underline = Word.WdUnderline.wdUnderlineNone;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"Дата и время поступления: {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).ArrivalDate}";
            mainRange.Bold = 0;
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Дата и время выписки ________________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "_________________________________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"Отделение {db.context.HospitalDepartments.FirstOrDefault(z => z.IdDepartment == db.context.HospitalWards.FirstOrDefault(x => x.IdWard == db.context.HospitalPatients.FirstOrDefault(y => y.IdPatient == idPatient).WardId).DepartmentId).NameDepartment} палата № {db.context.HospitalWards.FirstOrDefault(x => x.IdWard == db.context.HospitalPatients.FirstOrDefault(y => y.IdPatient == idPatient).WardId).NameWard}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Переведен в отделение ________________________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Проведено койко-дней __________________________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Виды транспортировки: на каталке, на кресле, может идти (подчеркнуть)";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"Группа крови: {db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).BloodGroup} Резус-принадлежность {db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).RhesusType}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"Побочное действие лекарств (непереносимость): {db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).SideEffect}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"название препарата, характер побочного действия: {db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).DrugNameOfSideEffect}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"1. Фамилия, имя, отчество: {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).FIO}  2. Пол: {"муж/жен"}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"3. Возраст: {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).AgePatientInt} (полных лет, для детей: до 1 года - месяцев, до 1 месяца – дней)";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"4. Постоянное место жительства: город, село (подчеркнуть): {db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).Adress}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"вписать адрес, указав для приезжих - область, район, ____________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"населенный пункт, адрес родственников и № телефона";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"5. Место работы, профессия или должность; для учащихся - место учебы; для детей - название детского учреждения, школы: {db.context.PatientInfo.FirstOrDefault(x => x.PatientId == idPatient).PlaceOfWork_Study}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"для инвалидов - род и группа инвалидности, иов – да, нет подчеркнуть";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "6. Кем направлен больной ___________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "название лечебного учреждения";
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "7. Доставлен в стационар по экстренным показаниям: да, нет";
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "через _________ часов после начала заболевания, получения травмы; ";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "госпитализирован в плановом порядке (подчеркнуть).";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"8. Диагноз направившего учреждения: {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).DiagnosisName}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"9. Диагноз при поступлении: {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).DiagnosisName}";

            Word.Table table = document.Tables.Add(mainRange, 2, 2);
            table.PreferredWidth = 400;
            table.Columns[1].Width = 240;
            table.Columns[2].Width = 160;
            table.Cell(1, 1).Range.Text = "Диагноз клинический";
            table.Cell(2, 1).Range.Text = $"{db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).DiagnosisName}";
            table.Cell(1, 2).Range.Text = "Дата установления";
            table.Cell(2, 2).Range.Text = $"{db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).ArrivalDate}";

            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"11. Диагноз заключительный клинический {1}";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"а) основной: _________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"б) осложнение основного: __________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"в) сопутствующий: ____________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"12. Госпитализирован в данном году по поводу данного заболевания: впервые, повторно (подчеркнуть), всего - _____ раз.";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = $"13. Хирургические операции, методы обезболивания и послеоперационные осложнения";

            Word.Table table1 = document.Tables.Add(mainRange, 5, 4);
            table1.PreferredWidth = 400;
            table1.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            table1.Columns[1].Width = 125;
            table1.Columns[2].Width = 75;
            table1.Columns[3].Width = 125;
            table1.Columns[4].Width = 75;
            table1.Cell(1, 1).Range.Text = "Название операции";
            table1.Cell(1, 2).Range.Text = "Дата, час";
            table1.Cell(1, 3).Range.Text = "Метод обезболивания";
            table1.Cell(1, 4).Range.Text = "Осложнения";
            table1.Cell(2, 1).Range.Text = "1.";
            table1.Cell(3, 1).Range.Text = "2.";
            table1.Cell(4, 1).Range.Text = "3.";
            table1.Cell(5, 3).Range.Text = "Оперировал";
            table1.Cell(5, 4).Range.Text = "___________";

            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "14. Другие виды лечения ____________________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "для больных злокачественными новообразованиями.";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "1. Специальное лечение: хирургическое (дистанционная гамматерапия, рентгенотерапия, быстрые электроны, контактная и дистанционная гамматерапия, контактная гамматерапия и глубокая рентгенотерапия); комбинированное (хирургическое и гамматерапия, хирургическое и рентгенотерапия, хирургическое и сочетанное лучевое); химиопрепаратами, гормональными препаратами. ";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "2. Паллиативное. ";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "3. Симптоматическое лечение.";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "15. Отметка о выдаче листка нетрудоспособности";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "№ _______ с _______ по ______ № _______ с ________ по ________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "№ _______ с _______ по ______ № _______ с ________ по ________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "16. Исход заболевания: выписан - с выздоровлением, с улучшением, без перемен, с ухудшением; переведен в другое учреждение ____________________________________________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "название лечебного учреждения";
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "Умер в приемном отделении, умерла беременная до 28 недель беременности, умерла после 28 недель беременности, роженица, родильница.";
            mainRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "17. Трудоспособность восстановлена полностью, снижена, временно утрачена, стойко утрачена в связи с данным заболеванием, с другими причинами (подчеркнуть)";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "18. Для поступивших на экспертизу-заключение ______________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "19. Особые отметки ___________________________________________________________________";
            mainRange.InsertParagraphAfter();
            mainRange = headParagraph.Range;
            mainRange.Text = "_____________________________________________________________________________________";

            Word.Table table2 = document.Tables.Add(mainRange, 3, 2);
            table2.PreferredWidth = 500;
            table2.Cell(1, 1).Range.Text = "Лечащий врач";
            table2.Cell(1, 2).Range.Text = "Зав. отделением";
            table2.Cell(2, 1).Range.Text = $"{db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == db.context.WorkerInWards.FirstOrDefault(y => y.WardId == db.context.HospitalPatients.FirstOrDefault(z => z.IdPatient == idPatient).WardId).WorkerId).NameWorker}";
            table2.Cell(2, 2).Range.Text = "________________";
            table2.Cell(3, 1).Range.Text = "подпись";
            table2.Cell(3, 2).Range.Text = "подпись";
            //получить путь
            string selectedPath = "";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedPath = folderBrowserDialog.SelectedPath;
                document.SaveAs2($"{selectedPath}\\Медицинская карта пациента {db.context.HospitalPatients.FirstOrDefault(x => x.IdPatient == idPatient).FIO}.docx");
            }
            document.Close();
            application.Quit();
        }
    }
}
