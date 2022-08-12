namespace Gibdd.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Police_view2
    {
        [Column("Гос. номер")]
        [StringLength(15)]
        public string Гос__номер { get; set; }

        [StringLength(15)]
        public string Производитель { get; set; }

        [StringLength(15)]
        public string Модель { get; set; }

        [StringLength(20)]
        public string Цвет { get; set; }

        [Key]
        [Column("Дата угона", TypeName = "date")]
        public DateTime Дата_угона { get; set; }

        [Column("Дата возврата", TypeName = "date")]
        public DateTime? Дата_возврата { get; set; }
    }
}
