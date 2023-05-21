using GardenControl2.Models;
using Microsoft.EntityFrameworkCore;

namespace GardenControl2.Data
{
    public class DbContextGardenControl2 : DbContext
    {
        public DbContextGardenControl2(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Curso>()
            .HasMany(c => c.Unidades)
            .WithOne(u => u.Curso)
            .HasForeignKey(u => u.CursoId);
            modelBuilder.Entity<Unidad>()
            .HasMany(u => u.Lecciones)
            .WithOne(l => l.Unidad)
            .HasForeignKey(l => l.UnidadId);
            modelBuilder.Entity<Leccion>()
            .HasMany(l => l.Recursos)
            .WithOne(r => r.Leccion)
            .HasForeignKey(r => r.LeccionId);

        }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<Leccion> Lecciones { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
    }
}
