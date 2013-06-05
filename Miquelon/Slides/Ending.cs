using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class Ending
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.AddInstr(SlideResource.bgmGoFishing);
            s.AddInstr(SlideResource.txtEnding1);
            s.AddInstr("Bella: It's over...");
            s.AddInstr("Bob: I beat you all right. Now, I'm going to the\nbar and get a fix. Good game though.");
            s.AddInstr("Bella: Don't you want a revenge. For the betrayal,\nfor the injustice? Finish me off now!");
            s.AddInstr("Bob: I'm too tired. Argue with me later. I'm going\nto the bar first. And don't forget to feed Kitty.");
            s.AddInstr(SlideResource.txtEnding2);
            s.AddInstr("AT THE BAR");
            s.AddInstr("Spike: Hey, dude!");
            s.AddInstr("Bob: Whatsup!");
            s.AddInstr("Spike: Good news, the Hashimoto-Jackson gov't has\ntotally cracked down the illegal fishhunters.");
            s.AddInstr("Bob: So you don't need to try to kill me again.");
            s.AddInstr("Spike: Indeed.");
            s.AddInstr("Bob: By the way, do you know Mike Peterson?\nIs he a new guy?");
            s.AddInstr("Spike: I've never heard of Mike Peterson before.\nWhere did you meet him?");
            s.AddInstr(SlideResource.txtEnding3);
            s.AddInstr(SlideResource.txtCredits);
            s.AddInstr(new Title());

            return s;
        }
    }
}
