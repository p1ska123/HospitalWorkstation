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
    
    public partial class HospitalWorkers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HospitalWorkers()
        {
            this.Users = new HashSet<Users>();
            this.WorkerInWards = new HashSet<WorkerInWards>();
        }
    
        public int IdWorker { get; set; }
        public string NameWorker { get; set; }
        public string SurnameWorker { get; set; }
        public string PatronymicWorker { get; set; }
        public int PostId { get; set; }
        public System.DateTime BirthdayWorker { get; set; }
    
        public virtual HospitalPosts HospitalPosts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users> Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkerInWards> WorkerInWards { get; set; }
    }
}
