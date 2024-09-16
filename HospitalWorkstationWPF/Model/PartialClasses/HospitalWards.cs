using HospitalWorkstationWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWorkstationWPF.Model
{
    partial class HospitalWards
    {
        readonly Core db = new Core();
        public string NameWardAdd
        {
            get
            {
                if (IdWard == 0) return $"{NameWard} палаты";
                return $"Палата №{NameWard}";
            }
        }
        public string DepartmentName
        {
            get
            {
                return $"{HospitalDepartments.NameDepartment} отделение";
            }
        }
        public string WorkerName
        {
            get
            {
                if (db.context.WorkerInWards.FirstOrDefault(y => y.WardId == IdWard) != null)
                {
                    int idWorker = db.context.WorkerInWards.FirstOrDefault(y => y.WardId == IdWard).WorkerId;
                    int idPost = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).PostId;
                    string fio = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).FIO;
                    string post = db.context.HospitalPosts.FirstOrDefault(z => z.IdPost == idPost).NamePost.ToLower();
                    return $"Работник: {fio}, {post}";
                }
                return "Работник отсутствует";
            }
        }
        public string WorkerNameShort
        {
            get
            {
                if (db.context.WorkerInWards.FirstOrDefault(y => y.WardId == IdWard) != null)
                {
                    int idWorker = db.context.WorkerInWards.FirstOrDefault(y => y.WardId == IdWard).WorkerId;
                    int idPost = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).PostId;
                    string fio = db.context.HospitalWorkers.FirstOrDefault(x => x.IdWorker == idWorker).FIOShort;
                    string post = db.context.HospitalPosts.FirstOrDefault(z => z.IdPost == idPost).NamePost.ToLower();
                    return $"Работник: {fio}, {post}";
                }
                return "Работник отсутствует";
            }
        }
        public string AmountPatients
        {
            get
            {
                return $"Количество пациентов: {HospitalPatients.Count()}";
            }
        }
        public int CountPatients
        {
            get
            {
                return HospitalPatients.Count;
            }
        }
    }
}
