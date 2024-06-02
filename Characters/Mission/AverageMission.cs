public class AverageMission : Mission
{
    public AverageMission() : base ("Mission moyenne", "Récupérer 40 d'énergies", false)
    {
    }

    public override void DisplayMission()
    {
        Console.WriteLine("=== 2ème Mission  ===");
        Console.WriteLine($"Nom: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplète")}");
        Console.WriteLine("=======================");
    }

    public override bool CheckCompletion(Character character, Boat boat, World world, Player player)
    {
        if (character.EnergyCount >= 40)
        {
            IsCompleted = true;
            player.Score += 5;
            Console.WriteLine("Félicitations ! Vous avez complété la mission moyenne"); 
            return true;
        }

        return false;
    }
}
