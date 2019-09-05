using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Penumbra;

namespace DungeonLeveling
{
    public class Hero : Unit
    {
        private TimerMaster cooldown = new TimerMaster(1000);
        private TimerMaster cooldown2 = new TimerMaster(1500);
        public int xp = 0;
        public int xpMax = 100;
        public int niv = 0;

        public Hero(Vector2 pos, Vector2 dims, Dictionary<string, Animation> animations) 
            : base(pos, dims, animations)
        {
            healh = 100;
            healhMax = healh;
            speed = 2.5f;
        }

        public override void Update()
        {
            cooldown.UpdateTimer();
            cooldown2.UpdateTimer();

            // Mouvement
            if ((Global.inputs.IsPressed(Input.Left) || Global.inputs.IsPressed(Keys.Q)))
            {
                position.X -= speed;
                --Velocity.X;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.X += speed;
                    ++Velocity.X;
                }
            }
            if ((Global.inputs.IsPressed(Input.Right) || Global.inputs.IsPressed(Keys.D)))
            {
                position.X += speed;
                ++Velocity.X;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.X -= speed;
                    --Velocity.X;
                }
            }
            if ((Global.inputs.IsPressed(Input.Up) || Global.inputs.IsPressed(Keys.Z)))
            {
                position.Y -= speed;
                --Velocity.Y;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.Y += speed;
                    ++Velocity.Y;
                }
            }
            if ((Global.inputs.IsPressed(Input.Down) || Global.inputs.IsPressed(Keys.S)))
            {
                position.Y += speed;
                ++Velocity.Y;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.Y -= speed;
                    --Velocity.Y;
                }
            }
            if ((Global.inputs.IsPressed(Input.RightStick) || Global.inputs.IsPressed(MouseInput.LeftButton)) && cooldown.Test())
            {
                cooldown.ResetToZero();
                Global.gameplay.world.map.AddProjectile(new Bullet(position, this, Global.inputs.GetMousePositionVector()));
            }
            if ((Global.inputs.IsPressed(Input.LeftStick) || Global.inputs.IsPressed(MouseInput.RightButton)) && cooldown2.Test())
            {
                cooldown2.ResetToZero();
                Global.gameplay.world.map.AddProjectile(new Bolt(position, this, Global.inputs.GetMousePositionVector()));
            }
            rotation = Global.RotateTowards(position, Global.inputs.GetMousePositionVector());

            // Global.camera.Pos += cameraDirection * speed;

            base.Update();
        }


    }
}
