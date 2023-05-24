using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Accion 1
        public IActionResult Index()
        {
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
            };
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() {
                new Proyecto
            {
                Titulo = "Amazon",
                Descripcion = "E-Commerce realizado con ASP.NET Core",
                Link = "https://google.com",
                ImagenURL= "/images/amazon.png"
            },
			    new Proyecto
			{
				Titulo = "Steam",
				Descripcion = "Tienda videojuegos",
				Link = "https://google.com",
				ImagenURL= "/images/steam.png"
			},
				new Proyecto
			{
				Titulo = "Reddit",
				Descripcion = "Red social",
				Link = "https://google.com",
				ImagenURL= "/images/reddit.png"
			},
				new Proyecto
			{
				Titulo = "New York Times",
				Descripcion = "Periodico digital",
				Link = "https://google.com",
				ImagenURL= "/images/nyt.png"
			},
			};
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