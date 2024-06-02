public class PositiveTreasure3 : Treasure
{
    public override void ApplyEffect(Character character, Player player)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif: vous avez perdu vos faiblesses.");
        character.RemoveWeakness();
        player.Score+=5;
    }

}