namespace Project.Commands;

public class ReviewCommand : GeneralCommand
{
    public ReviewCommand(IGitItem item) : base(item){}

    public override void Excute()
    {
        Item.Review();
    }
}