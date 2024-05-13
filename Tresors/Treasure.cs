public abstract class Treasure
{
    public abstract void ApplyEffect(Character character);
}


bool DemanderEnigme(int typeEnigme){

    string[] questionsEnigme = {"\nVous venez de tomber dans sur un trésor négatif ! voulez-vous résoudre une énigme pour éviter ce trésors (oui/non)",
                                "\nVous etes bloqué! voulez-vous résoudre une énigme pour débloquer le plateau? (oui/non)"};

    string réponse = "";
    //on redemande tant que la réponse n'est pas un "oui" ou un "non"
    while(réponse != "oui" && réponse != "non"){

        Console.WriteLine(questionsEnigme[typeEnigme]);
        réponse = Console.ReadLine()!;
    }

    return réponse == "oui";
}   


bool RésoudreEnigme(){

    string[,] enigmes = {{"3+4 = ?","7"},{"2+4 = ?","6"},{"4+8 = ?","12"},{"((4-4)*3)^2*342452 = ?","0"},{"2*2-3 = ?","1"}};

    //tire aléaltoirement une énigme parmis le tableau enigmes
    Random random = new Random();
    int nAleatoire = random.Next(0,enigmes.GetLength(0)-1);

    Console.WriteLine(enigmes[nAleatoire,0]); //affichage de l'énigme
    string réponse = Console.ReadLine()!;

    //évaluation de la réponse de l'utilisateur
    return enigmes[nAleatoire,1] == réponse;
}
