using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwaggerSqlite.Domain
{
    public class PersonaDb
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPersona { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        //public List<PersonaDb> Personas { get; set; } = new List<PersonaDb>();
        //Todavia no lo ingreso:
        //public int DepartamentoId { get; set; }
        //public Departamento Departamento { get; set; }

    }
}
