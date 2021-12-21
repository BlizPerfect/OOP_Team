using System;

// Receiver - Получатель
class Rover
{
    public RoverEngine Engine = new RoverEngine();
    public RoverHeadlightsPower HeadlightsPower = new RoverHeadlightsPower();
}
class RoverEngine
{
    bool IsOn = false;
    public void On()
    {
        if (IsOn)
        {
            Console.WriteLine("Двигатель марсохода уже запущен!");
        }
        else
        {
            Console.WriteLine("Двигатель марсохода запущен!");
            IsOn = true;
        }
    }

    public void Off()
    {
        if (!IsOn)
        {
            Console.WriteLine("Двигатель марсохода уже выключен!");
        }
        else
        {
            Console.WriteLine("Двигатель марсохода выключен!");
            IsOn = false;
        }
    }
}

class RoverEngineOnCommand : ICommand
{
    Rover Rover;
    public RoverEngineOnCommand(Rover RoverSet)
    {
        Rover = RoverSet;
    }
    public void Execute()
    {
        Rover.Engine.On();
    }
    public void Undo()
    {
        Rover.Engine.Off();
    }
}

class RoverHeadlightsPower
{
    public const int OFF = 0;
    public const int HIGH = 3;
    private int Level;
    public RoverHeadlightsPower()
    {
        Level = OFF;
    }

    public void RaiseLevel()
    {
        if (Level < HIGH)
        {
            Level += 1;
            Console.WriteLine("Мощность фар {0}", Level);
        }
        else
        {
            Console.WriteLine("Мощность фар уже на максимуме!");
        }
    }
    public void DropLevel()
    {
        if (Level > OFF)
        {
            Level -= 1;
            Console.WriteLine("Мощность фар {0}", Level);
        }
        else
        {
            Console.WriteLine("Мощность фар уже на минимуме!");
        }

    }
}
class RoverHeadlightsPowerCommand : ICommand
{
    Rover Rover;
    public RoverHeadlightsPowerCommand(Rover rover)
    {
        Rover = rover;
    }
    public void Execute()
    {
        Rover.HeadlightsPower.RaiseLevel();
    }

    public void Undo()
    {
        Rover.HeadlightsPower.DropLevel();
    }
}
