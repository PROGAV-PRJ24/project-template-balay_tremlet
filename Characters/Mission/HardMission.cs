
public class MediumMission : Mission
{
    public MediumMission()
    {
        Name = "Mission moyenne";
        Description = "Collectez 5 trésors variés.";
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public override bool CheckCompletion(Character character)
    {
        int uniqueTreasureCount = character.Inventory.Treasures.Select(t => t.Name).Distinct().Count();
        if (uniqueTreasureCount >= 5)
        {
            IsCompleted = true;
            return true;
        }
        return false;
    }
}

public class HardMission : Mission
{
    public HardMission()
    {
        Name = "Mission difficile";
        Description = "trouver et rapporter un trésor rare."; // rajouter un trésor rare
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public override bool CheckCompletion(Character character)
    {
        int specificTreasureCount = character.Inventory.Treasures.Count(t => t is SpecificTreasure);
        if (specificTreasureCount >= 10)
        {
            IsCompleted = true;
            return true;
        }
        return false;
    }
}

public class ChallengingMission : Mission
{
    public ChallengingMission()
    {
        Name = "Mission très difficile";
        Description = "Trouvez et rapportez un trésor légendaire.";
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public override bool CheckCompletion(Character character)
    {
        bool hasLegendaryTreasure = character.Inventory.Treasures.Any(t => t is LegendaryTreasure);
        if (hasLegendaryTreasure)
        {
            IsCompleted = true;
            return true;
        }
        return false;
    }
}
