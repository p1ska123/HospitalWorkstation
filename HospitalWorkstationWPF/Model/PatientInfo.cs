//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalWorkstationWPF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientInfo
    {
        public int IdInfo { get; set; }
        public int PatientId { get; set; }
        public string BloodGroup { get; set; }
        public string RhesusType { get; set; }
        public string SideEffect { get; set; }
        public string DrugNameOfSideEffect { get; set; }
        public string Adress { get; set; }
        public string PlaceOfWork_Study { get; set; }
    
        public virtual HospitalPatients HospitalPatients { get; set; }
    }
}
