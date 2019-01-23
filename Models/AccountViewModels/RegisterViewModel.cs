using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakturisanje.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Unesite email")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesite ime")]
        [StringLength(30, ErrorMessage = "Mozete uneti najvise 30 karaktera")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite prezime")]
        [StringLength(30, ErrorMessage = "Mozete uneti najvise 30 karaktera")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Unesite drzavu")]
        [StringLength(30, ErrorMessage = "Mozete uneti najvise 30 karaktera")]
        public string Drzava { get; set; }

        [Required(ErrorMessage = "Unesite grad")]
        [StringLength(30, ErrorMessage = "Mozete uneti najvise 30 karaktera")]
        public string Grad { get; set; }

        [Required(ErrorMessage = "Unesite adresu")]
        [StringLength(30, ErrorMessage = "Mozete uneti najvise 30 karaktera")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Unesite lozinku")]
        [StringLength(100, ErrorMessage = "Morate uneti najmanje 3 karaktera.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Lozinka { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrda lozinke")]
        [Compare("Lozinka", ErrorMessage = "Potvrda ne odgovara lozinci.")]
        public string PotvrdaLozinke { get; set; }
    }
}
