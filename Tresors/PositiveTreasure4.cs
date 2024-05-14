public class PositiveTreasure4 : Treasure
{
    public override void ApplyEffect(Character character)
    {
        Console.WriteLine("Vous avez trouvé un trésor positif: vous avez un objet que vous pourrez échanger au bateau contre de la vie.");
        Inventory.AddTreasure()
        }

}