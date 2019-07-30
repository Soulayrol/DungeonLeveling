using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{
    public class SpawnPoint : Unit
    {
        public TimerMaster spawnTimer;

        public SpawnPoint(string Path, Vector2 Pos, Vector2 Dims) : base(Path, Pos, Dims)
        {
            spawnTimer = new TimerMaster(4000);
        }

        public override void Update()
        {
            spawnTimer.UpdateTimer();
            if (spawnTimer.Test())
            {
                SpawnMob();
                spawnTimer.ResetToZero();
            }

            base.Update();
        }

        public virtual void SpawnMob()
        {
            Global.gameplay.world.AddMob(new RedBlop(new Vector2(position.X, position.Y)));
        }


        public override void Draw()
        {
            base.Draw();
        }


    }
}
