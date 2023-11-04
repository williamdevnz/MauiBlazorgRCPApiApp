using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace MauiBlazorgRCPApiApp.Data
{
    public class PersonaDb
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPersona { get; set; } = 0;
        [StringLength(64, MinimumLength = 3, ErrorMessage = "El nombre debe contener al menos 3 caracteres.")]
        [Required(ErrorMessage = "Requerido")]
        public string Nombres { get; set; }
        [StringLength(64, MinimumLength = 3, ErrorMessage = "El apellido debe contener al menos 3 caracteres.")]
        [Required(ErrorMessage = "Requerido")]
        public string Apellidos { get; set; }

        [EmailAddress(ErrorMessage = "Dirección de correo electrónico no válida")]
        [Required(ErrorMessage = "Requerido")]
        public string Email { get; set; }

        //public List<PersonaDb> Personas { get; set; } = new List<PersonaDb>();
        //Todavia no lo ingreso:
        //public int DepartamentoId { get; set; }
        //public Departamento Departamento { get; set; }

    }
}
