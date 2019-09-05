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
        protected AnimationManager _animationManager;
        public Vector2 Velocity;
        protected Dictionary<string, Animation> _animations;
        public bool isDead;
        public float speed, hitDist, healh, healhMax;
        public Rectangle BoudingBox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, (int)dimension.X, (int)dimension.Y); }
        }

        public Unit(string path, Vector2 pos, Vector2 dims, float healhMaxP, float speedBase = 2f) 
            : base(path, pos, dims)
        {
            isDead = false;
            speed = speedBase;
            hitDist = 35f;
            healh = healhMaxP;
            healhMax = healh;
        }
        public Unit(Vector2 pos, Vector2 dims, Dictionary<string, Animation> animations, float speedBase = 2f)
            : base(null, pos, dims)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
            speed = speedBase;
        }

        public override void Update()
        {
            if (_animationManager != null)
            {
                SetAnimations();
                _animationManager.Update();
            }
            
            base.Update();
            Velocity = Vector2.Zero;
        }
        public override void Draw()
        {
            if (_animationManager != null)
            {
                _animationManager.Position = position;
                _animationManager.Draw(Global.spriteBatch);

            }
            else if (texture != null)
                base.Draw();
        }

        public virtual void GetHit(float dmg)
        {
            healh -= dmg;
            if(healh <= 0)
                isDead = true;
        }

        protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Stop();
        }
        


    }
}
