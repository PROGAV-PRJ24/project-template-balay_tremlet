public abstract class Character
{
    public bool Unlock { get; set; }
    public int QuantityEnergy { get; set; }
    public int ManageEnergy { get; set; }
    public int InventorySize { get; set; }
    public int InventoryWeight { get; set; }
    public string StrongPoint { get; set; }
    public string WeakPoint { get; set; }
    public int LifePoint { get; set; }
    public string Movement { get; protected set; }
    public int IdCharacter { get; private set; }
    public int IdWeakness1;
    public int IdWeakness2;
/*     public Boat Boat { get; set; } // Référence vers le bateau associé au personnage */

   
    private static int characterIdCounter = 1;


    public Character(bool unlock, int quantityEnergy, int manageEnergy, int inventorySize, int inventoryWeight, string weakPoint, string strongPoint,int lifePoint, string movement)
    {
        Unlock = unlock;
        QuantityEnergy = quantityEnergy;
        ManageEnergy = manageEnergy;
        InventorySize = inventorySize;
        InventoryWeight = inventoryWeight;
        StrongPoint = strongPoint;
        WeakPoint = weakPoint;
        LifePoint = lifePoint;
        Movement = movement;
        IdCharacter = characterIdCounter++;
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
        int maxEnergy = 100; 
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