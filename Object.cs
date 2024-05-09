class Object : Character
{
    public Object(bool unlock, int inventorySize, int inventoryWeight) : base(unlock, 500, 5, inventorySize, inventoryWeight, "Non", "Montagne/Eau", "Zigzag")
    {
    }

    public override void DisplayCharacter()
    {
        Console.WriteLine($"ID : {IdCharacter}");
        Console.WriteLine($"Débloqué ? : {Unlock}");
        Console.WriteLine($"Quantité d'énergie : {QuantityEnergy}");
        Console.WriteLine($"Taille de l'inventaire : {InventorySize}");
        Console.WriteLine($"Poids de l'inventaire : {InventoryWeight}");
        Console.WriteLine($"Point fort : {StrongPoint}");
        Console.WriteLine($"Point faible : {WeakPoint}");
        Console.WriteLine($"Déplacement : {Movement}");
    }

    public override bool Move(string direction, int roll, World world, Character character)
    {
        int oldX = world.GetCharacterX();
        int oldY = world.GetCharacterY();

        int oldPoint = world.IsInCircle(oldX, oldY) ? 1 : 0;

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
                return false;
        }

        if (newX < 0 || newX >= world.Mat.GetLength(0) || newY < 0 || newY >= world.Mat.GetLength(1))
        {
            Console.WriteLine("Impossible de se déplacer dans cette direction");
            return false;

        }
         if (world.Mat[newX, newY] == 3)
        {
            Console.WriteLine($"Votre object (ID : {IdCharacter}) ne peut pas traverser les arbres.");
            return false;
            
        }
        if (world.Mat[newX, newY] == 2)
        {
            Console.WriteLine($"Votre object (ID : {IdCharacter}) ne peut pas traverser les montagnes.");
            return false;
        }
        if ( world.Mat[newX, newY] == IdWeakness1 || world.Mat[newX, newY] == IdWeakness2)
        {
            Console.WriteLine($"Votre object (ID : {IdCharacter}) ne pas aller dans {WeakPoint}.");
            return false;

        } else {
            world.Mat[newX, newY] = 17;
            world.Mat[oldX, oldY] = oldPoint;
            QuantityEnergy -= ManageEnergy;
            world.CheckFood(newX, newY,character);
            Console.WriteLine($"Votre object (ID : {IdCharacter}) bouge vers le/la {direction}.");
            return true;
        }
    }
}