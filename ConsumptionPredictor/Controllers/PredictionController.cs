using Application.Dtos;
using Application.Enums;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsumptionPredictor.Controllers
{
    public class PrediccionController : Controller
    {
        private readonly PredictionOrchestratorService _orquestador;

        public PrediccionController(PredictionOrchestratorService orquestador)
        {
            _orquestador = orquestador;
        }

        // GET: /Prediccion/Inicio
        public IActionResult Inicio()
        {
            return View("~/Views/Prediction/Home.cshtml");
        }

        // GET: /Prediccion/Modos
        public IActionResult Modos()
        {
            var vm = new ModoViewModel(); // Carga el modo según tu lógica si es requerido
            return View("~/Views/Prediction/Modes.cshtml", vm);
        }

        // POST: /Prediccion/GuardarModo
        [HttpPost]
        public IActionResult GuardarModo(ModoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes guardar el modo usando tus servicios/repo si lo necesitas
                TempData["Mensaje"] = "Modo de predicción guardado correctamente.";
                TempData["TipoMensaje"] = "alert-success";
            }
            return RedirectToAction("Inicio");
        }

        // POST: /Prediccion/Calcular
        [HttpPost]
        public IActionResult Calcular(NuevaPrediccionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Mensaje"] = "Por favor corrija los errores del formulario.";
                TempData["TipoMensaje"] = "alert-danger";
                return RedirectToAction("Inicio");
            }

            // Map ViewModel to DTOs ("Consumos" debe venir del formulario)
            var consumos = vm.Consumos.Select(c => new ConsumptionDto
            {
                Fecha = DateTime.Parse(c.Fecha),       // ¡Ahora la propiedad Fecha del DTO sí se usa!
                ValorKwh = c.ValorKwh
            }).ToList();

            // Cálculo de predicción usando el orquestador
            var resultado = _orquestador.Calcular((ModoPrediccion)vm.Modo, consumos);

            // Puedes mapearlo a un PredictionViewModel si lo necesitas
            var modeloVista = new PredictionViewModel
            {
                Metodo = resultado.Metodo,
                Prediccion = resultado.Prediccion,
                Tendencia = resultado.Tendencia,
                Promedio = resultado.Promedio,
                Pendiente = resultado.Pendiente,
                PromedioVariacion = resultado.PromedioVariacion,
                Variaciones = resultado.Variaciones,
                Aumentos = resultado.Aumentos,
                Disminuciones = resultado.Disminuciones,
                Estables = resultado.Estables
            };

            return View("~/Views/Prediction/Result.cshtml", modeloVista);
        }
    }
}