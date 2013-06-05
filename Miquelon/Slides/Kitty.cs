using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class Kitty
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.AddInstr(SlideResource.bgmBossBanter3);
            s.AddInstr(SlideResource.txtKitty);
            s.AddInstr("Bob: Kitty! What are you doing here?");
            s.AddInstr("Kitty: Meow! (Hiding your girlfriend and stuffs.)");
            s.AddInstr("Bob: You were on the fishhunters' sides?");
            s.AddInstr("Kitty: Meow! Meow, meow! (You are so dumb.)");
            s.AddInstr("Bob: You are going down, man!");
            s.AddInstr("Kitty: Meow! Meow, meow meow! (I'm a cat, but whatever!\nWell, before that, ya got to catch me first!)");
            s.AddInstr(SlideResource.txtLevel3);
            s.AddInstr(new Level3());

            return s;
        }
    }
}
