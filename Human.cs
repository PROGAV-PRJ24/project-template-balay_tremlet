class Human : Character
{

    public Human(bool unlock, int quantityEnergy, int inventorySize, int inventoryWeight) : base(unlock, quantityEnergy, 10, inventorySize, inventoryWeight, "Eau", "Montagne", "Lignes droites")
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
                newX = oldX ;
                newY = oldY - roll;
                break;
            case "droite":
                newX = oldX ;
                newY = oldY + roll;
                break;
            case "haut":
                newX = oldX  - roll;
                newY = oldY;
                break;
            case "bas":
                newX = oldX + roll;
                newY = oldY ;
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
        if ( world.Mat[newX, newY] == IdWeakness1 || world.Mat[newX, newY] == IdWeakness2)
        {
            Console.WriteLine($"Votre humain (ID : {IdCharacter}) ne pas aller dans {WeakPoint}.");
            return false;

        } else {
            world.CheckFood(newX, newY,character);
            world.Mat[newX, newY] = 17;
            world.Mat[oldX, oldY] = oldPoint;
            QuantityEnergy -= ManageEnergy;
            Console.WriteLine($"Votre human (ID : {IdCharacter}) bouge vers le/la {direction}.");
            return true;
        }
    }
}