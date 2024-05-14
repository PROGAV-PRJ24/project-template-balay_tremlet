public abstract class Mission
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public abstract void DisplayMission();

    public abstract bool CheckCompletion(Character character);
}
