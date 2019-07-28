using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{ 
    // Gestion de la 2d /  création des entitées
    public class Basic2d
    {
        public float rotation;
        public Vector2 position, dimension;
        public Texture2D texture;

        public Basic2d(string path, Vector2 pos, Vector2 dims)
        {
            position = pos;
            dimension = dims;
            if(path != null)
                texture = Global.content.Load<Texture2D>(path);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (texture != null) {
                Global.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y), null, Color.White, rotation, new Vector2(texture.Bounds.Width / 2, texture.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }
        public virtual void Draw(Vector2 Origin, Color color)
        {
            if (texture != null) {
                Global.spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y), null, color, rotation, new Vector2(Origin.X / 2, Origin.Y / 2), new SpriteEffects(), 0);
            }
        }
        
    }
}
