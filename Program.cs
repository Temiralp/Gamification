using System.Text.Json;

class Program
{
    //static List<string> gorevler;

    static void Main()
    {
        bool calisiyor = true;

        while (calisiyor)
        {
            Console.Clear();
            Console.WriteLine("UYGULAMA MENÜSÜ");

            Console.WriteLine("1) Kullanıcı Girişi");
            Console.WriteLine("2) Yönetici İşlemleri");
            Console.WriteLine("3) Çalışan İşlemleri");
            Console.WriteLine("4) Raporlar");
            Console.WriteLine("5) Sistem Yönetimi (Test Süreçleri)");
            Console.WriteLine("6) Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    SistemYonetimi();
                    break;

                case "6":
                    calisiyor = false;
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim! Lütfen 1-6 arası değer giriniz.");
                    Devam();
                    break;
            }
        }
    }

    

    // SİSTEM YÖNETİMİ 
    static void SistemYonetimi()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("SİSTEM YÖNETİMİ — TEST SÜREÇLERİ");
            Console.WriteLine("1) Menü Yönetimi Testi");
            Console.WriteLine("2) Eklenen Özellikler Testi");
            Console.WriteLine("3) Geri Dön");
            Console.Write("Seçiminiz: ");
            string? secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    MenuYonetimiTesti();
                    break;
                case "2":
                    OzelliklerTesti();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim! 1-3 arası değer giriniz.");
                    Devam();
                    break;
            }
        }
    }

    // MENÜ YÖNETİMİ TESTİ
    static void MenuYonetimiTesti()
    {
        Console.Clear();
        Console.WriteLine("MENÜ YÖNETİMİ TESTİ");

        int toplam = 0, gecti = 0;

        Soru("Uygulama açıldığında ana menü (1..6) ve başlık hatasız görünüyor mu?", ref toplam, ref gecti);
        Soru("Geçersiz giriş yaptığınızda (örn. 9/a/boş) program çökmeden uyarı verip menüye dönüyor mu?", ref toplam, ref gecti);
        Soru("Sistem Yönetimi (5) seçildiğinde test menüsü açılıyor mu?", ref toplam, ref gecti);
        Soru("Test menüsünde 'Geri Dön' (3) seçildiğinde ana menüye sorunsuz dönüyor mu?", ref toplam, ref gecti);
        Soru("Çıkış (6) seçildiğinde uygulama düzgün kapanıyor mu? (Bu soruyu gerçek kapatmadan mantıksal olarak işaretleyin.)", ref toplam, ref gecti);

        Console.WriteLine($"\nÖzet: {gecti}/{toplam} adım PASS");
        Devam();
    }

    // EKLENEN ÖZELLİKLER TESTİ - manuel olarak test edilmektedir.
    static void OzelliklerTesti()
    {
        Console.Clear();
        Console.WriteLine("EKLENEN ÖZELLİKLER TESTİ");

        int toplam = 0, gecti = 0;

        Soru("Yönetici > 'Görev Oluştur': Görev kaydı oluşuyor ve listelerde görünüyor mu?", ref toplam, ref gecti);
        Soru("Yönetici > 'Görev Ata': Seçilen görev doğru çalışana atanıyor mu?", ref toplam, ref gecti);
        Soru("Çalışan > 'Görevlerimi Görüntüle': Sadece ilgili çalışanın görevleri listeleniyor mu?", ref toplam, ref gecti);
        Soru("Çalışan > 'Görev Tamamla': Görev tamamlanıyor ve XP/puan gibi sonuçlar doğru yansıyor mu?", ref toplam, ref gecti);
        Soru("Raporlar: Temel istatistik/sıralamalar doğru görünüyor mu?", ref toplam, ref gecti);

        Console.WriteLine($"Özet: {gecti}/{toplam} adım PASS");
        Devam();
    }

    // YARDIMCI METODLAR
    static void Soru(string metin, ref int toplam, ref int gecti)
    {
        toplam++;
        Console.Write($"{toplam}. {metin} (Y/N): ");
        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Y)
            {
                Console.WriteLine("PASS");
                gecti++;
                break;
            }
            if (key == ConsoleKey.N)
            {
                Console.WriteLine("FAIL");
                break;
            }
        }
    }

    
    static void Devam()
    {
        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadKey(true);
    }
}

    




    // public static void GorevlerimiGoruntule()
    // {
    //     Console.WriteLine("Görevleriniz : ");
    //     if (gorevler.Count == 0)
    //     {
    //         Console.WriteLine("Henüz görev yok");
    //         return;
    //     }

    //     for (int i = 0; i < gorevler.Count; i++)
    //     {
    //         Console.WriteLine((i + 1) + "  " + gorevler[i]);
    //     }
    // }


    // public static void GorevTamamla()
    // {
    //     if (gorevler.Count == 0)
    //     {
    //         Console.WriteLine("Henüz görev yok");
    //         return;
    //     }

    //     Console.Write("Tamamlanacak görev numarası : ");

    //     int numara = int.Parse(Console.ReadLine());
    //     if (numara > 0 && numara <= gorevler.Count)
    //     {
    //         Console.WriteLine(gorevler[numara - 1] + " tamamlandı");
    //         gorevler.RemoveAt(numara - 1);
    //     }
    //     else
    //     {
    //         Console.WriteLine("Geçersiz numara");
    //     }
    // }

