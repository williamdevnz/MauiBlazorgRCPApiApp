using System.ComponentModel.DataAnnotations;

namespace MauiBlazorgRCPApiApp.Models
{
    public class PersonalInfo
    {
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico no válida")]
        [Required(ErrorMessage = "Requerido")]
        public string Email { get; set; }

        [StringLength(64, MinimumLength = 8, ErrorMessage = "La contraseña debe contener al menos 8 caracteres.")]
        [Required(ErrorMessage = "Requerido")]
        public string Password { get; set; }
    }
}
