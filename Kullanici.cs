public class Kullanici
{
    public int Id { get; set; }
    public string KullaniciAdi { get; set; }
    public string AdSoyad {  get; set; }
    public string Email { get; set; }
    public string Rol {  get; set; }
    public string Sifre {  get; set; }

    public bool Aktif { get; set; }
    public DateTime KayitTarihi { get; set; } = DateTime.Now;
    public DateTime SonGirisZamani { get; set; }
    public string Departman {  get; set; }
    public string Pozisyon { get; set; }


    public static void KullaniciSil()
    {

    }
}