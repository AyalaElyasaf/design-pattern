namespace Project;

public class TaskManager
{
    Queue<GeneralCommand> FunctionsToExecute=new Queue<GeneralCommand>();
    public void runTheFunctions(GeneralCommand command){
        FunctionsToExecute.Enqueue(command);
        var commandTodo= FunctionsToExecute.Dequeue();
        commandTodo.Excute();
    }
}
