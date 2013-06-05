using Miquelon.Shooter.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    public class Intro
    {
        public static Slide Create()
        {
            Slide s = new Slide();

            s.AddInstr(SlideResource.bgmGoFishing);
            s.AddInstr(SlideResource.txtPollutedWorld);
            s.AddInstr("In the future, the world has become heavily \npolluted. Creatures mutates. The environment becomes\nirreversibly altered.");
            s.AddInstr(SlideResource.txtInternationalBan);
            s.AddInstr("The fish population has been reduced. To preserve the fish,\nthe international law has banned all fishing. Still, illegal\nfishing persists.");
            s.AddInstr(SlideResource.txtEvolution);
            s.AddInstr("Due to natural selection, the surviving fish population has\nbecome smarter. Most fish now also have poisonous flesh.\nFish can no longer be fished; they must now be hunted.");
            s.AddInstr("Fishermen now become fishhunters.");
            s.AddInstr(SlideResource.txtEnslavement);
            s.AddInstr("Illegal fishhunters have enslaved a population of poisonous\nfish to aid them with tracking down the last few remaining\nedible fish.");
            s.AddInstr("One day, the fishhunters decide to hunt for Bob, the most\nelusive edible fish in the ocean. In order to do so, they\nhave kidnapped Bob's girlfriend.");
            s.AddInstr(SlideResource.txtKidnapped);
            s.AddInstr("You must help Bob to get back his girlfriend. Are you bad\nenough of a dude to do so?");
            s.AddInstr(SlideResource.txtLevel1);
            s.AddInstr(new Level1());

            return s;
        }
    }
}
