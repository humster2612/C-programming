using System;

public class SomeClass


{
    public void CanThrowException()


    {

        if (new Random().Next(5) == 0)

            throw new Exception("Wyjątek w CanThrowException");

    }
}

class Program
{
    static void Main(string[] args)


    {
        SomeClass someClassObj = new SomeClass();

        for (int i = 1; i <= 5; i++)
        {

            try
            {
                someClassObj.CanThrowException();
            }
            catch (Exception e)

            {
                Console.WriteLine($"Złapany wyjątek podczas wykonania instrukcji {i}: {e.Message}");
            }
        }


    }



}
