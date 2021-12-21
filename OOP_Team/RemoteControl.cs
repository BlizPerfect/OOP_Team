using System;
using System.Collections.Generic;

// Invoker - инициатор
class RemoteControl
{
    ICommand[] Buttons;

    public RemoteControl(int count)
    {
        Buttons = new ICommand[count];
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i] = new NoCommand();
        }
    }

    public void SetCommand(int number, ICommand com)
    {
        Buttons[number] = com;
    }

    public void PressButton(int number)
    {
        Buttons[number].Execute();
    }
    public void PressUndoButton(int number)
    {
        Buttons[number].Undo();
    }
}
