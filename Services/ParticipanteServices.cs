using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Data;
using UrbanCareBack.Models;

namespace UrbanCareBack.Services{
    public class ParticipanteServices{
        private readonly UrbanCareDbContext _context;

        public ParticipanteServices(UrbanCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Participante>> ListarTodosParticipante()
        {
            return await _context.Participantes.ToListAsync();
        }

        public async Task<Participante> ObtenerParticipantePorId(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante == null)
            {
                throw new KeyNotFoundException($"No se encontró un participante con el ID {id}");
            }
            return participante;
        }

        public async Task AgregarParticipante(Participante participante)
        {
            _context.Participantes.Add(participante);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarParticipante(Participante participante)
        {
            _context.Participantes.Update(participante);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarParticipante(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante != null)
            {
                _context.Participantes.Remove(participante);
                await _context.SaveChangesAsync();
            }
        }
    }
}