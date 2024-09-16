using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalWorkstationWPF.Model
{
    partial class HospitalPatients
    {
        readonly Core db = new Core();
        public string AgePatient
        {
            get
            {
                int ageDifference = DateTime.Now.Year - BirthdayPatient.Year;
                if (DateTime.Now < BirthdayPatient.AddYears(ageDifference)) ageDifference--;
                return $"Возраст: {ageDifference}";
            }
        }
        public int AgePatientInt
        {
            get
            {
                int ageDifference = DateTime.Now.Year - BirthdayPatient.Year;
                if (DateTime.Now < BirthdayPatient.AddYears(ageDifference)) ageDifference--;
                return ageDifference;
            }
        }
        public string FIO
        {
            get
            {
                return $"{SurnamePatient} {NamePatient} {PatronymicPatient}";
            }
        }
        public string ArrivalDateString
        {
            get
            { 
                return $"Дата прибытия: {ArrivalDate.ToShortDateString()}";
            }
        }
        public string DiagnosisName
        {
            get
            {
                return $"Диагноз: {Diagnoses.NameDiagnosis}";
            }
        }
        public string WardName
        {
            get
            {
                return $"Палата №{HospitalWards.NameWard}";
            }
        }
        public int IdDepartment
        {
            get
            {
                return HospitalWards.DepartmentId;
            }
        }
        public string DepartmentName
        {
            get
            {
                return $"{db.context.HospitalDepartments.FirstOrDefault(x => x.IdDepartment == IdDepartment).NameDepartment} отделение";
            }
        }
        public string RegistrationNumberString
        {
            get
            {
                return $"№{RegistrationNumber}";
            }
        }
        public string AppointmentContent
        {
            get
            {
                if (db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == IdPatient) != null) return db.context.Doctor_s_Appointment.FirstOrDefault(x => x.PatientId == IdPatient).Description;
                return "";
            }
        }
        public Visibility VisibilityAppointment
        {
            get
            {
                if (db.context.Doctor_s_Appointment.Where(x => x.PatientId == IdPatient).Count() == 0) return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }
        public Visibility VisibilityAddAppointmentButton
        {
            get
            {
                if (db.context.Doctor_s_Appointment.Where(x => x.PatientId == IdPatient).Count() > 0) return Visibility.Collapsed;
                return Visibility.Visible;
            }
        }
    }
}
