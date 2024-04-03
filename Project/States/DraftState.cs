namespace Project.States;

public class DraftState: BranchState
{

    public DraftState(GeneralFile file) : base(file)
    {

    }

    #region function
    public override void Commit()
    {
        file.ChangeState(new CommitState(file));
        Console.WriteLine($"the file{file.Name} pass to commit state");
    }

    public override void Druft()
    {
        throw new InvalidStateException($"the file{file.Name} can not pass to Druft state");
    }

    public override void Error()
    {
        throw new InvalidStateException();
    }

    public override void GetMassage()
    {
        throw new NotImplementedException();
    }

    

    public override void staged()
    {
        throw new InvalidStateException();
    }

    public override void UnderReveiw()
    {
        throw new InvalidStateException();
    }
    #endregion
}
