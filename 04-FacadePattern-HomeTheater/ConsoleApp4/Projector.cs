using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class Projector
    {
        private DvdPlayer _dvdPlayer;
        public Projector()
        {
        }

        public void SetInput(DvdPlayer dvdPlayer)
        {
            Console.WriteLine("Projector: SetInput(DvdPlayer)");
            this._dvdPlayer = dvdPlayer;
        }

        public void On()
        {
            Console.WriteLine("Projector: On()");
        }

        public void Off()
        {
            Console.WriteLine("Projector: Off()");
        }

        public void TvMode()
        {
            Console.WriteLine("Projector: TvMode()");
        }

        public void WideScreenMode()
        {
            Console.WriteLine("Projector: WideScreenMode()");
        }
    }
}
