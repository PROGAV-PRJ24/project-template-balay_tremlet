class Animal : Character
{
    public Animal(int id, bool unlock, int quantityEnergy, int inventoryWeight, int boatWeight) : base(id, unlock, quantityEnergy, 15, inventoryWeight, boatWeight, "Montagne", "Eau", "Saute de 2 cases")
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

    public override bool Move(string direction, int roll, World world, Character character, Player player)
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
        if (world.Mat[newX, newY] == 16)
        {
            Console.WriteLine("Vous avez atteint le bateau !");
            character.FileTreasure(world.Boat1);
            return false;
        } else {
            world.CheckFood(newX, newY, character);
            world.CheckTreasure(newX, newY, character, player);
            world.Mat[newX, newY] = 18;
            world.Mat[oldX, oldY] = oldPoint;
            player.Score+=roll;
            QuantityEnergy -= ManageEnergy;
            Console.WriteLine($"Votre animal (ID : {IdCharacter}) bouge vers le/la {direction}.");
            return true;
        }
    }






    public override bool Move1v1(string direction, int roll, World world, Character character, bool isJoueur1, Player player)
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
            if (world.Mat[newX, newY] == 16)
            {
                Console.WriteLine("Vous avez atteint le bateau !");
                character.FileTreasure(world.Boat1);
                return false;
            } else {
                world.CheckFood(newX, newY, character);
                world.CheckTreasure(newX, newY, character, player);
                world.Mat[newX, newY] = 18;
                world.Mat[oldX, oldY] = oldPoint;
                player.Score+=roll;
                QuantityEnergy -= ManageEnergy;
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
            if (world.Mat[newX, newY] == 17)
            {
                Console.WriteLine("Vous avez atteint le bateau !");
                character.FileTreasure(world.Boat2);
                return false;
            }else {
                world.CheckFood(newX, newY, character);
                world.CheckTreasure(newX, newY, character, player);
                world.Mat[newX, newY] = 19;
                world.Mat[oldX, oldY] = oldPoint;
                player.Score+=roll;
                QuantityEnergy -= ManageEnergy;
                Console.WriteLine($"Votre animal (ID : {IdCharacter}) bouge vers le/la {direction}.");
                return true;
            }
        }
    }

    public override void Save()
    {
        File.WriteAllText($"{IdCharacter}.txt", Unlock.ToString());
    }

    public override void SaveInventory ()
    {
        File.WriteAllText($"{IdCharacter}-Inventory.txt", $"{InventoryWeight}");
    }

}