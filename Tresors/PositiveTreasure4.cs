public class PositiveTreasure4 : Treasure
{
    public PositiveTreasure4()
    {
        Name = "Hache";
        WeightTreasure = 10; 
    }

    //function which applys the treasure's effect
    public override void ApplyEffect(Character character, Player player)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif : vous avez trouvez une hache.");
        if (character.Inventory.AddTreasure(this))
        {
            Console.WriteLine("Félicitations ! Vous devez rapporter au bateau pour compléter la mission.");
            player.Score+=5;
        }
        
    }
}
