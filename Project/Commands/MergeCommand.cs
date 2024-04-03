namespace Project.Commands;

public class MergeCommand : GeneralCommand
{

    public IGitItem Item { get; set; }
    public Repository project { get; set; }

    public MergeCommand(IGitItem item, IGitItem item1, Repository anotherItem) : base(item)
    {
        Item = item;
        project = anotherItem;
    }

    public override void Excute()
    {
        Item.Merge(Item, project);
    }
}
