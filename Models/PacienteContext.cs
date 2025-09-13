using System.Data.Entity;

namespace SistemaGestionPacientes.Models
{
    public class PacienteContext : DbContext
    {
        public PacienteContext() : base("DefaultConnection")
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}