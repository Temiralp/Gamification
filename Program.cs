using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


public class Kullanici
{
    public string AdSoyad { get; set; }
    public int TamamlananGorevSayisi { get; set; }
    public int AktifGorevSayisi { get; set; }
    public int Id { get; set; }
    public string KullaniciAdi { get; set; }
    public string Email { get; set; }
    public string Rol { get; set; }
    public string Sifre { get; set; }
    public bool Aktif { get; set; }
    public DateTime KayitTarihi { get; set; } = DateTime.Now;
    public DateTime SonGirisZamani { get; set; }
    public string Departman { get; set; }
    public string Pozisyon { get; set; }
}

public class Gorev
{
    public int Id { get; set; }
    public string GorevAdi { get; set; }
    public string Aciklama { get; set; }
    public string Kategori { get; set; }
    public string Zorluk { get; set; }
    public int DeneyimPuani { get; set; }
    public int AtananCalisanId { get; set; }
}

public class Calisan : Kullanici
{
    public int ToplamDeneyim { get; set; }
    public int MevcutSeviye { get; set; }
    public int YoneticiId { get; set; }
    public List<int> Rozet { get; set; }
}


public class JsonVeriIsleyici
{
    public static List<Kullanici> KullanicilariYukle(string dosyaYolu)
    {
       
        string jsonMetni = File.ReadAllText(dosyaYolu);
        List<Kullanici> kullanicilar = JsonSerializer.Deserialize<List<Kullanici>>(jsonMetni);
        return kullanicilar;
    }

    public static List<Calisan> CalisanlariYukle(string dosyaYolu)
    {

        string jsonMetni = File.ReadAllText(dosyaYolu);
        List<Calisan> calisanlar = JsonSerializer.Deserialize<List<Calisan>>(jsonMetni);
        return calisanlar;
    }
}


{
  



public class GorevIstatistikleri
{
    public static void RaporuGoster(Kullanici kullanici)
    {
        Console.WriteLine($" {kullanici.AdSoyad} - Görev İstatistikleri ");
        Console.WriteLine($"Toplam Tamamlanan Görev Sayısı: {kullanici.TamamlananGorevSayisi}");
        Console.WriteLine($"Toplam Aktif Görev Sayısı: {kullanici.AktifGorevSayisi}");
        Console.WriteLine("-----------------------------");
    }
}

public class RaporIstatistikleri
{
    public static void RaporuGoster(Calisan calisan)
    {
        Console.WriteLine($" {calisan.AdSoyad} - Görev İstatistikleri ");
        Console.WriteLine($"Toplam Tamamlanan Görev Sayısı: {calisan.TamamlananGorevSayisi}");
        Console.WriteLine($"Toplam Aktif Görev Sayısı: {calisan.AktifGorevSayisi}");
        Console.WriteLine($"Toplam Deneyim Puani: {calisan.ToplamDeneyim}");
        Console.WriteLine($"Mevcut Seviye: {calisan.MevcutSeviye}");
        Console.WriteLine("-----------------------------");
    }
}


class Program
{
    
    static void IstatistikleriGoster()
    {
        string dosyaYolu = "kullanicilar.json";
        List<Kullanici> tumKullanicilar = JsonVeriIsleyici.KullanicilariYukle(dosyaYolu);

        if (tumKullanicilar.Any())
        {
            Console.Write("Lütfen adınızı ve soyadınızı girin: ");
            string girisYapacakKullaniciAdi = Console.ReadLine();

            Kullanici aktifKullanici = tumKullanicilar.FirstOrDefault(k => k.AdSoyad.ToLower() == girisYapacakKullaniciAdi.ToLower());

            if (aktifKullanici != null)
            {
                GorevIstatistikleri.RaporuGoster(aktifKullanici);
            }
            else
            {
                Console.WriteLine("Kullanıcı bulunamadı. Lütfen tekrar bir isim girin.");
            }
        }
        else
        {
            Console.WriteLine("Program sonlandırılıyor.");
        }

        Console.ReadLine();
    }

    static void DeneyimRaporuGoster()
    {
        string dosyaYolu = "calisanlar.json"; 
        List<Calisan> tumCalisanlar = JsonVeriIsleyici.CalisanlariYukle(dosyaYolu);

        if (tumCalisanlar.Any())
        {
            Console.Write("Lütfen adınızı ve soyadınızı girin: ");
            string girisYapacakCalisanAdi = Console.ReadLine();

            Calisan aktifCalisan = tumCalisanlar.FirstOrDefault(c => c.AdSoyad.ToLower() == girisYapacakCalisanAdi.ToLower());

            if (aktifCalisan != null)
            {
                RaporIstatistikleri.RaporuGoster(aktifCalisan);
            }
            else
            {
                Console.WriteLine("Çalışan bulunamadı. Lütfen tekrar bir isim girin.");
            }
        }
        else
        {
            Console.WriteLine("Program sonlandırılıyor.");
        }

        Console.ReadLine();
    }



    static void Main(string[] args)
    {
        Console.Write("Görev istatistiklerini görmek ister misiniz? (evet/hayır): ");
        string istatistikSecim = Console.ReadLine();

        if (istatistikSecim.ToLower() == "evet")
        {
            IstatistikleriGoster();
            Console.WriteLine(); 
        }
        else
        {
            Console.WriteLine("Program Sonlandırılıyor.");
        }

        Console.Write("Deneyim raporunu görmek ister misiniz? (evet/hayır): ");
        string deneyimSecim = Console.ReadLine();

        if (deneyimSecim.ToLower() == "evet")
        {
            DeneyimRaporuGoster();
        }
        else
        {
            Console.WriteLine("Program sonlandırılıyor.");
        }

        Console.ReadLine(); 
    }
}
}
