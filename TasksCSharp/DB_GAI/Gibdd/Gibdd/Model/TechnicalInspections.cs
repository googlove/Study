namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TechnicalInspections
    {
        [Key]
        public int TechnicalInspectionID { get; set; }

        [Required]
        [StringLength(60)]
        public string Inspector { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateSee { get; set; }

        [Column(TypeName = "money")]
        public decimal? YearNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Work { get; set; }

        public int Distance { get; set; }

        public bool Okey { get; set; }

        [Column(TypeName = "text")]
        public string Reason { get; set; }

        public int AutoID { get; set; }

        public virtual Autos Autos { get; set; }
    }
}
