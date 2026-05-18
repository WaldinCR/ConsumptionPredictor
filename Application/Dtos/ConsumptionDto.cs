namespace Application.Dtos
{
    public class ConsumptionDto
    {
        public required DateTime Fecha { get; set; }
        public required decimal ValorKwh { get; set; }
    }
}
