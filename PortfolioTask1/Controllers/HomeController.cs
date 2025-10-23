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
                // DÝKKAT: Burada Context.cs'teki isimleri kullanýyoruz
                Sliders = await _context.Sliders.ToListAsync(),
                Yetenekler = await _context.Yeteneklerims.ToListAsync(), // Context'teki adý "Yeteneklerims"
                Projeler = await _context.Projelerims.ToListAsync(),     // Context'teki adý "Projelerims"
                Ozgecmisler = await _context.Ozgecmiss.ToListAsync(),      // Context'teki adý "Ozgecmis"
                GenelBilgiler = await _context.Genels.FirstOrDefaultAsync(), // Context'teki adý "Genels"
                AboutMe = await _context.Hakkimdas.FirstOrDefaultAsync()  // Context'teki adý "Hakkimdas"
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult iletisimEkle(IletisimForm form)
        {
            _context.ýletisimForms.Add(form);
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
