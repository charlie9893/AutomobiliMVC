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

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var automobil = await mvcDemoDbContext.Automobili.FirstOrDefaultAsync(x => x.Id == id);


            if (automobil != null)
            {

                var viewModel = new UpdateAutomobilViewModel()
                {
                    Id = Guid.NewGuid(),
                    Marka = automobil.Marka,
                    Model = automobil.Model,
                    Godiste = automobil.Godiste,
                    Zapremina = automobil.Zapremina,
                    Snaga = automobil.Snaga,
                    Gorivo = automobil.Gorivo,
                    Karoserija = automobil.Karoserija,
                    Opis = automobil.Opis,
                    Cena = automobil.Cena,
                    Kontakt = automobil.Kontakt
                }; 
                return await Task.Run(() => View("View",viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateAutomobilViewModel model)
        {
            var automobil = await mvcDemoDbContext.Automobili.FindAsync(model.Id);

            if (automobil != null)
            {
                automobil.Marka = model.Marka;
                automobil.Model = model.Model;
                automobil.Godiste = model.Godiste;
                automobil.Zapremina = model.Zapremina;
                automobil.Gorivo = model.Gorivo;
                automobil.Karoserija = model.Karoserija;
                automobil.Opis = model.Opis;
                automobil.Cena = model.Cena;
                automobil.Kontakt = model.Kontakt;

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
