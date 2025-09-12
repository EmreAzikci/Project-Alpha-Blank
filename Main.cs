static class Program
{
    static void Main()
    {
        System.Console.WriteLine("Hello and welcome to:");
        SlowWriteLine("  --PEST CONTROL--  ");
        SlowWriteLine("Would you like to?");
        int menuChoice = 0;
        do
        {
            SlowWriteLine("[1] START GAME");
            SlowWriteLine("[2] EXIT");
            menuChoice = Convert.ToInt32(Console.ReadLine());

        } while (menuChoice != 1 && menuChoice != 2);

        if (menuChoice == 1)
        {
            // location();
            Console.WriteLine("You wake up at your home!");
        }
        else if (menuChoice == 2)
        {
            System.Console.WriteLine("BYE BYE!");
        }


    }

    static void SlowWriteLine(string text, int delayMilliseconds = 50)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMilliseconds);
        }
        Console.WriteLine();
    }
}
