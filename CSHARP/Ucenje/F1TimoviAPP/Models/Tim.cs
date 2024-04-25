using System.ComponentModel.DataAnnotations;

namespace F1TimoviAPP.Models
{
    /// <summary>
    /// Ovo mi je POCO koji je mapiran na bazu
    /// </summary>
    public class Tim : Entitet
    {
        /// <summary>
        /// Ime tima u bazi
        /// </summary>
        [Required(ErrorMessage = "Ime tima obavezno!")]
        public string? Ime_tima { get; set; }
        /// <summary>
        /// Država sjedišta tima
        /// </summary>
        //[Required(ErrorMessage = "Država sjedišta obavezno!")]
        public string? Drzava_sjedista { get; set; }
        /// <summary>
        /// Godina osnutka tima
        /// </summary>
        [Range(1900, 2023, ErrorMessage = "Vrijednost {0} mora biti između {1} i {2}")]
        public int? Godina_osnutka { get; set; }
    }
}
