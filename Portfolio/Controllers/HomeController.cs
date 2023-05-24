using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Servicios;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IRepositorioProyectos repositorioProyectos;

		// Inyeccion de dependencias
		// ILogger => mostrar mensajes
		public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos)
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
		}

        // Accion 1
        public IActionResult Index()
        {
            _logger.LogInformation("Este es un mensaje de log");
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        // Accion 2
        public IActionResult Proyectos()
        {
			var proyectos = repositorioProyectos.ObtenerProyectos();
			return View(proyectos);
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost] // Atributo
		public IActionResult Contacto(ContactoViewModel contacto)
		{

			return RedirectToAction("Gracias");
		}

        public IActionResult Gracias()
        {
            return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}