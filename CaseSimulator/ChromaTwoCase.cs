public class ChromaTwoCase : Case
{
    public ChromaTwoCase() : base("Chroma 2 Case", GetChromaTwoCaseItems())
    {
    }

    private static Item[] GetChromaTwoCaseItems()
    {
        return new Item[]
        {
            new Item { Name = "MAC-10 - Neon Rider", Rarity = "Covert" },
            new Item { Name = "M4A1-S - Hyper Beast", Rarity = "Covert" },
            new Item { Name = "FAMAS - Djinn", Rarity = "Classified" },
            new Item { Name = "Galil AR - Eco", Rarity = "Classified" },
            new Item { Name = "Five-SeveN - Monkey Business", Rarity = "Classified" },
            new Item { Name = "UMP-45 - Grand Prix", Rarity = "Restricted" },
            new Item { Name = "CZ75-Auto - Pole Position", Rarity = "Restricted" },
            new Item { Name = "MAG-7 - Heat", Rarity = "Restricted" },
            new Item { Name = "AWP - Worm God", Rarity = "Restricted" },
            new Item { Name = "Sawed-Off - Origami", Rarity = "Mil-Spec" },
            new Item { Name = "Negev - Man-o'-war", Rarity = "Mil-Spec" },
            new Item { Name = "P250 - Valence", Rarity = "Mil-Spec" },
            new Item { Name = "Desert Eagle - Bronze Deco", Rarity = "Mil-Spec" },
            new Item { Name = "MP7 - Armor Core", Rarity = "Mil-Spec" },
            new Item { Name = "AK-47 Elite Build", Rarity = "Mil-Spec" }
        };
    }
}