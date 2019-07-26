using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace DungeonLeveling
{
    public class Fireball : Projectile
    {
        private TimerMaster timerFireball = new TimerMaster(5000);

        public Fireball(Vector2 Pos, Unit Owner, Vector2 Target) 
            : base("2d/Projectiles/fireball", Pos, new Vector2(40, 40), Owner, Target)
        {
            speed = 5.0F;
            timer = timerFireball;
        }

        public override void Update(List<Unit> units)
        {
            base.Update(units);
        }

        public override void Draw()
        {
            base.Draw();
        }

    }
}
