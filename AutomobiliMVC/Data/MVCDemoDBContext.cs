using AutomobiliMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutomobiliMVC.Data
{
    public class MVCDemoDBContext : DbContext
    {
        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<Automobil> Automobili { get; set; }
    }
}
