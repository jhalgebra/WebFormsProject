using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RWAProject.DAL {
    [Serializable]
    [Table("PersonEmail")]
    public partial class PersonEmail
    {
        #region Properties

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int PersonID { get; set; }

        public virtual Person Person { get; set; } 

        #endregion

        #region Methods

        public override bool Equals(object obj)
            => obj is PersonEmail mail && Email == mail.Email && PersonID == mail.PersonID;

        public override int GetHashCode() => Email.GetHashCode() + PersonID.GetHashCode();

        public override string ToString() => Email; 

        #endregion
    }
}
