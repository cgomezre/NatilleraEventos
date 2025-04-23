
using System;

namespace NatilleraEventos.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public decimal TotalIngreso { get; set; }
        public DateTime Fecha { get; set; }
        public string Sede { get; set; }
        public string Actividades { get; set; }
    }
}
