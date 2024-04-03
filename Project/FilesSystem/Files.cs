namespace Project.FilesSystem;

public class Files:GeneralFile
{
    public string DataContext { get; set; }

    public Files(string name, double size) : base(name, size)
    {
    }

    public override string ShowDetails(int depth)
    => $"{base.ShowDetails(depth)}{nameof(Files)}- name: {Name}, size: {Size}KB";

    public void AddData(string data)
    {
        Console.WriteLine("context added succsesfully");
        DataContext += data;
    }
}
