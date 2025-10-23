using PortfolioTask1.Models.Entities;

namespace PortfolioTask1.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Yeteneklerim> Yetenekler { get; set; } // "Yeteneklerims" yerine
        public List<Projelerim> Projeler { get; set; }     // "Projelerims" yerine
        public List<Ozgecmis> Ozgecmisler { get; set; }    // "Ozgecmis" yerine
        public Genel GenelBilgiler { get; set; }        // "Genels" yerine
        public Hakkimda AboutMe { get; set; }           // "Hakkimda" için ekledik
    }
}

