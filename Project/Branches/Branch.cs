using Project.FilesSystem;
using System.Drawing;

namespace Project.Branches;

public class Branch : IGitItem
{
    #region members
    public string Name { get; set; }
    public double Capacity { get; set; }
    public DateTime LastUpdateDate { get; set; }

    public BranchShared branch;
    //  List<GeneralFile> FilesSystem { get; set; }

    public List<string> Commits;

    public Repository repository;

    public bool isOpenFileSystem { get; set; }
    #endregion


    #region functions 
    public Branch(string name, Repository repository)
    {
        Name = name;
        LastUpdateDate = DateTime.Now;
        Commits = new List<string>();
        branch = repository.GetBranchShared(Name);
        this.repository = repository;
        isOpenFileSystem = true;
    }
    public Branch() { }
    public bool Delete(Repository repository)
    {
        Console.WriteLine("you sure you want to delete the branch?? enter y/n");
        if (Console.ReadLine().Equals("y"))
        {
            repository.Branches.Remove(this);
            Console.WriteLine($"{this.Name} deleted successfully");
            return true;
        }
        Console.WriteLine($"{this.Name} not deleted!!");
        return false;
    }
    public bool Merge(IGitItem item, Repository repo)
    {
        if (item.GetType() == typeof(Branch))
        {
            // make merge for each file in item
            (item as Branch).branch.FilesSystem.ToList().ForEach(f =>
            {
                var fs = this.branch.FilesSystem.FirstOrDefault(ff => ff.Name == f.Name);
                if (fs != null )
                {
                    this.branch.FilesSystem.Remove(fs);
                    this.branch.FilesSystem.Add(f);
                }
               
            });
            repo.Branches.Remove(item as Branch);
        }
        else
            this.branch.FilesSystem.Add((item as GeneralFile));
        Console.WriteLine($"{item} merged successfully");
        return true;
    }
    public void Review()
    {
        //branch.FilesSystem.ForEach((f) => { f.CurrentState.UnderReveiw()}) ;
        foreach (var item in branch.FilesSystem)
        {
            if (typeof(Files) == item.GetType())
            {
                item.Review();
            }
            else
            {
                (item as Folder).RecFile();
            }
        }
        repository.Notify();
    }
    public void Commit()
    {
        Console.WriteLine("enter commit name");
        string CommitName = Console.ReadLine();
        this.Commits.Add(CommitName);
        foreach (var item in branch.FilesSystem)
        {
            if (typeof(Files) == item.GetType())
            {
                item.CurrentState.Commit();
            }
            else
            {
                item.CurrentState.Commit();
                (item as Folder).RecFileToCommit();
            }
        }
        Console.WriteLine("I pass to commit state");
    }
    public void Add(GeneralFile file)
    {

        if (!this.isOpenFileSystem)
        {
            List<GeneralFile> files = new List<GeneralFile>();
            this.branch.FilesSystem.ForEach(f => files.Add(f));
            this.branch.FilesSystem = files;
            this.isOpenFileSystem = true;
        }
        Capacity += file.Size;
        file.FatherBranch = this;
        this.branch.FilesSystem.Add(file);
        Console.WriteLine($"{file.Name} added sucssecfully");
    }
    public void Get(GeneralFile file) { }
    public GeneralFile GetFileSystem(string name)
    {
        foreach (var item in branch.FilesSystem)
        {
            if (item.GetType() == typeof(Files) && item.Name.Equals(name))
                return item;
            return (item as Folder).GetFile(name);
        }
        return null;
    }
    #endregion
}
