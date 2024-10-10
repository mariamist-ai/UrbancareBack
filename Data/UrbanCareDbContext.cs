using Microsoft.EntityFrameworkCore;
using UrbanCareBack.Models;

namespace UrbanCareBack.Data
{
    public class UrbanCareDbContext : DbContext
    {
        public UrbanCareDbContext(DbContextOptions<UrbanCareDbContext> options)
            : base(options) // Llama al constructor base con las opciones
        {
        }

        public required DbSet<Administrador> Administradores { get; set; }
        public required DbSet<Colaborador> Colaboradores { get; set; }
        public required DbSet<Evento> Eventos { get; set; }
        public required DbSet<Insignia> Insignias { get; set; }
        public required DbSet<LogEvento> LogEventos { get; set; }
        public required DbSet<Organizacion> Organizaciones { get; set; }
        public required DbSet<Participacion> Participaciones { get; set; }
        public required DbSet<Participante> Participantes { get; set; }
        public required DbSet<TipoDoc> TiposDoc { get; set; }
        public required DbSet<TipoEvento> TiposEvento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves primarias
            modelBuilder.Entity<Administrador>()
                .HasKey(a => a.IdAdministrador);

            modelBuilder.Entity<Colaborador>()
                .HasKey(c => c.IdColaborador);

            modelBuilder.Entity<Evento>()
                .HasKey(e => e.IdEvento);

            modelBuilder.Entity<Insignia>()
                .HasKey(i => i.IdInsignia);

            modelBuilder.Entity<LogEvento>()
                .HasKey(le => le.IdLogEvento);

            modelBuilder.Entity<Organizacion>()
                .HasKey(o => o.IdOrganizacion);

            modelBuilder.Entity<Participacion>()
                .HasKey(p => new { p.EventoId, p.ParticipanteId });

            modelBuilder.Entity<Participante>()
                .HasKey(pa => pa.IdParticipante);

            modelBuilder.Entity<TipoDoc>()
                .HasKey(td => td.IdTipoDoc);

            modelBuilder.Entity<TipoEvento>()
                .HasKey(te => te.IdTipoEvento);

            // Configuración de claves foráneas
            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Organizacion)
                .WithMany(o => o.Colaboradores)
                .HasForeignKey(c => c.OrganizacionId);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.TipoEvento)
                .WithMany(te => te.Eventos)
                .HasForeignKey(e => e.TipoEventoId);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Organizacion)
                .WithMany(o => o.Eventos)
                .HasForeignKey(e => e.OrganizacionId);

            modelBuilder.Entity<Evento>()
                .HasOne(e => e.LogEvento)
                .WithMany(le => le.Eventos)
                .HasForeignKey(e => e.LogEventoId);

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

            modelBuilder.Entity<Participante>()
                .HasOne(p => p.TipoDoc)
                .WithMany()
                .HasForeignKey(p => p.TipoDocId);
        }
    }
}
