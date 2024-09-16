using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWorkstationWPF.Model
{
    partial class HospitalDepartments
    {
        readonly Core db = new Core();
        public string NameDepartmentAdd
        {
            get
            {   if (IdDepartment == 0) return $"{NameDepartment} отделения";
                return $"{NameDepartment} отделение";
            }
        }
        public string AmountWards
        {
            get
            {
                return $"Количество палат: {HospitalWards.Count()}";
            }
        }
        public string AmountPatients
        {
            get
            {
                int amount = 0;
                foreach (HospitalWards myWardsRow in HospitalWards.Where(x => x.DepartmentId == IdDepartment).ToList())
                {
                    foreach (HospitalPatients myPatient in db.context.HospitalPatients.Where(x => x.WardId == myWardsRow.IdWard).ToList())
                    {
                        amount++;
                    }
                }
                return $"Количество пациентов: {amount}";
            }
        }
        public string AmountWorkers
        {
            get
            {
                List<int> idWorkers = new List<int>();
                foreach (HospitalWards myWardsRow in HospitalWards.Where(x => x.DepartmentId == IdDepartment).ToList())
                {
                    foreach (WorkerInWards myWardWorkers in db.context.WorkerInWards.Where(x => x.WardId == myWardsRow.IdWard).ToList())
                    {
                        idWorkers.Add(myWardWorkers.WorkerId);
                    }
                }
                return $"Количество работников: {idWorkers.Distinct().Count()}";
            }
        }
    }
}
