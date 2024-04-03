namespace Project.Commands;

public class CommitCommand : GeneralCommand
{
    public CommitCommand(IGitItem item) : base(item)
    {
    }

    public override void Excute()
    {
        Item.Commit();
    }

}
