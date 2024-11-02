using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Data;
using UrbanCareBack.Models;

namespace UrbanCareBack.Services{
    public class ColaboradoresService{
        private readonly UrbanCareDbContext _context;

        public ColaboradoresService(UrbanCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Colaborador>> ListarTodosColaboradores()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        public async Task<IEnumerable<Colaborador>> ListarColaboradoresPorOrganizacion(int organizacionId)
        {
            return await _context.Colaboradores
                                .Where(c => c.OrganizacionId == organizacionId)
                                .ToListAsync();
        }
        
        public async Task<Colaborador> ObtenerColaboradorPorId(int id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                throw new KeyNotFoundException($"No se encontró un colaborador con el ID {id}");
            }
            return colaborador;
        }

        public async Task AgregarColaborador(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarColaborador(Colaborador colaborador)
        {
            _context.Colaboradores.Update(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarColaborador(int id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador != null)
            {
                _context.Colaboradores.Remove(colaborador);
                await _context.SaveChangesAsync();
            }
        }
    }
}