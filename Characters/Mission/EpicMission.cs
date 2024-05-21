public class EpicMission : Mission
{
    public EpicMission()
    {
        Name = "Mission très difficile";
        Description = "Trouver le one piece ";
        IsCompleted = false;
    }

    public override void DisplayMission()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public override bool CheckCompletion(Character character,Boat boat)
    {
     // Le one piece Devra être rajouter et unlock tout les personnages. 
     //On peut rajouter des indices pour trouver le one piece qui sera toujours au même endroit. Il sera présent que si les missions d'avant sont complétées.
        return false;
    }
}
