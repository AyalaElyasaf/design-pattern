namespace Project.Commands;

public class DeleteCommand : GeneralCommand
{
    Repository Repository;
    public DeleteCommand(IGitItem item, Repository repository) : base(item)
    {
        Repository = repository;
    }
    public override void Excute()
    {
        if (Item.GetType()==typeof(Branch))
        {
            (Item as Branch).Delete(Repository);
        }
    }
}
