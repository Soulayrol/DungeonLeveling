using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace DungeonLeveling
{
    public class Bullet : Projectile
    {
        private TimerMaster timerBullet = new TimerMaster(5000);

        public Bullet(Vector2 Pos, Unit Owner, Vector2 Target) 
            : base("2d/Projectiles/bullet", Pos, new Vector2(10, 30), Owner, Target)
        {
            timer = timerBullet;
            speed = 5.0F;
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
