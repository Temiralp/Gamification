using System.Text.Json;

class Program
{

    static void Main()
    {
        Gorevler gorev1 = new Gorevler();
        string okunanVeri =  File.ReadAllText("test.json");
        gorev1= JsonSerializer.Deserialize<Gorevler>(okunanVeri);

        Console.WriteLine(gorev1.gorevBaslik);
        gorev1.gorevMetni = "";
        string jsonVeri = JsonSerializer.Serialize(gorev1);
        File.WriteAllText("test.json", jsonVeri);

        //Görev başlığını güncelleyin yeniden yazdırın




    }

}