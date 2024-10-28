using System.ComponentModel.DataAnnotations;

namespace NarvaezEsteban_ExamenProgreso1.Models
{
    public class Celular
    {
        [Key] 
        public int IdCelular { get; set; }
        [Required]
        [StringLength(100)]
        public string Modelo { get; set; }
        [MaxLength(10)]
        public int año { get; set; }
        [MinLength(1)]
        public int precio { get; set; }

    }
}
