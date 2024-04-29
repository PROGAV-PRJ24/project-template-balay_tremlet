public abstract class Character
{
    public bool Unlock { get; set; }
    public int QuantityEnergy { get; set; }
    public int ManageEnergy { get; set; }
    public int Size { get; set; }
    public int Weight { get; set; }
    public string StrongPoint { get; set; }
    public string WeakPoint { get; set; }
    public string Movement { get; protected set; }
    public int IdCharacter { get; private set; }
    public Boat Boat { get; set; } // Référence vers le bateau associé au personnage

   
    private static int characterIdCounter = 1;

   
    public Character()
    {
    
        IdCharacter = characterIdCounter++;
    }

  
    public abstract void DisplayCharacter();


    public abstract void Move(string direction);


    public void MoveBoat(string direction)
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
