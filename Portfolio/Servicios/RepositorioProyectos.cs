using Portfolio.Models;

namespace Portfolio.Servicios
{
	public interface IRepositorioProyectos
	{
		List<Proyecto> ObtenerProyectos();
	}

	public class RepositorioProyectos : IRepositorioProyectos
	{
		public List<Proyecto> ObtenerProyectos()
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
	}
}
