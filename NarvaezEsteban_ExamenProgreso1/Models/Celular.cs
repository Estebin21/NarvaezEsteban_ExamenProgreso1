using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NarvaezEsteban_ExamenProgreso1.Models
{
    public class Celular
    {
        [Key] 
        public int IdCelular { get; set; }
        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }
        [Range (1980, 2025)]
        public int año { get; set; }
        [AllowNull]
        public int precio { get; set; }

    }
}
