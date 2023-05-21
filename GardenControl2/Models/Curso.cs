using System.ComponentModel.DataAnnotations;

namespace GardenControl2.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El grado es obligatorio")]
        public int Grado { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public bool Autorizado { get; set; }
        public ICollection<Unidad> Unidades { get; set; }
    }
}
