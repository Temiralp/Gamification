public class Gorev
{
    public int Id { get; set; }
    public string GorevAdi { get; set; }
    public string Aciklama { get; set; }    
    public string Kategori { get; set; }    
    public string Zorluk {  get; set; }
    public int DeneyimPuani { get; set; }
    public int AtananCalisanId { get; set; }


}

class Program
{
    static List<string> gorevler;

    static void Main()
    {

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
            return;
        }

        Console.Write("Tamamlanacak görev numarasý : ");

        int numara = int.Parse(Console.ReadLine());
        if (numara > 0 && numara <= gorevler.Count)
        {
            Console.WriteLine(gorevler[numara - 1] + " tamamlandý");
            gorevler.RemoveAt(numara - 1);
        }
        else
        {
            Console.WriteLine("Geçersiz numara");
        }
    }

}