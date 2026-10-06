using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    internal class DvdPlayer
    {
        private Amplifier _amplifier;
        public DvdPlayer(Amplifier amplifier)
        {
            _amplifier = amplifier;
        }

        public void On()
        {
            Console.WriteLine("DvdPlayer: On()");
        }
        public void Off()
        {
            Console.WriteLine("DvdPlayer: Off()");
        }
        public void Eject()
        {
            Console.WriteLine("DvdPlayer: Eject()");
        }
        public void Pause()
        {
            Console.WriteLine("DvdPlayer: Pause()");
        }
        public void Play(string movie)
        {
            Console.WriteLine($"DvdPlayer: Play({movie})");
        }
        public void SetSurroundAudio()
        {
            Console.WriteLine("DvdPlayer: SetSurroundAudio()");
        }
        public void SetTWoChannelAudio()
        {
            Console.WriteLine("DvdPlayer: SetTWoChannelAudio()");
        }
        public void Stop()
        {
            Console.WriteLine("DvdPlayer: Stop()");
        }
    }
}
