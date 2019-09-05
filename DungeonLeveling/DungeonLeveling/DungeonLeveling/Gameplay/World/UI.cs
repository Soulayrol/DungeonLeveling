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
        public QuantityDisplayBarHero healtBar;
        public QuantityDisplayBarHero xpBar;



        public UI()
        {
            font = Global.content.Load<SpriteFont>("Fonts\\futurist");
            healtBar = new QuantityDisplayBarHero(2, Color.Red, "Autre/healthBar");
            xpBar = new QuantityDisplayBarHero(2, Color.Green, "Autre/xpBar");
        }
        public void Update(World world)
        {
            healtBar.Update(world.hero.healh, world.hero.healhMax);
            xpBar.Update(world.hero.xp, world.hero.xpMax);
        }
        public void Draw(World world)
        {
            // Heal Bar
            healtBar.Draw();

            // Nb kill string
            string tempStr;
            Vector2 strDims;
            // Hero heal txt
            tempStr = "Healh : " + Global.gameplay.world.hero.healh;
            Global.spriteBatch.DrawString(font, tempStr, new Vector2(25, Global.screenHeight - 30), Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
            // Xp 
            xpBar.Draw();
            tempStr = "Xp : " + Global.gameplay.world.hero.xp;
            Global.spriteBatch.DrawString(font, tempStr, new Vector2(Global.screenWidth - 215, Global.screenHeight - 30), Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
            Global.spriteBatch.DrawString(font, "Niv : " + Global.gameplay.world.hero.niv.ToString(), new Vector2(Global.screenWidth - 100, Global.screenHeight - 25), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);

            // Loose
            if (world.hero.isDead) {
                tempStr = "Appuyer sur ENTRER pour recommencer !";
                strDims = font.MeasureString(tempStr);
                Global.spriteBatch.DrawString(font, tempStr, new Vector2(Global.screenWidth / 2 - strDims.X / 2, Global.screenHeight / 2 - strDims.X / 2), Color.White);
            }
            
        }
    }
}
