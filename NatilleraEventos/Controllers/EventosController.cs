
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatilleraEventos.Data;
using NatilleraEventos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatilleraEventos.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;

        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> Get(string? tipo, string? nombre, string? fecha)
        {
            var query = _context.Eventos.AsQueryable();
            if (!string.IsNullOrEmpty(tipo)) query = query.Where(e => e.Tipo.Contains(tipo));
            if (!string.IsNullOrEmpty(nombre)) query = query.Where(e => e.Nombre.Contains(nombre));
            if (!string.IsNullOrEmpty(fecha) && System.DateTime.TryParse(fecha, out var f))
                query = query.Where(e => e.Fecha.Date == f.Date);
            return await query.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Evento updated)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return NotFound();

            evento.Tipo = updated.Tipo;
            evento.Nombre = updated.Nombre;
            evento.TotalIngreso = updated.TotalIngreso;
            evento.Fecha = updated.Fecha;
            evento.Sede = updated.Sede;
            evento.Actividades = updated.Actividades;

            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null) return NotFound();
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
