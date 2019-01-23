﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fakturisanje.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Unesite email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Unesite lozinku")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }

        [Display(Name = "Zapamti me?")]
        public bool ZapamtiMe { get; set; }
    }
}
