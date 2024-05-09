class LifeFood : Food
{
    public LifeFood() : base(35, 10)
    {
    }

    public override void DisplayFood()
    {
        Console.WriteLine($"ID : {IdFood}");
        Console.WriteLine($"Quantité d'énergie donné/enlevé: {EnergyGift}");
        Console.WriteLine("Cette nourriture vous redonne de la vie !");
    }

    public override void EffectFood(Character character){
        Console.WriteLine("Pas encore codé");
    }

}
