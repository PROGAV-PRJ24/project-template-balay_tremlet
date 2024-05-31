public class EpicMission : Mission
{
    public EpicMission()
    {
        Name = "Mission très difficile";
        Description = "Trouver le One Piece";
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine("=== 3ème Mission  ===");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplete")}");
        Console.WriteLine("=======================");
    }

    public override bool CheckCompletion(Character character, Boat boat)
    {
        foreach (Treasure treasure in boat.Treasures)
        {
            if (treasure.Name == "One Piece")
            {
                IsCompleted = true;
                Console.WriteLine("Félicitations ! Vous avez complété la mission très difficile en trouvant le One Piece.");
                return true;
            }
        }
        return false;
    }
}
