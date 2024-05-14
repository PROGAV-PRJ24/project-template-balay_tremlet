public class World
{
    public int Treasure { get; set; }
    public int[,] Mat { get; set; }
    public int CharacterX {get; set; }
    public int CharacterY {get; set; }
    public int Character2X {get; set; }
    public int Character2Y {get; set; }
    public int CenterX {get; set; }  
    public int CenterY {get; set; }
    public int Radius {get; set; }
    public string CaseName {get; set; }
    public bool IsSolo {get; set; }
    public Boat Boat1 { get; private set; }
    public Boat Boat2 { get; private set; }


    public World(bool isSolo)
    {
        IsSolo = isSolo;
        Mat = new int[30,30];
        Treasure = 0;
        CenterX = Mat.GetLength(0) / 2;  
        CenterY = Mat.GetLength(1) / 2; 
        Radius = 12;
        
        InitialiseWorld();

        if(IsSolo){
            GetCharacterX();
            GetCharacterY();
        } else {
            GetCharacterX();
            GetCharacterY();
            GetCharacter2X();
            GetCharacter2Y();
        }

    }

    public void InitialiseWorld() {
        if (IsSolo){
            Random random = new Random ();
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
                    if (Mat[i, j] == 1 && random.NextDouble() < 0.1) // 10% de chance d'avoir une montagne
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
                    if (Mat[i, j] == 1 && random.NextDouble() < 0.3) // 30% de chance d'avoir un arbre
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
                    if (Mat[i, j] == 2 && random.NextDouble() < 0.1) // 10% de chance d'avoir un trésor positif
                    {
                        int treasure = random.Next(4, 7); // Génère un nombre aléatoire entre 4 et 6
                        Mat[i, j] = treasure; // trésor positif
                    }
                }
            }

            // Ajoute des trésors négatifs sur les montagnes
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    if (Mat[i, j] == 2 && random.NextDouble() < 0.1) // 10% de chance d'avoir un trésor négatif
                    {
                        int treasure = random.Next(7, 10); // Génère un nombre aléatoire entre 7 et 9
                        Mat[i, j] = treasure; // trésor négatif
                    }
                }
            }
                // Ajoute de la nourriture sur la terre
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    if (Mat[i, j] == 1 && random.NextDouble() < 0.2) // 20% de chance d'avoir de la nourriture
                    {
                        int food = random.Next(10, 14); // Génère un nombre aléatoire entre 10 et 13
                        Mat[i, j] = food; // nourriture
                    }
                }
            }

            // Ajoute un bateau sur la mer
            int boatX = random.Next(0, 20);
            int boatY = random.Next(0, 20);
            if (Mat[boatX, boatY] == 0)
            {
                Mat[boatX, boatY] = 14; // bateau
                Boat1 = new Boat();
            }

            int characterX;
            int characterY;
            bool characterPlaced = false;
            // Ajoute un personnage sur la terre
            while (!characterPlaced)
            {
                characterX = random.Next(0, Mat.GetLength(0));
                characterY = random.Next(0, Mat.GetLength(1));
                
                if (Mat[characterX, characterY] == 1)
                {
                    
                    Mat[characterX, characterY] = 17; 
                    characterPlaced = true; 
                }
            }
        } else {
            Random random = new Random ();
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
                    if (Mat[i, j] == 1 && random.NextDouble() < 0.1) // 10% de chance d'avoir une montagne
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
                    if (Mat[i, j] == 2 && random.NextDouble() < 0.1) // 10% de chance d'avoir un trésor positif
                    {
                        int treasure = random.Next(4, 7); // Génère un nombre aléatoire entre 4 et 6
                        Mat[i, j] = treasure; // trésor positif
                    }
                }
            }

            // Ajoute des trésors négatifs sur les montagnes
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    if (Mat[i, j] == 2 && random.NextDouble() < 0.1) // 10% de chance d'avoir un trésor négatif
                    {
                        int treasure = random.Next(7, 10); // Génère un nombre aléatoire entre 7 et 9
                        Mat[i, j] = treasure; // trésor négatif
                    }
                }
            }
            // Ajoute de la nourriture sur la terre
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    if (Mat[i, j] == 1 && random.NextDouble() < 0.2) // 20% de chance d'avoir de la nourriture
                    {
                        int food = random.Next(10, 14); // Génère un nombre aléatoire entre 10 et 13
                        Mat[i, j] = food; // nourriture
                    }
                }
            }

            // Ajoute un bateau sur la mer
            int boat1X = random.Next(0, 20);
            int boat1Y = random.Next(0, 20);
            if (Mat[boat1X, boat1Y] == 0)
            {
                Mat[boat1X, boat1Y] = 14; // bateau
                Boat1 = new Boat();
            }

            int boat2X = random.Next(0, 20);
            int boat2Y = random.Next(0, 20);
            if (Mat[boat2X, boat2Y] == 0)
            {
                Mat[boat2X, boat2Y] = 15; // bateau
                Boat2 = new Boat();
            }

            int character1X;
            int character1Y;
            bool character1Placed = false;
            // Ajoute un personnage sur la terre
            while (!character1Placed)
            {
                character1X = random.Next(0, Mat.GetLength(0));
                character1Y = random.Next(0, Mat.GetLength(1));
                
                if (Mat[character1X, character1Y] == 1)
                {
                    
                    Mat[character1X, character1Y] = 17; 
                    character1Placed = true; 
                }
            }
            int character2X;
            int character2Y;
            bool character2Placed = false;
            while (!character2Placed)
            {
                character2X = random.Next(0, Mat.GetLength(0));
                character2Y = random.Next(0, Mat.GetLength(1));
                
                if (Mat[character2X, character2Y] == 1)
                {
                    
                    Mat[character2X, character2Y] = 16; 
                    character2Placed = true; 
                }
            }
        }
    } 

        
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
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
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
                    case 4: // Trésor positif1
                    case 5: // Trésor positif2
                    case 6: // Trésor positif3
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("T ");
                        break;
                    case 7: // Trésor négatif1
                    case 8: // Trésor négatif2
                    case 9: // Trésor négatif3
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("π ");
                        break;
                    case 10: // Nourriture vi
                    case 11: // Viandes
                    case 12: // Pates
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");
                        break;
                    case 13: // Herbes
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" ");
                        break;
                    case 14: // Bateau
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("B ");
                        break;
                    case 15: // Bateau
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("B ");
                        break;
                    case 16: // Personnage
                        Console.Write("🦁");
                        break;
                    case 17: // Personnage
                        Console.Write("🐷");
                        break;
                    default:
                        Console.Write("🦁");
                        break;
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public void ApplyTreasureEffect(int treasureId, Character character)
    {
        Treasure treasure;

        switch (treasureId)
        {
            case 4:
                treasure = new PositiveTreasure1();
                break;
            case 5:
                treasure = new PositiveTreasure2();
                break;
            case 6:
                treasure = new PositiveTreasure3();
                break;
            case 7:
                treasure = new NegativeTreasure1();
                break;
            case 8:
                treasure = new NegativeTreasure2();
                break;
            case 9:
                treasure = new NegativeTreasure3();
                break;
            default:
                Console.WriteLine("Pas de trésor");
                return;
        }

        treasure.ApplyEffect(character);
        Mat[CharacterX, CharacterY] = 1; // mettre de la terre à la place du trésor
    }


    public void CheckTreasure(int characterX, int characterY, Character character)
    {

        int treasureId = Mat[characterX, characterY];

        if (treasureId >= 4 && treasureId <= 9)
        {
            ApplyTreasureEffect(treasureId, character);
        }
    }

    
    public int GetCharacterX()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 17)
                {
                    CharacterX = i ;
                    return CharacterX;
                }
            }
        }
        return -1;
    }

    public int GetCharacterY()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 17)
                {
                    CharacterY = j ;
                    return CharacterY;
                }
            }
        }
        return -1;
    }

    public int GetCharacter2X()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 16)
                {
                    Character2X = i ;
                    return Character2X;
                }
            }
        }
        return -1;
    }

    public int GetCharacter2Y()
    {
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                if (Mat[i, j] == 16)
                {
                    Character2Y = j ;
                    return Character2Y;
                }
            }
        }
        return -1;
    }

    public bool IsInCircle(int X, int Y)
    {
        int distanceX = X - CenterX;
        int distanceY = Y - CenterY;
        int distanceSquared = distanceX * distanceX + distanceY * distanceY;
        return distanceSquared <= Radius * Radius;
    }

    public void CheckFood(int characterX, int characterY, Character character)
    {
        int foodId = Mat[characterX, characterY];
        GetFoodById(foodId);
        string foodName = CaseName;

        if (foodName == "LifeFood"){

            LifeFood food = new LifeFood ();
            Console.WriteLine ($"Vous avez trouvé de la nourriture vie !");
            food.EffectFood(character);
            Mat[characterX, characterY] = 17;   

        }  else if (foodName == "Viande"){

            Meat food = new Meat();
            Console.WriteLine ($"Vous avez trouvé de la viande !");
            food.EffectFood(character);
            Mat[characterX, characterY] = 17;     

        } else if (foodName == "Pate"){

            Pate food = new Pate();
            Console.WriteLine ($"Vous avez trouvé des pates !");
            food.EffectFood(character);
            Mat[characterX, characterY] = 17;

        } else if (foodName == "Herbe"){

            Herbe food = new Herbe ();
            Console.WriteLine ($"Vous avez trouvé de l'herbe !");
            food.EffectFood(character);
            Mat[characterX, characterY] = 17;

        } 
    }

    private void GetFoodById(int foodId)
    {
         Console.WriteLine(foodId);
        if (foodId >= 10 && foodId <= 13){
            switch (foodId)
            {
                case 10:
                    CaseName = "LifeFood";
                    break;
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
            Console.WriteLine("Pas de nourriture");
        }

    }
}