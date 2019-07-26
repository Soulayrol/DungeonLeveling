using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonLeveling { 
    public class UI
    {
        public SpriteFont font;

        public UI()
        {
            font = Global.content.Load<SpriteFont>("Fonts\\pixel");
        }
        public void Update(World world)
        {

        }
        public void Draw(World world)
        {
            string tempStr = "Killed = " + world.numKilled;
            Vector2 strDims = font.MeasureString(tempStr);
            Global.spriteBatch.DrawString(font, tempStr, new Vector2(Global.screenWidth / 2 - strDims.X / 2, Global.screenHeight - 40), Color.Black);
        }
    }
}
