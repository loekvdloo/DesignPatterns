using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class PopcornPopper
    {
        public void On()
        {
            Console.WriteLine("PopcornPopper: On()");
        }

        public void Off()
        {
            Console.WriteLine("PopcornPopper: Off()");
        }

        public void Pop()
        {
            Console.WriteLine("PopcornPopper: Pop()");
        }
    }
}
