//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalWorkstationTests.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor_s_Appointment
    {
        public int IdAppointment { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
    
        public virtual HospitalPatients HospitalPatients { get; set; }
    }
}
