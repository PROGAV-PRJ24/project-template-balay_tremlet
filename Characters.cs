public abstract class Character
{
    public bool Unlock { get; set; }
    public int QuantityEnergy { get; set; }
    public int ManageEnergy { get; set; }
    public int InventorySize { get; set; }
    public int InventoryWeight { get; set; }
    public string StrongPoint { get; set; }
    public string WeakPoint { get; set; }
    public string Movement { get; protected set; }
    public int IdCharacter { get; private set; }
    public int IdWeakness1;
    public int IdWeakness2;
/*     public Boat Boat { get; set; } // Référence vers le bateau associé au personnage */

   
    private static int characterIdCounter = 1;


    public Character(bool unlock, int quantityEnergy, int manageEnergy, int inventorySize, int inventoryWeight, string weakPoint, string strongPoint, string movement)
    {
        Unlock = unlock;
        QuantityEnergy = quantityEnergy;
        ManageEnergy = manageEnergy;
        InventorySize = inventorySize;
        InventoryWeight = inventoryWeight;
        StrongPoint = strongPoint;
        WeakPoint = weakPoint;
        Movement = movement;
        IdCharacter = characterIdCounter++;
    }

  
    public abstract void DisplayCharacter();

    public abstract void Move(string direction, int roll, World world);

    public void Weakness () {

        switch (WeakPoint.ToLower())
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
            default:
                Console.WriteLine("Weakness invalide");
                return;
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