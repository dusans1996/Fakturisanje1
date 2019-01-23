using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fakturisanje.Data;
using Fakturisanje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fakturisanje.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private UserManager<ApplicationUser> um;
        private RoleManager<IdentityRole> rm;
        private ApplicationDbContext db;
        private SignInManager<ApplicationUser> sm;

        public RoleController(UserManager<ApplicationUser> _um, RoleManager<IdentityRole> _rm, ApplicationDbContext _db, SignInManager<ApplicationUser> _sm)
        {
            sm = _sm;
            um = _um;
            rm = _rm;
            db = _db;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index(string poruka)
        {
            ViewBag.Poruka = poruka;
            List<IdentityRole> uloge = rm.Roles.ToList();
            return View(uloge);           
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(IdentityRole Rola)
        {
            var rez = await rm.CreateAsync(Rola);

            if (rez.Succeeded)
            {
                return RedirectToAction("Index", new { poruka = $"Kreirana rola: {Rola.Name}" });
            }
            else
            {
                return View(Rola);
            }
        }

        [Authorize(Roles = "admin,manager")]
        public IActionResult DodajKorisnikaUrolu()
        {
            ViewBag.Korisnici = new SelectList(db.Users, "UserName", "UserName");
            ViewBag.Uloge = new SelectList(db.Roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin,manager")]
        public async Task<IActionResult> DodajKorisnikaUrolu(string imeKorisnika, string uloga)
        {
            ViewBag.Korisnici = new SelectList(db.Users, "UserName", "UserName");
            ViewBag.Uloge = new SelectList(db.Roles, "Name", "Name");
            ApplicationUser korisnik = await um.FindByNameAsync(imeKorisnika);

            bool rez1 = await um.IsInRoleAsync(korisnik, uloga);

            if (rez1)
            {
                ViewBag.Poruka = $"Korisnik {imeKorisnika} vec postoji u rolu {uloga}";
                return View();
            }

            var rez2 = await um.AddToRoleAsync(korisnik, uloga);
            if (rez2.Succeeded)
            {
                return RedirectToAction("Index", new { poruka = $"Korisnik {imeKorisnika} je dodat u rolu{uloga}" });
            }
            else
            {
                ViewBag.Poruka = "Greska";
                return View();
            }
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Obrisi(string ime)
        {
            IdentityRole rola = await rm.FindByNameAsync(ime);

            return View(rola);
        }


        [HttpPost, ActionName("Obrisi")]
        public async Task<IActionResult> PotvrdiBrisanje(string ime)
        {
            IdentityRole rola = await rm.FindByNameAsync(ime);
            db.Roles.Remove(rola);
            db.SaveChanges();
            return RedirectToAction("Index", new { poruka = $"Obrisana uloga {ime}" });
        }
    }
}
