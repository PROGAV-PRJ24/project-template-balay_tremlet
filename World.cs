public class World
{
    public int Treasure { get; set; }
    public int[,] Mat { get; set; }
    public int CharacterX {get; set; }
    public int CharacterY {get; set; }
    public int CenterX {get; set; }  
    public int CenterY {get; set; }
    public int Radius {get; set; }


    public World()
    {
        Mat = new int[30,30];
        Treasure = 0;
        CenterX = Mat.GetLength(0) / 2;  
        CenterY = Mat.GetLength(1) / 2; 
        Radius = 12;
        InitialiseWorld();
        GetCharacterX();
        GetCharacterY();
    }

    public void InitialiseWorld() {

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
                    int food = random.Next(10, 16); // Génère un nombre aléatoire entre 10 et 15
                    Mat[i, j] = food; // nourriture
                }
            }
        }

        // Ajoute un bateau sur la mer
        int boatX = random.Next(0, 20);
        int boatY = random.Next(0, 20);
        if (Mat[boatX, boatY] == 0)
        {
            Mat[boatX, boatY] = 16; // bateau
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
        /* // Affiche la matrice dans la console
        for (int i = 0; i < Mat.GetLength(0); i++)
        {
            for (int j = 0; j < Mat.GetLength(1); j++)
            {
                Console.Write(Mat[i, j] + " ");
            }
            Console.WriteLine();
        }*/
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
                    case 13: // Omelette
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(" ");
                        break;
                    case 14: // Glaçons
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" ");
                        break;
                    case 15: // Chewing-gum
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" ");
                        break;
                    case 16: // Bateau
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("B ");
                        break;
                    case 17: // Personnage
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("P ");
                        break;
                    default:
                        Console.Write("P ");
                        break;
                }
                Console.ResetColor();
            }
            Console.WriteLine();
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

    public bool IsInCircle(int X, int Y)
    {
        int distanceX = X - CenterX;
        int distanceY = Y - CenterY;
        int distanceSquared = distanceX * distanceX + distanceY * distanceY;
        return distanceSquared <= Radius * Radius;
    }
}