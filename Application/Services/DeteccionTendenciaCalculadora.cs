using Application.Dtos;

namespace Application.Services
{
    public class DeteccionTendenciaCalculadora : ICalculadoraPrediccion
    {
        public PrediccionResultadoDto Calcular(List<ConsumptionDto> consumos)
        {
            var valores = consumos.Select(c => (double)c.ValorKwh).ToList();
            int aumentos = 0, disminuciones = 0, estables = 0;

            for (int i = 1; i < valores.Count; i++)
            {
                if (valores[i] > valores[i - 1]) aumentos++;
                else if (valores[i] < valores[i - 1]) disminuciones++;
                else estables++;
            }

            string tendencia;
            if (aumentos > disminuciones && aumentos > estables) tendencia = "Alcista";
            else if (disminuciones > aumentos && disminuciones > estables) tendencia = "Bajista";
            else if (estables > aumentos && estables > disminuciones) tendencia = "Estable";
            else if (aumentos >= disminuciones) tendencia = "Alcista";
            else tendencia = "Bajista";

            return new PrediccionResultadoDto
            {
                Metodo = "Detección de Tendencia",
                Prediccion = 0,
                Aumentos = aumentos,
                Disminuciones = disminuciones,
                Estables = estables,
                Tendencia = tendencia
            };
        }
    }
}