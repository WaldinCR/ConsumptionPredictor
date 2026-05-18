using Application.Enums;

namespace Application.Repositories
{
    // Singleton para persistencia en memoria del modo seleccionado
    public sealed class RepositorioPrediccion
    {
        private RepositorioPrediccion() { }

        public static RepositorioPrediccion Instancia { get; } = new();

        public ModoPrediccion ModoActual { get; set; } = ModoPrediccion.PROMEDIO_MOVIL_SIMPLE;
    }
}
