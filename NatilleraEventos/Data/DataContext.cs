
using Microsoft.EntityFrameworkCore;
using NatilleraEventos.Models;

namespace NatilleraEventos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}
