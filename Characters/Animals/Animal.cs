class Animal : Character
{
    public Animal(bool unlock, int quantityEnergy, int inventoryWeight, int boatWeight) : base(unlock, quantityEnergy, 15, inventoryWeight, boatWeight, "Montagne", "Eau", "Saute de 2 cases")
    {
    }

    public override void DisplayCharacter(Character character)
    {
        Console.WriteLine($"ID : {IdCharacter}");
        Console.WriteLine($"Débloqué ? : {Unlock}");
        Console.WriteLine($"Quantité d'énergie : {QuantityEnergy}");
        Console.WriteLine($"Poids de l'inventaire : {InventoryWeight} kg");
        Console.WriteLine($"Poids du bateau : {BoatWeight} kg");
        Console.WriteLine($"Point fort : {StrongPoint}, Arbre");
        Console.WriteLine($"Point faible : {WeakPoint}");
        Console.WriteLine($"Déplacement : {Movement}");
        Weakness(character);
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
                newY = world.GetCharacterY() - roll * 2;
                break;
            case "droite":
                newX = world.GetCharacterX() ;
                newY = world.GetCharacterY() + roll * 2;
                break;
            case "haut":
                newX = world.GetCharacterX()  - roll * 2;
                newY = world.GetCharacterY();
                break;
            case "bas":
                newX = world.GetCharacterX() + roll * 2;
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
        if ( world.Mat[newX, newY] == IdWeakness1 || world.Mat[newX, newY] == IdWeakness2)
        {
            Console.WriteLine($"Votre animal (ID : {IdCharacter}) ne pas aller dans {WeakPoint}.");
            return false;


        }           
        if (world.Mat[newX, newY] == 14)
        {
            Console.WriteLine("Vous avez atteint le bateau !");
            character.FileTreasure(world.Boat1);
            return false;
        } else {
            world.Mat[newX, newY] = 17;
            world.Mat[oldX, oldY] = oldPoint;
            QuantityEnergy -= ManageEnergy;
            world.CheckFood(newX, newY, character);
            Console.WriteLine($"Votre animal (ID : {IdCharacter}) bouge vers le/la {direction}.");
            return true;
        }
    }






    public override bool Move1v1(string direction, int roll, World world, Character character, bool isJoueur1)
    {
        if(isJoueur1){


            int oldX = world.GetCharacterX();
            int oldY = world.GetCharacterY();


            int oldPoint = world.IsInCircle(oldX, oldY) ? 1 : 0;


            int newX = -1;
            int newY = -1;


            switch (direction.ToLower())
            {
                case "gauche":
                    newX = world.GetCharacterX() ;
                    newY = world.GetCharacterY() - roll * 2;
                    break;
                case "droite":
                    newX = world.GetCharacterX() ;
                    newY = world.GetCharacterY() + roll * 2;
                    break;
                case "haut":
                    newX = world.GetCharacterX()  - roll * 2;
                    newY = world.GetCharacterY();
                    break;
                case "bas":
                    newX = world.GetCharacterX() + roll * 2;
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
            if ( world.Mat[newX, newY] == IdWeakness1 || world.Mat[newX, newY] == IdWeakness2)
            {
                Console.WriteLine($"Votre animal (ID : {IdCharacter}) ne pas aller dans {WeakPoint}.");
                return false;


            } 
            if (world.Mat[newX, newY] == 14)
            {
                Console.WriteLine("Vous avez atteint le bateau !");
                character.FileTreasure(world.Boat1);
                return false;
            }else {
                world.Mat[newX, newY] = 17;
                world.Mat[oldX, oldY] = oldPoint;
                QuantityEnergy -= ManageEnergy;
                world.CheckFood(newX, newY, character);
                Console.WriteLine($"Votre animal (ID : {IdCharacter}) bouge vers le/la {direction}.");
                return true;
            }


        } else {
            int oldX = world.GetCharacter2X();
            int oldY = world.GetCharacter2Y();


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
                Console.WriteLine($"Votre animal (ID : {IdCharacter}) ne pas aller dans {WeakPoint}.");
                return false;


            } 
            if (world.Mat[newX, newY] == 15)
            {
                Console.WriteLine("Vous avez atteint le bateau !");
                character.FileTreasure(world.Boat2);
                return false;
            }else {
                world.Mat[newX, newY] = 16;
                world.Mat[oldX, oldY] = oldPoint;
                QuantityEnergy -= ManageEnergy;
                world.CheckFood(newX, newY, character);
                Console.WriteLine($"Votre animal (ID : {IdCharacter}) bouge vers le/la {direction}.");
                return true;
            }
        }
    }

}