class Human : Character
{
    public Human() : base(true, 100, 10, 20, 50, "Intelligence", "Eau", "Lignes droites")
    {
    }


    public override void DisplayCharacter()
    {
        Console.WriteLine($"ID : {IdCharacter}");
        Console.WriteLine($"Débloqué ? : {IdCharacter}");
        Console.WriteLine($"Quantité d'énergie : {QuantityEnergy}");
        Console.WriteLine($"Taille de l'inventaire : {InventorySize}");
        Console.WriteLine($"Poids de l'inventaire : {InventoryWeight}");
        Console.WriteLine($"Point fort : {StrongPoint}");
        Console.WriteLine($"Point faible : {WeakPoint}");
        Console.WriteLine($"Déplacement : {Movement}");
    }

    public override void Move(string direction, int roll, World world)
    {
        int newX = -1;
        int newY = -1;

        switch (direction.ToLower())
        {
            case "gauche":
                newX = world.GetCharacterX() ;
                newY = world.GetCharacterY() - roll;
                break;
            case "droite":
                newX = world.GetCharacterX() ;
                newY = world.GetCharacterY() + roll;
                break;
            case "haut":
                newX = world.GetCharacterX()  - roll;
                newY = world.GetCharacterY();
                break;
            case "bas":
                newX = world.GetCharacterX() + roll;
                newY = world.GetCharacterY() ;
                break;
            default:
                Console.WriteLine("Direction invalide");
                return;
        }

        if (newX >= 0 && newX < world.Mat.GetLength(0) && newY >= 0 && newY < world.Mat.GetLength(1) && world.Mat[newX, newY] != 2)
        {
            world.Mat[world.GetCharacterX(), world.GetCharacterY()] = 1; 
            world.Mat[newX, newY] = 17;
            QuantityEnergy-= 10;
            Console.WriteLine($"Votre human (ID : {IdCharacter}) bouge vers le/la {direction}.");

        }
        else
        {
            Console.WriteLine("Impossible de se déplacer dans cette direction");
        }
    }
}