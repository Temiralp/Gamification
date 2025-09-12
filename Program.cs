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
}

public class JsonVeriIsleyici
{
    public static List<Kullanici> KullanicilariYukle(string dosyaYolu)
    {
       
        string jsonMetni = File.ReadAllText(dosyaYolu);
        List<Kullanici> kullanicilar = JsonSerializer.Deserialize<List<Kullanici>>(jsonMetni);
        return kullanicilar;
    }
}


public class GorevIstatistikleri
{
    public static void RaporuGoster(Kullanici kullanici)
    {
        Console.WriteLine($"--- {kullanici.AdSoyad} - Görev İstatistikleri ---");
        Console.WriteLine($"Toplam Tamamlanan Görev Sayısı: {kullanici.TamamlananGorevSayisi}");
        Console.WriteLine($"Toplam Aktif Görev Sayısı: {kullanici.AktifGorevSayisi}");
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

   
    static void Main(string[] args)
    {
        IstatistikleriGoster();
    }
}
