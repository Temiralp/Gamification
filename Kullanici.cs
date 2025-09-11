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

    public static void JsonaYaz()
        {
        //Listeyi json a cevir
        List<Kullanici> kullanicilar = new List<Kullanici>();
        string donusenVeri = JsonSerializer.Serialize(kullanicilar, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("kullanicilar.json", donusenVeri);
        }

    public static void JsonOku()
        {
        //Json dosyasini oku
        string okunanVeri = File.ReadAllText("kullanicilar.json");
        List<Kullanici> kullanicilar = new List<Kullanici>();
        kullanicilar = JsonSerializer.Deserialize<List<Kullanici>>(okunanVeri);
        }

    public static void Login()
        {
        int denemeHakki = 5;
        bool girisBasarili = false;

        // JSON'u oku (dosya yoksa boş liste oluştur)
        List<Kullanici> kullanicilar;
        if(File.Exists("kullanicilar.json"))
            {
            string okunanVeri = File.ReadAllText("kullanicilar.json");
            if(string.IsNullOrWhiteSpace(okunanVeri))
                {
                kullanicilar = new List<Kullanici>();
                }
            else
                {
                kullanicilar = JsonSerializer.Deserialize<List<Kullanici>>(okunanVeri);
                }
            }
        else
            {
            kullanicilar = new List<Kullanici>();
            }

        while(denemeHakki > 0 && girisBasarili == false)
            {
            Console.WriteLine("Kullanici Adi: ");
            string girilenKullaniciAdi = Console.ReadLine();

            Console.WriteLine("Sifre: ");
            string girilenSifre = Console.ReadLine();

            //eslesme ara
            int bulunanIndex = -1;
            for(int i = 0; i < kullanicilar.Count; i++)
                {
                if(kullanicilar[i].KullaniciAdi == girilenKullaniciAdi && kullanicilar[i].Sifre == girilenSifre)
                    {
                    bulunanIndex = i;
                    break;
                    }
                }

            if(bulunanIndex != -1)
                {
                girisBasarili = true;

                Console.WriteLine("Giriş başarılı. Hoş geldiniz, " + kullanicilar[bulunanIndex].AdSoyad + "!");

                //son giris zamani guncellemesi
                kullanicilar[bulunanIndex].SonGirisZamani = DateTime.Now;

                JsonaYaz();
                }
            else
                {
                denemeHakki = denemeHakki - 1;
                if(denemeHakki > 0)
                    {
                    Console.WriteLine("Yanlış kullanıcı adı ve/veya şifre. Lütfen tekrar deneyin. Kalan deneme: " + denemeHakki);
                    }
                else
                    {
                    Console.WriteLine("Yanlış bilgiler 5 kez girildi. Giriş başarısız.");
                    }
                }
            }

        }



    public static void KullaniciSil()
    {
        Console.WriteLine("Lütfen silmek istediğiniz kullanıcının ID'sini girin: ");
        int silinecekId = int.Parse(Console.ReadLine());

        string okunanVeri = File.ReadAllText("kullanicilar.json");

        List<Kullanici> kullanicilar = JsonSerializer.Deserialize<List<Kullanici>>(okunanVeri);

        if(kullanicilar == null)
            {
            kullanicilar = new List<Kullanici>();
            }
        Console.WriteLine("Kullanıcı sayısı (önce): " + kullanicilar.Count);

        int silinecekIndex = -1;

        for(int i = 0; i < kullanicilar.Count; i++)
            {
            if(kullanicilar[i].Id == silinecekId)
                {
                silinecekIndex = i;
                break;
                }

            }

        if(silinecekIndex != -1)
            {
            // Kullanıcı bilgilerini göster
            Kullanici kisi = kullanicilar[silinecekIndex];
            Console.WriteLine("Silinecek Kullanıcı Bilgileri:");
            Console.WriteLine("ID: " + kisi.Id);
            Console.WriteLine("Ad Soyad: " + kisi.AdSoyad);
            Console.WriteLine("Email: " + kisi.Email);
            Console.WriteLine("Pozisyon: " + kisi.Pozisyon);
            Console.WriteLine("Departman: " + kisi.Departman);
            Console.WriteLine("Rol: " + kisi.Rol);


            // onay icin
            Console.Write("Bu kişiyi silmek istediğinizden emin misiniz? (evet/hayir): ");
            string onay = Console.ReadLine().ToLower();

            if(onay == "evet")
                {
                kullanicilar.RemoveAt(silinecekIndex);

                var options = new JsonSerializerOptions
                    {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };

                //jsona cevir ve dosyaya yaz(UTF-8 ile)
                string donusenVeri = JsonSerializer.Serialize(kullanicilar, options);

                File.WriteAllText("kullanicilar.json", donusenVeri, System.Text.Encoding.UTF8);

                Console.WriteLine("Kullanıcı başarıyla silindi.");

                }

            else
                {
                Console.WriteLine("Silme işlemi iptal edildi.");
                }
            }
        else
            {
            Console.WriteLine("Belirtilen ID ile kullanıcı bulunamadı.");
            }

        }
    }