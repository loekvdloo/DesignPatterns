using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Interfaces.SwimBehavior
{
    class SinkSwim : SwimBehavior
    {
        public void Swim()
        {
            Console.WriteLine("I can't swim, I sink!");
        }
    }
}
