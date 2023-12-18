using System;

class CustomException1 : Exception
{

    public CustomException1(string message) : base(message) { }
}


class CustomException2 : Exception
{
    public CustomException2(string message) : base(message) { }

}

class CustomException3 : Exception
{
    public CustomException3(string message) : base(message) { }


}

class Program
{
    static void Main()
    {
        TryCatchRandomException();


    }

    static void TryCatchRandomException()

    {
        try
        {
            Random random = new Random();


            int randomNumber = random.Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    throw new CustomException1("Zgłoszono CustomException1.");

                case 2:
                    throw new CustomException2("Zgłoszono CustomException2.");

                case 3:
                    throw new CustomException3("Zgłoszono CustomException3.");
            }
        }

        catch (CustomException1 ex1)
        {

            Console.WriteLine("Złapany wyjątek: " + ex1.Message);
        }


        catch (CustomException2 ex2)
        {
            Console.WriteLine("Złapany wyjątek: " + ex2.Message);
        }
        catch (CustomException3 ex3)


        {
            Console.WriteLine("Złapany wyjątek: " + ex3.Message);
        }


    }



}
