using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using System;
using System.Collections.Generic;

namespace DungeonLeveling
{
    public class Collision
    {
        public List<Rectangle> collision;

        public void LoadCollision()
        {
            int[] collisionLayer = new int[400]{    744,744,744,744,744,744,744,744,744,0,0,744,744,744,744,744,744,744,744,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,744,744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,744,744,744,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                                    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,744,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,
                                                    744,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,744,744,
                                                    744,744,744,744,744,744,744,744,744,0,0,744,744,744,744,744,744,744,744,744,
                                                    744,744,744,744,744,744,744,744,744,0,0,744,744,744,744,744,744,744,744,744             }; 


            Vector2 pointeur = new Vector2(16, 29);
            int y = 0;
            collision = new List<Rectangle>();
            foreach (int i in collisionLayer)
            {
                if (i == 744)
                {
                    collision.Add(new Rectangle((int)pointeur.X, (int)pointeur.Y, 32, 32));
                }
                pointeur.X += 32;
                if (y == 19) { pointeur.Y += 32; pointeur.X = 16; y = -1; }
                y++;
            }
        }

        public bool IsCollision(Rectangle unit)
        {
            bool isCollide = false;
            for (int i = 0; i < collision.Count && isCollide == false; i++)
            {
                if (collision[i].Intersects(unit)) { isCollide = true; }
            }
            return isCollide;
        }

    }
}
