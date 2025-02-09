public class HardMission : Mission
{
    
    public HardMission() : base ("Mission difficile", "Trouver et rapporter la hache au bateau qui est un trésor rare", false)
    {
    }
    
    //function which displays missions caracteristics
    public override void DisplayMission()
    {
        Console.WriteLine("=== 3ème Mission  ===");
        Console.WriteLine($"Nom: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Status: {(IsCompleted ? "Complété" : "Incomplète")}");
        Console.WriteLine("=======================");
    }

    //function which checks if the mission is completed
    public override bool CheckCompletion(Character character, Boat boat, World world, Player player)
    {

        foreach (Treasure treasure in boat.Treasures)
        {
            if (treasure.Name == "Hache")
            {
                IsCompleted = true;
                player.Score+=10;
                Console.WriteLine("Félicitations ! Vous avez complété la mission difficile en trouvant et rapportant la hache au bateau. "); 
              

                return true;
            }
        }
        return false;
    
    }

 
}


