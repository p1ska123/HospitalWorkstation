using HospitalWorkstationWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWorkstationWPF.ViewModel
{
    public class HospitalWardsViewModel
    {
        static readonly Core db = new Core();
        public static bool AddWard(string nameWard, int idDepartment, int idWorker)
        {
            if (string.IsNullOrWhiteSpace(nameWard)) throw new Exception("Поле не заполнено");
            if (nameWard.Length > 10) throw new Exception("Длина текста поля слишком велика");
            if (db.context.HospitalWards.Where(x => x.NameWard == nameWard).Count() > 0) throw new Exception($"Палата {nameWard} уже существует");
            HospitalWards newWard = new HospitalWards()
            {
                NameWard = nameWard,
                DepartmentId = idDepartment,
            };
            db.context.HospitalWards.Add(newWard);
            if (idWorker != 0)
            {
                WorkerInWards workerInWards = new WorkerInWards()
                {
                    WardId = newWard.IdWard,
                    WorkerId = idWorker,
                };
                db.context.WorkerInWards.Add(workerInWards);
            }
            if (db.context.SaveChanges() > 0) return true;
            throw new Exception("Ошибка");
        }
        public static bool UpdateWard(int idWard, string nameWard, int idDepartment, int idWorker)
        {
            if (string.IsNullOrWhiteSpace(nameWard)) throw new Exception("Поле не заполнено");
            if (nameWard.Length > 10) throw new Exception("Длина текста поля слишком велика");
            HospitalWards newWard = new HospitalWards()
            {
                IdWard = idWard,
                NameWard = nameWard,
                DepartmentId = idDepartment,
            };
            db.context.HospitalWards.AddOrUpdate(newWard);
            if (db.context.WorkerInWards.FirstOrDefault(x => x.WardId == idWard) != null)
            {
                if (idWorker != 0)
                {
                    WorkerInWards workerInWards = new WorkerInWards()
                    {
                        IdWorkerInWards = db.context.WorkerInWards.FirstOrDefault(x => x.WardId == idWard).IdWorkerInWards,
                        WardId = newWard.IdWard,
                        WorkerId = idWorker,
                    };
                    db.context.WorkerInWards.AddOrUpdate(workerInWards);
                }
                else
                {
                    db.context.WorkerInWards.Remove(db.context.WorkerInWards.FirstOrDefault(x => x.WardId == idWard));
                }
            }
            else
            {
                if (idWorker != 0)
                {
                    WorkerInWards workerInWards = new WorkerInWards()
                    {
                        WardId = newWard.IdWard,
                        WorkerId = idWorker,
                    };
                    db.context.WorkerInWards.Add(workerInWards);
                }
            }
            if (db.context.SaveChanges() > 0) return true;
            throw new Exception("Ошибка");
        }
        public static bool DeleteWards(int idWard)
        {
            db.context.HospitalWards.Remove(db.context.HospitalWards.FirstOrDefault(x => x.IdWard == idWard));
            if (db.context.SaveChanges() > 0) return true;
            throw new Exception("Ошибка");
        }
    }
}
