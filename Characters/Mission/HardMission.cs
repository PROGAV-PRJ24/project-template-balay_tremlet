public class HardMission : Mission
{
    public HardMission()
    {
        Name = "Mission difficile";
        Description = "trouver et rapporter la hache au bateau qui est un trésor rare";
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public override bool CheckCompletion(Character character, Boat boat)
    {

        foreach (Treasure treasure in boat.Treasures)
        {
            if (treasure.Name == "Hache")
            {
                IsCompleted = true;
                return true;
                Console.WriteLine("Félicitations ! Vous avez complété la mission difficile en trouvant et rapportant la hache au bateau. "); //annoncer la prochaine mission

            }
        }
        return false;
    }
}
