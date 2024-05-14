class LifeFood : Food
{
    public LifeFood() : base(5, 10)
    {
    }

    public override void DisplayFood()
    {
        Console.WriteLine($"ID : {IdFood}");
        Console.WriteLine($"Quantité d'énergie donné/enlevé: {EnergyGift}");
        Console.WriteLine("Cette nourriture vous redonne de la vie !");
    }

    public override void EffectFood(Character character){
        character.LifePoint += EnergyGift;
        Console.WriteLine($"Cette nourriture vous redonne {EnergyGift} de vie ! :)");
        Console.WriteLine ($"Il vous reste {character.LifePoint} point de vie !");
    }

}
