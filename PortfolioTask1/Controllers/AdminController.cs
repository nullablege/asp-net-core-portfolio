using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioTask1.Models;
using PortfolioTask1.Models.Entities;
using PortfolioTask1.Models.ViewModels;
using System.Threading.Tasks;


namespace PortfolioTask1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AdminController(Context context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous] 
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            // Kullanıcı zaten giriş yapmışsa Admin paneline yönlendir
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı adı veya parola hatalı.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            var viewModel = new AdminDashboardViewModel{
                projeSayisi = _context.Projelerims.Count(),
                yetenekSayisi = _context.Yeteneklerims.Count(),
                okunmamisMesajSayisi = _context.ıletisimForms.Count(x => x.Goruldu == false),
                sliderSayisi = _context.Sliders.Count(),
                sonMesajlar = _context.ıletisimForms.OrderByDescending( x => x.Tarih ).Take(3).ToList(),
                sonProjeler = _context.Projelerims.OrderByDescending( x => x.ProjelerimId).Take(3).ToList(),
            };

            return View(viewModel);
        }
   
        public IActionResult Genel()
        {
            var degerler = _context.Genels.FirstOrDefault();
            return View(degerler);
        }
        [HttpPost]
        public IActionResult Genel(Genel p)
        {
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Genel");
        }

        public IActionResult Hakkimda()
        {
            var degerler = _context.Hakkimdas.FirstOrDefault();
            return View(degerler);
        }

        [HttpPost]
        public IActionResult Hakkimda(Hakkimda p)
        {
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Hakkimda");
        }
    
        public IActionResult Ozgecmis()
        {
            var ozgecmisler = _context.Ozgecmiss.ToList();
            return View(ozgecmisler);
        }

        public IActionResult OzgecmisEkle()
        {

            return View();
        }
        [HttpPost]
        public IActionResult OzgecmisEkle(Ozgecmis p)
        {
            _context.Ozgecmiss.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Ozgecmis");
        }

        [HttpGet]
        public IActionResult OzgecmisDuzenle(int id)
        {
            var ozgecmis = _context.Ozgecmiss.Find(id);
            if(ozgecmis == null)
            {
                return RedirectToAction("Index");
            }
            return View(ozgecmis);
        }

        [HttpPost]
        public IActionResult OzgecmisDuzenle(Ozgecmis p)
        {
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Ozgecmis");
        }
        [HttpGet]
        public IActionResult OzgecmisSil(int id)
        {
            var ozgecmis = _context.Ozgecmiss.Find(id);
            if( ozgecmis != null)
            {
                _context.Ozgecmiss.Remove(ozgecmis);
                _context.SaveChanges();
            }
            return RedirectToAction("Ozgecmis");

        }

        public IActionResult Projeler()
        {
            var projeler = _context.Projelerims.ToList();
            return View(projeler);
        }
        public IActionResult ProjeEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProjeEkle(Projelerim p)
        {
            _context.Projelerims.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Projeler");
        }

        public IActionResult ProjeDuzenle(int id)
        {
            var proje = _context.Projelerims.Find(id);
            if( proje != null)
            {
                return View(proje);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ProjeDuzenle(Projelerim p)
        {
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult ProjeSil(int id)
        {
            var proje = _context.Projelerims.Find(id);
            if (proje != null)
            {
                _context.Projelerims.Remove(proje);
                _context.SaveChanges();
            }
            return RedirectToAction("Projeler");
        }

        public IActionResult Yetenekler()
        {
            var yetenekler = _context.Yeteneklerims.ToList();
            return View(yetenekler);
        }


        public IActionResult YetenekEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YetenekEkle(Yeteneklerim p)
        {
            _context.Yeteneklerims.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Yetenekler");
        }
   
        public IActionResult YetenekSil(int id)
        {
            var yetenek = _context.Yeteneklerims.Find(id);
            if (yetenek != null)
            {
                _context.Yeteneklerims.Remove(yetenek);
                _context.SaveChanges();
            }
            return RedirectToAction("Yetenekler");
        }

        public IActionResult YetenekDuzenle(int id)
        {
            var yetenek = _context.Yeteneklerims.Find(id);
            if (yetenek != null)
            {
                return View(yetenek);
            }
            else
            {
                 return View();
            }
               
        }

        [HttpPost]
        public IActionResult YetenekDuzenle(Yeteneklerim p)
        {
            if( p != null)
            {
                _context.Entry(p).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Yetenekler");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Iletisim()
        {
            var iletisimler = _context.ıletisimForms.ToList();
            return View(iletisimler);
        }

        [HttpGet]
        public IActionResult IletisimMesajGoruldu(int id)
        {
            var iletisim = _context.ıletisimForms.Find(id);
            if (iletisim != null)
            {
                if(iletisim.Goruldu == false)
                {
                    iletisim.Goruldu = true;
                }
                else
                {
                    iletisim.Goruldu = false;
                }
                _context.SaveChanges();
            }
            return RedirectToAction("Iletisim");
        }
        [HttpGet]
        public IActionResult IletisimMesajSil(int id)
        {
            var iletisim = _context.ıletisimForms.Find(id);
            if (iletisim != null)
            {
                _context.ıletisimForms.Remove(iletisim);
                _context.SaveChanges();
            }
            return RedirectToAction("Iletisim");
        }

        public IActionResult Slider()
        {
            var slider = _context.Sliders.ToList();

            return View(slider);
        }

        public IActionResult SliderSİl(int id)
        {
            var slider = _context.Sliders.Find(id);
            if(slider != null)
            {
                _context.Sliders.Remove(slider);
                _context.SaveChanges();
                return RedirectToAction("Slider");
            }
            else
            {
                return RedirectToAction("Slider");
            }
        }
        public IActionResult SliderDuzenle(int id)
        {
            var slider = _context.Sliders.Find(id); 
            if (slider != null)
            {
                return View(slider);
            }
            else
            {
                return RedirectToAction("Slider");
            }
        }

        [HttpPost]
        public IActionResult SliderDuzenle(Slider p)
        {
            if(p != null)
            {
                _context.Entry(p).State = EntityState.Modified; 
                _context.SaveChanges();
            }
            return RedirectToAction("Slider");
        }
        public IActionResult SliderEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SliderEkle(Slider p)
        {
            if(p != null)
            {
                _context.Sliders.Add(p);
                _context.SaveChanges();
            }
            return RedirectToAction("Slider");
        }



        [AllowAnonymous] // Herkes erişebilsin
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous] // Herkes erişebilsin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        }

    }

