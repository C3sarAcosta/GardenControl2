using System.ComponentModel.DataAnnotations;

namespace GardenControl2.Models
{
    public class Leccion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int UnidadId { get; set; }
        public Unidad Unidad { get; set; }
        public ICollection<Recurso> Recursos { get; set; }
    }
}
