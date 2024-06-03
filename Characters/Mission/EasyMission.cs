public class EasyMission : Mission
{
    public EasyMission() : base ("Mission facile", "Faites plus de 50 pas", false)
    {
    }

    public override void DisplayMission()
    {
        Console.WriteLine("=== 1ère Mission  ===");
        Console.WriteLine($"Nom: {Name}");
        Console.WriteLine($"Description: {Description}");
              Console.WriteLine($"Status: {(IsCompleted ? "Complété" : "Incomplète")}");
        Console.WriteLine("=======================");
    }

    public override bool CheckCompletion(Character character, Boat boat, World world, Player player)
    {
        if (character.RollCount >= 10)
        {
            IsCompleted = true;
            player.Score+=5;
            Chamois Chamois = new Chamois();
            Chamois.Unlock = true;
            Chamois.Save();
            Console.WriteLine("Félicitations ! Vous avez complété la mission facile et débloqué le personnage Chamois !"); 
            return true;
        }

        return false;
    }
}
