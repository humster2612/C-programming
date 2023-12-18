using System;

class Program
{
    static void Main()
    {
        try
        {
            WypiszDlugoscNapisu(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Obsłużono wyjątek:");
            Console.WriteLine(ex.StackTrace);
        }
    }

    static void WypiszDlugoscNapisu(string napis)
    {
        try
        {
            if (napis == null)
            {
                
                throw new NullReferenceException("Podany napis jest null.");
            }

           
            int dlugosc = napis.Length;

          
            Console.WriteLine("Długość napisu: " + dlugosc);
        }
        catch (NullReferenceException ex)
        {
            
            Console.WriteLine("Zgłoszono wyjątek: " + ex.Message);

            
            Console.WriteLine("Ślad stosu:");
            Console.WriteLine(ex.StackTrace);

       
            throw new Exception("Obsłużony wyjątek z dodaną przyczyną", ex);
        }
    }
}
