using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class DvdPlayer : IPlayable
    {
        public void play()
        {
            WriteLine("DVD is playing");
        }
        public void pause()
        {
            WriteLine("DVD is paused");
        }
    }
}
