public class EasyMission : Mission
{
    public EasyMission() : base ("Mission facile", "Faites plus de 50 pas", false)
    {
    }

    public override void DisplayMission()
    {
        Console.WriteLine("=== 1ère Mission  ===");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
              Console.WriteLine($"Status: {(IsCompleted ? "Completed" : "Incomplete")}");
        Console.WriteLine("=======================");
    }

    public override bool CheckCompletion(Character character, Boat boat, World world)
    {
        if (character.RollCount >= 10) // pas sure que ca marche 
        {
            IsCompleted = true;
            Console.WriteLine("Félicitations ! Vous avez complété la mission facile"); 
            return true;
        }

        return false;
    }
}
