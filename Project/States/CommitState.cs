namespace Project.States;

public class CommitState : BranchState
{
    public CommitState(GeneralFile file):base(file)
    {

    }
    #region function
    public override void Commit()
    {
        throw new InvalidStateException("you are un this state!");
    }

    public override void Druft()
    {
        file.ChangeState(new DraftState(file));
    }

    public override void Error()
    {
        file.ChangeState(new ErrorState(file));

    }

    public override void GetMassage()
    {
        throw new NotImplementedException();
    }

   

    public override void staged()
    {
        throw new InvalidStateException("you can not pass to merge state");
    }

    public override void UnderReveiw()
    {
        throw new InvalidStateException("you can not pass to merge state");
    }
    #endregion
}
