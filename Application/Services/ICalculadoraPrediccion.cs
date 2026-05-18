using Application.Dtos;


namespace Application.Services
{
    public interface ICalculadoraPrediccion
    {
        PrediccionResultadoDto Calcular(List<ConsumptionDto> consumos);
    }
}