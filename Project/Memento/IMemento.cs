namespace Project.Memento;

public interface IMemento
{
    public void save(GeneralFile file);
    public string Restore();
}
