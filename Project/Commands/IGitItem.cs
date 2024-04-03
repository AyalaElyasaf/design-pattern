namespace Project.Commands;

public interface IGitItem
{
    public bool Merge(IGitItem another, Repository repository);
    public void Review();
    public void Commit();
}
