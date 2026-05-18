using Application.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class VariacionPorcentualCalculadora : ICalculadoraPrediccion
    {
        public PrediccionResultadoDto Calcular(List<ConsumptionDto> consumos)
        {
            var valores = consumos.Select(c => (double)c.ValorKwh).ToList();
            var variaciones = new List<double> { 0 };

            for (int i = 1; i < valores.Count; i++)
                variaciones.Add(valores[i - 1] == 0 ? double.NaN : ((valores[i] - valores[i - 1]) / valores[i - 1]) * 100);

            var validas = variaciones.Skip(1).Where(v => !double.IsNaN(v)).ToList();
            double prom = validas.Any() ? validas.Average() : 0;
            var tendencia = prom > 1 ? "Aumentando" : prom < -1 ? "Disminuyendo" : "Estable";
            return new PrediccionResultadoDto
            {
                Metodo = "Variación Porcentual",
                Prediccion = prom,
                PromedioVariacion = prom,
                Variaciones = variaciones,
                Tendencia = tendencia
            };
        }
    }
}