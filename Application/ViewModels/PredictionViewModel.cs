namespace Application.ViewModels
{
    public class PredictionViewModel
    {
        public string Metodo { get; set; } = string.Empty;
        public double Prediccion { get; set; }
        public string Tendencia { get; set; } = string.Empty;

        // SMA
        public double Promedio { get; set; }

        // Regresion lineal
        public double Pendiente { get; set; }

        // Variacion porcentual
        public double PromedioVariacion { get; set; }
        public List<double> Variaciones { get; set; } = new();

        // Deteccion tendencia
        public int Aumentos { get; set; }
        public int Disminuciones { get; set; }
        public int Estables { get; set; }
    }
}
