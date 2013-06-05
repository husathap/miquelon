using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class TestIntro
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.Instructions.Enqueue("Hello, World!");
            s.Instructions.Enqueue("This is a test. I am not jesting!\n\nNow comes with newline!");
            s.AddInstr("Well, this one is made out of new instruction type thingie...!");
            s.AddInstr(new TestLevel());

            return s;
        }
    }
}
