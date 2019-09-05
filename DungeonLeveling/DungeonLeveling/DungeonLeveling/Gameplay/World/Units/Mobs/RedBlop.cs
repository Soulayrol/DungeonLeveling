using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DungeonLeveling
{
    public class RedBlop : Mob
    {
        private static int xp = 10;
        public RedBlop(Vector2 Pos) : base("2d\\Units\\Mobs\\monster_1", Pos, new Vector2(50, 50), xp)
        {
            speed = 2f;
        }

        public override void Update(Hero hero)
        {
            base.Update(hero);
        }

        public override void Draw()
        {
            base.Draw();
        }


    }
}
