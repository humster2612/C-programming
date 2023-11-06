static void Zadanie3()
{
    int a = 10;

    static int[] doladujList(int a)
    {
        int[] list = new int[a];
      
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Podaj " + (i + 1) + " liczbę:");

            list[i] = int.Parse(Console.ReadLine());
        }
        return list;
    }

    while (true)
    {
        Console.WriteLine("Wybierz numer, któryj chcesz zrobić:");
        Console.WriteLine("1 - summa");
        Console.WriteLine("2 - roznice");
        Console.WriteLine("3 - iloczyn");
        Console.WriteLine("4 - iloraz");
        Console.WriteLine("5 -  potęgę");

        var x = int.Parse(Console.ReadLine());
      
        int[] list = doladujList(10);

        switch (x)
        {
            case 1:
                {
                    Console.WriteLine();
                    int count = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        count += list[i];
                    }
                    Console.WriteLine("Wynik:" + count);

                    Console.WriteLine();

                    break;
                }
            case 2:
                {
                    Console.WriteLine();
                    int count = 0;
                  
                    for (int i = 0; i < 10; i++)
                    {
                        count *= list[i];
                    }
                    Console.WriteLine("Wynik:" + count);
                  
                    Console.WriteLine();
                    break;
                }
            case 3:
                {
                    Console.WriteLine();
                    int count = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        count += list[i];
                    }
                    Console.WriteLine("Wynik:" + count);
                    Console.WriteLine();

                    count = count / 10;
                    break;
                }
            case 4:
                {
                    Console.WriteLine();
                    int count = list[0];
                    for (int i = 1; i < 10; i++)
                    {
                        if (list[i] < count)
                        {
                            count = list[i];
                        }
                    }
                    Console.WriteLine("Wynik:" + count);

                    Console.WriteLine();
                    break;
                }
            case 5:
                {
                    Console.WriteLine();
                    int count = list[0];

                    for (int i = 1; i < 10; i++)
                    {
                        if (list[i] > count)
                        {
                            count = list[i];
                        }
                    }
                    Console.WriteLine("Wynik:" + count);
                  
                    Console.WriteLine();

                    break;
                }


        }
    }
}

