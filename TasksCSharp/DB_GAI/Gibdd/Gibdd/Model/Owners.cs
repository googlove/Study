namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Owners
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Owners()
        {
            Autos = new HashSet<Autos>();
        }

        [Key]
        public int OwnerID { get; set; }

        [Required]
        [StringLength(25)]
        public string Phone { get; set; }

        public bool OwnerType { get; set; }

        [Required]
        [StringLength(60)]
        public string Address { get; set; }

        [Required]
        [StringLength(15)]
        public string District { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Autos> Autos { get; set; }

        public virtual Entities Entities { get; set; }

        public virtual IndividualOwners IndividualOwners { get; set; }
    }
}
