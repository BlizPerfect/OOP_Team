using System;

interface ICommand
{
    void Execute();
    void Undo();
}
class NoCommand : ICommand
{
    public void Execute()
    {
    }
    public void Undo()
    {
    }
}