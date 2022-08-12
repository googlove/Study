namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Autos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Autos()
        {
            Stealings = new HashSet<Stealings>();
            TechnicalInspections = new HashSet<TechnicalInspections>();
        }

        [Key]
        public int AutoID { get; set; }

        [Required]
        [StringLength(15)]
        public string Number { get; set; }

        [Required]
        [StringLength(15)]
        public string Brand { get; set; }

        [Required]
        [StringLength(15)]
        public string Model { get; set; }

        [Required]
        [StringLength(20)]
        public string BodyID { get; set; }

        [Required]
        [StringLength(20)]
        public string EngineID { get; set; }

        [Required]
        [StringLength(20)]
        public string BodyModel { get; set; }

        [Required]
        [StringLength(20)]
        public string Color { get; set; }

        public double Volume { get; set; }

        public int Power { get; set; }

        public bool Helm { get; set; }

        public bool Drive { get; set; }

        public int Year { get; set; }

        [Required]
        [StringLength(15)]
        public string TypeBody { get; set; }

        public bool DrivingAway { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        [Column(TypeName = "money")]
        public decimal YearTax { get; set; }

        public int OwnerID { get; set; }

        public virtual Owners Owners { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stealings> Stealings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechnicalInspections> TechnicalInspections { get; set; }
    }
}
