public class Inventory 
{

    public List<Treasure> Treasures { get; set; } = new List<Treasure>();
    public int MaxWeight { get; private set; }
    public int CurrentWeight { get; set; }

    public Inventory(){}

    public Inventory(int maxWeight)
    {
        MaxWeight = maxWeight;
        CurrentWeight = 0;
    }

    //function which adds treasure in the inventory
    public bool AddTreasure(Treasure treasure)
    {
        if (CurrentWeight + treasure.WeightTreasure <= MaxWeight)
        {
            Treasures.Add(treasure);
            CurrentWeight += treasure.WeightTreasure;
            return true;
        }
        else
        {
            Console.WriteLine("L'inventaire est plein, impossible d'ajouter le trésor.");
            return false;
        }
    }

    //function which removes treasure in the inventory
    public bool RemoveTreasure(Treasure treasure)
    {
        if (Treasures.Contains(treasure))
        {
            Treasures.Remove(treasure);
            CurrentWeight -= treasure.WeightTreasure;
            return true;
        }
        else
        {
            Console.WriteLine("L'inventaire est vide.");
            return false;
        }
    }

    //function which displays treasure in the inventory
    public void DisplayInventory()
    {
        Console.WriteLine("Contenu de l'inventaire :");
        if (Treasures.Count == 0)
        {
            Console.WriteLine("L'inventaire est vide.");
        }
        else
        {
            foreach (Treasure treasure in Treasures)
            {
                Console.WriteLine($"- {treasure.Name} ({treasure.WeightTreasure} kg)");
            }
        }
        Console.WriteLine($"Poids total : {CurrentWeight} kg / {MaxWeight} kg");
    }
}
