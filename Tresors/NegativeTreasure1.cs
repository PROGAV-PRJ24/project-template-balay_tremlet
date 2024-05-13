public class NegativeTreasure1 : Treasure
{
    public override void ApplyEffect(Character character)
    {
       bool résoudreÉnigme = DemanderEnigme(0); // Demander à résoudre une énigme spécifique

        if (résoudreÉnigme && RésoudreEnigme())
        {
     
            Console.WriteLine("Bravo ! Vous avez évité l'effet négatif du trésor.");
        }
        else
        {
            
            Console.WriteLine("Vous subissez l'effet négatif du trésor: votre energie est réduit de 20.");
            character.QuantityEnergy -= 20;


        }  
    }
}
