
public class PositiveTreasure2 : Treasure
{
    public override void ApplyEffect(Character character)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif: le poids de votre bateau est augmenté de 1.");
        character.BoatWeight += 1;
    }
}