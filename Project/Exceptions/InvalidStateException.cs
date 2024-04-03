namespace Project.Exceptions;

internal class InvalidStateException:Exception
{
    public InvalidStateException(string massage)
    {
        Console.WriteLine(massage); 
    }
    public InvalidStateException()
    {
        
    }
}
