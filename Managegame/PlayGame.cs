
public class PlayGame
{
    private string nomDuJeu = "One Piece";
    private string nomEquipe = "Tom et Emma";
    private bool menuActif = false;
    private string descriptionRegle = "";
    public List<Player> Players { get; private set; } = new List<Player>();

    public PlayGame() {
        LoadPlayers();
        SavePlayers();
    }

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
                       
                        DisplayTopPlayers();
                        break;
                    case 4:
                      
                        Console.WriteLine("\nBye bye !\n");
                        SavePlayers();
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
        Console.WriteLine("Choississez votre nom :");
        string name = Console.ReadLine();
        Player Player = new Player();
        Player.Name = name;
        AddPlayer(Player);
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
                    ChooseName(player1, player2, true);
                    
                    Console.WriteLine($"\n{player1.Name}");
                    ChooseCharacter1v1(player1, world, false);

                    Console.WriteLine("\nJoueur 2 (ordinateur),");
                    ChooseCharacter1v1(player2, world, true);
                    
                    Console.WriteLine($"\n{player1.Name}, vous serez le cochon.");
                    Console.WriteLine("\nL'ordinateur sera le lion.");
                    StartGame1v1(player1, player2, world, true);
                    break;
                case 2:
                    ChooseName(player1, player2, false);

                    Console.WriteLine($"\n{player1.Name}");
                    ChooseCharacter1v1(player1, world, false);

                    Console.WriteLine($"\n{player2.Name}");
                    ChooseCharacter1v1(player2, world, false);

