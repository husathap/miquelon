using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class FinalBoss
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.AddInstr(SlideResource.bgmBossBanter3);
            s.AddInstr(SlideResource.txtFinalBoss);
            s.AddInstr("Bob: Ah! Bella, finally found you. Want to go out?");
            s.AddInstr("Bella: Oh Bob... I thought the mutants would get you.");
            s.AddInstr("Bob: Well, they've certainly failed.");
            s.AddInstr("Bella: But at least, I'd get to personally catch you.");
            s.AddInstr("Bob: What do you mean?");
            s.AddInstr("Bella: I'm actually a human working with the fishhunters.\nThey turned me into a fish so that I'd lure you into\ntheir trap.");
            s.AddInstr("Bob: Is being a fish fun?");
            s.AddInstr("Bella: NO! I don't want to be a fish. But I have no choice,\nI have to be one to pay the rental mortgage. Thanks to\nHashimoto-Wrangler's government...");
            s.AddInstr("Bob: Are you here to catch/kill me?");
            s.AddInstr("Bella: Unfornately yes... But I don't want to...");
            s.AddInstr("Bob: Then down with Kitty, Mike Peterson, Epsilon & Delta,\nSpike and the Ultimate Blocky!");
            s.AddInstr(new Boss3());

            return s;
        }
    }
}
