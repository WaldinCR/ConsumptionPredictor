using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ModoViewModel
    {
        [Range(1, 4, ErrorMessage = "Seleccione un modo válido")]
        public int ModoSeleccionado { get; set; } = 1;
    }
}
