using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{
    public class Gameplay
    {
        int playState;
        public World world;

        public Gameplay()
        {
            playState = 0;
            ResetWorld();
        }
        public virtual void Update()
        {
            if (playState == 0)
                world.Update();
        }
        public virtual void Draw()
        {
            if (playState == 0)
                world.Draw();
        }

        public virtual void ResetWorld()
        {
            world = new World();
        }


    }
}
