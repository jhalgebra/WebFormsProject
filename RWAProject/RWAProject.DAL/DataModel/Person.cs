using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RWAProject.DAL {
    [Serializable]
    [Table("Person")]
    public partial class Person {
        #region Properties

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [StringLength(100)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int RoleID { get; set; }

        public bool Admin => RoleID == 2;

        public int CityID { get; set; }

        public virtual City City { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonEmail> PersonEmails { get; set; } 

        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            PersonEmails = new HashSet<PersonEmail>();
        }
    }
}
