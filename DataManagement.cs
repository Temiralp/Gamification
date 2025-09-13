using System.Text.Json;

public class DataManagement
{

    public static List<Kullanici> kullanicilar = new List<Kullanici>();

    public static List<Gorev> gorevler = new List<Gorev>();
    public void KullanicilarOku()
    {
     

          kullanicilar = JsonSerializer.Deserialize<List<Kullanici>>(jsonMetni);
    }

    public void GorevlerOku()
{      


    gorevler = JsonSerializer.Deserialize<List<Gorev>>(jsonMetni);
        File.WriteAllText("gorevler.json", jsonMetni);

}

    public void GorevlerOku()
    {


        gorevler = JsonSerializer.Deserialize<List<Gorev>>(jsonMetni);
        File.WriteAllText("gorevler.json", jsonMetni);

    }


}