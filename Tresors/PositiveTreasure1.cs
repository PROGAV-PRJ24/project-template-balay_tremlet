public class PositiveTreasure1 : Treasure
{
    public override void ApplyEffect(Character character, Player player)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif: votre energie est augmentée de 20.");
        character.QuantityEnergy += 20;
        player.Score+=5;
    }
}