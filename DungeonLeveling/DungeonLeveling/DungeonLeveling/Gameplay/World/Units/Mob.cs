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

        public Mob(string Path, Vector2 Pos, Vector2 Dims) : base(Path, Pos, Dims)
        {

        }

        public virtual void Update(Hero hero)
        {
            AI(hero);
            base.Update();
        }

        public virtual void AI(Hero hero)
        {
            position += Global.RadialMovement(hero.position, position, speed);
            rotation = Global.RotateTowards(position, hero.position);
        }


        public override void Draw()
        {
            base.Draw();
        }


    }
}
