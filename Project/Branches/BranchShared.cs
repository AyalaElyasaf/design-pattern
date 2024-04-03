namespace Project.Branches;

public class BranchShared
{
    public List<GeneralFile> FilesSystem { get; set; }
    public BranchShared()
    {
        FilesSystem = new List<GeneralFile>();
    }
}
