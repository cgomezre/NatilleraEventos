
namespace NatilleraEventos.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; } // plain text password as required
    }
}
