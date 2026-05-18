using Application.Dtos;
using Application.Enums;

namespace Application.Services
{
    public class PredictionOrchestratorService
    {
        private readonly IDictionary<ModoPrediccion, ICalculadoraPrediccion> _calculadoras;

        public PredictionOrchestratorService(
            SmaCalculadora sma,
            RegresionLinealCalculadora reg,
            VariacionPorcentualCalculadora var,
            DeteccionTendenciaCalculadora tendencia)
        {
            _calculadoras = new Dictionary<ModoPrediccion, ICalculadoraPrediccion>
            {
                { ModoPrediccion.PROMEDIO_MOVIL_SIMPLE, sma },
                { ModoPrediccion.REGRESION_LINEAL, reg },
                { ModoPrediccion.VARIACION_PORCENTUAL, var },
                { ModoPrediccion.DETECCION_TENDENCIA, tendencia }
            };
        }

        public PrediccionResultadoDto Calcular(ModoPrediccion modo, List<ConsumptionDto> consumos)
        {
            if (_calculadoras.TryGetValue(modo, out var calculadora))
                return calculadora.Calcular(consumos);

            throw new NotSupportedException("Modo de predicción no soportado.");
        }
    }
}