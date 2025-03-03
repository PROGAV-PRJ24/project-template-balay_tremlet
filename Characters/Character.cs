public abstract class Character
{
    public Inventory Inventory;
    public bool Unlock { get; set; }
    public int QuantityEnergy { get; set; }
    public int ManageEnergy { get; set; }
    public int MaxQuantityEnergy{ get;set;}
    public int InventoryWeight { get; set; }
    public int BoatWeight { get; set; }
    public string StrongPoint { get; set; }
    public string WeakPoint { get; set; }
    public string Movement { get; protected set; }
    public int IdCharacter { get; private set; }
    public int IdWeakness1;
    public int IdWeakness2;
    public int RollCount { get; set; }
    public int EnergyCount {get; set;}
    // public Boat Boat { get; set; } // Référence vers le bateau associé au personnage


    public Character(int id, bool unlock, int quantityEnergy, int manageEnergy, int inventoryWeight, int boatWeight, string weakPoint, string strongPoint, string movement)
    {
        Unlock = unlock;
        QuantityEnergy = quantityEnergy;
        ManageEnergy = manageEnergy;
        InventoryWeight = inventoryWeight;
        BoatWeight = boatWeight;
        StrongPoint = strongPoint;
        WeakPoint = weakPoint;
        MaxQuantityEnergy = quantityEnergy;
        Movement = movement;
        IdCharacter = id;
        Inventory = new Inventory(InventoryWeight);
        RollCount = 0;
        EnergyCount = 0;

    }

    //function which display characters caracteristics
    public abstract void DisplayCharacter(Character character);

    // function which save the setting size inventory of the character
    public abstract void SaveInventory();

    // function which save the setting unlock of the character
    public abstract void Save();

    //function which move the character in function of the direction
    public abstract bool Move(string direction, int roll, World world, Character character, Player player);

    //function which move the character in function of the direction for the 1v1 game
    public abstract bool Move1v1(string direction, int roll, World world, Character character, bool isJoueur1, Player player);

    //function which determines the chatacter's weakness 
    public void Weakness (Character character) {

        switch (character.WeakPoint)
        {
            case "Montagne":
                IdWeakness1 = 2;
                IdWeakness2 = 500;
                break;
            case "Eau":
                IdWeakness1 = 0;
                IdWeakness2 = 500;
                break;
            case "Montagne/Eau":
                IdWeakness1 = 2;
                IdWeakness2 = 0;
                break;
            case "Foret":
                IdWeakness1 = 1;
                IdWeakness2 = 500;
                break;
            default:
                Console.WriteLine("Weakness invalide");
                return;
        }
    }

    //function which removes the character's weakness
    public void RemoveWeakness()
    {
      
        IdWeakness2 = -1;
    }

    //function which displays the character's energy
    public virtual void DisplayEnergy()
    {
        int maxEnergy = MaxQuantityEnergy ; 
        int barSize = 20; 
        int energyPerBar = 5; 

        int fullBars = QuantityEnergy / energyPerBar;
        int remainingEnergy = QuantityEnergy % energyPerBar;

        Console.Write($"L'energie restante de votre personnage est : ");

        for (int i = 0; i < fullBars; i++)
        {
            Console.Write("■"); 
        }

        if (remainingEnergy > 0)
        {
            Console.Write("□"); 
        }

        for (int i = fullBars + (remainingEnergy > 0 ? 1 : 0); i < barSize; i++)
        {
            Console.Write(" "); 
        }
        
        Console.Write($" ({QuantityEnergy}/{maxEnergy})");
    }

    //function which drops treasures in the boat
    public void FileTreasure(Boat boat)
    {
        if (Inventory.CurrentWeight > 0)
        {
            foreach (Treasure treasure in Inventory.Treasures)
            {
                boat.AddTreasure(treasure);
            }

            Inventory.Treasures.Clear();
            Inventory.CurrentWeight = 0;

            Console.WriteLine($"Votre {GetType().Name} (ID : {IdCharacter}) a déposé ses trésors dans le bateau !");
        }
        else
        {
            Console.WriteLine($"Votre {GetType().Name} (ID : {IdCharacter}) ne possède pas de trésors à déposer.");
        }
    }

}
