using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioTask1.Models;
using PortfolioTask1.Models.Entities;
using PortfolioTask1.Models.ViewModels;

namespace PortfolioTask1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel
            {
                // D�KKAT: Burada Context.cs'teki isimleri kullan�yoruz
                Sliders = await _context.Sliders.ToListAsync(),
                Yetenekler = await _context.Yeteneklerims.ToListAsync(), // Context'teki ad� "Yeteneklerims"
                Projeler = await _context.Projelerims.ToListAsync(),     // Context'teki ad� "Projelerims"
                Ozgecmisler = await _context.Ozgecmiss.ToListAsync(),      // Context'teki ad� "Ozgecmis"
                GenelBilgiler = await _context.Genels.FirstOrDefaultAsync(), // Context'teki ad� "Genels"
                AboutMe = await _context.Hakkimdas.FirstOrDefaultAsync()  // Context'teki ad� "Hakkimdas"
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult iletisimEkle(IletisimForm form)
        {
            _context.�letisimForms.Add(form);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult SliderPartial()
        {
            List<Slider> sliderlar = _context.Sliders.ToList();
            return PartialView("_SliderPartial", sliderlar);
        }
    }
}
