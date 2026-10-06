using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class Amplifier
    {
        private Tuner _tuner;
        private DvdPlayer _dvdPlayer;
        private CdPlayer _cdPlayer;

        public void On()
        {
            Console.WriteLine("Amplifier: On()");
        }

        public void Off()
        {
            Console.WriteLine("Amplifier: Off()");
        }
        public void SetCd(CdPlayer cdPlayer)
        {
            Console.WriteLine("Amplifier: SetCd(CdPlayer)");
            this._cdPlayer = cdPlayer;
        }
        public void SetDvd(DvdPlayer dvdPlayer)
        {
            Console.WriteLine("Amplifier: SetDvd(DvdPlayer)");
            this._dvdPlayer = dvdPlayer;
        }
        public void SetStereoSound()
        {
            Console.WriteLine("Amplifier: SetStereoSound()");
        }
        public void SetSurroundSound()
        {
            Console.WriteLine("Amplifier: SetSurroundSound()");
        }
        public void SetTuner(Tuner tuner)
        {
            Console.WriteLine("Amplifier: SetTuner(Tuner)");
            this._tuner = tuner;
        }
        public void SetVolume(int volume)
        {
            Console.WriteLine($"Amplifier: SetVolume({volume})");
        }

    }
}
