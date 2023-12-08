using AutomobiliMVC.Data;
using AutomobiliMVC.Models;
using AutomobiliMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutomobiliMVC.Controllers
{
    public class AutomobiliController : Controller
    {
        private readonly MVCDemoDBContext mvcDemoDbContext;

        public AutomobiliController(MVCDemoDBContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var automobili = await mvcDemoDbContext.Automobili.ToListAsync();
            return View(automobili);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DodajAutomobilViewModel dodajAutomobilRequest)
        {
            var automobil = new Automobil()
            {
                Id = Guid.NewGuid(),
                Marka = dodajAutomobilRequest.Marka,
                Model = dodajAutomobilRequest.Model,
                Godiste = dodajAutomobilRequest.Godiste,
                Zapremina = dodajAutomobilRequest.Zapremina,
                Snaga = dodajAutomobilRequest.Snaga,
                Gorivo = dodajAutomobilRequest.Gorivo,
                Karoserija = dodajAutomobilRequest.Karoserija,
                Opis = dodajAutomobilRequest.Opis,
                Cena = dodajAutomobilRequest.Cena,
                Kontakt = dodajAutomobilRequest.Kontakt
            };

            await mvcDemoDbContext.Automobili.AddAsync(automobil);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
