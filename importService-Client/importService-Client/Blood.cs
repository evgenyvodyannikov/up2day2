//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace importService_Client
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blood
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blood()
        {
            this.Blood_Service = new HashSet<Blood_Service>();
        }
    
        public int ID { get; set; }
        public int Barcode { get; set; }
        public System.DateTime DonateDate { get; set; }
        public Nullable<int> IPatient { get; set; }
    
        public virtual Patient Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blood_Service> Blood_Service { get; set; }
    }
}
