using Application.Dtos;

namespace Application.Services
{
    public class RegresionLinealCalculadora : ICalculadoraPrediccion
    {
        public PrediccionResultadoDto Calcular(List<ConsumptionDto> consumos)
        {
            var valores = consumos.Select(c => (double)c.ValorKwh).ToList();
            int n = valores.Count;
            double sumX = n * (n + 1) / 2.0, sumX2 = n * (n + 1) * (2 * n + 1) / 6.0;
            double sumY = valores.Sum(), sumXY = valores.Select((v, i) => v * (i + 1)).Sum();

            double m = (sumXY - (sumX * sumY / n)) / (sumX2 - (sumX * sumX / n));
            double pred = m * (n + 1) + (sumY / n - m * sumX / n);
            var tendencia = m > 0 ? "Alcista" : m < 0 ? "Bajista" : "Estable";
            return new PrediccionResultadoDto
            {
                Metodo = "Regresión Lineal",
                Prediccion = pred,
                Pendiente = m,
                Tendencia = tendencia
            };
        }
    }
}