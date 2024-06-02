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
       for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 1 && random.NextDouble() < 0.01) // 1% de chance d'avoir le trésor OnePiece
                {
                    Mat[i, j] = 11; 
                }
            }
        }
}

}
