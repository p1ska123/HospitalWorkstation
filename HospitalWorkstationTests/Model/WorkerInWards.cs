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
    
    public partial class WorkerInWards
    {
        public int IdWorkerInWards { get; set; }
        public int WardId { get; set; }
        public int WorkerId { get; set; }
    
        public virtual HospitalWards HospitalWards { get; set; }
        public virtual HospitalWorkers HospitalWorkers { get; set; }
    }
}
