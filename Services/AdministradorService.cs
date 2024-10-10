using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Data;
using UrbanCareBack.Models;

namespace UrbanCareBack.Services{
    public class AdministradorService{
        private readonly UrbanCareDbContext _context;

        public AdministradorService(UrbanCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Administrador>> ListarTodosAdmin()
        {
            return await _context.Administradores.ToListAsync();
        }

        public async Task<Administrador> ObtenerAdministradorPorId(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                throw new KeyNotFoundException($"No se encontró un administrador con el ID {id}");
            }
            return administrador;
        }

        public async Task AgregarAdministrador(Administrador administrador)
        {
            _context.Administradores.Add(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAdministrador(Administrador administrador)
        {
            _context.Administradores.Update(administrador);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAdministrador(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador != null)
            {
                _context.Administradores.Remove(administrador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
