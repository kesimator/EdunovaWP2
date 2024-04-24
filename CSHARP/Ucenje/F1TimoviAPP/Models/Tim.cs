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
        [Required(ErrorMessage ="Ime tima obavezno!")]
        public string? ime_tima { get; set; }
        public string? drzava_sjedista { get; set; }
        public int godina_osnutka { get; set; }
    }
}
