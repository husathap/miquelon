using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miquelon.Shooter.Level
{
    public class TestLevel : Level
    {
        Random rand = new Random();
       

        protected override void UpdateBackground(GameTime gameTime) 
        {
        }

        protected override void DrawBackground(SpriteBatch sb)
        {
        }

        protected override void PrepareLevel()
        {
            
        }

        public TestLevel() : base(null)
        {
            this.WaveList = null;
            EnemyList.Add(new Enemy.Bella(this));

        }

        protected override void EndLevel()
        {
            throw new NotImplementedException();
        }
    }
}
