public class World
{
    public int Treasure { get; set; }
    private int[,] Mat;

    public World()
    {
        Mat = new int[20,20];
        Treasure = 0;
        InitialiseWorld();
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
            int centerX = 10;
            int centerY = 10;
            int radius = 7;
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    int distance = (int)Math.Sqrt(Math.Pow(i - centerX, 2) + Math.Pow(j - centerY, 2));
                    if (distance <= radius)
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

            // Ajoute un personnage sur la terre
            int characterX = random.Next(0, 20);
            int characterY = random.Next(0, 20);
            if (Mat[characterX, characterY] == 1)
            {
                Mat[characterX, characterY] = 17; // personnage
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
        }