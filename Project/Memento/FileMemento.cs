namespace Project.Memento;

public class FileMemento : IMemento
{
    Stack<string> history = new Stack<string>();
    public void save(GeneralFile file)
    {
        if (file.GetType() == typeof(Files))
            history.Push((file as Files).DataContext);
        else
            history.Push(file.Name);
    }
    public string Restore()
    {
        return history.Pop();
    }
}
