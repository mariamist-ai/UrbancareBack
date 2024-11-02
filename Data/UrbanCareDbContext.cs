using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Models;

namespace UrbanCareBack.Data
{
    public class UrbanCareDbContext : DbContext
    {
        public UrbanCareDbContext(DbContextOptions<UrbanCareDbContext> options)
            : base(options)
        {
        }

        public required DbSet<Administrador> Administradores { get; set; }
        public required DbSet<Colaborador> Colaboradores { get; set; }
        public required DbSet<Evento> Eventos { get; set; }
        public required DbSet<Insignia> Insignias { get; set; }
        public required DbSet<Organizacion> Organizaciones { get; set; }
        public required DbSet<Participacion> Participaciones { get; set; }
        public required DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>()
                .HasKey(a => a.IdAdministrador);

            modelBuilder.Entity<Colaborador>()
                .HasKey(c => c.IdColaborador);

            modelBuilder.Entity<Evento>()
                .HasKey(e => e.IdEvento);

            modelBuilder.Entity<Insignia>()
                .HasKey(i => i.IdInsignia);

            modelBuilder.Entity<Participacion>()
                .HasKey(p => new { p.EventoId, p.ParticipanteId });

            modelBuilder.Entity<Participante>()
                .HasKey(pa => pa.IdParticipante);

            modelBuilder.Entity<Organizacion>()
                .HasKey(o => o.IdOrganizacion);

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Organizacion)
                .WithMany(o => o.Colaboradores)
                .HasForeignKey(c => c.OrganizacionId);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Organizacion)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizacionId);

            modelBuilder.Entity<Insignia>()
                .HasOne(i => i.Participacion)
                .WithMany(p => p.Insignias)
                .HasForeignKey(i => new { i.EventoId, i.ParticipanteId });

            modelBuilder.Entity<Participacion>()
                .HasOne(p => p.Evento)
                .WithMany(e => e.Participaciones)
                .HasForeignKey(p => p.EventoId);

            modelBuilder.Entity<Participacion>()
                .HasOne(p => p.Participante)
                .WithMany(pa => pa.Participaciones)
                .HasForeignKey(p => p.ParticipanteId);
        }
    }
}
