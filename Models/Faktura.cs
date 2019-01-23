using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fakturisanje.Models
{
    [Table("Faktura")]
    public partial class Faktura
    {
        public Faktura()
        {
            Stavke = new HashSet<Stavka>();
        }

        public int FakturaId { get; set; }
        [Required]
        [StringLength(400)]
        public string KupacId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DatumFakture { get; set; }
        [Required]
        [StringLength(10)]
        public string BrojFakture { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal UkupnoFaktura { get; set; }

        [ForeignKey("KupacId")]
        [InverseProperty("Fakture")]
        public virtual Kupac Kupac { get; set; }
        [InverseProperty("Faktura")]
        public virtual ICollection<Stavka> Stavke { get; set; }
    }
}