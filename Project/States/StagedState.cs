namespace Project.States;

public class StagedState : BranchState
{

    public StagedState(GeneralFile file) : base(file)
    {

    }
    #region function
    public override void Commit()
    {
        throw new InvalidStateException();
    }

    public override void Druft()
    {
        throw new InvalidStateException();
    }

    public override void Error()
    {
        throw new InvalidStateException();
    }

    public override void GetMassage()
    {
        throw new InvalidStateException();
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
