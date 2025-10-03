/************************************************
klasa: NumbersCollection
opis: Klasa reprezentująca kolekcję liczb całkowitych wraz z metodami do manipulacji i analizy tych liczb.
pola:
    numbersArray - tablica przechowująca liczby całkowite
    numbersCount - liczba elementów w kolekcji
autor: Patryk Skolimowski
************************************************/
class NumbersCollection
{
    private short[] numbersArray;
    private int numbersCount;

    /*
    **********************************************
    nazwa metody: NumbersCollection
    opis metody: Inicjalizuje kolekcję określonej długości i wypełnia ją losowymi liczbami z zakresu 1-999.
    parametry:
        count - liczba elementów kolekcji
    zwracany typ i opis: brak
    autor: Patryk Skolimowski
    ***********************************************
    */
    public NumbersCollection(int count)
    {
        this.numbersCount = count;
        this.numbersArray = new short[count];

        Random random = new Random();

        for (int i = 0; i < this.numbersCount; i++)
        {
            this.numbersArray[i] = (short)random.Next(1, 1000);
        }
    }

    /*
    **********************************************
    nazwa metody: DisplayNumbers
    opis metody: Wyświetla wszystkie liczby w kolekcji wraz z ich indeksem.
    parametry: brak
    zwracany typ i opis: void - brak wartości
    autor: Patryk Skolimowski
    ***********************************************
    */
    public void DisplayNumbers()
    {
        for (int i = 0; i < numbersArray.Length; i++)
        {
            Console.WriteLine($"{i}: {numbersArray[i]}");
        }
    }

    /*
    **********************************************
    nazwa metody: GetFirstResult
    opis metody: Zwraca indeks pierwszego wystąpienia podanej liczby w kolekcji lub -1, jeśli nie znaleziono.
    parametry:
        arg - szukana liczba
    zwracany typ i opis: int - indeks pierwszego wystąpienia lub -1, gdy nie znaleziono
    autor: Patryk Skolimowski
    ***********************************************
    */
    public int GetFirstResult(short arg)
    {
        for (int i = 0; i < numbersArray.Length; i++)
            if (numbersArray[i] == arg) return i;

        return -1;
    }

    /*
    **********************************************
    nazwa metody: DisplayOddNumbersAndGetCount
    opis metody: Wyświetla wszystkie liczby nieparzyste z kolekcji i zwraca ich liczbę.
    parametry: brak
    zwracany typ i opis: short - liczba elementów nieparzystych
    autor: Patryk Skolimowski
    ***********************************************
    */
    public short DisplayOddNumbersAndGetCount()
    {
        short oddNumbersCount = 0;

        Console.WriteLine("Liczby nieparzyste:");

        foreach (short number in numbersArray)
            if (number % 2 != 0)
            {
                Console.WriteLine(number);
                oddNumbersCount++;
            }

        return oddNumbersCount;
    }

    /*
    **********************************************
    nazwa metody: GetAverage
    opis metody: Oblicza średnią arytmetyczną wszystkich liczb w kolekcji i zaokrągla wynik do 2 miejsc po przecinku.
    parametry: brak
    zwracany typ i opis: double - średnia arytmetyczna liczb
    autor: Patryk Skolimowski
    ***********************************************
    */
    public double GetAverage()
    {
        double sum = 0;

        foreach (short number in numbersArray)
            sum += number;

        return Math.Round(sum / this.numbersCount, 2);
    }
}

class Program
{
    /*
    **********************************************
    nazwa metody: Main
    opis metody: Punkt wejścia programu; tworzy kolekcję, prezentuje dane, wyszukuje wartość, zlicza liczby nieparzyste i oblicza średnią.
    parametry: brak
    zwracany typ i opis: void - brak wartości
    autor: Patryk Skolimowski
    ***********************************************
    */
    static void Main()
    {
        NumbersCollection collection = new NumbersCollection(500);

        collection.DisplayNumbers();

        short searchQuery = 20;
        var searchResult = collection.GetFirstResult(searchQuery);
        if (searchResult != -1)
            Console.WriteLine($"Znaleziono liczbę {searchQuery} w indeksie {searchResult}");

        var oddNumbersCount = collection.DisplayOddNumbersAndGetCount();
        Console.WriteLine($"Liczb nieparzystych: {oddNumbersCount}");

        var numbersAverage = collection.GetAverage();
        Console.WriteLine($"Średnia liczb: {numbersAverage}");
    }
}
