using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace SwaggerSqlite.Domain
{
    [Table("Departamentos")]
    public class Departamentos 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdDepto")]
        public int IdDepto { get; set; }
        public string NombreDepto { get; set; }
    }
}
