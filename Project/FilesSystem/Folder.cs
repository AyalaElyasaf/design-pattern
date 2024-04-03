namespace Project.FilesSystem;

public class Folder : GeneralFile
{
    public List<GeneralFile> folders { get; private set; }

    #region funcs

    public Folder(string name, double size) : base(name, size)
    {
        folders = new List<GeneralFile>();
    }
    public void Clear()
    {
        folders.Clear();
    }
    public bool Contains(GeneralFile item)
    {
        if (folders.Contains(item)) { return true; }
        return false;
    }
    public void Add(GeneralFile item)
    {
        item.FatherBranch = this.FatherBranch;
        if (!FatherBranch.isOpenFileSystem)
        {
            List<GeneralFile> files = new List<GeneralFile>();
            FatherBranch.branch.FilesSystem.ForEach(f => files.Add(f));
            FatherBranch.branch.FilesSystem = files;
            FatherBranch.isOpenFileSystem=true;
        }
        Size += item.Size;
        folders.Add(item);
        FatherBranch.Capacity += item.Size;
    }
    public bool Remove(GeneralFile item)
    {
        if (!FatherBranch.isOpenFileSystem)
        {
            List<GeneralFile> files = new List<GeneralFile>();
            FatherBranch.branch.FilesSystem.ForEach(f => files.Add(f));
            FatherBranch.branch.FilesSystem = files;
            FatherBranch.isOpenFileSystem = true;
        }
        GeneralFile file = folders.FirstOrDefault( i=> i.Name == item.Name);
        if (file != null)
        {
            folders.Remove(file);
            Console.WriteLine($"{file.Name} removed succesfully");
            Size -= file.Size;
            FatherBranch.Capacity-= file.Size;
            return true;
        }
        Console.WriteLine($"not found file {item.Name}");
        return false;
    }
    public override string ShowDetails(int depth)
    {
        string indent = base.ShowDetails(depth);
        string s = $"{indent}{nameof(Folder)}- name: {Name}, size: {Size}KB";
        foreach (var item in folders)
        {
            s += "\n";
            s += item.ShowDetails(depth + 1);
        }
        return s;
    }
    public void RecFile()
    {
        foreach (var item in folders)
        {
            if (item.GetType() == typeof(Files))
                item.Review();
            else
            {
                item.Review();
                (item as Folder).RecFile();
            }
        }
    }
    public void RecFileToCommit()
    {
        foreach (var item in folders)
        {
            if (item.GetType() == typeof(Files))
                item.ChangeState(new CommitState(item));
            else
            {
                (item as Folder).ChangeState(new CommitState(item));
                (item as Folder).RecFileToCommit();
            }
        }
    }
    public GeneralFile GetFile(string name)
    {
        foreach (var item in folders)
        {
            if (typeof(Files) == item.GetType() && item.Name.Equals(name))
                return item;
            else if (name.Equals(item.Name))
                return item;
            else
                return (item as Folder).GetFile(name);
        }

        return null;
    }
    #endregion
}
