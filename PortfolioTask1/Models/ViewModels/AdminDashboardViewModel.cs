using PortfolioTask1.Models.Entities;

namespace PortfolioTask1.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int projeSayisi { get; set; }
        public int yetenekSayisi { get; set; }
        public int okunmamisMesajSayisi { get; set; }
        public int sliderSayisi { get; set; }
        public List<IletisimForm> sonMesajlar { get; set; }
        public List<Projelerim> sonProjeler { get; set; }

    }
}