                    Console.WriteLine($"\n{player1.Name}, vous serez le cochon.");
                    Console.WriteLine($"{player2.Name}, vous serez le lion.\n");
                    StartGame1v1(player1, player2, world, false);
                    break;
                default:
                    Console.WriteLine("\nErreur : ce choix ne correspond à aucune option.");
                    Start1v1Game();
                    break;
            }
        }
        menuActif = false;
    }

    public void ChooseName(Player player1, Player player2, bool isComputer){
        if (!isComputer){
            Console.WriteLine("Joueur 1, choississez votre nom :");
            string name1 = Console.ReadLine();
            player1.Name = name1;
            AddPlayer(player1);

            Console.WriteLine("Joueur 2, choississez votre nom :");
            string name2 = Console.ReadLine();
            player2.Name = name2;
            AddPlayer(player2);
        } else {
            Console.WriteLine("Joueur 1, choississez votre nom :");
            string name1 = Console.ReadLine();
            player1.Name = name1;
            AddPlayer(player1);

            player2.Name = "Ordinateur";
        }
    }


    private void PlayTurn(Character character, World world, bool isJoueur1, bool isComputer)
    {
        if (isJoueur1 && world.IsSolo){
            world.DisplayWorld();
            Console.WriteLine("\nAppuyez sur une touche pour lancer le dé...");
            Console.ReadKey();
            int roll = RollDice();
            Console.WriteLine("\nVous avez obtenu un " + roll + " !");

            if (character != null && world != null)
            {
                ConsoleKeyInfo keyInfo;
                bool validDirection = false;
                while (!validDirection)
                {
                    Console.WriteLine("\nDans quelle direction voulez-vous avancer ? (haut/bas/gauche/droite)");
                    keyInfo = Console.ReadKey(true);
                    string direction;

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.WriteLine("Touche fléchée haut appuyée");
                            direction = "haut";
                            validDirection = character.Move(direction, roll, world, character);
                            break;
                        case ConsoleKey.DownArrow:
                            Console.WriteLine("Touche fléchée bas appuyée");
                            direction = "bas";
                            validDirection = character.Move(direction, roll, world, character);
                            break;
                        case ConsoleKey.LeftArrow:
                            Console.WriteLine("Touche fléchée gauche appuyée");
                            direction = "gauche";
                            validDirection = character.Move(direction, roll, world, character);
                            break;
                        case ConsoleKey.RightArrow:
                            Console.WriteLine("Touche fléchée droite appuyée");
                            direction = "droite";
                            validDirection = character.Move(direction, roll, world, character);
                            break;
                        default:
                            Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                            PlayTurn(character, world, true, false);
                            break;
                    }
                    character.DisplayEnergy();
                }            
            } else {
                Console.WriteLine("Direction invalide");
            }
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();

        } else if (isJoueur1){
            world.DisplayWorld();
            Console.WriteLine("\nAppuyez sur une touche pour lancer le dé...");
            Console.ReadKey();
            int roll = RollDice();
            Console.WriteLine("\nVous avez obtenu un " + roll + " !");

            if (character != null && world != null)
                {
                    ConsoleKeyInfo keyInfo;
                    bool validDirection = false;
                    while (!validDirection)
                    {
                        Console.WriteLine("\nDans quelle direction voulez-vous avancer ? (haut/bas/gauche/droite)");
                        keyInfo = Console.ReadKey(true);
                        string direction;

                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.WriteLine("Touche fléchée haut appuyée");
                                direction = "haut";
                                validDirection = character.Move1v1(direction, roll, world, character, true);
                                break;
                            case ConsoleKey.DownArrow:
                                Console.WriteLine("Touche fléchée bas appuyée");
                                direction = "bas";
                                validDirection = character.Move1v1(direction, roll, world, character, true);
                                break;
                            case ConsoleKey.LeftArrow:
                                Console.WriteLine("Touche fléchée gauche appuyée");
                                direction = "gauche";
                                validDirection = character.Move1v1(direction, roll, world, character, true);
                                break;
                            case ConsoleKey.RightArrow:
                                Console.WriteLine("Touche fléchée droite appuyée");
                                direction = "droite";
                                validDirection = character.Move1v1(direction, roll, world, character, true);
                                break;
                            default:
                                Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                                PlayTurn(character, world, true, false);
                                break;
                        }
                        character.DisplayEnergy();
                    }            
                }

            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        } else if (!isJoueur1 && !isComputer){
            world.DisplayWorld();
            Console.WriteLine("\nAppuyez sur une touche pour lancer le dé...");
            Console.ReadKey();
            int roll = RollDice();
            Console.WriteLine("\nVous avez obtenu un " + roll + " !");

            if (character != null && world != null)
                {
                    ConsoleKeyInfo keyInfo;
                    bool validDirection = false;
                    while (!validDirection)
                    {
                        Console.WriteLine("\nDans quelle direction voulez-vous avancer ? (haut/bas/gauche/droite)");
                        keyInfo = Console.ReadKey(true);
                        string direction;

                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                Console.WriteLine("Touche fléchée haut appuyée");
                                direction = "haut";
                                validDirection = character.Move1v1(direction, roll, world, character, false);
                                break;
                            case ConsoleKey.DownArrow:
                                Console.WriteLine("Touche fléchée bas appuyée");
                                direction = "bas";
                                validDirection = character.Move1v1(direction, roll, world, character, false);
                                break;
                            case ConsoleKey.LeftArrow:
                                Console.WriteLine("Touche fléchée gauche appuyée");
                                direction = "gauche";
                                validDirection = character.Move1v1(direction, roll, world, character, false);
                                break;
                            case ConsoleKey.RightArrow:
                                Console.WriteLine("Touche fléchée droite appuyée");
                                direction = "droite";
                                validDirection = character.Move1v1(direction, roll, world, character, false);
                                break;
                            default:
                                Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                                PlayTurn(character, world, false, true);
                                break;
                        }
                        character.DisplayEnergy();
                    }            
                }
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        } else {
            world.DisplayWorld();
            int roll = RollDice();

            if (character != null && world != null)
            {
                Random rand = new Random();
                int choix = rand.Next(1, 4);
                bool validDirection = false;
                string directionOrdi;
                while (!validDirection)
                {
                    switch (choix)
                    {
                        case 1:
                            directionOrdi = "bas";
                            validDirection = character.Move1v1(directionOrdi, roll, world, character, false);
                            break;
                        case 2:
                            directionOrdi = "haut";
                            validDirection = character.Move1v1(directionOrdi, roll, world, character, false);
                            break;
                        case 3:
                            directionOrdi = "droite";
                            validDirection = character.Move1v1(directionOrdi, roll, world, character, false);
                            break;
                        case 4:
                            directionOrdi = "gauche";
                            validDirection = character.Move1v1(directionOrdi, roll, world, character, false);
                            break;
                        default:
                            Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                            PlayTurn(character, world, false, true);
                            break;
                    } 
                    character.DisplayEnergy();
                }            
            }
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
    }

    private int RollDice()
    {
        Random rand = new Random();
        return rand.Next(1, 7);
    }


    public bool IsUnlock(Character character){
        if (character.Unlock) {
            Console.Clear();
            Console.WriteLine($"Vous avez choisi le personnage {character} !");
            character.DisplayCharacter(character);
            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
            return true;
        } else {
            Console.WriteLine("Vous n'avez pas débloqué ce personnage !");
            return false;
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
                    if(IsUnlock(Emma)){
                        player.Character = Emma;  
                        while (IsGameOver(Emma))
                        {
                            PlayTurn(Emma, world, true, false);
                        }
                        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                        Console.ReadKey();
                        Introduction();
                    } else {
                        ChooseCharactere(world, player);
                    }
                    break;
                case 2:
                    Tom Tom = new Tom();
                    if(IsUnlock(Tom)){
                        player.Character = Tom;  
                        while (IsGameOver(Tom))
                        {
                            PlayTurn(Tom, world, true, false);
                        }
                        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                        Console.ReadKey();
                        Introduction();
                    } else {
                        ChooseCharactere(world, player);
                    }
                    break;
                case 3:
                    Chamois Chamois = new Chamois();
                    if(IsUnlock(Chamois)){
                        player.Character = Chamois; 
                        while (IsGameOver(Chamois))
                        {
                            PlayTurn(Chamois, world, true, false);
                        }
                        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                        Console.ReadKey();
                        Introduction();
                    } else {
                        ChooseCharactere(world, player);
                    }
                    break;
                case 4:
                    Kangourou Kangourou = new Kangourou();
                    if(IsUnlock(Kangourou)){
                        player.Character = Kangourou;  
                        while (IsGameOver(Kangourou))
                        {
                            PlayTurn(Kangourou, world, true, false);
                        }
                        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                        Console.ReadKey();
                        Introduction();
                    } else {
                        ChooseCharactere(world, player);
                    }
                    break;
                case 5:
                    Pez Pez = new Pez();
                    if(IsUnlock(Pez)){
                        player.Character = Pez;  
                        while (IsGameOver(Pez))
                        {
                            PlayTurn(Pez, world, true, false);
                        }
                        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                        Console.ReadKey();
                        SavePlayers();
                        Introduction();
                    } else {
                        ChooseCharactere(world, player);
                    }
                    break;
                case 6:
                    Rhum Rhum = new Rhum();
                    if(IsUnlock(Rhum)){
                        player.Character = Rhum;  
                        while (IsGameOver(Rhum))
                        {
                            PlayTurn(Rhum, world, true, false);
                        }
                        Console.WriteLine("\nVous n'avez plus d'énergie ! La partie est terminée.");
                        Console.WriteLine("Appuyez sur une touche pour revenir au menu principal...");
                        Console.ReadKey();
                        SavePlayers();
                        Introduction();
                    } else {
                        ChooseCharactere(world, player);
                    }
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
                            if(IsUnlock(Emma)){
                                player.Character = Emma;  
                            } else {
                                ChooseCharacter1v1(player, world, isComputer);
                            }
                            break;
                        case 2:
                            Tom Tom = new Tom();
                            if(IsUnlock(Tom)){
                                player.Character = Tom;  
                            } else {
                                ChooseCharacter1v1(player, world, isComputer);
                            }
                            break;
                        case 3:
                            Chamois Chamois = new Chamois();
                            if(IsUnlock(Chamois)){
                                player.Character = Chamois;  
                            } else {
                                ChooseCharacter1v1(player, world, isComputer);
                            }
                            break;
                        case 4:
                            Kangourou Kangourou = new Kangourou();
                            if(IsUnlock(Kangourou)){
                                player.Character = Kangourou;  
                            } else {
                                ChooseCharacter1v1(player, world, isComputer);
                            }
                            break;
                        case 5:
                            Pez Pez = new Pez();
                            if(IsUnlock(Pez)){
                                player.Character = Pez;  
                            } else {
                                ChooseCharacter1v1(player, world, isComputer);
                            }
                            break;
                        case 6:
                            Rhum Rhum = new Rhum();
                            if(IsUnlock(Rhum)){
                                player.Character = Rhum;  
                            } else {
                                ChooseCharacter1v1(player, world, isComputer);
                            }
                            break;
                        default:
                            Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                            ChooseCharacter1v1(player, world, isComputer);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nErreur : veuillez entrer un nombre valide entre 1 et 6.");
                    ChooseCharacter1v1(player, world, isComputer);
                }
        } else {
            ComputerChooseCharacter(world, player);
        }
    }

    public void ComputerChooseCharacter(World world, Player player){
            Random rand = new Random();
            int choix = rand.Next(1, 7);

            switch (choix)
            {
                case 1:
                    Emma Emma = new Emma();
                    if(IsUnlock(Emma)){
                        player.Character = Emma;  
                    } else {
                        ComputerChooseCharacter(world, player);
                    } 
                    break;
                case 2:
                    Tom Tom = new Tom();
                    if(IsUnlock(Tom)){
                        player.Character = Tom;  
                    } else {
                        ComputerChooseCharacter(world, player);
                    }  
                    break;
                case 3:
                    Chamois Chamois = new Chamois();
                    if(IsUnlock(Chamois)){
                        player.Character = Chamois;  
                    } else {
                        ComputerChooseCharacter(world, player);
                    } 
                    break;
                case 4:
                    Kangourou Kangourou = new Kangourou();
                    if(IsUnlock(Kangourou)){
                        player.Character = Kangourou;  
                    } else {
                        ComputerChooseCharacter(world, player);
                    } 
                    break;
                case 5:
                    Pez Pez = new Pez();
                    if(IsUnlock(Pez)){
                        player.Character = Pez;  
                    } else {
                        ComputerChooseCharacter(world, player);
                    } 
                    break;
                case 6:
                    Rhum Rhum = new Rhum();
                    if(IsUnlock(Rhum)){
                        player.Character = Rhum;  
                    } else {
                        ComputerChooseCharacter(world, player);
                    } 
                    break;
                default:
                    Console.WriteLine("\nErreur : ce choix ne correspond à aucune option du menu.");
                    ComputerChooseCharacter(world, player);
                    break;
            }
    }

    private void StartGame1v1(Player player1, Player player2, World world, bool isComputer)
    {
        if(!isComputer){
            while (true)
            {
                Console.WriteLine($"Tour de {player1.Name} :");
                PlayTurn(player1.Character, world, true, false);

                if (IsGameOver1v1(player1.Character, player2.Character))
                {
                    break;
                }

                Console.WriteLine($"Tour de {player2.Name} :");
                PlayTurn(player2.Character, world, false, false);

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
        } else {
            while (true)
            {
                Console.WriteLine($"Tour de {player1.Name} :");
                PlayTurn(player1.Character, world, true, false);

                if (IsGameOver1v1(player1.Character, player2.Character))
                {
                    break;
                }

                Console.WriteLine("Tour de l'ordinateur : ");
                PlayTurn(player2.Character, world, false, true);

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
            Console.WriteLine($"Votre score est de {player1.Score} !");
        }
        else if (character1.QuantityEnergy < character2.QuantityEnergy)
        {
            Console.WriteLine($"Le joueur {player2.Name} a gagné !");
            Console.WriteLine($"Votre score est de {player2.Score} !");
        }
        else
        {
            Console.WriteLine("Égalité !");
        }
    }


    public void AddPlayer(Player player)
    {
        Players.Add(player);
        Console.WriteLine($"Nombre de joueurs : {Players.Count}");
        SavePlayers();
    }

    public void UpdatePlayerScore(Player player, int score)
    {
        player.Score += score;
    }


    public void DisplayTopPlayers()
    {
        List<Player> topPlayers = Players.OrderByDescending(p => p.Score).Take(3).ToList();
        Console.WriteLine("Voici le classement des parties/joueurs : ");

        for (int i = 0; i < topPlayers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {topPlayers[i].Name} - Score: {topPlayers[i].Score}");
        }
    }

    public void SavePlayers()
    {
        string filePath = "players.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Player player in Players)
            {
                writer.WriteLine($"{player.Name}|{player.Score}");
            }
        }
    }


    public void LoadPlayers()
    {
        string filePath = "players.txt";

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] playerData = line.Split('|');
                    if (playerData.Length == 2)
                    {
                        Player player = new Player();
                        player.Name = playerData[0];
                        player.Score = int.Parse(playerData[1]);
                        Players.Add(player);
                    }
                }
            }
        }
    }

}