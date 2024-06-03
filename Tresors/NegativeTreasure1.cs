public class NegativeTreasure1 : Treasure
{

    //function which applys the treasure's effect
    public override void ApplyEffect(Character character, Player player)
    {
       bool résoudreÉnigme = DemanderEnigme(0); 

        if (résoudreÉnigme && RésoudreEnigme())
        {
            
            Console.WriteLine("Bravo ! Vous avez évité l'effet négatif du trésor.");
        }
        else
        {
            Console.WriteLine("Vous subissez l'effet négatif du trésor: votre energie est réduit de 20.");
            character.QuantityEnergy -= 20;
            player.Score-=5;
        }  
    }
}
