namespace Project.States;
public class UnderReviewState : BranchState
{
    public UnderReviewState(GeneralFile file) : base(file)
    {

    }
    public override void Commit()
    {
        throw new InvalidStateException("can not pass");
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
        file.ChangeState(new StagedState(file));
    }

    public override void UnderReveiw()
    {
        throw new InvalidStateException("current state");
    }
}
