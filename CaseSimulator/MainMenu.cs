public class MainMenu
{
    static decimal _balance = 1000; // Initial balance

    public static void RunNoAcc()
    {
        while (true)
        {
            Console.Clear();
            DisplayPleaseLogIn();

            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Preview Cases");
            Console.WriteLine("2. Open cases");
            Console.WriteLine("3. Profile");
            Console.WriteLine("4. Exit\n");


            
            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CasePreview.Run();
                    break;
                case "2":
                    break;
                case "3":
                    ProfileManager.Run();
                    RunAcc();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    
    public static void RunAcc()
    {
        while (true)
        {
            Console.Clear();
            DisplayUserName();

            DisplayBalance();

            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Preview Cases");
            Console.WriteLine("2. Open cases");
            Console.WriteLine("3. Profile");
            Console.WriteLine("4. Exit");


            
            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CasePreview.Run();
                    break;
                case "2":
                    break;
                case "3":
                    // if the user is logged in 
                    if (ProfileManager.currentUsername != null)
                    {
                        ProfileManager.Stats();
                    }
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void DisplayBalance()
    {
        int top = Console.CursorTop + 1; // Increase the top position by 1 to display balance below the username
        int left = Console.WindowWidth - 17; 

        Console.SetCursorPosition(left, top);
        Console.Write("Balance: $" + _balance.ToString("0.00"));
    }

    static void DisplayPleaseLogIn()
    {
        int top = Console.CursorTop;
        int left = Console.WindowWidth - 12;
        Console.SetCursorPosition(left, top);

        Console.Write($"Please login");
    }
    static void DisplayUserName()
    {
        int top = Console.CursorTop;
        int left = Console.WindowWidth - 17;
        Console.SetCursorPosition(left, top);
        Console.Write($"Hi, {ProfileManager.currentUsername}");

    }
}