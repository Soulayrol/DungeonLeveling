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


        public QuantityDisplayBarHero(Vector2 dims, int Border, Color Color)
        {
            boarder = Border;
            color = Color;
            bar = new Basic2d("Autre/healthBar", new Vector2(20, Global.screenHeight - 100), dims);
            barBkg = new Basic2d("Autre/healthBarBkg", new Vector2(20, Global.screenHeight - 100), dims);
        }

        public virtual void Update(float current, float max)
        {
            bar.dimension.X = current / max * (barBkg.dimension.X - boarder * 2);

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
