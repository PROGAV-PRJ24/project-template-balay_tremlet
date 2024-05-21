public class PositiveTreasure4 : Treasure
{
    public PositiveTreasure4()
    {
        Name = "Hache";
        WeightTreasure = 10; 
    }

    public override void ApplyEffect(Character character)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif : vous avez gagné une hache que vous devez rapporter au bateau pour compléter la mission.");
        character.Inventory.AddTreasure(this);
    }
}
