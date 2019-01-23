using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fakturisanje.Models
{
    [Table("Stavka")]
    public partial class Stavka
    {
        public int StavkaId { get; set; }
        public int FakturaId { get; set; }
        public int RedniBroj { get; set; }
        public int Kolicina { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Cena { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Ukupno { get; set; }

        [ForeignKey("FakturaId")]
        [InverseProperty("Stavke")]
        public virtual Faktura Faktura { get; set; }
    }
}