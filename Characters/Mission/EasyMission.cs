public class EasyMission : Mission
{
    public EasyMission()
    {
        Name = "Mission facile";
        Description = "Fait plus de 50 lancers de dé";
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public override bool CheckCompletion(Character character)
    {
        
        
      //  PlayGame.PlayTurn(rollCount)  comment récupérer la valeur de Roll Count
// unlock un autre personnage
  
        if (rollCount >= 50)
        {
            IsCompleted = true;
            return true;
        }

        return false;
    }
}
