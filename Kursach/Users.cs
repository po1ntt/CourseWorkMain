//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursach
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Results = new HashSet<Results>();
        }
    
        public int id_u { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int id_role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
        public virtual Role Role { get; set; }
    }
}