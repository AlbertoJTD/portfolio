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
		private readonly ServicioDelimitado servicioDelimitado;
		private readonly ServicioTransitorio servicioTransitorio;
		private readonly ServicioUnico servicioUnico;

		// Inyeccion de dependencias
		public HomeController(ILogger<HomeController> logger, IRepositorioProyectos repositorioProyectos, ServicioDelimitado servicioDelimitado, ServicioTransitorio servicioTransitorio, ServicioUnico servicioUnico)
        {
            _logger = logger;
			this.repositorioProyectos = repositorioProyectos;
			this.servicioDelimitado = servicioDelimitado;
			this.servicioTransitorio = servicioTransitorio;
			this.servicioUnico = servicioUnico;
		}

        // Accion 1
        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();

            var guidViewModel = new EjemploGUIDViewModel()
            {
                Delimitado = servicioDelimitado.ObtenerGuid,
                Transitorio = servicioTransitorio.ObtenerGuid,
                Unico = servicioUnico.ObtenerGuid,
            };

            var modelo = new HomeIndexViewModel() { Proyectos = proyectos, EjemploGUID_1 = guidViewModel};
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