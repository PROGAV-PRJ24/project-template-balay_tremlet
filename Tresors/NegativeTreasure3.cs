public class NegativeTreasure3 : Treasure
{
    public override void ApplyEffect(Character character)
    {
        bool résoudreÉnigme = DemanderEnigme(0);

        if (résoudreÉnigme && RésoudreEnigme())
        {
            Console.WriteLine("Bravo ! Vous avez évité l'effet négatif du trésor.");
        }
        else
        {
            Console.WriteLine("Vous subissez l'effet négatif du trésor: le poids de votre inventaire est réduit de 1.");
            character.InventoryWeight -= 1;
        }
    }
}
