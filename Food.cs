public abstract class Food
{
    public int EnergyGift {get; set;}
    public int IdFood { get; private set; }

    private static int foodIdCounter = 1;


    public Food(int energyGift)
    {
        EnergyGift = energyGift;
        IdFood = foodIdCounter ++;
    }

  
    public abstract void DisplayFood();

    public abstract void EffectFood(Character character);

}