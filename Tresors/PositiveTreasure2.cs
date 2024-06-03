
public class PositiveTreasure2 : Treasure
{
    public override void ApplyEffect(Character character, Player player)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif: le poids de votre inventaire est augmenté de 1.");
        character.InventoryWeight += 1;
        character.Save();
        player.Score+=5;
    }
}