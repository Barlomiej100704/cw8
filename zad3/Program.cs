using System;

enum KlasaRzadkosci
{
    Powszechny,
    Rzadki,
    Unikalny,
    Epicki
}

enum TypPrzedmiotu
{
    Bron,
    Zbroja,
    Amulet,
    Pierscien,
    Helm,
    Tarcza,
    Buty
}

struct Przedmiot
{
    public float Waga;
    public int Wartosc;
    public KlasaRzadkosci Rzadkosc;
    public TypPrzedmiotu Typ;
    public string NazwaWlasna;

    public Przedmiot(float waga, int wartosc, KlasaRzadkosci rzadkosc, TypPrzedmiotu typ, string nazwaWlasna)
    {
        Waga = waga;
        Wartosc = wartosc;
        Rzadkosc = rzadkosc;
        Typ = typ;
        NazwaWlasna = nazwaWlasna;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine("Przedmiot: " + NazwaWlasna);
        Console.WriteLine("Typ: " + Typ);
        Console.WriteLine("Rzadkosc: " + Rzadkosc);
        Console.WriteLine("Waga: " + Waga);
        Console.WriteLine("Wartosc: " + Wartosc);
        Console.WriteLine();
    }
}

class Program
{
    static Random random = new Random();

    static Przedmiot LosujPrzedmiot(Przedmiot[] przedmioty)
    {
        int totalWeight = 0;

        foreach (Przedmiot przedmiot in przedmioty)
        {
            totalWeight += (int)przedmiot.Rzadkosc;
        }

        int losowyNumer = random.Next(totalWeight);
        int kumulowanaSuma = 0;

        foreach (Przedmiot przedmiot in przedmioty)
        {
            kumulowanaSuma += (int)przedmiot.Rzadkosc;

            if (losowyNumer < kumulowanaSuma)
            {
                return przedmiot;
            }
        }

        return przedmioty[0];
    }

    static void Main(string[] args)
    {
        Przedmiot[] przedmioty = new Przedmiot[5];

        przedmioty[0] = new Przedmiot(2.5f, 50, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Bron, "Miecz");
        przedmioty[1] = new Przedmiot(1.8f, 100, KlasaRzadkosci.Rzadki, TypPrzedmiotu.Zbroja, "Pancerz");
        przedmioty[2] = new Przedmiot(0.5f, 200, KlasaRzadkosci.Unikalny, TypPrzedmiotu.Amulet, "Amulet Mocy");
        przedmioty[3] = new Przedmiot(0.1f, 500, KlasaRzadkosci.Epicki, TypPrzedmiotu.Helm, "Hełm Nieskończonego Władcy");
        przedmioty[4] = new Przedmiot(1.2f, 150, KlasaRzadkosci.Powszechny, TypPrzedmiotu.Tarcza, "Tarcza Ochronna");

        Console.WriteLine("Wylosowany przedmiot:");
        Przedmiot wylosowanyPrzedmiot = LosujPrzedmiot(przedmioty);
        wylosowanyPrzedmiot.WyswietlInformacje();

        Console.ReadLine();
    }
}
