using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonLeveling
{
    public class Unit : Basic2d
    {
        public bool isDead;
        public float speed, hitDist;


        public Unit(string path, Vector2 pos, Vector2 dims, float speedBase = 2f) 
            : base(path, pos, dims)
        {
            isDead = false;
            speed = speedBase;
            hitDist = 35f;
        }

        public override void Update()
        {
            base.Update();
        }
        public override void Draw()
        {
            base.Draw();
        }

        public virtual void GetHit()
        {
            isDead = true;
        }

    }
}
