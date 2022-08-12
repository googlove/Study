namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TechnicalOwners_View
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(60)]
        public string OwnerFio { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string Phone { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(60)]
        public string Address { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(15)]
        public string Number { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string Brand { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(15)]
        public string Model { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(60)]
        public string Inspector { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "date")]
        public DateTime DateSee { get; set; }

        [Column(TypeName = "money")]
        public decimal? YearNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Work { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Distance { get; set; }

        [Key]
        [Column(Order = 9)]
        public bool Okey { get; set; }

        [Column(TypeName = "text")]
        public string Reason { get; set; }
    }
}
