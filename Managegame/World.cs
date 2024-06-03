public class World
{
    public int Treasure { get; set; }
    public int[,] Mat { get; set; }
    public int CharacterX { get; set; }
    public int CharacterY { get; set; }
    public int Character2X { get; set; }
    public int Character2Y { get; set; }
    public int CenterX { get; set; }
    public int CenterY { get; set; }
    public int Radius { get; set; }
    public string CaseName { get; set; }
    public bool IsSolo { get; set; }
    public Boat Boat1 { get; private set; }
    public Boat Boat2 { get; private set; }

    public World(bool isSolo)
    {
        IsSolo = isSolo;
        Mat = new int[30, 30];
        Treasure = 0;
        CenterX = Mat.GetLength(0) / 2;
        CenterY = Mat.GetLength(1) / 2;
        Radius = 12;
        CaseName="";
        Boat1 = new Boat();
        Boat2 = new Boat();
        InitialiseWorld();

        if (IsSolo)
        {
            GetCharacterX();
            GetCharacterY();
        }
        else
        {
            GetCharacterX();
            GetCharacterY();
            GetCharacter2X();
            GetCharacter2Y();
        }
    }

    //function which initializes the matrix with elements id
    public void InitialiseWorld()
    {
        Random random = new Random();
        // Initialise la matrice avec des zéros (mer)
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                Mat[i, j] = 0;
            }
        }

        // Crée une forme de base pour l'île en utilisant des cercles
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                int distance = (int)Math.Sqrt(Math.Pow(i - CenterX, 2) + Math.Pow(j - CenterY, 2));
                if (distance <= Radius)
                {
                    Mat[i, j] = 1; // terre
                }
            }
        }

        // Ajoute des montagnes sur la terre
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 1 && random.NextDouble() < 0.05) // 5% de chance d'avoir une montagne
                {
                    Mat[i, j] = 2; // montagne
                }
            }
        }

        // Ajoute des arbres sur la terre
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 1 && random.NextDouble() < 0.1) // 10% de chance d'avoir un arbre
                {
                    Mat[i, j] = 3; // arbre
                }
            }
        }

        // Ajoute des trésors positifs sur les montagnes
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 2 && random.NextDouble() < 0.30) // 30% de chance d'avoir un trésor positif
                {
                    int positiveTreasure = random.Next(4, 8); // valeurs de 4 à 7 pour différents trésors positifs
                    Mat[i, j] = positiveTreasure;
                }
            }
        }

        // Ajoute le trésor OnePiece sur la terre
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 1 && random.NextDouble() < 0.01) // 1% de chance d'avoir le trésor OnePiece
                {
                    Mat[i, j] = 11;
                }
            }
        }

        // Ajoute des trésors négatifs sur les montagnes
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 2 && random.NextDouble() < 0.2) // 20% de chance d'avoir un trésor négatif
                {
                    int negativeTreasure = random.Next(8, 11); // valeurs de 8 à 10 pour différents trésors négatifs
                    Mat[i, j] = negativeTreasure;
                }
            }
        }

        // Ajoute le trésor spécial OnePiece
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 1 && random.NextDouble() < 0.01) // 1% de chance d'avoir le trésor OnePiece
                {
                    Mat[i, j] = 11; // valeur pour le trésor OnePiece
                }
            }
        }

        // Ajoute de la nourriture sur la terre
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 1 && random.NextDouble() < 0.15) // 15% de chance d'avoir de la nourriture
                {
                    int food = random.Next(13, 16); // Génère un nombre aléatoire entre 12 et 15 pour différents types de nourriture
                    Mat[i, j] = food; // nourriture
                }
            }
        }

        // Ajoute des bateaux
        if (TryPlaceBoat(out int boatX, out int boatY))
        {
            Mat[boatX, boatY] = 16;
            Boat1 = new Boat();
        }

        if (!IsSolo)
        {
            if (TryPlaceBoat(out int boat2X, out int boat2Y))
            {
                Mat[boat2X, boat2Y] = 17;
                Boat2 = new Boat();
            }
        }

        // Ajoute les personnages
        PlaceCharacter(18); // Character 1
        if (!IsSolo)
        {
            PlaceCharacter(19); // Character 2
        }
    }

    //function which displays the world
    public void DisplayWorld()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                switch (Mat[i, j])
                {
                    case 0: // Mer
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("~ ");
                        break;
                    case 1: // Terre
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("— ");
                        break;
                    case 2: // Montagne
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("M ");
                        break;
                    case 3: // Arbre
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("‡ ");
                        break;
                    case 4: // Trésor positif 1
                    case 5: // Trésor positif 2
                    case 6: // Trésor positif 3
                    case 7: // Trésor positif 4
                    case 8: // Trésor négatif 1
                    case 9: // Trésor négatif 2
                    case 10: // Trésor négatif 3
                    case 11: // Trésor OnePiece
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("— ");
                        break;
                    case 13: // Nourriture type 2
                    case 14: // Nourriture type 3
                    case 15: // Nourriture type 4
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                        break;
                    case 16: // Bateau 1
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("B ");
                        break;
                    case 17: // Bateau 2
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B ");
                        break;
                    case 18: // Personnage 1
                        Console.Write("🐷");
                        break;
                    case 19: // Personnage 2
                        Console.Write("🦁");
                        break;
                    default:
                        Console.Write("  ");
                        break;
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }



    //function which permits to have the position x of the first character
    public int GetCharacterX()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 18)
                {
                    CharacterX = i;
                    return CharacterX;
                }
            }
        }
        return -1;
    }

    //function which permits to have the position y of the first character
    public int GetCharacterY()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 18)
                {
                    CharacterY = j;
                    return CharacterY;
                }
            }
        }
        return -1;
    }

    //function which permits to have the position x of the second character
    public int GetCharacter2X()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 19)
                {
                    Character2X = i;
                    return Character2X;
                }
            }
        }
        return -1;
    }

    //function which permits to have the position y of the second character
    public int GetCharacter2Y()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 19)
                {
                    Character2Y = j;
                    return Character2Y;
                }
            }
        }
        return -1;
    }

    //function which permits to place boat 
    private bool TryPlaceBoat(out int boatX, out int boatY)
    {
        Random random = new Random();

        do
        {
            boatX = random.Next(0, Mat.GetLength(0));
            boatY = random.Next(0, Mat.GetLength(1));
        } while (Mat[boatX, boatY] != 0 || !IsNearLand(boatX, boatY));

        if (IsValidBoatPosition(boatX, boatY))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //function which checks if boat is in the water and in the map
    private bool IsValidBoatPosition(int boatX, int boatY)
    {
        if (boatX < 0 || boatX >= Mat.GetLength(0) || boatY < 0 || boatY >= Mat.GetLength(1))
        {
            return false;
        }

        if (Mat[boatX, boatY] != 0)
        {
            return false;
        }

        return true;
    }

    //function which checks if boat is near land
    private bool IsNearLand(int x, int y)
    {
        if (x < Mat.GetLength(0)-1 && x >= 1 &&  y < Mat.GetLength(1)-1 && y >= 1) 
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (Mat[x + i, y + j] == 1)
                    {
                        return true;
                    }
                }
            }
        } else {
            return false;
        }

        return false;

    }

    //function which places character
    private void PlaceCharacter(int characterId)
    {
        Random random = new Random();
        while (true)
        {
            int x = random.Next(Mat.GetLength(0));
            int y = random.Next(Mat.GetLength(1));
            if (Mat[x, y] == 1)
            {
                Mat[x, y] = characterId;
                if (characterId == 18)
                {
                    CharacterX = x;
                    CharacterY = y;
                }
                else if (characterId == 19)
                {
                    Character2X = x;
                    Character2Y = y;
                }
                break;
            }
        }
    }

    //function which checks if the position is in the circle of isle
    public bool IsInCircle(int X, int Y)
    {
        int distanceX = X - CenterX;
        int distanceY = Y - CenterY;
        int distanceSquared = distanceX * distanceX + distanceY * distanceY;
        return distanceSquared <= Radius * Radius;
    }

    //function which checks if there is food in the case and if there is, applys effects
    public void CheckFood(int characterX, int characterY, Character character)
    {
        int foodId = Mat[characterX, characterY];
        GetFoodById(foodId);
        string foodName = CaseName;
        if (foodName == "Viande"){

            Meat food = new Meat();
            Console.WriteLine ($"Vous avez trouvé de la viande !");
            food.EffectFood(character);

        } else if (foodName == "Pate"){

            Pate food = new Pate();
            Console.WriteLine ($"Vous avez trouvé des pates !");
            food.EffectFood(character);

        } else if (foodName == "Herbe"){

            Herbe food = new Herbe ();
            Console.WriteLine ($"Vous avez trouvé de l'herbe !");
            food.EffectFood(character);

        } 

    }

    //function which determines what food is it
    private void GetFoodById(int foodId)
    {
        if (foodId >= 10 && foodId <= 13){
            switch (foodId)
            {
                case 11:
                    CaseName = "Viande";
                    break;
                case 12:
                    CaseName = "Pate";
                    break;
                case 13:
                    CaseName = "Herbe";
                    break;
                default:
                    Console.WriteLine("Erreur de la nourriture");
                    break;
            }
        } else {
            Console.WriteLine("");
        }

    }

    //function which checks if there is treasure in the case and if there is, applys effects
    public void CheckTreasure(int characterX, int characterY, Character character, Player player)
    {
        int treasureId = Mat[characterX, characterY];
        if (treasureId >= 4 && treasureId <= 11){
            switch (treasureId)
            {
                case 4:
                    PositiveTreasure1 treasure1 = new PositiveTreasure1();
                    treasure1.ApplyEffect(character, player);
                    break;
                case 5:
                    PositiveTreasure2 treasure2 = new PositiveTreasure2();
                    treasure2.ApplyEffect(character, player);
                    break;
                case 6:
                    PositiveTreasure3 treasure3 = new PositiveTreasure3();
                    treasure3.ApplyEffect(character, player);
                    break;
                case 7:
                    PositiveTreasure4 treasure4 = new PositiveTreasure4();
                    treasure4.ApplyEffect(character, player);
                    break;
                case 8:
                    NegativeTreasure1 treasureBad1 = new NegativeTreasure1();
                    treasureBad1.ApplyEffect(character, player);
                    break;
                case 9:
                    NegativeTreasure2 treasureBad2 = new NegativeTreasure2();
                    treasureBad2.ApplyEffect(character, player);
                    break;
                case 10:
                    NegativeTreasure3 treasureBad3 = new NegativeTreasure3();
                    treasureBad3.ApplyEffect(character, player);
                    break;
                case 11:
                    OnePieceTreasure OnePiece = new OnePieceTreasure();
                    OnePiece.ApplyEffect(character, player);
                    break;
                default:
                    Console.WriteLine("Erreur de trésor");
                    break;
            }
        } else {
            Console.WriteLine("\n");
        }

    }


}

    
