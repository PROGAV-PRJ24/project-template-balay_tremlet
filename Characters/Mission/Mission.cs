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

    public abstract void DisplayMission();

    public abstract bool CheckCompletion(Character character, Boat boat, World world);
} 
