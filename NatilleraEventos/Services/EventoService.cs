
using Microsoft.EntityFrameworkCore;
using NatilleraEventos.Data;
using NatilleraEventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatilleraEventos.Services
{
    public class EventoService : IEventoService
    {
        private readonly DataContext _context;

        public EventoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetEventos(string tipo, string nombre, string fecha)
        {
            var query = _context.Eventos.AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(e => e.Tipo.Contains(tipo));
            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(e => e.Nombre.Contains(nombre));
            if (!string.IsNullOrEmpty(fecha) && DateTime.TryParse(fecha, out var f))
                query = query.Where(e => e.Fecha.Date == f.Date);

            return await query.ToListAsync();
        }

        public async Task<Evento> CreateEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<Evento> UpdateEvento(int id, Evento updated)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return null;

            evento.Tipo = updated.Tipo;
            evento.Nombre = updated.Nombre;
            evento.TotalIngreso = updated.TotalIngreso;
            evento.Fecha = updated.Fecha;
            evento.Sede = updated.Sede;
            evento.Actividades = updated.Actividades;

            await _context.SaveChangesAsync();
            return evento;
        }

        public async Task<bool> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return false;
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
