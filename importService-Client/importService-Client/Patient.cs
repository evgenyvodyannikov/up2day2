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
    
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.User_Patient = new HashSet<User_Patient>();
        }
    
        public int ID { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string GuID { get; set; }
        public string Email { get; set; }
        public int SocialSecNumber { get; set; }
        public string EIN { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Social_Type { get; set; }
        public int Passport_Serial { get; set; }
        public int Passport_Number { get; set; }
        public System.DateTime BirthDate { get; set; }
        public Nullable<int> IInsurance { get; set; }
    
        public virtual Insurance Insurance { get; set; }
        public virtual Social_License Social_License { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Patient> User_Patient { get; set; }
    }
}
