using System.Text.Json;


class Program
{
    static void Main()
    {
                
    }
    static void GorevlerimiGoruntule(int calisanId)
    {
        string json = File.ReadAllText("gorevler.json");
               
        List<Dictionary<string, string>> gorevler = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
            
        foreach (Dictionary<string, string> gorev in gorevler)
        {
            if (int.Parse(gorev["CalisanId"].ToString()) == calisanId)
            {

                Console.WriteLine("Id: " + gorev["Id"]);
                Console.WriteLine("Ad: " + gorev["Ad"]);
                Console.WriteLine("Durum: " + gorev["Durum"]);
               
            }
        }
    }



    static void GorevTamamla(int calisanId)
    {
        string json = File.ReadAllText("gorevler.json");
                
        List<Dictionary<string, string>> gorevler = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
            
        Console.Write("Tamamlanacak gorev ID: ");
        int id = int.Parse(Console.ReadLine());

        bool bulundu = false;

        foreach (Dictionary<string, string> g in gorevler)
        {
            if (int.Parse(g["Id"].ToString()) == id &&
                int.Parse(g["CalisanId"].ToString()) == calisanId)
            {
                g["Durum"] = "Tamamlandı";
                bulundu = true;
            }
        }

        if (bulundu)
        {
            string yeniJson = JsonSerializer.Serialize(gorevler);
            File.WriteAllText("gorevler.json", yeniJson);
            Console.WriteLine("Gorev tamamlandı!");
        }
        else
        {
            Console.WriteLine("Gorev bulunamadı.");
        }
    }

}