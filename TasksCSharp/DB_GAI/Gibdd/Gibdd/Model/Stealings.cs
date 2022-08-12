namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stealings
    {
        [Key]
        public int StealingID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateAway { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateReturn { get; set; }

        public int AutoID { get; set; }

        public virtual Autos Autos { get; set; }
    }
}
