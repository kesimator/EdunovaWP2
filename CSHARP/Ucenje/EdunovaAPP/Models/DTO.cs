namespace EdunovaAPP.Models
{
    public record SmjerDTORead(int sifra, string naziv, int trajanje,
        decimal cijena, decimal upisnina, bool verificiran);

    public record SmjerDTOInsertUpdate(string naziv, int trajanje,
        decimal cijena, decimal upisnina, bool verificiran);



    public record PolaznikDTORead(int sifra, string ime, string prezime,
        string email, string oib, string brojugovora);

    public record PolaznikDTOInsertUpdate(string ime, string prezime,
        string email, string oib, string brojugovora);



    public record PredavacDTORead(int sifra, string ime, string prezime,
        string email, string oib, string iban);

    public record PredavacDTOInsertUpdate(string ime, string prezime,
        string email, string oib, string iban);


    /*
     * IDEJA: u ekstenziji MappingGrupa ručno postaviti vrijednosti u record
    public record GrupaDTORead(int sifra, string naziv, string predavac,
        string smjer, int maksimalnopolaznika, DateTime datumpocetka, int brojpolaznika);
    */

    public class GrupaDTORead
    {
        public int? sifra { get; set; }
        public string? naziv { get; set; }
        public string? smjer { get; set; }
        public string? predavac { get; set; }
        public DateTime? datumpocetka { get; set; }
        public int? maksimalnopolaznika { get; set; }
        public int? brojpolaznika { get; set; }
    }

    public record GrupaDTOInsertUpdate(string naziv, int predavac,
        int smjer, int maksimalnopolaznika, DateTime datumpocetka, int brojpolaznika);
}