using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;





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
