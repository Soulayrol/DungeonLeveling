using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{
    public class Mob : Unit
    {
        public QuantityDisplayBar healBar;
        public int xp;

        public Mob(string Path, Vector2 Pos, Vector2 Dims, int xpParam = 10) : base(Path, Pos, Dims, 100 * (1 + ((float)Global.gameplay.world.hero.niv / 10)), 2)
        {
            healBar = new QuantityDisplayBar(new Vector2(80, 8), 2, Color.Red, Pos);
            xp = xpParam;
        }

        public virtual void Update(Hero hero)
        {
            healBar.Update(healh, healhMax, position);
            AI(hero);
            base.Update();
        }

        public virtual void AI(Hero hero)
        {
            position += Global.RadialMovement(hero.position, position, speed);
            rotation = Global.RotateTowards(position, hero.position);

            if (Global.GetDistance(position, hero.position) < 15)
            {
                hero.GetHit(25);
                isDead = true;
            }

        }


        public override void Draw()
        {
            healBar.Draw();
            base.Draw();
        }


    }
}
