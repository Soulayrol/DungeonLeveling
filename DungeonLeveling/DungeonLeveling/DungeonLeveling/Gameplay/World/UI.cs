﻿using System;
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



        public UI()
        {
            font = Global.content.Load<SpriteFont>("Fonts\\futurist");
            healtBar = new QuantityDisplayBarHero(new Vector2(208, 32), 2, Color.Red);
        }
        public void Update(World world)
        {
            healtBar.Update(world.hero.healh, world.hero.healhMax);
        }
        public void Draw(World world)
        {
            // Heal Bar
            healtBar.Draw();


            // Nb kill string
            string tempStr = "Killed = " + world.numKilled;
            Vector2 strDims = font.MeasureString(tempStr);
            Global.spriteBatch.DrawString(font, tempStr, new Vector2(Global.screenWidth / 2 - strDims.X / 2, Global.screenHeight - 40), Color.Black);
            // Hero heal txt
            string tempStrHeal = "Healh : " + Global.world.hero.healh;
            Vector2 strDimsHeal = font.MeasureString(tempStr);
            Global.spriteBatch.DrawString(font, tempStrHeal, new Vector2(25, Global.screenHeight - 83), Color.White, 0f, Vector2.Zero, 0.8f, SpriteEffects.None, 0);
            
        }
    }
}