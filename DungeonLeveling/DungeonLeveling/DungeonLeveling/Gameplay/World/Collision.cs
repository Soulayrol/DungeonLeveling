using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using Penumbra;
using System;
using System.Collections.Generic;
using TiledSharp;

namespace DungeonLeveling
{
    public class Collision
    {
        public List<Rectangle> collision;

        public void LoadMap(string path)
        {
            var map = new TmxMap(path);
            var myLayer = map.Layers["collision"];

            int[] collisionLayer = new int[400];
           
            for (int i = 0; i < myLayer.Tiles.Count; i++)
            {
                collisionLayer[i] = myLayer.Tiles[i].Gid;
            }

            Vector2 pointeur = new Vector2(16, 29);
            int y = 0;
            collision = new List<Rectangle>();
            foreach (int i in collisionLayer)
            {
                if (i == 743)
                {
                    collision.Add(new Rectangle((int)pointeur.X, (int)pointeur.Y, 32, 32));
                    Global.penumbra.Hulls.Add(HullFromRectangle(new Rectangle((int)pointeur.X, (int)pointeur.Y, 32, 32)));
                                  
                }
                pointeur.X += 32;
                if (y == 19) { pointeur.Y += 32; pointeur.X = 16; y = -1; }
                y++;
            }
        }

        private static Hull HullFromRectangle(Rectangle bounds)
        {
            return new Hull
            {
                Position = new Vector2(bounds.X, bounds.Y),
                Scale = new Vector2(bounds.Width, bounds.Height)
            };
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

        // LINE/RECTANGLE
        public bool lineRect(float x1, float y1, float x2, float y2, float rx, float ry, float rw, float rh)
        {
            // check if the line has hit any of the rectangle's sides
            // uses the Line/Line function below
            bool left = lineLine(x1, y1, x2, y2, rx, ry, rx, ry + rh);
            bool right = lineLine(x1, y1, x2, y2, rx + rw, ry, rx + rw, ry + rh);
            bool top = lineLine(x1, y1, x2, y2, rx, ry, rx + rw, ry);
            bool bottom = lineLine(x1, y1, x2, y2, rx, ry + rh, rx + rw, ry + rh);

            // if ANY of the above are true, the line
            // has hit the rectangle
            if (left || right || top || bottom)
            {
                return true;
            }
            return false;
        }
        
        // LINE/LINE
        public bool lineLine(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            // calculate the direction of the lines
            float uA = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));
            float uB = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / ((y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1));

            // if uA and uB are between 0-1, lines are colliding
            if (uA >= 0 && uA <= 1 && uB >= 0 && uB <= 1)
            {
                return true;
            }
            return false;
        }

    }
}
