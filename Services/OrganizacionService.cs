using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Data;
using UrbanCareBack.Models;

namespace UrbanCareBack.Services{
    public class OrganizacionService{
        private readonly UrbanCareDbContext _context;

        public OrganizacionService(UrbanCareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Organizacion>> ListarOrganizaciones()
        {
            return await _context.Organizaciones.ToListAsync();
        }

        public async Task<Organizacion> ObtenerOrganizacionPorId(int id)
        {
            var organizacion = await _context.Organizaciones.FindAsync(id);
            if (organizacion == null)
            {
                throw new KeyNotFoundException($"No se encontró una organizacion con el ID {id}");
            }
            return organizacion;
        }

        public async Task AgregarOrganizacion(Organizacion organizacion)
        {
            _context.Organizaciones.Add(organizacion);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarOrganizacion(Organizacion organizacion)
        {
            _context.Organizaciones.Update(organizacion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarOrganizacion(int id)
        {
            var organizacion = await _context.Organizaciones.FindAsync(id);
            if (organizacion != null)
            {
                _context.Organizaciones.Remove(organizacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
