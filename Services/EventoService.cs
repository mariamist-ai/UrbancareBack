using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Data;
using UrbanCareBack.Models;

namespace UrbanCareBack.Services{
    public class EventoService{
        private readonly UrbanCareDbContext _context;

        public EventoService(UrbanCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> ListarTodosEvento()
        {
            return await _context.Eventos.ToListAsync();
        }

        public async Task<IEnumerable<Evento>> ListarEventosPorOrganizacion(int eventoId)
        {
            return await _context.Eventos
                                .Where(c => c.IdEvento == eventoId)
                                .ToListAsync();
        }

        public async Task<Evento> ObtenerEventoPorId(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                throw new KeyNotFoundException($"No se encontró un evento con el ID {id}");
            }
            return evento;
        }

        public async Task AgregarEvento(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEvento(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
            }
        }
    }
}