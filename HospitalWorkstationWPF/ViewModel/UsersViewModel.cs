using HospitalWorkstationWPF.Classes;
using HospitalWorkstationWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWorkstationWPF.ViewModel
{
    public class UsersViewModel
    {
        private static readonly Core db = new Core();
        public static bool CheckAuth(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) throw new Exception("Поля не заполнены");
            if (db.context.Users.Where(x => x.Login == login).Count() == 0) throw new Exception($"Пользователь с логином {login} не найден");
            password = AdditionalMethods.CachingPassword(password);
            if (db.context.Users.Where(x => x.Login == login && x.Password == password).Count() == 0) throw new Exception("Неверный пароль");
            return true;
        }
        public static string GetFullUserName(int idWorker, int idRole)
        {
            string userName = $"{db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).SurnameWorker} {db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).NameWorker} {db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).PatronymicWorker}";
            string post = db.context.HospitalPosts.FirstOrDefault(x => x.IdPost == db.context.HospitalWorkers.FirstOrDefault(y => y.IdWorker == idWorker).PostId).NamePost;
            string role = db.context.Roles.FirstOrDefault(x => x.IdRole == idRole).NameRole;
            return userName + ", " + role + ", " + post.ToLower();
        }
    }
}
