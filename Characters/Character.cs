public abstract class Character
{
    public Inventory Inventory;
    public bool Unlock { get; set; }
    public int QuantityEnergy { get; set; }
    public int ManageEnergy { get; set; }
    public int InventoryWeight { get; set; }
    public int BoatWeight { get; set; }
    public string StrongPoint { get; set; }
    public string WeakPoint { get; set; }
    public string Movement { get; protected set; }
    public int IdCharacter { get; private set; }
    public int IdWeakness1;
    public int IdWeakness2;
/*     public Boat Boat { get; set; } // Référence vers le bateau associé au personnage */

   
    private static int characterIdCounter = 1;


    public Character(bool unlock, int quantityEnergy, int manageEnergy, int inventoryWeight, int boatWeight, string weakPoint, string strongPoint, string movement)
    {
        Unlock = unlock;
        QuantityEnergy = quantityEnergy;
        ManageEnergy = manageEnergy;
        InventoryWeight = inventoryWeight;
        BoatWeight = boatWeight;
        StrongPoint = strongPoint;
        WeakPoint = weakPoint;
        Movement = movement;
        IdCharacter = characterIdCounter++;
        Inventory Inventory = new Inventory();
    }

  
    public abstract void DisplayCharacter(Character character);

    public abstract bool Move(string direction, int roll, World world, Character character);


    public abstract bool Move1v1(string direction, int roll, World world, Character character, bool isJoueur1);

    public void Weakness (Character character) {

        switch (character.WeakPoint.ToLower())
        {
            case "montagne":
                IdWeakness1 = 2;
                IdWeakness2 = 500;
                break;
            case "eau":
                IdWeakness1 = 0;
                IdWeakness2 = 500;
                break;
            case "montagne/eau":
                IdWeakness1 = 2;
                IdWeakness2 = 0;
                break;
            default:
                Console.WriteLine("Weakness invalide");
                return;
        }
    }

    public virtual void DisplayEnergy()
    {
        int maxEnergy = QuantityEnergy; 
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


    // public virtual void DisplayBagpack()
    // {
    //     Console.WriteLine($"Votre sac à dos peut contenir {InventorySize} objets et vous avez maintenant {InventoryWeight} objets.");

    // }


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



    
   /*  public void MoveBoat(string direction)
    {
        if (Boat != null)
        {
            Boat.Move(direction);
        }
        else
        {
            Console.WriteLine($"Le personnage (ID : {IdCharacter}) n'a pas de bateau associé.");
        }
    }
}
 */