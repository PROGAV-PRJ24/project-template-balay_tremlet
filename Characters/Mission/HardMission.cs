public class HardMission : Mission
{
    
    public HardMission() : base ("Mission difficile", "Trouver et rapporter la hache au bateau qui est un trésor rare", false)
    {
    }
    

    public override void DisplayMission()
    {
        Console.WriteLine("=== 2eme Mission  ===");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completé" : "Pas complété")}");
        Console.WriteLine("=======================");
    }

    public override bool CheckCompletion(Character character, Boat boat, World world)
    {

        foreach (Treasure treasure in boat.Treasures)
        {
            if (treasure.Name == "Hache")
            {
                IsCompleted = true;
              
                Console.WriteLine("Félicitations ! Vous avez complété la mission difficile en trouvant et rapportant la hache au bateau. "); 
              

                return true;
            }
        }
        return false;
    
    }

 
}


