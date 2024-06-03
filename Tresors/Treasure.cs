public abstract class Treasure
{
    public int WeightTreasure {get; set;}
    public string Name {get; set;}

    public Treasure (){
        Name = "";
    }

    public Treasure(int weightTreasure){
        WeightTreasure = weightTreasure;
        Name="";
    }

    //function which applys the treasure's effect
    public abstract void ApplyEffect(Character character, Player player);

    //function which shows the enigma
    protected bool DemanderEnigme(int typeEnigme)
    {
        string[] questionsEnigme = {
            "\nVous venez de tomber sur un trésor négatif ! Voulez-vous résoudre une énigme pour éviter cet effet négatif ? (oui/non)",
         
        };

        string réponse = "";
   
        while (réponse != "oui" && réponse != "non")
        {
            Console.WriteLine(questionsEnigme[typeEnigme]);
            réponse = Console.ReadLine()?.ToLower() ?? "";
        }

        return réponse == "oui";
    }

    //function which determines if the enigma is solved
    protected bool RésoudreEnigme()
    {
        string[,] enigmes = {
            {"Qu'est-ce qui est toujours devant vous mais que vous ne pouvez jamais atteindre ?", "L'avenir"},
            {"Qu'est-ce qui fait le tour de la maison sans bouger ?","Le mur"},
            {"Un smartphone et sa coque coûtent 110 euros en tout. Le smartphone coûte 100 euros de plus que la coque. Combien coûte le smartphone ?","105"},
            {"((4 - 4) * 3) ^ 2 * 342452 = ?", "0"},
          
        };

        Random random = new Random();
        int nAleatoire = random.Next(0, enigmes.GetLength(0));

        Console.WriteLine(enigmes[nAleatoire, 0]); 
        string réponse = Console.ReadLine()?.Trim() ?? "";

        return enigmes[nAleatoire, 1] == réponse;
    }

}


