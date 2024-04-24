using System.ComponentModel.DataAnnotations;

namespace F1TimoviAPP.Models
{
    /// <summary>
    /// Ovo je vršna nadklasa koja služi za osnovne atribute
    /// tipa id, ime_tima, drzava_sjedista, godina_osnutka
    /// </summary>
    public abstract class Entitet
    {
        /// <summary>
        /// Ovo svojstvo mi služi kao primarni ključ u bazi
        /// s generiranjem vrijednosti identity(1,1)
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
