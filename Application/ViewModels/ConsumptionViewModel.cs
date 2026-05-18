using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ConsumptionViewModel
    {
        [Required(ErrorMessage = "Debe ingresar la fecha")]
        public required string Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar el valor de consumo")]
        [Range(0, double.MaxValue, ErrorMessage = "El consumo no puede ser negativo")]
        public required decimal ValorKwh { get; set; }
    }
}
