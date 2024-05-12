
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
                DisplayMenu();
            }
        }
    }

    private void StartSoloGame()
    {
        Console.WriteLine("\nLancement de la partie solo...");
        menuActif = false;
        Player Player = new Player();
        World world = new World(true);
        ChooseCharactere(world, Player);
    }

       
    
    private void Start1v1Game()
    {
        Console.WriteLine("\nContre qui voulez-vous jouer ?");
        Console.WriteLine("\n 1. Contre l'ordinateur");
        Console.WriteLine(" 2. Avec un ami");

        Console.Write("\nEntrez votre choix (1-2): ");
        string choix1v1 = Console.ReadLine();

        Player player1 = new Player();
        Player player2 = new Player();
        World world = new World(false);

        if (int.TryParse(choix1v1, out int choix))
        {
            switch (choix)
            {
                case 1:
                    Console.WriteLine("\nJoueur 1,");
                    ChooseCharacter1v1(player1, world, false);

                    Console.WriteLine("\nJoueur 2 (ordinateur),");
                    ChooseCharacter1v1(player2, world, true);
                    
                    Console.WriteLine("\nJoueur 1, vous serez le cochon.");
                    Console.WriteLine("\nL'ordinateur sera le lion.");
                    StartGame1v1(player1, player2, world);
                    break;
                case 2:
                    Console.WriteLine("\nJoueur 1,");
                    ChooseCharacter1v1(player1, world, false);

                    Console.WriteLine("\nJoueur 2,");
                    ChooseCharacter1v1(player2, world, false);

                    Console.WriteLine("\nJoueur 1, vous serez le cochon.");
                    Console.WriteLine("Joueur 2, vous serez le lion.\n");
                    StartGame1v1(player1, player2, world);
                    break;
                default:
                    Console.WriteLine("\nErreur : ce choix ne correspond à aucune option.");
                    Start1v1Game();
                    break;
            }
        }
        menuActif = false;
    }


    private void DisplayLeaderboard()
    {
        Console.WriteLine("\nAffichage du classement des meilleurs joueurs...");
    }


    private void PlayTurn(Character character, World world)
    {
        if (world.IsSolo){
            world.DisplayWorld();
            Console.WriteLine("\nAppuyez sur une touche pour lancer le dé...");
            Console.ReadKey();
            int roll = RollDice();
            Console.WriteLine("\nVous avez obtenu un " + roll + " !");

            if (character != null && world != null)
                {
                    bool validDirection = false;
                    while (!validDirection)
                    {
                        Console.WriteLine("\nDans quelle direction voulez-vous avancer ? (haut/bas/gauche/droite)");
                        string direction = Console.ReadLine().ToLower();

                        if (direction == "haut" || direction == "bas" || direction == "gauche" || direction == "droite")
                        {
                            validDirection = character.Move(direction, roll, world, character);
                        }
                        else
                        {
                            Console.WriteLine("Direction invalide");
                        }
                        character.DisplayEnergy();
                    }            
                }

            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        } else {
            world.DisplayWorld();
            Console.WriteLine("\nAppuyez sur une touche pour lancer le dé...");
            Console.ReadKey();
            int roll = RollDice();
            Console.WriteLine("\nVous avez obtenu un " + roll + " !");

            if (character != null && world != null)
                {
                    bool validDirection = false;
                    while (!validDirection)
                    {
                        Console.WriteLine("\nDans quelle direction voulez-vous avancer ? (haut/bas/gauche/droite)");
                        string direction = Console.ReadLine().ToLower();

                        if (direction == "haut" || direction == "bas" || direction == "gauche" || direction == "droite")
                        {
                            validDirection = character.Move1v1(direction, roll, world, character, true);
                        }
                        else
                        {
                            Console.WriteLine("Direction invalide");
                        }
                        character.DisplayEnergy();
                    }            
                }

            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
    }

    private int RollDice()
    {
        Random rand = new Random();
        return rand.Next(1, 7);
    }


    public void IsUnlock(Character character){
        if (character.Unlock) {
            Console.Clear();
            Console.WriteLine($"Vous avez choisi le personnage {character} !");
            character.DisplayCharacter(character);
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        } else {
            Console.WriteLine("Vous n'avez pas débloqué ce personnage !");
            StartSoloGame();
        }
    }

    
    public void ChooseCharactere (World world, Player player) {

        Console.WriteLine("Choisissez votre personnage :");
        Console.WriteLine("1. Emma");
        Console.WriteLine("2. Tom");
        Console.WriteLine("3. Chamois");
        Console.WriteLine("4. Kangourou");
        Console.WriteLine("5. Pez");
        Console.WriteLine("6. Rhum");


        Console.Write("Entrez votre choix (1-6) : ");
        string characterChoose = Console.ReadLine();


        if (int.TryParse(characterChoose, out int choix))
        {
            switch (choix)
            {
                case 1:
                    Emma Emma = new Emma();
                    IsUnlock(Emma);     
                    player.Character = Emma;  
                    Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                    Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                    Console.ReadKey();
                    Introduction();
                    break;
                case 2:
                    Tom Tom = new Tom();
                    IsUnlock(Tom);
                    player.Character = Tom;

                    break;
                case 3:
                    Chamois Chamois = new Chamois();
                    IsUnlock(Chamois);
                    player.Character = Chamois;
                    break;
                case 4:
                    Kangourou Kangourou = new Kangourou();
                    IsUnlock(Kangourou);
                    player.Character = Kangourou;
                    Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                    Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                    Console.ReadKey();
                    Introduction();
                    break;
                case 5:
                    Pez Pez = new Pez();
                    IsUnlock(Pez);
                    player.Character = Pez;
                    break;
                case 6:
                    Rhum Rhum = new Rhum();
                    IsUnlock(Rhum);
                    player.Character = Rhum;
                    while (IsGameOver(Rhum))
                    {
                        PlayTurn(Rhum, world);
                    }
                    Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                    Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                    Console.ReadKey();
                    Introduction();
                    break;
                default:
                    Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("\nErreur : veuillez entrer un nombre valide entre 1 et 6.");
            ChooseCharactere(world, player);
        }
    }

    public void ChooseCharacter1v1 (Player player, World world, bool isComputer) {

        if(!isComputer){

            Console.WriteLine("Choisissez votre personnage :");
            Console.WriteLine("1. Emma");
            Console.WriteLine("2. Tom");
            Console.WriteLine("3. Chamois");
            Console.WriteLine("4. Kangourou");
            Console.WriteLine("5. Pez");
            Console.WriteLine("6. Rhum");

            Console.Write("Entrez votre choix (1-6) : ");
            string characterChoose = Console.ReadLine();


            if (int.TryParse(characterChoose, out int choix))
                {
                    switch (choix)
                    {
                        case 1:
                            Emma Emma = new Emma();
                            IsUnlock(Emma);     
                            player.Character = Emma;  
 
                            break;
                        case 2:
                            Tom Tom = new Tom();
                            IsUnlock(Tom);
                            player.Character = Tom;
                            break;
                        case 3:
                            Chamois Chamois = new Chamois();
                            IsUnlock(Chamois);
                            player.Character = Chamois;
                            break;
                        case 4:
                            Kangourou Kangourou = new Kangourou();
                            IsUnlock(Kangourou);
                            player.Character = Kangourou;
                            break;
                        case 5:
                            Pez Pez = new Pez();
                            IsUnlock(Pez);
                            player.Character = Pez;
                            break;
                        case 6:
                            Rhum Rhum = new Rhum();
                            IsUnlock(Rhum);
                            player.Character = Rhum;
                            break;
                        default:
                            Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nErreur : veuillez entrer un nombre valide entre 1 et 6.");
                    ChooseCharacter1v1(player, world, isComputer);
                }
        } else {
            Random rand = new Random();
            int choix = rand.Next(1, 7);

            switch (choix)
            {
                case 1:
                    Emma Emma = new Emma();
                    IsUnlock(Emma);
                    player.Character = Emma;   
                    break;
                case 2:
                    Tom Tom = new Tom();
                    IsUnlock(Tom);
                    player.Character = Tom;   
                    break;
                case 3:
                    Chamois Chamois = new Chamois();
                    IsUnlock(Chamois);
                    player.Character = Chamois;   
                    break;
                case 4:
                    Kangourou Kangourou = new Kangourou();
                    IsUnlock(Kangourou);
                    player.Character = Kangourou;   
                    break;
                case 5:
                    Pez Pez = new Pez();
                    IsUnlock(Pez);
                    player.Character = Pez;   
                    break;
                case 6:
                    Rhum Rhum = new Rhum();
                    IsUnlock(Rhum);
                    player.Character = Rhum;   
                    break;
                default:
                    Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                    ChooseCharacter1v1(player, world, true);
                    break;
            }
        }
    }

    private void StartGame1v1(Player player1, Player player2, World world)
    {
        while (true)
        {
            Console.WriteLine("Tour du joueur 1 :");
            PlayTurn(player1.Character, world);

            if (IsGameOver1v1(player1.Character, player2.Character))
            {
                break;
            }

            Console.WriteLine("Tour du joueur 2 :");
            PlayTurn(player2.Character, world);

            if (IsGameOver1v1(player1.Character, player2.Character))
            {
                break;
            }
        }
        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
        DisplayResult1v1(player1.Character, player2.Character, player1, player2);
        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
        Console.ReadKey();
        Introduction();
    }


    private bool IsGameOver1v1(Character character1, Character character2)
    {
        return character1.QuantityEnergy <= 0 || character2.QuantityEnergy <= 0;
    }


    private bool IsGameOver(Character character)
    {
        return character.QuantityEnergy > 0;
    }

    private void DisplayResult1v1(Character character1, Character character2, Player player1, Player player2)
    {
        if (character1.QuantityEnergy > character2.QuantityEnergy)
        {
            Console.WriteLine($"Le joueur {player1.Name} a gagné !");
        }
        else if (character1.QuantityEnergy < character2.QuantityEnergy)
        {
            Console.WriteLine($"Le joueur {player2.Name} a gagné !");
        }
        else
        {
            Console.WriteLine("Égalité !");
        }
    }


}