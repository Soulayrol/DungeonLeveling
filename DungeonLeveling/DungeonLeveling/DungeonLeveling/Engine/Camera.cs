using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DungeonLeveling
{
    public class Camera
    {
        protected float _zoom; // Camera Zoom
        public Matrix _transform; // Matrix Transform
        public Vector2 _pos; // Camera Position
        protected float _rotation; // Camera Rotation

        public Camera()
        {
            _zoom = 1.0f;
            _rotation = 0.0f;
            _pos = Vector2.Zero;
        }

        // Sets and gets zoom
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            _pos += amount;
        }
        // Get set position
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =       // Thanks to o KB o for this solution
                Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 0));
            return _transform;
        }


        public Vector2 GetScreenPosition(Vector2 worldPosition)
        {
            return worldPosition - Pos;
        }

        public Vector2 GetWorldPosition(Vector2 screenPosition)
        {
            return screenPosition + Pos;
        }

    }

/*


    public class Camera
    {
        public Matrix transform;
        
       
        public void Follow(Hero hero)
        {
            Rectangle rectangle = new Rectangle((int)hero.position.X, (int)hero.position.Y, (int)hero.dimension.X, (int)hero.dimension.Y);

            var position = Matrix.CreateTranslation(
                -hero.position.X - (rectangle.Width / 2),
                -hero.position.Y - (rectangle.Height / 2),
                0);

            var offset = Matrix.CreateTranslation(
                Global.screenWidth / 2,
                Global.screenHeight / 2,
                0);

            transform = position * offset;
        }

        public Vector2 GetScreenPosition(Vector2 worldPosition)
        {
            return worldPosition - Pos;
        }

        public Vector2 GetWorldPosition(Vector2 screenPosition)
        {
            return screenPosition + Pos;
        }

        /*
        private void UpdateVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(Transform);

            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);

            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }
        
    }
    */
}

