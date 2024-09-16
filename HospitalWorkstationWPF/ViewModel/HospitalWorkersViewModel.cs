using HospitalWorkstationWPF.Classes;
using HospitalWorkstationWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWorkstationWPF.ViewModel
{
    public class HospitalWorkersViewModel
    {
        static readonly Core db = new Core();
        public static bool AddWorker(string name, string surname, string patronymic, int idPost, DateTime birthday, string login, string password, int idRole, List<int> idWards)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(patronymic) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) throw new Exception("Поля не заполнены");
            if (birthday > DateTime.Now) throw new Exception("Человек с такой датой еще не родился");
            if (name.Length > 50 || surname.Length > 50 || patronymic.Length > 50 || login.Length > 50 || password.Length > 50) throw new Exception("Длина текста поля слишком велика");
            if (db.context.Users.Where(x => x.Login == login).Count() > 0) throw new Exception($"Работник с логином {login} уже существует");
            HospitalWorkers newWorker = new HospitalWorkers()
            {
                NameWorker = name,
                SurnameWorker = surname,
                PatronymicWorker = patronymic,
                PostId = idPost,
                BirthdayWorker = birthday,
            };
            db.context.HospitalWorkers.Add(newWorker);
            Users newUser = new Users()
            {
                Login = login,
                Password = AdditionalMethods.CachingPassword(password),
                RoleId = idRole,
                WorkerId = newWorker.IdWorker
            };
            db.context.Users.Add(newUser);
            if (idWards.Count != 0)
            {
                foreach (int idWard in idWards)
                {
                    WorkerInWards workerInWards = new WorkerInWards()
                    {
                        WorkerId = newWorker.IdWorker,
                        WardId = idWard
                    };
                    db.context.WorkerInWards.Add(workerInWards);
                }
            }
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool UpdateWorker(string name, string surname, string patronymic, int idPost, DateTime birthday, int idRole, List<int> idWards, int idWorker, string pass)
        {
            if (db.context.Users.FirstOrDefault(x => x.WorkerId == idWorker).RoleId == 3) throw new Exception("Вы не можете редактировать данные администратора");
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(patronymic)) throw new Exception("Поля не заполнены");
            if (name.Length > 50 || surname.Length > 50 || patronymic.Length > 50 || pass.Length > 50) throw new Exception("Длина текста поля слишком велика");
            if (birthday > DateTime.Now) throw new Exception("Человек с такой датой еще не родился");
            HospitalWorkers newWorker = new HospitalWorkers()
            {
                IdWorker = idWorker,
                NameWorker = name,
                SurnameWorker = surname,
                PatronymicWorker = patronymic,
                PostId = idPost,
                BirthdayWorker = birthday,
            };
            db.context.HospitalWorkers.AddOrUpdate(newWorker);
            if (pass == "") pass = db.context.Users.FirstOrDefault(x => x.WorkerId == idWorker).Password;
            else
            {
                pass = AdditionalMethods.CachingPassword(pass);
            }
            Users newUser = new Users()
            {
                Login = db.context.Users.FirstOrDefault(x => x.WorkerId == idWorker).Login,
                Password = pass,
                RoleId = idRole,
                WorkerId = newWorker.IdWorker
            };
            db.context.Users.AddOrUpdate(newUser);
            if (db.context.WorkerInWards.Where(x => x.WorkerId == idWorker).Count() != 0)
            {
                foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == idWorker))
                {
                    db.context.WorkerInWards.Remove(workerInWards);
                }
                foreach (int idWard in idWards)
                {
                    WorkerInWards workerInWards = new WorkerInWards()
                    {
                        WorkerId = newWorker.IdWorker,
                        WardId = idWard
                    };
                    db.context.WorkerInWards.Add(workerInWards);
                }
            }
            else
            {
                if (idWards.Count != 0)
                {
                    foreach (int idWard in idWards)
                    {
                        WorkerInWards workerInWards = new WorkerInWards()
                        {
                            WorkerId = newWorker.IdWorker,
                            WardId = idWard
                        };
                        db.context.WorkerInWards.Add(workerInWards);
                    }
                }
            }
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool DeleteWorker(int idWorker)
        {
            db.context.HospitalWorkers.Remove(db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker));
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
    }
}
