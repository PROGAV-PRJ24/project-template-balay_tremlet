public class Inventory 
{

    public List<Treasure> Treasures { get; private set; } = new List<Treasure>();
    public int MaxWeight { get; private set; }
    public int CurrentWeight { get; private set; }

    public Inventory(){}

    public Inventory(Character character)
    {
        MaxWeight = character.InventoryWeight;
        CurrentWeight = 0;
    }

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
