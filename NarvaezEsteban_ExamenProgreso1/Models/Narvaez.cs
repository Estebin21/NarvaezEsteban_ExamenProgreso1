using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NarvaezEsteban_ExamenProgreso1.Models
{
    public class Narvaez
    {
        [Key]
        public string Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MinLength(2)]
        public int Edad {  get; set; }
        public float Altura { get; set; }
        public bool Nacionalidad { get; set; }
        [Required]
        public DateOnly Fechanacimiento { get; set; }
        [ForeignKey("Celular")]
        public int IdCelular { get; set; }
        public Celular? Celular { get; set; }

    }
}
