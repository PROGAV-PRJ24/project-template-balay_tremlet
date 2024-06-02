public class EpicMission : Mission
{
    public EpicMission() : base ("Mission très difficile", "Trouver le One Piece", false)
    {
    }

    public override void DisplayMission()
    {
        Console.WriteLine("=== 4ème Mission  ===");
        Console.WriteLine($"Nom: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplète")}");
        Console.WriteLine("=======================");
    }

    public override bool CheckCompletion(Character character, Boat boat, World world, Player player)
    {
        foreach (Treasure treasure in boat.Treasures)
        {
            if (treasure.Name == "One Piece")
            {
                IsCompleted = true;
                player.Score+=15;
                Console.WriteLine("Félicitations ! Vous avez complété la mission très difficile en trouvant le One Piece.");
                return true;
            }
        }
        return false;
    }
}
