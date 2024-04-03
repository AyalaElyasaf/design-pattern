using Microsoft.VisualBasic;
using Project.Memento;
using Project.States;

namespace Project.FilesSystem;
public class GeneralFile : IGitItem
{
    #region members
    public string Name { get; set; }
    public double Size { get; set; }

    public Branch FatherBranch { get; set; }
    public BranchState CurrentState { get; set; }

    public IMemento FilesHistory { get; set; }

    #endregion


    #region functions
    public virtual string ShowDetails(int depth)
    {
        string indent = "";
        for (int i = 0; i < depth; i++, indent += "\t") ;
        return indent;
    }
    public GeneralFile(string name, double size)
    {
        CurrentState = new DraftState(this);
        Name = name;
        Size = size;
        FilesHistory = new FileMemento();
    }
    public void ChangeState(BranchState state)
    {
        CurrentState = state;
    }
    public bool Merge(IGitItem another, Repository repository)
    {
        if (this.GetType() == typeof(Files) && another.GetType() == typeof(Files) || this.GetType() == typeof(Folder) && another.GetType() == typeof(Branch))
        {
            this.CurrentState.Error();
            return false;
        }
        if (this.CurrentState.GetType() == typeof(CommitState))
        {

            GeneralFile f = (GeneralFile)another;
            f.CurrentState.staged();
            Console.WriteLine("I passed from Merge");
            
            return true;
        }
        this.CurrentState.Error();
        return false;
    }
    public void Review()
    {
        CurrentState.UnderReveiw();
    }
    public void Commit()
    {
        if (CurrentState.GetType() == typeof(DraftState))
        {
            Console.WriteLine("enter commit name");
            string CommitName = Console.ReadLine();
            this.FatherBranch.Commits.Add(CommitName);
            FilesHistory.save(this);
            Console.WriteLine("I mooved to commit state");
            this.CurrentState.Commit();
        }
        else
        {
            Console.WriteLine("the requet file, Jast from druft you can move to commit");
            this.CurrentState.Error();
        }
    }
    public void UndoTheCommit()
    {
        switch (this.CurrentState)
        {
            case CommitState:
                ChangeState(new DraftState(this));
                break;
            case UnderReviewState:
                ChangeState(new DraftState(this));
                break;
            case BranchState:
                throw new InvalidStateException("you dont showld to commited");
        }
        if (this.GetType() == typeof(Files))
            (this as Files).DataContext = FilesHistory.Restore();
        else this.Name = FilesHistory.Restore();

    }
    #endregion
}
