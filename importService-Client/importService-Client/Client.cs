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
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Client_Service = new HashSet<Client_Service>();
        }
    
        public int ID { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Patronimyc { get; set; }
        public Nullable<int> IGender { get; set; }
        public string PhoneNumber { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Mail { get; set; }
        public System.DateTime DateOfRegistation { get; set; }
    
        public virtual Gender Gender { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client_Service> Client_Service { get; set; }
    }
}