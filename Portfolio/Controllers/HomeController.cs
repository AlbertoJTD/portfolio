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
		private readonly IConfiguration configuration;

		// Inyeccion de dependencias
		// ILogger => mostrar mensajes
		public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, IConfiguration configuration)
        {
            _logger = logger;
			this.repositorioProyectos = repositorioProyectos;
			this.configuration = configuration;
		}

        // Accion 1
        public IActionResult Index()
        {
            var test = configuration.GetValue<string>("extraInfo");
            _logger.LogInformation("Este es un mensaje de log" + test);
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos = proyectos };
            return View(modelo);
        }

        // Accion 2
        public IActionResult Privacy()
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