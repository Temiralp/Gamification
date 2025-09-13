using System.Text.Json;

class Program
{
    static List<string> gorevler;

    static void Main()
    {
        Console.WriteLine("test");
    }


    public static void GorevlerimiGoruntule()
    {
        Console.WriteLine("Görevleriniz : ");
        if (gorevler.Count == 0)
        {
            Console.WriteLine("Henüz görev yok");
            return;
        }

        for (int i = 0; i < gorevler.Count; i++)
        {
            Console.WriteLine((i + 1) + "  " + gorevler[i]);
        }
    }


    public static void GorevTamamla()
    {
        if (gorevler.Count == 0)
        {
            Console.WriteLine("Henüz görev yok");
            Console.WriteLine("Kullanıcı seviyesini göster");
            return;
        }

        Console.Write("Tamamlanacak görev numarası : ");
        
        int numara = int.Parse(Console.ReadLine());
        if (numara > 0 && numara <= gorevler.Count)
        {
            Console.WriteLine(gorevler[numara - 1] + " tamamlandı");
            gorevler.RemoveAt(numara - 1);
        }
        else
        {
            Console.WriteLine("Geçersiz numara");
        }
    }

}