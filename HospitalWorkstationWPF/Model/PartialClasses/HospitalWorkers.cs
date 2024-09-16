using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWorkstationWPF.Model
{
    partial class HospitalWorkers
    {
        readonly Core db = new Core();
        public string AgeWorker
        {
            get
            {
                int ageDifference = DateTime.Now.Year - BirthdayWorker.Year;
                if (DateTime.Now < BirthdayWorker.AddYears(ageDifference)) ageDifference--;
                return $"Возраст: {ageDifference}";
            }
        }
        public string FIO
        {
            get
            {
                if (IdWorker == Properties.Settings.Default.idWorker) return $"{SurnameWorker} {NameWorker} {PatronymicWorker} (Это вы)";
                return $"{SurnameWorker} {NameWorker} {PatronymicWorker}";
            }
        }
        public string FIOShort
        {
            get
            {
                if (IdWorker == Properties.Settings.Default.idWorker) return $"{SurnameWorker} {NameWorker} {PatronymicWorker} (Это вы)";
                return $"{SurnameWorker} {NameWorker[0]}.{PatronymicWorker[0]}";
            }
        }
        public string AmountWards
        {
            get
            {
                return $"Количество палат: {WorkerInWards.Count}";
            }
        }
        public string AmountPatients
        {
            get
            {
                int amount = 0;
                foreach (WorkerInWards workerInWards in db.context.WorkerInWards.Where(x => x.WorkerId == IdWorker).ToList())
                {
                    foreach (HospitalPatients patient in db.context.HospitalPatients.Where(x => x.WardId == workerInWards.WardId).ToList())
                    {
                        amount++;
                    }
                }
                return $"Количество пациентов: {amount}";
            }
        }
        public string RoleName
        {
            get
            {
                return db.context.Roles.FirstOrDefault(x => x.IdRole == db.context.Users.FirstOrDefault(y => y.WorkerId == IdWorker).RoleId).NameRole;
            }
        }
    }
}
