using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fakturisanje.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Fakturisanje.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly FakturisanjeContext db;
        private readonly UserManager<ApplicationUser> um;
        private readonly RoleManager<IdentityRole> rm;

        public HomeController(FakturisanjeContext _db, UserManager<ApplicationUser> _um, RoleManager<IdentityRole> _rm)
        {
            db = _db;
            um = _um;
            rm = _rm;
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AdminSis()
        {
            int rolaPostoji = await KreirajRoluAsync("admin");
            ApplicationUser admin = await KreirajAdministratora();

            if (rolaPostoji == -1)
            {
                ViewBag.Poruka = "Greska pri kreiranju role";
                return View();
            }

            if (admin == null)
            {
                ViewBag.Poruka = "Greska pri kreiranju admina";
                return View();
            }

            bool rez1 = await um.IsInRoleAsync(admin, "admin");

            if (rez1)
            {
                ViewBag.Poruka = "Korisnik je vec u roli admin";
                return View();
            }

            var rez = await um.AddToRoleAsync(admin, "admin");

            if (rez.Succeeded)
            {
                ViewBag.Poruka = "Administrator kreiran";
            }
            else
            {
                ViewBag.Poruka = "Greska pri dodavanju korisnika u rolu";
            }
            return View();
        }

        private async Task<ApplicationUser> KreirajAdministratora()
        {
            ApplicationUser admin = await um.FindByEmailAsync("admin@gmail.com");

            if (admin == null)
            {
                //kreiranje novog admina

                admin = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Ime = "Dusan",
                    Prezime = "Stojanovic",
                    Adresa = "Ljubicica 2b",
                    Grad = "Beograd",
                    Drzava = "Srbija"
                };

                string loz = "123";

                var rez = await um.CreateAsync(admin, loz);

                if (rez.Succeeded)
                {
                    return admin;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //admin exists
                return admin;
            }
        }

        private async Task<int> KreirajRoluAsync(string rola)
        {
            bool rolaPostoji = await rm.RoleExistsAsync(rola);

            if (rolaPostoji)
            {
                return 0;
            }
            else
            {
                IdentityRole rolaAdmina = new IdentityRole(rola);
                var rez = await rm.CreateAsync(rolaAdmina);

                if (rez.Succeeded)
                {
                    return 1;

                }
                else
                {
                    return -1;
                }
            }
        }

        [Authorize(Roles = "admin")]
        public IActionResult Administracija()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Fakture.ToListAsync());

        }

        public PartialViewResult _PrikaziFakture()
        {
            return PartialView(db.Fakture.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
