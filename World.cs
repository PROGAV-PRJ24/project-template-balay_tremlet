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

            // Affiche la matrice dans la console
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    Console.Write(Mat[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void DisplayWorld () {
            for (int i = 0; i < Mat.GetLength(0); i++)
            {
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    if (Mat[i, j]==0){
                        Console.Write("~ ");
                    }
                    else if (Mat[i,j] == 1){
                        Console.Write("— ");
                    }
                    else if (Mat[i,j] == 2){
                        Console.Write("M ");
                    }
                    else if (Mat[i,j] == 3){
                        Console.Write("‡ ");
                    }
                    else if (Mat[i,j] == 4){
                        Console.Write("T ");
                    }
                    else if (Mat[i,j] == 5){
                        Console.Write("T ");
                    }
                    else if (Mat[i,j] == 6){
                        Console.Write("T ");
                    }
                    else if (Mat[i,j] == 7){
                        Console.Write("π ");
                    }
                    else if (Mat[i,j] == 8){
                        Console.Write("π");
                    }
                    else if (Mat[i,j] == 9){
                        Console.Write("π ");
                    }
                    else if (Mat[i,j] == 10){
                        Console.Write(" ");
                    }
                    else if (Mat[i,j] == 11){
                        Console.Write(" ");
                    }
                    else if (Mat[i,j] == 12){
                        Console.Write(" ");
                    }
                    else if (Mat[i,j] == 13){
                        Console.Write(" ");
                    }
                    else if (Mat[i,j] == 14){
                        Console.Write(" ");
                    }
                    else if (Mat[i,j] == 15){
                        Console.Write(" ");
                    }
                    else if (Mat[i,j] == 16){
                        Console.Write("B ");
                    }
                    else {
                        Console.Write("P ");
                    }
                }
                Console.WriteLine();
            }
        }
}