using F1TimoviAPP.Data;
using Microsoft.AspNetCore.Mvc;

namespace F1TimoviAPP.Controllers
{
    /// <summary>
    /// Namijenjeno za CRUD operacije nad entitetom Tim u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1[controller]")]
    public class TimController : ControllerBase
    {
        /// <summary>
        /// Sadržaj za rad s bazom koji će biti postavljen pomoću Dependency-Injection-om
        /// </summary>
        private readonly EdunovaContext _context;
        /// <summary>
        /// Konstruktor klase koja prima Edunova kontekst
        /// pomoću DI principa
        /// </summary>
        /// <param name="context"></param>
        public TimController(EdunovaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dohvaća sve timove iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita
        /// 
        ///     GET api/v1/Tim
        /// </remarks>
        /// <returns>Timovi u bazi</returns>
        /// <response code="200">Sve OK</response>
        /// <response code="400">Zahtjev nije valjan</response>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Timovi.ToList());
        }
    }
}
