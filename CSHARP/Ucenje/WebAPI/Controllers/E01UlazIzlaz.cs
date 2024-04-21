using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("E01")]
    public class E01UlazIzlaz : ControllerBase
    {
        [HttpGet]
        [Route("Hello")]
        public string HelloWorld(string Ime, int Godine, bool Aktivan) 
        {
            return "Upisali ste " + Ime + ", koji ima " + Godine + " godina" + Aktivan;
        }
    }
}
