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
    
    public partial class HospitalWards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HospitalWards()
        {
            this.HospitalPatients = new HashSet<HospitalPatients>();
            this.WorkerInWards = new HashSet<WorkerInWards>();
        }
    
        public int IdWard { get; set; }
        public string NameWard { get; set; }
        public int DepartmentId { get; set; }
    
        public virtual HospitalDepartments HospitalDepartments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HospitalPatients> HospitalPatients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerInWards> WorkerInWards { get; set; }
    }
}
