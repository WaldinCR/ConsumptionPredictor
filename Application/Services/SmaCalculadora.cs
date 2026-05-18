using Application.Dtos;
using System.Collections.Generic;

namespace Application.Services
{
    public class SmaCalculadora : ICalculadoraPrediccion
    {
        public PrediccionResultadoDto Calcular(List<ConsumptionDto> consumos)
        {
            var valores = consumos.Select(c => (double)c.ValorKwh).ToList();
            var promedio = valores.TakeLast(3).Average();
            var tendencia = promedio > valores.Last() ? "Alcista"
                          : promedio < valores.Last() ? "Bajista" : "Estable";
            return new PrediccionResultadoDto
            {
                Metodo = "Promedio Móvil Simple (SMA)",
                Prediccion = promedio,
                Promedio = promedio,
                Tendencia = tendencia
            };
        }
    }
}
