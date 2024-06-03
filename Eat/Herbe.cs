class Herbe : Food
{
    public Herbe() : base(15, 13)
    {
    }

    //function which displays food's caracteristics
    public override void DisplayFood()
    {
        Console.WriteLine($"ID : {IdFood}");
        Console.WriteLine($"Quantité d'énergie donné/enlevé: {EnergyGift}");
        Console.WriteLine("Cette nourriture vous redonne de l'énergie aux animaux !");
    }

    //function which applys the food's effect
    public override void EffectFood(Character character){
        if ($"{character}" == "Chamois" || $"{character}" == "Kangourou") {
            character.QuantityEnergy += EnergyGift;
            character.EnergyCount += EnergyGift;
            Console.WriteLine($"Cette nourriture vous redonne {EnergyGift} d'énergie ! :)");
            Console.WriteLine ($"Il vous reste {character.QuantityEnergy} d'énergie");
        }
        else {
            character.QuantityEnergy -= EnergyGift;
            Console.WriteLine($"Cette nourriture vous enlève {EnergyGift} d'énergie ! :(");
            Console.WriteLine ($"Il vous reste {character.QuantityEnergy} d'énergie");
        }
    }
}