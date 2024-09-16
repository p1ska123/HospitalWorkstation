using HospitalWorkstationWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalWorkstationWPF.ViewModel
{
    public class HospitalDepartmentsViewModel
    {
        static readonly Core db = new Core();
        public static bool AddDepartment(string departmentName)
        {
            if (string.IsNullOrWhiteSpace(departmentName)) throw new Exception("Поле не заполнено");
            if (departmentName.Length > 50) throw new Exception("Длина текста поля слишком велика");
            if (db.context.HospitalDepartments.Where(x => x.NameDepartment == departmentName).Count() > 0) throw new Exception("Отделение с таким названием существует");
            HospitalDepartments department = new HospitalDepartments()
            {
                NameDepartment = departmentName,
            };
            db.context.HospitalDepartments.Add(department);
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool UdpateDepartment(int idDepartment, string departmentName)
        {
            if (string.IsNullOrWhiteSpace(departmentName)) throw new Exception("Поле не заполнено");
            if (departmentName.Length > 50) throw new Exception("Длина текста поля слишком велика");
            HospitalDepartments department = new HospitalDepartments()
            {
                IdDepartment = idDepartment,
                NameDepartment = departmentName,
            };
            db.context.HospitalDepartments.AddOrUpdate(department);
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
        public static bool DeleteDepartment(int idDepartment) 
        {
            db.context.HospitalDepartments.Remove(db.context.HospitalDepartments.FirstOrDefault(x => x.IdDepartment == idDepartment));
            if (db.context.SaveChanges() > 0) return true;
            else throw new Exception("Ошибка");
        }
    }
}
