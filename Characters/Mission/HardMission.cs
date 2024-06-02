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
                AddOnePieceTreasure(world);
                return true;
            }
        }
        return false;
    
    }

    public void AddOnePieceTreasure(World world)
    {
        Random random = new Random();
        int x, y;

        do
        {
            x = random.Next(0, world.Mat.GetLength(0));
            y = random.Next(0, world.Mat.GetLength(1));
        } while (world.Mat[x, y] != 1); 

        world.Mat[x, y] = 18; 
    }
}

