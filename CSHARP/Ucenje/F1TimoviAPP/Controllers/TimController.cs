using F1TimoviAPP.Data;
using Microsoft.AspNetCore.Mvc;

namespace F1TimoviAPP.Controllers
{
    /// <summary>
    /// Namijenjeno za CRUD operacije nad entitetom Tim u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
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
        ///     
        /// </remarks>
        /// <returns>Timovi u bazi</returns>
        /// <response code="200">Sve OK, ako nema podataka - content-length: 0</response>
        /// <response code="400">Zahtjev nije valjan</response>
        /// <response code="503">Baza na koju se spajam nije dostupna</response>
        [HttpGet]
        public IActionResult Get()
        {
            // Kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var timovi = _context.Timovi.ToList();
                if (timovi == null || timovi.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(timovi);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
    }
}
