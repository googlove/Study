namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IndividualOwners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IndividualOwnerID { get; set; }

        [Required]
        [StringLength(60)]
        public string OwnerFio { get; set; }

        public virtual Owners Owners { get; set; }
    }
}
