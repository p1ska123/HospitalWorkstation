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
    
    public partial class Users
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int WorkerId { get; set; }
    
        public virtual HospitalWorkers HospitalWorkers { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
