using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{
    public class Elemental : Mob
    {
        public Elemental(Vector2 Pos) : base("2d\\Units\\Mobs\\water_elemental", Pos, new Vector2(50,50))
        {
            speed = 2f;
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);
        }
        


        public override void Draw(Vector2 Offset)
        {
            base.Draw(Offset);
        }


    }
}
