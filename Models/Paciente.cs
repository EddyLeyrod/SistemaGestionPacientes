using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPacientes.Models
{
    // Representa a un paciente en el sistema de gestión de pacientes
    public class Paciente
    {
        // Identificador único del paciente
        public int Id { get; set; }

        // Nombre del paciente (obligatorio, máximo 50 caracteres)
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
        public string Nombre { get; set; }

        // Apellido del paciente (obligatorio, máximo 50 caracteres)
        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder 50 caracteres")]
        public string Apellido { get; set; }

        // Teléfono de contacto (opcional, máximo 15 caracteres)
        [StringLength(15, ErrorMessage = "El teléfono no puede exceder 15 caracteres")]
        public string Telefono { get; set; }

        // Correo electrónico del paciente (opcional, formato válido)
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        // Fecha de nacimiento del paciente (obligatorio)
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }

        // Tipo de sangre del paciente (opcional, máximo 5 caracteres)
        [StringLength(5, ErrorMessage = "El tipo de sangre no puede exceder 5 caracteres")]
        public string TipoSangre { get; set; }

        // Fecha en que se registró el paciente en el sistema
        public DateTime FechaRegistro { get; set; }

        // Indica si el paciente está activo en el sistema
        public bool Activo { get; set; }

        // Constructor: inicializa la fecha de registro y marca al paciente como activo
        public Paciente()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
        }
    }
}