using System;

namespace LifeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var automaton = new Automaton(16,32);

            while (true)
            {
                automaton.Print();
                System.Threading.Thread.Sleep(1500);
                automaton.Update();
            }
        }
    }
}