using System;
using System.Data.SQLite;

public class ProfileManager
{
    public static string currentUsername;

    private static string _path = @"C:\Users\mhd-o\OneDrive\Documents\GitHub\CaseSimulator\CaseSimulator/database.db";
    private static string _connectionString = $"Data Source={_path};Version=3;";

    public static void Run()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        CreateProfile(name);

    }

    public static void CreateTable()
    {
        try
        {
            if (!File.Exists(_path))
            {
                SQLiteConnection.CreateFile(_path);
            }

            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteCommand createTableCommand = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Profiles (Id INTEGER PRIMARY KEY AUTOINCREMENT, Username TEXT)", connection))
                {
                    createTableCommand.ExecuteNonQuery();
                }
            }
        }
        catch (SQLiteException ex)
        {
            Console.WriteLine("SQLite Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }


    public static void CreateProfile(string username)
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Check if the username already exists in the Profiles table
                using (SQLiteCommand checkUsernameCommand = new SQLiteCommand("SELECT COUNT(*) FROM Profiles WHERE Username = @Username", connection))
                {
                    checkUsernameCommand.Parameters.AddWithValue("@Username", username);
                    int count = Convert.ToInt32(checkUsernameCommand.ExecuteScalar());

                    if (count > 0) // Username exists, log in the user
                    {
                        currentUsername = username;
                        Console.WriteLine($"Logged in as {currentUsername}.");
                    }
                    else // Username does not exist, create a new profile
                    {
                        // Create the inventory table for the profile
                        string inventoryTableName = $"{username}_Inventory";
                        using (SQLiteCommand createInventoryTableCommand = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {inventoryTableName} (ItemId INTEGER PRIMARY KEY, Quantity INTEGER)", connection))
                        {
                            createInventoryTableCommand.ExecuteNonQuery();
                        }

                        // Insert the new profile record
                        using (SQLiteCommand insertCommand = new SQLiteCommand("INSERT INTO Profiles (Username) VALUES (@Username)", connection))
                        {
                            insertCommand.Parameters.AddWithValue("@Username", username);
                            insertCommand.ExecuteNonQuery();

                            currentUsername = username;
                            Console.WriteLine($"Profile created and logged in as {currentUsername}.");
                        }
                    }

                    Console.ReadKey();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while creating the profile: " + ex.Message);
        }
    }



public static void AddItemToInventory(int itemId)
{
    if (string.IsNullOrEmpty(currentUsername))
    {
        Console.WriteLine("No user logged in.");
        return;
    }
    try
    {
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            // Check if the item already exists in the inventory
            string inventoryTableName = $"{currentUsername}_Inventory";
            using (SQLiteCommand checkItemCommand = new SQLiteCommand($"SELECT Quantity FROM {inventoryTableName} WHERE ItemId = @ItemId", connection))
            {
                checkItemCommand.Parameters.AddWithValue("@ItemId", itemId);
                object result = checkItemCommand.ExecuteScalar();

                if (result != null) // Item already exists, increment the quantity
                {
                    int currentQuantity = Convert.ToInt32(result);
                    int newQuantity = currentQuantity + 1;

                    // Update the quantity of the item in the inventory
                    using (SQLiteCommand updateItemCommand = new SQLiteCommand($"UPDATE {inventoryTableName} SET Quantity = @NewQuantity WHERE ItemId = @ItemId", connection))
                    {
                        updateItemCommand.Parameters.AddWithValue("@NewQuantity", newQuantity);
                        updateItemCommand.Parameters.AddWithValue("@ItemId", itemId);
                        updateItemCommand.ExecuteNonQuery();
                    }
                }
                else // Item does not exist, insert a new record
                {
                    // Insert the item into the inventory with quantity 1
                    using (SQLiteCommand insertItemCommand = new SQLiteCommand($"INSERT INTO {inventoryTableName} (ItemId, Quantity) VALUES (@ItemId, 1)", connection))
                    {
                        insertItemCommand.Parameters.AddWithValue("@ItemId", itemId);
                        insertItemCommand.ExecuteNonQuery();
                    }
                }
            }

            Console.WriteLine("Item added to the inventory successfully.");
            Console.ReadKey();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while adding the item to the inventory: " + ex.Message);
    }
}



    public static void UpdateProfile(string username, string newUsername)
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Update the username in the database
                using (SQLiteCommand command = new SQLiteCommand("UPDATE Profiles SET Username = @NewUsername WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@NewUsername", newUsername);
                    command.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("Profile updated successfully.");
                    else
                        Console.WriteLine("No profile found with the given username.");
                    Console.ReadKey();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while updating the profile: " + ex.Message);
        }
    }

    public void DeleteProfile(string username)
    {
        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Delete the profile from the database
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Profiles WHERE Username = @Username", connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("Profile deleted successfully.");
                    else
                        Console.WriteLine("No profile found with the given username.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while deleting the profile: " + ex.Message);
        }
    }
    public static List<InventoryItem> GetInventory(string username)
    {
        List<InventoryItem> inventory = new List<InventoryItem>();

        try
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                // Retrieve the user's inventory from the corresponding table
                string tableName = $"{username}_Inventory";
                using (SQLiteCommand command = new SQLiteCommand($"SELECT ItemId, Quantity FROM {tableName}", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int itemId = reader.GetInt32(0);
                            int quantity = reader.GetInt32(1);

                            // Create an InventoryItem object and add it to the inventory list
                            InventoryItem item = new InventoryItem(itemId, quantity);
                            inventory.Add(item);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while retrieving the inventory: " + ex.Message);
        }

        return inventory;
    }



    public static void Stats()
    {
        Console.WriteLine("User Statistics:");
        Console.WriteLine("----------------");

        // Retrieve the user's inventory and calculate statistics
        List<InventoryItem> inventory = GetInventory(ProfileManager.currentUsername);
        int totalItems = inventory.Sum(item => item.Quantity);
        int uniqueItems = inventory.Count;

        Console.WriteLine($"Total Items: {totalItems}");
        Console.WriteLine($"Unique Items: {uniqueItems}");

        // Calculate the frequency of each item
        var itemFrequency = inventory
            .GroupBy(item => item.ItemId)
            .Select(group => new { ItemId = group.Key, Quantity = group.Sum(item => item.Quantity) });

        Console.WriteLine("Item Frequencies:");
        foreach (var item in itemFrequency)
        {
            Console.WriteLine($"Item ID: {item.ItemId}, Quantity: {item.Quantity}");
        }

        Console.ReadKey();
    }


}
