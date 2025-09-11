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


    public static void YeniKullaniciEkle ()
    {
    Console.WriteLine ("Yeni kullanıcı bilgilerini girin:");

    Kullanici yeniKullanici = new Kullanici ();

    Console.WriteLine ("ID: ");
    yeniKullanici.Id = int.Parse (Console.ReadLine ());

    Console.WriteLine ("Kullanıcı Adı: ");
    yeniKullanici.KullaniciAdi = Console.ReadLine ();

    Console.WriteLine ("Ad Soyad: ");
    yeniKullanici.AdSoyad = Console.ReadLine ();

    Console.WriteLine ("Email: ");
    yeniKullanici.Email = Console.ReadLine ();

    Console.WriteLine ("Şifre: ");
    yeniKullanici.Sifre = Console.ReadLine ();

    Console.WriteLine ("Rol: ");
    yeniKullanici.Rol = Console.ReadLine ();

    Console.WriteLine ("Aktif mi? (evet/hayir): ");
    string aktifGiris = Console.ReadLine ().ToLower();

    if(aktifGiris == "evet")
    {
    yeniKullanici.Aktif = true;
    }
    else
    {
    yeniKullanici.Aktif = false;
    }

    Console.WriteLine ("Departman: ");
    yeniKullanici.Departman = Console.ReadLine ();

    Console.WriteLine ("Pozisyon: ");
    yeniKullanici.Pozisyon = Console.ReadLine ();

    yeniKullanici.KayitTarihi = DateTime.Now;
    yeniKullanici.SonGirisZamani = DateTime.Now;

    //Json dosyasini oku
    string okunanVeri = File.ReadAllText("kullanicilar.json");
    List<Kullanici> kullanicilar = new List<Kullanici> ();
    kullanicilar = JsonSerializer.Deserialize<List<Kullanici>> (okunanVeri);

    //yeni kullaniciyi listeye ekle
    kullanicilar.Add (yeniKullanici);

    //Listeyi json a cevir
    string donusenVeri = JsonSerializer.Serialize(kullanicilar, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText ("kullanicilar.json", donusenVeri);

    Console.WriteLine ("Yeni kullanıcı başarıyla eklendi.");
    }



    public static void KullaniciSil()
    {

    }
}