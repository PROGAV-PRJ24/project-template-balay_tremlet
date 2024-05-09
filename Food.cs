public abstract class Food
{
    public int EnergyGift {get; set;}
    public int IdFood { get; set; }



    public Food(int energyGift, int idFood)
    {
        EnergyGift = energyGift;
        IdFood = idFood;
    }

  
    public abstract void DisplayFood();

    public abstract void EffectFood(Character character);

}