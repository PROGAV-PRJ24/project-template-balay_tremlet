public class EasyMission : Mission
{
    public EasyMission()
    {
        Name = "Mission facile";
        Description = "Faites plus de 50 pas";
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public override bool CheckCompletion(Character character, Boat boat)
    {
        if (character.RollCount >= 50) // pas sure que ca marche 
        {
            IsCompleted = true;
            return true;
        }

        return false;
    }
}
