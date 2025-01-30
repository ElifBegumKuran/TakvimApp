using Microsoft.EntityFrameworkCore;

namespace TakvimUygulama.Data
{
    public class UygulamaContext : DbContext
    {
        // Constructor ekleniyor ve DI ile çalışabilmesi için DbContextOptions alınıyor
        public UygulamaContext(DbContextOptions<UygulamaContext> options)
            : base(options)
        {
        }

        // Etkinlikler tablosunu temsil eden DbSet
        public DbSet<Etkinlik> Etkinlikler { get; set; }
    }

    // Etkinlik modelini oluşturuyoruz.
    public class Etkinlik
    {
        public int Id { get; set; }
        public string? Başlık { get; set; }  // Başlık null olabilecek şekilde
        public string? Açıklama { get; set; }  // Açıklama null olabilecek şekilde
        public DateTime Tarih { get; set; }
    }
}
