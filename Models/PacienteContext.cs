using System.Data.Entity; // EF: Librería para Entity Framework

namespace SistemaGestionPacientes.Models
{
    public class PacienteContext : DbContext
    {
        public PacienteContext() : base("DefaultConnection")
        {
        }

        // ← EF: DbSet representa la tabla "Pacientes" en la base de datos
        public DbSet<Paciente> Pacientes { get; set; }
        // Esto permite hacer: db.Pacientes.Add(), db.Pacientes.Findasync(id), db.Pacientes.Remove(), etc.

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Por ahora solo llama al método base
            // Aquí se pueden agregar configuraciones adicionales como:
            // - Claves primarias personalizadas
            // - Relaciones entre tablas
            // - Índices
            // - Restricciones
            base.OnModelCreating(modelBuilder);
        }
    }
}