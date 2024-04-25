using F1TimoviAPP.Data;
using F1TimoviAPP.Models;
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
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response>
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

        /// <summary>
        /// Dohvaća tim sa šifrom
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            // Kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var tim = _context.Timovi.Find(id);
                if (tim == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(tim);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Dodaje novi tim u bazu
        /// </summary>
        /// <remarks>
        ///     POST api/v1/Tim
        ///     {naziv: "Primjer naziva"}
        /// </remarks>
        /// <param name="tim">Tim za unijeti u JSON formatu</param>
        /// <returns>Tim sa šifrom koju je dala baza</returns>
        /// <response code="201">Kreirano</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response>
        /// <response code="503">Baza nedostupna iz nekog razloga</response>
        [HttpPost]
        public IActionResult Post(Tim tim)
        {
            if (!ModelState.IsValid || tim == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Timovi.Add(tim);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, tim);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Mijenja podatke postojećeg tima u bazi
        /// </summary>
        /// <param name="id">Šifra smjera koji se mijenja</param>
        /// <param name="tim">Tim za unijeti u JSON formatu</param>
        /// <returns>Svi poslani podaci od tima koji su spremljeni u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi nema tima kojeg želimo promijeniti</response>
        /// <response code="415">Nije poslan JSON</response>
        /// <response code="503">Baza nedostupna iz nekog razloga</response>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put(int id, Tim tim)
        {
            if (id <= 0 || !ModelState.IsValid || tim == null)
            {
                return BadRequest();
            }

            try
            {
                var timIzBaze = _context.Timovi.Find(id);

                if (timIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, id);
                }
                // Inače ovo rade mapperi
                // Za sada ručno
                timIzBaze.Ime_tima = tim.Ime_tima;
                timIzBaze.Drzava_sjedista = tim.Drzava_sjedista;
                timIzBaze.Godina_osnutka = tim.Godina_osnutka;

                _context.Timovi.Update(timIzBaze);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, timIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Briše tim iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///     DELETE api/v1/tim/1
        ///     
        /// </remarks>
        /// <param name="id">Šifra smjera koji se briše</param>
        /// <returns>Odgovori je li obrisano ili ne</returns>
        /// <response code="200">Sve je u redu, obrisano je u bazi</response>
        /// <response code="204">U bazi nema tima kojeg želimo promijeniti</response>
        /// <response code="503">Problem s bazom</response>
        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            try
            {
                var timIzBaze = _context.Timovi.Find(id);

                if (timIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, id);
                }

                _context.Timovi.Remove(timIzBaze);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\": \"Obrisano\"}");    // Ovo nije baš najbolja praksa, ali se i to može
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }
    }
}
