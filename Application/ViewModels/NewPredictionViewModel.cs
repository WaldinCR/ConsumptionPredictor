using Application.ViewModels;
using System.ComponentModel.DataAnnotations;

public class NuevaPrediccionViewModel
{
    [Required(ErrorMessage = "Debe seleccionar un modo de predicción")]
    public int Modo { get; set; }

    [Required(ErrorMessage = "Debe ingresar los 12 consumos")]
    [MinLength(12, ErrorMessage = "Se requieren exactamente 12 consumos")]
    public List<ConsumptionViewModel> Consumos { get; set; } = new();
}