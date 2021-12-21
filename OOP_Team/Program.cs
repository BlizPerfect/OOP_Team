using System;

namespace OOP_Team
{
    class Program
    {
        public static int InputCount()
        {
            var error = true;
            int result = 0;
            while (error)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result < 5 && result > 0)
                    {
                        error = false;
                    }
                    else
                    {
                        Console.Write("Параметра с таким индексом не существет, повторите ввод: ");
                    }
                }
                else
                {
                    Console.Write("Вы ввели не число, попробуйте снова: ");
                }
            }
            return result;
        }


        static void Main(string[] args)
        {
            Rover rover = new Rover();
            RemoteControl remoteControl = new RemoteControl(2);
            remoteControl.SetCommand(0, new RoverEngineOnCommand(rover));
            remoteControl.SetCommand(1, new RoverHeadlightsPowerCommand(rover));
            Console.WriteLine("СПИСОК ДЕЙСТВИЙ МАРСОХОДА:\n1: Запуск двигателя\n2: Выключение двигателя\n3: Увеличить мощность фар\n4: Уменьшить мощность фар\n");
            var choise = 0;

            while (true)
            {
                Console.Write("\nЧто вы хотите сделать?: ");
                choise = InputCount();
                if (choise == 1)
                {
                    remoteControl.PressButton(0);
                }
                else if (choise == 2)
                {
                    remoteControl.PressUndoButton(0);
                }
                else if (choise == 3)
                {
                    remoteControl.PressButton(1);
                }
                else if (choise == 4)
                {
                    remoteControl.PressUndoButton(1);
                }
            }
        }
    }
}
