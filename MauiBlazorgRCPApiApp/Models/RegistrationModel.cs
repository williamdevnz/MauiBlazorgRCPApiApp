using System.ComponentModel.DataAnnotations;

namespace MauiBlazorgRCPApiApp.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        
        public int PhoneNumber { get; set; }
    }
}
