using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class FirstBoss
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.AddInstr(SlideResource.bgmBossBanter1);
            s.AddInstr(SlideResource.txtFirstBoss);
            s.AddInstr("Bob: I've come to rescue my girlfriend!");
            s.AddInstr("Spike: I'd like to apologize for my underlings' and for my\nown behaviours. But our masters' commands are absolute.");
            s.AddInstr("Bob: Just give me back my girlfriend.");
            s.AddInstr("Spike: We are afraid that we are not allowed to do that.");
            s.AddInstr("Bob: Fine, I'll take you down then! You and your formality!");
            s.AddInstr("Spike: Then, come at me bro!");
            s.AddInstr(new Boss1());

            return s;
        }
    }
}
