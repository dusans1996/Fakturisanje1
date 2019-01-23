using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fakturisanje.Models
{
    [Table("Kupac")]
    public partial class Kupac
    {
        public Kupac()
        {
            Fakture = new HashSet<Faktura>();
        }

        [StringLength(400)]
        public string KupacId { get; set; }
        [Required]
        [StringLength(30)]
        public string Ime { get; set; }
        [Required]
        [StringLength(30)]
        public string Prezime { get; set; }
        [Required]
        [StringLength(30)]
        public string Drzava { get; set; }
        [Required]
        [StringLength(30)]
        public string Grad { get; set; }
        [Required]
        [StringLength(100)]
        public string Adresa { get; set; }

        [InverseProperty("Kupac")]
        public virtual ICollection<Faktura> Fakture { get; set; }
    }
}