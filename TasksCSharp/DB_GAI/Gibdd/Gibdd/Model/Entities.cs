namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntityID { get; set; }

        [Required]
        [StringLength(60)]
        public string EntityName { get; set; }

        [Required]
        [StringLength(60)]
        public string Chief { get; set; }

        [Required]
        [StringLength(10)]
        public string EntityInn { get; set; }

        public virtual Owners Owners { get; set; }
    }
}
