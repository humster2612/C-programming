using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj liczbę elementów: ");
        int n = int.Parse(Console.ReadLine());
        int[] num = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Podaj {i + 1}. liczbę: ");
            num[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n-1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (num[j] > num[j + 1]) {
                    int m = num[j];
                    num[j] = num[j + 1];
                    num[j + 1] = m;
                }
            }
        }
        foreach (int liczby in num)
        {
            Console.Write(liczby + " ");
        }
        Console.WriteLine();
    }

}
