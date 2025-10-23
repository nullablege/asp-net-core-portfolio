namespace PortfolioTask1.Models.Entities
{
    public class IletisimForm
    {
        public int IletisimFormId { get; set; }
        public string Isim { get; set; }
        public string Mail { get; set; }
        public string Aciklama { get; set; }
        public string Mesaj { get; set; }
        public bool Goruldu { get; set; } = false;
        public DateTime Tarih { get; set; } = DateTime.Now;

    }
}
