public class Boat
{
    public List<Treasure> Treasures { get; private set; } = new List<Treasure>();
    public int WeightBoat { get; private set; }
    public int CurrentWeightBoat { get; private set; }

    public Boat()
    {
        CurrentWeightBoat = 0;
    }

    //function which adds treasure in the boat
    public bool AddTreasure(Treasure treasure)
    {
        if (CurrentWeightBoat + treasure.WeightTreasure <= WeightBoat)
        {
            Treasures.Add(treasure);
            CurrentWeightBoat += treasure.WeightTreasure;
            return true;
        }
        else
        {
            Console.WriteLine("Le bateau est plein, impossible d'ajouter le trésor.");
            return false;
        }
    }

    //function which removes treasure in the boat
    public bool RemoveTreasure(Treasure treasure)
    {
        if (Treasures.Contains(treasure))
        {
            Treasures.Remove(treasure);
            CurrentWeightBoat -= treasure.WeightTreasure;
            return true;
        }
        else
        {
            Console.WriteLine("Le bateau est vide.");
            return false;
        }
    }

    //function which displays treasures in the boat
    public void DisplayBoat()
    {
        Console.WriteLine("Contenu du bateau :");
        if (Treasures.Count == 0)
        {
            Console.WriteLine("Le bateau est vide.");
        }
        else
        {
            foreach (Treasure treasure in Treasures)
            {
                Console.WriteLine($"- {treasure.Name} ({treasure.WeightTreasure} kg)");
            }
        }
        Console.WriteLine($"Poids total : {CurrentWeightBoat} kg / {WeightBoat} kg");
    }
}
