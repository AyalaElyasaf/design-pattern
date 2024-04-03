namespace Project.Commands;

public abstract class GeneralCommand
{
    protected IGitItem Item { get; set; }
    private GeneralCommand() { }
    public GeneralCommand(IGitItem item)
    {
        Item = item;
    }
    public abstract void Excute();

    private static TaskManager _instance;

    private static readonly object _lock = new object();

    public static TaskManager GetInstance()
    {
        if (_instance == null){
            lock (_lock){
                if (_instance == null)
                    _instance = new TaskManager();
            }
        }
        return _instance;
    }
}


