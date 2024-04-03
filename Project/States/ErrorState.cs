using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.States;

public class ErrorState:BranchState
{
    public ErrorState(GeneralFile file) : base(file)
    {

    }

    #region functions
    public override void Commit()
    {
        file.ChangeState(new DraftState(file));
    }

    public override void Druft()
    {
        file.ChangeState(new DraftState(file));
    }

    public override void Error()
    {
        throw new InvalidStateException("the corrent state");
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
        file.ChangeState(new DraftState(file));
    }
    #endregion
}
