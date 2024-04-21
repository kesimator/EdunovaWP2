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

		[HttpGet]
		[Route("Zad2")]
		public float Zad2(int i, int j)
		{
			// Ruta vraæa kvocijent dvaju primljenih brojeva
			return (float)i / j;
		}

		[HttpGet]
		[Route("Zad3")]
		public float Zad3(int i, int j)
		{
			// Ruta vraæa zbroj umnoška i kvocijenta primljenih brojeva
			var Umnozak = i * j;	// var je kljuèna rijeè koja preuzima tip podatka s desne strane znaka =
			var Kvocijent = (float)i / j;
			return Umnozak + Kvocijent;
		}

		[HttpGet]
		[Route("Zad4")]
		public string Zad4(string s, string s1)
		{
			// Ruta vraæa spojene primljene znakove
			return s + s1;
		}

		[HttpGet]
		[Route("Zad5")]
		public bool IstiSu(int a, int b)
		{
            Console.WriteLine("a={0}",a);	// Pogledati u konzoli
            // Ruta vraæa True ako je a jednako b, inaèe vraæa False
            return a == b;
		}
	}
}