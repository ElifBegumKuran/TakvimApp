using System.ComponentModel.DataAnnotations;

namespace TakvimUygulama.Data
{
    public class Etkinlik1
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık boş olamaz.")]
        public string Başlık { get; set; }

        [Required(ErrorMessage = "Açıklama boş olamaz.")]
        public string Açıklama { get; set; }

        [Required(ErrorMessage = "Tarih boş olamaz.")]
        public DateTime Tarih { get; set; }
    }
}
