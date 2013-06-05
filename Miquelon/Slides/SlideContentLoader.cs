using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Slides
{
    /// <summary>
    /// A class that helps to load Slide's stuffs.
    /// </summary>
    public static class SlideContentLoader
    {

        /// <summary>
        /// The method that loads the stuffs.
        /// </summary>
        /// <param name="Content"></param>
        public static void LoadContent(ContentManager Content)
        {
            Slide.TransitionTexture = Content.Load<Texture2D>("Art/Screen");
            Slide.IntertileTexture = Content.Load<Texture2D>("Art/Intertile");
            Slide.SlideFont = Content.Load<SpriteFont>("Fonts/Slide");

            SlideResource.txtEnslavement = Content.Load<Texture2D>("Art/Slide/Enslavement");
            SlideResource.txtEvolution = Content.Load<Texture2D>("Art/Slide/Evolution");
            SlideResource.txtInternationalBan = Content.Load<Texture2D>("Art/Slide/InternationalBan");
            SlideResource.txtKidnapped = Content.Load<Texture2D>("Art/Slide/Kidnapped");
            SlideResource.txtPollutedWorld = Content.Load<Texture2D>("Art/Slide/PollutedWorld");

            SlideResource.txtFirstBoss = Content.Load<Texture2D>("Art/Slide/FirstBoss");
            SlideResource.txtSecondBoss = Content.Load<Texture2D>("Art/Slide/SecondBoss");
            SlideResource.txtKitty = Content.Load<Texture2D>("Art/Slide/Kitty");
            SlideResource.txtFinalBoss = Content.Load<Texture2D>("Art/Slide/FinalBoss");

            SlideResource.txtEnding1 = Content.Load<Texture2D>("Art/Slide/Ending1");
            SlideResource.txtEnding2 = Content.Load<Texture2D>("Art/Slide/Ending2");
            SlideResource.txtEnding3 = Content.Load<Texture2D>("Art/Slide/Ending3");

            SlideResource.txtLevel1 = Content.Load<Texture2D>("Art/Slide/Level1");
            SlideResource.txtLevel2 = Content.Load<Texture2D>("Art/Slide/Level2");
            SlideResource.txtLevel3 = Content.Load<Texture2D>("Art/Slide/Level3");

            SlideResource.txtCredits = Content.Load<Texture2D>("Art/Slide/Credits");

            SlideResource.bgmGoFishing = Content.Load<SoundEffect>("Music/GoFishing");
            SlideResource.bgmBossBanter1 = Content.Load<SoundEffect>("Music/BossBanter1");
            SlideResource.bgmBossBanter2 = Content.Load<SoundEffect>("Music/BossBanter2");
            SlideResource.bgmBossBanter3 = Content.Load<SoundEffect>("Music/BossBanter3");
        }
    }
}
