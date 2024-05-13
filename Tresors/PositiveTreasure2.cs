
public class PositiveTreasure2 : Treasure
{
    public override void ApplyEffect(Character character)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif: votre inventaire est augmenté de 1.");
        character.InventorySize += 1;
    }
}