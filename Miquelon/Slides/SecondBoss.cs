using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class SecondBoss
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.AddInstr(SlideResource.bgmBossBanter2);
            s.AddInstr(SlideResource.txtSecondBoss);
            s.AddInstr("???: Congrats on making up to me. I'm Mike Peterson.\nAnd you shall not pass!");
            s.AddInstr("Bob: Why?");
            s.AddInstr("Mike Peterson: You must prove to me first that\nyou are the strongest!");
            s.AddInstr("Bob: Such phrase is relative, but have at you!");
            s.AddInstr(new Boss2());

            return s;
        }
    }
}
