public class Invoker
{
    private Command m_Command;

    public void SetCommand(Command command)
    {
        m_Command = command;
    }

    public void ExecuteCommandWithEnqueue(Command command)
    {
        CommandLog.commands.Enqueue(m_Command);
        m_Command.Execute();
    }

    public void ExecuteCommandWithoutEnqueue(Command command)
    {
        m_Command.Execute();
    }
}