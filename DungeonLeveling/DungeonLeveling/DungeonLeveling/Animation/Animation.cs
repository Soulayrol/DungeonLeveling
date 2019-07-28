using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{
    public class Animation
    {
        public int CurrentFrame;
        public int FrameCount;
        public int FrameHeight = 53;
        public float FrameSpeed;
        public int FrameWidth = 33;
        public bool isLooping;
        public Texture2D Texture;

        public Animation(Texture2D texture, int frameCount)
        {
            Texture = texture;
            FrameCount = frameCount;
            isLooping = true;
            FrameSpeed = 0.1f;
        }
        

    }
}
