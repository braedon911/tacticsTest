using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandRecord
{
    public CommandRecord() { }
    private readonly Stack<CommandBase> history = new Stack<CommandBase>();
    public void Do(CommandBase command)
    {
        command.Execute();
        history.Push(command);
    }
    public void Undo()
    {
        history.Pop().Undo();
    }
    void RefreshHistory() { history.Clear(); }

}
