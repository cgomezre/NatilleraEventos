
using NatilleraEventos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NatilleraEventos.Services
{
    public interface IEventoService
    {
        Task<IEnumerable<Evento>> GetEventos(string tipo, string nombre, string fecha);
        Task<Evento> CreateEvento(Evento evento);
        Task<Evento> UpdateEvento(int id, Evento evento);
        Task<bool> DeleteEvento(int id);
    }
}
