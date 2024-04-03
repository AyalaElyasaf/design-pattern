namespace Project;

public class Repository : IClone
{
    #region members
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }

    Dictionary<string, BranchShared> _shared;

    public List<Branch> Branches;

    public List<User> RepositoryOwner;

    List<User> Subscribes;
    #endregion

    #region functions
    public Repository(string name, string description)
    {
        Name = name;
        Description = description;
        Branches = new List<Branch>();
        RepositoryOwner = new List<User>();
        Subscribes = new List<User>();
        _shared = new Dictionary<string, BranchShared>();
    }
    public BranchShared GetBranchShared(string name)
    {
        if (!_shared.ContainsKey(name))
        {
            BranchShared newBranchShared = new();
            _shared[name] = newBranchShared;
        }
        return _shared[name];
    }
    public void Subscribe(User user)
    {
        if (RepositoryOwner.Contains(user))
        {
            Subscribes.Add(user);
            Console.WriteLine("The registration was successful");
        }
        else
            Console.WriteLine("You do not have permission!!");
    }
    public void Unsubscribe(User user)
    {
        if (Subscribes.Contains(user))
        {
            Subscribes.Remove(user);
            Console.WriteLine("Removal from the list of subscribes was done successfully!");
        }
        else
            Console.WriteLine("your remove filed!!");
    }
    public void Notify()
    {
        Subscribes.ForEach(u => u.Update());
    }
    public void AddBranch(Branch branch)
    {
        Branches.Add(branch);
    }
    public Branch Clone(Branch branch)
    {
        Branch newBranch = new Branch();
        newBranch.Name = branch.Name;
        newBranch.LastUpdateDate = DateTime.Now;
        newBranch.repository = branch.repository;
        newBranch.branch = branch.repository.GetBranchShared(branch.Name);
        Console.WriteLine("new branch created.");
        newBranch.isOpenFileSystem = true;
        return newBranch;
    }
    #endregion
}
