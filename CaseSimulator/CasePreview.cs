public class CasePreview
{
    public static void Run()
    {
        Console.Clear();
        Console.WriteLine("Choose a case to preview:");
        Console.WriteLine("1. Clutch Case");
        Console.WriteLine("2. Chroma 2 Case");
        bool check = int.TryParse(Console.ReadLine(), out int userChoice);
        if (!check)
        {
            Console.WriteLine();
            Console.WriteLine("Please enter an integer.");
            Console.WriteLine("Press a key to go back...");
            Console.ReadKey();
            Run();
        }

        Case previewCase = null;

        switch (userChoice)
        {
            case 1:
                previewCase = new ClutchCase();
                break;
            case 2:
                previewCase = new ChromaTwoCase();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting...");
                return;
        }

        // Accessing case properties
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Case Name: " + previewCase.Name);
        Console.WriteLine("Number of Items: " + previewCase.Items.Length);
        Console.WriteLine("--------------------");
        Console.WriteLine();

        // Iterating over the case items
        foreach (Item item in previewCase.Items)
        {
            Console.Write("Item Name: ");
            Console.ForegroundColor = GetRarityColor(item.Rarity);
            Console.WriteLine(item.Name);
            Console.ResetColor();

            Console.Write("Item Rarity: ");
            Console.ForegroundColor = GetRarityColor(item.Rarity);
            Console.WriteLine(item.Rarity);
            Console.ResetColor();

            Console.WriteLine("--------------------");
        }

        Console.WriteLine("\nPress a key to go back...");
        Console.ReadKey();
    }

    static ConsoleColor GetRarityColor(string rarity)
    {
        switch (rarity.ToLower())
        {
            case "gold":
                return ConsoleColor.DarkYellow;
            case "covert":
                return ConsoleColor.Red;
            case "classified":
                return ConsoleColor.Magenta;
            case "restricted":
                return ConsoleColor.DarkMagenta;
            case "mil-spec":
                return ConsoleColor.Blue;
            case "industrial":
                return ConsoleColor.Green;
            default:
                return ConsoleColor.White;
        }
    }
}