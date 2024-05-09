class Pate : Food
{
    public Pate() : base(15)
    {
    }

    public override void DisplayFood()
    {
        Console.WriteLine($"ID : {IdFood}");
        Console.WriteLine($"Quantité d'énergie donné/enlevé: {EnergyGift}");
        Console.WriteLine("Cette nourriture vous redonne de l'énergie à Emma !");
    }

    public override void EffectFood(Character character){
        if ($"{character}" == "Emma") {
            character.QuantityEnergy += EnergyGift;
            Console.WriteLine($"Cette nourriture vous redonne {EnergyGift} d'énergie ! :)");
            Console.WriteLine ($"Il vous reste {character.QuantityEnergy} d'énergie");

        } else {
            character.QuantityEnergy -= EnergyGift;
            Console.WriteLine($"Cette nourriture vous enlève {EnergyGift} d'énergie ! :(");
            Console.WriteLine ($"Il vous reste {character.QuantityEnergy} d'énergie");
        }
    }
}