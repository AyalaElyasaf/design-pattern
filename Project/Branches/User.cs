namespace Project;

public class User 
{
    #region properties
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<Repository> Repositories = new List<Repository>();
    #endregion

    #region functions
    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
    public void Sharing(string repoName, User user)
    {
        Repository repository = Repositories.FirstOrDefault(r => r.Name == repoName);
        if (repository != null)
        {
            user.Repositories.Add(repository);
            Console.WriteLine($"user {user.Name} Added to the owner of the repository {repository.Name}");
            repository.RepositoryOwner.Add(user);
        }
        else
        Console.WriteLine("repository not found");
    }
    public void AddRepo(Repository repo)
    {
        Repositories.Add(repo);
        repo.RepositoryOwner.Add(this);
    }
    public void Update()
    {
        Console.WriteLine($"user: {this.Name} got Automatic notification of a user's request to review of his code");
    }

    #endregion
}