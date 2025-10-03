/************************************************
klasa:      DicesCollection
opis:       Kolekcja wyników rzutów kośćmi i operacje na nich.
pola:       dices - lista wartości wyrzuconych na kościach (1-6) typu byte
autor:      Patryk Skolimowski
************************************************/
class DicesCollection
{
    public List<byte> dices = new List<byte>();

    /**********************************************
    nazwa funkcji: DicesCollection
    opis funkcji: Inicjalizuje kolekcję kości losując wskazaną liczbę rzutów (1-6) i zapisuje je w polu dices.
    parametry: amount – liczba kości do wylosowania
    zwracany typ i opis: brak – konstruktor nie zwraca wartości
    autor: Patryk Skolimowski
    ***********************************************/
    public DicesCollection(int amount)
    {
        Random random = new Random();

        for (int i = 0; i < amount; i++)
        {
            byte dice = (byte)random.Next(1, 7);
            dices.Add(dice);
        }
    }

    /**********************************************
    nazwa funkcji: GetScore
    opis funkcji: Oblicza wynik na podstawie liczby powtórzeń wartości oczek; sumuje (liczba_wystąpień * wartość oczka) tylko dla wartości, które wystąpiły co najmniej 2 razy.
    parametry: brak
    zwracany typ i opis: int – łączny wynik obliczony z aktualnej kolekcji rzutów
    autor: Patryk Skolimowski
    ***********************************************/
    public int GetScore()
    {
        byte[] numberInterations = new byte[6];
        int score = 0;

        foreach (byte dice in dices)
        {
            numberInterations[dice - 1] += 1;
        }

        for (int i = 0; i < numberInterations.Length; i++)
        {
            if (numberInterations[i] >= 2)
            {
                score += numberInterations[i] * (i + 1);
            }
        }

        return score;
    }
}

class Program
{
    static void Main()
    {
        bool isUserPlaying = true;

        while (isUserPlaying)
        {
            byte userAmount = 0;

            while (!(userAmount >= 3 && userAmount <= 10))
            {
                Console.Write("Ile kostek chcesz rzucić? (3 - 10): ");
                string? userText = Console.ReadLine();

                Byte.TryParse(userText, out userAmount);
            }

            DicesCollection collection = new DicesCollection(userAmount);

            for (int i = 0; i < collection.dices.Count; i++)
            {
                Console.WriteLine($"Kostka {i + 1}: {collection.dices[i]}");
            }

            int score = collection.GetScore();

            Console.WriteLine($"Wynik losowania: {score}");

            Console.Write("Jeszcze raz? (t/n): ");
            string? userChoice = Console.ReadLine();
            if (userChoice == "t")
            {
                continue;
            }
            else
            {
                break;
            }
        }
    }

}
