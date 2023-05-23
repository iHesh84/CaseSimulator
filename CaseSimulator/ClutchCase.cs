public class ClutchCase : Case
{
    public ClutchCase() : base("Clutch Case", GetClutchCaseContents())
    {
    }

    private static Item[] GetClutchCaseContents()
    {
        Item[] clutchCaseItems = new Item[]
        {
            new Item { Name = "*Rare*", Rarity = "Gold"},
            new Item { Name = "M4A4 - Neo-Noir", Rarity = "Covert" },
            new Item { Name = "MP7 - Bloodsport", Rarity = "Covert" },
            new Item { Name = "AWP - Mortis", Rarity = "Classified" },
            new Item { Name = "USP-S - Cortex", Rarity = "Classified" },
            new Item { Name = "AUG - Stymphalian", Rarity = "Classified" },
            new Item { Name = "Glock-18 - Moonrise", Rarity = "Restricted" },
            new Item { Name = "UMP-45 - Arctic Wolf", Rarity = "Restricted" },
            new Item { Name = "MAG-7 - SWAG-7", Rarity = "Restricted" },
            new Item { Name = "Negev - Lionfish", Rarity = "Restricted" },
            new Item { Name = "Nova - Wild Six", Rarity = "Restricted" },
            new Item { Name = "R8 Revolver - Grip", Rarity = "Mil-Spec" },
            new Item { Name = "P2000 - Urban Hazard", Rarity = "Mil-Spec" },
            new Item { Name = "MP9 - Black Sand", Rarity = "Mil-Spec" },
            new Item { Name = "Five-SeveN - Flame Test", Rarity = "Mil-Spec" },
            new Item { Name = "SG 553 - Aloha", Rarity = "Mil-Spec" },
            new Item { Name = "PP-Bizon - Night Riot", Rarity = "Mil-Spec" },
            new Item { Name = "XM1014 - Oxide Blaze", Rarity = "Mil-Spec" }
        };

        return clutchCaseItems;
    }
}