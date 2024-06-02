
public class OnePieceTreasure : Treasure
{
    public OnePieceTreasure()
    {
        Name = "One Piece";
        WeightTreasure = 10;
    }

    public override void ApplyEffect(Character character)
    {
        Console.WriteLine("Vous avez trouvé le One Piece !");
        if (character.Inventory.AddTreasure(this)){
            Console.WriteLine("Félicitations ! Vous devez le rapporter au bateau pour compléter la mission.");
        }
        
    }
}
