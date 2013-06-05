using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class TransitionToLevel2
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.AddInstr(SlideResource.bgmBossBanter2);
            s.AddInstr("???: Good game on beating the first level.");
            s.AddInstr("???: But you will need to be stronger.");
            s.AddInstr("???: Meet me at the end of the level!");
            s.AddInstr(SlideResource.txtLevel2);
            s.AddInstr(new Level2());

            return s;
        }
    }
}
