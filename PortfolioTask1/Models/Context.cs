using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioTask1.Models.Entities;

namespace PortfolioTask1.Models
{
    public class Context:IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Genel> Genels { get; set; }
        public DbSet<Hakkimda> Hakkimdas { get; set; }
        public DbSet<IletisimForm> ıletisimForms { get; set; }
        public DbSet<Ozgecmis> Ozgecmiss  { get; set; }
        public DbSet<Projelerim> Projelerims { get; set; }
        public DbSet<Yeteneklerim> Yeteneklerims { get; set; }
        public DbSet<Slider> Sliders { get; set; }


    }
}
