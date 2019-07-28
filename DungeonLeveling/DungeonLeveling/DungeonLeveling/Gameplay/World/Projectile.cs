using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace DungeonLeveling
{
    public class Projectile : Basic2d
    {
        public float speed;
        public Unit owner;
        public Vector2 direction;
        public bool done;

        protected TimerMaster timer;

        public Projectile(string Path, Vector2 Pos, Vector2 Dims, Unit Owner, Vector2 Targer)
            : base(Path, Pos, Dims)
        {
            owner = Owner;
            done = false;
            direction = Targer - owner.position;
            direction.Normalize();
            rotation = Global.RotateTowards(position, new Vector2(Targer.X, Targer.Y));
        }

        public virtual void Update(List<Unit> units)
        {
            position += direction * speed;

            timer.UpdateTimer();
            if (timer.Test())
                done = true;
            if (CollisionTest(units))
                done = true;
                
        }

        public virtual bool CollisionTest(List<Unit> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (Global.GetDistance(position, units[i].position) < units[i].hitDist)
                {
                    units[i].GetHit(50f);
                    return true;
                }
            }
            return false;
        }


        public override void Draw()
        {
            base.Draw();
        }

    }
}
