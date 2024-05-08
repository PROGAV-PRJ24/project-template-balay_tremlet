
public class PlayGame
{
    private string nomDuJeu = "One Piece";
    private string nomEquipe = "Tom et Emma";
    private bool menuActif = false;
    private string descriptionRegle = "";

    public void Introduction()
    {
  
        descriptionRegle = "\nLe jeu est simple : il existe une île qui se compose de plusieurs trésors : des coffres, des pierres précieuses, ou même le One Piece ? 💰💰💰" +
                           "\nLe joueur incarnera un personnage doté de caractéristiques uniques en fonction de sa classe : un pirate, un chasseur de trésors, une bouteille de rhum vivante… Tout le monde peut prétendre à sa part du butin." +
                           "\nLe personnage devra se rendre sur une île pour y récupérer un maximum de trésors et de ressources, et les rapporter à son bateau pour valider ses gains." +
                           "\nAttention, chaque action aura un coût, et il se peut que le personnage ne revienne jamais, auquel cas la partie sera perdue." +
                           "\nUne fois le butin enregistré dans le bateau, il sera possible de l’échanger contre des améliorations de caractéristiques ou des outils. Mais plus les missions avancent, plus elles seront difficiles…";

        Console.WriteLine("\n\nBienvenue à vous, les One Piecers ! Vous voici sur le jeu : " + nomDuJeu + " développé par l'équipe " + nomEquipe + ".");
        Console.WriteLine("\nVoici les règles du jeu :\n" + descriptionRegle);

        DisplayMenu();
    }

    public void DisplayMenu()
    {
        menuActif = true;

        while (menuActif)
        {
            Console.WriteLine("\n----------------- MENU ------------------");
            Console.WriteLine("\n 1. Lancer une Partie Solo");
            Console.WriteLine(" 2. Lancer une Partie 1v1");
            Console.WriteLine(" 3. Classement des meilleurs Joueurs");
            Console.WriteLine(" 4. Quitter");

            Console.Write("\nEntrez votre choix (1-4): ");
            string choixString = Console.ReadLine();

            if (int.TryParse(choixString, out int choix))
            {
                switch (choix)
                {
                    case 1:
                       
                        StartSoloGame();
                        break;
                    case 2:
                       
                        Start1v1Game();
                        break;
                    case 3:
                       
                        DisplayLeaderboard();
                        break;
                    case 4:
                      
                        Console.WriteLine("\nBye bye !\n");
                        menuActif = false;
                        break;
                    default:
                        Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nErreur : veuillez entrer un nombre valide entre 1 et 4.");
            }
        }
    }

    private void StartSoloGame()
    {
        Console.WriteLine("\nLancement de la partie solo...");
        menuActif = false;
        World world = new World();
        world.DisplayWorld();
        Emma emma = new Emma();
        emma.DisplayCharacter();
        while (emma.QuantityEnergy > 0)
        {
            PlayTurn(emma, world);
        }
        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
        Introduction();
    }

       
    

    private void Start1v1Game()
    {
        Console.WriteLine("\nLancement de la partie 1v1...");
        menuActif = false;
        World world = new World();
        world.DisplayWorld();
    }

    private void DisplayLeaderboard()
    {
        
        Console.WriteLine("\nAffichage du classement des meilleurs joueurs...");
    }


    private void PlayTurn(Character character, World world)
    {
        Console.Clear();
        world.DisplayWorld();
        Console.WriteLine("\nAppuyez sur une touche pour lancer le dé...");
        Console.ReadKey();
        int roll = RollDice();
        Console.WriteLine("\nVous avez obtenu un " + roll + " !");
        Console.WriteLine("\nDans quelle direction voulez-vous avancer ? (haut/bas/gauche/droite)");
        string direction = Console.ReadLine().ToLower();

        if (character != null && world != null)
            {
                character.Move(direction, roll, world);
                Console.WriteLine("\nVotre personnage a maintenant " + character.QuantityEnergy + " points d'énergie restants.");
            }

        Console.WriteLine("Appuyez sur une touche pour continuer...");
        Console.ReadKey();
    }

    private int RollDice()
    {
        Random rand = new Random();
        return rand.Next(1, 7);
    }

}