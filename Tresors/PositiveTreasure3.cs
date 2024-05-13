public class PositiveTreasure3 : Treasure
{
    public PositiveTreasure3() : base(1)
    {
    }

    public override void ApplyEffect(Character character)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif: vous avez gagné un nouvel outil.");

        //.....
        // inventory.AddTreasure(tresor);
    
    }
}