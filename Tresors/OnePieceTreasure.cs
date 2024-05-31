
public class OnePieceTreasure : Treasure
{
    public OnePieceTreasure()
    {
        Name = "One Piece";
        WeightTreasure = 20;
    }

    public override void ApplyEffect(Character character)
    {
        Console.WriteLine("Vous avez trouvé le One Piece ! Félicitations ! Vous devez le rapporter au bateau pour compléter la mission.");
        character.Inventory.AddTreasure(this);
    }
}
