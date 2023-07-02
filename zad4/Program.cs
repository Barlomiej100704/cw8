using System;

enum Plec
{
    Kobieta,
    Mezczyzna
}

struct Student
{
    public string Nazwisko;
    public int NrAlbumu;
    public double Ocena;
    public Plec Plec;

    public Student(string nazwisko, int nrAlbumu, double ocena, Plec plec)
    {
        Nazwisko = nazwisko;
        NrAlbumu = nrAlbumu;
        Ocena = Math.Max(2.0, Math.Min(5.0, ocena));
        Plec = plec;
    }

    public void WyswietlInformacje()
    {
        Console.Write("Student: ");
        Console.Write("Nazwisko: " + Nazwisko + ", ");
        Console.Write("Nr albumu: " + NrAlbumu + ", ");
        Console.Write("Ocena: " + Ocena + ", ");
        Console.Write("Płeć: " + Plec);
        Console.WriteLine();
    }
}

class Program
{
    static void WypelnijStudenta(ref Student student, string nazwisko, int nrAlbumu, double ocena, Plec plec)
    {
        student.Nazwisko = nazwisko;
        student.NrAlbumu = nrAlbumu;
        student.Ocena = Math.Max(2.0, Math.Min(5.0, ocena));
        student.Plec = plec;
    }

    static double ObliczSrednia(Student[] grupa)
    {
        double suma = 0;

        foreach (Student student in grupa)
        {
            suma += student.Ocena;
        }

        return suma / grupa.Length;
    }

    static void Main(string[] args)
    {
        Student[] grupa = new Student[5];

        WypelnijStudenta(ref grupa[0], "Kowalski", 12345, 4.5, Plec.Mezczyzna);
        WypelnijStudenta(ref grupa[1], "Nowak", 23456, 3.8, Plec.Kobieta);
        WypelnijStudenta(ref grupa[2], "Wójcik", 34567, 4.9, Plec.Kobieta);
        WypelnijStudenta(ref grupa[3], "Kaczmarek", 45678, 5.5, Plec.Mezczyzna);
        WypelnijStudenta(ref grupa[4], "Lewandowska", 56789, 2.2, Plec.Kobieta);

        Console.WriteLine("Grupa studentów:");
        foreach (Student student in grupa)
        {
            student.WyswietlInformacje();
        }

        double srednia = ObliczSrednia(grupa);
        Console.WriteLine("Średnia ocen: " + srednia);

        Console.ReadLine();
    }
}
