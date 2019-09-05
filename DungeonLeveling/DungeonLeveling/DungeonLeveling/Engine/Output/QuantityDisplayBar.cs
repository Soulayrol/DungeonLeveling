using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonLeveling
{
    public class QuantityDisplayBarHero
    {
        public int boarder;
        public Basic2d bar, barBkg;
        public Color color;
        public int test;


        public QuantityDisplayBarHero(int Border, Color Color, string path)
        {
            boarder = Border;
            color = Color;
            if(path == "Autre/xpBar")
            {
                bar = new Basic2d(path, new Vector2(Global.screenWidth - 217, Global.screenHeight - 47), new Vector2(200, 32));
                barBkg = new Basic2d(path + "Bkg", new Vector2(Global.screenWidth - 220, Global.screenHeight - 46), new Vector2(200, 32));
            }
            else
            {
                bar = new Basic2d(path, new Vector2(24, Global.screenHeight - 46), new Vector2(200, 32));
                barBkg = new Basic2d(path + "Bkg", new Vector2(20, Global.screenHeight - 46), new Vector2(200, 32));
            }
            
        }

        public virtual void Update(float current, float max)
        {
            bar.dimension.X = current / max * (barBkg.dimension.X - boarder * 2) - 8;
        }

        public virtual void Draw()
        {
            barBkg.Draw(new Vector2(0,0), Color.Black);
            bar.Draw(new Vector2(0, 0), color);
        }
    }

    public class QuantityDisplayBar
    {
        public int boarder;
        public Basic2d bar, barBkg;
        public Color color;
        public Vector2 offset;

        public QuantityDisplayBar(Vector2 dims, int Border, Color Color, Vector2 position)
        {
            boarder = Border;
            color = Color;
            offset = new Vector2(-40, -40);
            bar = new Basic2d("Autre/healthBarSimple", position + offset, dims);
            barBkg = new Basic2d("Autre/healthBarBkgSimple", position + offset, dims);
        }

        public virtual void Update(float current, float max, Vector2 position)
        {
            bar.dimension.X = current / max * (barBkg.dimension.X - boarder * 2);
            bar.position = position + offset;
            barBkg.position = position + offset;
        }

        public virtual void Draw()
        {
            barBkg.Draw(new Vector2(0, 0), Color.Black);
            bar.Draw(new Vector2(0, 0), color);
        }
    }
}
