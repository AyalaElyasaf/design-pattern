namespace Project.States;

public abstract class BranchState
{
    protected GeneralFile file { get; }


    #region functions
    public BranchState(GeneralFile file)
    {
        this.file = file;
    }
    public abstract void GetMassage();
    public abstract void Druft();
    public abstract void Commit();
    public abstract void staged();
    public abstract void Error();
    public abstract void UnderReveiw();
    #endregion
}
