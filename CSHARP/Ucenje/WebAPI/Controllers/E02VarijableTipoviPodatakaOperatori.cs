using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[ApiController]
	[Route("E02")]
	public class E02VarijableTipoviPodatakaOperatori : ControllerBase
	{
		[HttpGet]
		[Route("Zad1")]
		public int Zad1()
		{
			// Vratite najmanji broj
			return int.MinValue;
		}
	}
}