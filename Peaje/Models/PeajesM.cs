using System.ComponentModel.DataAnnotations;

namespace Peaje.Models
{
    public class PeajesM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del peaje es obligatorio.")]
        [StringLength(6, ErrorMessage = "La placa tiene 6 caracteres.")]
        public string Placa { get; set; }

        
        [StringLength(100, ErrorMessage = "El nombre del peaje tiene más de 100 caracteres.")]
        public string NombrePeaje { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de kilos debe ser un valor positivo.")]
        public int categoriaTarifaId  { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad de kilos debe ser un valor positivo.")]
        public int Valor { get; set; }


        [DataType(DataType.Date)]
        public DateOnly? fechaRegistro { get; set; }

    }
}
