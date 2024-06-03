public abstract class Food
{
    public int EnergyGift {get; set;}
    public int IdFood { get; set; }



    public Food(int energyGift, int idFood)
    {
        EnergyGift = energyGift;
        IdFood = idFood;
    }

    //function which displays food's caracteristics
    public abstract void DisplayFood();

    //function which applys the food's effect
    public abstract void EffectFood(Character character);

}