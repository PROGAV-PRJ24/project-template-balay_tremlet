public abstract class Mission
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Mission (string name, string description, bool isCompleted){
        Name = name;
        Description = description;
        IsCompleted = isCompleted;
    }

    //function which displays missions caracteristics
    public abstract void DisplayMission();

    //function which checks if the mission is completed
    public abstract bool CheckCompletion(Character character, Boat boat, World world, Player player);
} 
