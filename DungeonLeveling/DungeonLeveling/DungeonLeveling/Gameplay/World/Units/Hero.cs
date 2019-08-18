using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonLeveling
{
    public class Hero : Unit
    {
        private TimerMaster cooldown = new TimerMaster(500);

        public Hero(Vector2 pos, Vector2 dims, Dictionary<string, Animation> animations) 
            : base(pos, dims, animations)
        {
            healh = 100;
            healhMax = healh;
            speed = 2.5f;
        }

        public override void Update()
        {
            Vector2 cameraDirection = Vector2.Zero;
            cooldown.UpdateTimer();
            
            // Mouvement
            if ((Global.inputs.IsPressed(Input.Left) || Global.inputs.IsPressed(Keys.Q)))
            {
                position.X -= speed;
                --cameraDirection.X;
                --Velocity.X;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.X += speed;
                    ++cameraDirection.X;
                    ++Velocity.X;
                }
            }
            if ((Global.inputs.IsPressed(Input.Right) || Global.inputs.IsPressed(Keys.D)))
            {
                position.X += speed;
                ++cameraDirection.X;
                ++Velocity.X;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.X -= speed;
                    --cameraDirection.X;
                    --Velocity.X;
                }
            }
            if ((Global.inputs.IsPressed(Input.Up) || Global.inputs.IsPressed(Keys.Z)))
            {
                position.Y -= speed;
                --cameraDirection.Y;
                --Velocity.Y;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.Y += speed;
                    ++cameraDirection.Y;
                    ++Velocity.Y;
                }
            }
            if ((Global.inputs.IsPressed(Input.Down) || Global.inputs.IsPressed(Keys.S)))
            {
                position.Y += speed;
                ++cameraDirection.Y;
                ++Velocity.Y;
                // Test colision
                if (Global.collision.IsCollision(BoudingBox))
                {
                    position.Y -= speed;
                    --cameraDirection.Y;
                    --Velocity.Y;
                }
            }
            if ((Global.inputs.IsPressed(Input.RightStick) || Global.inputs.IsPressed(MouseInput.LeftButton)) && cooldown.Test())
            {
                cooldown.ResetToZero();
                Global.gameplay.world.AddProjectile(new Bullet(position, this, Global.camera.GetWorldPosition(Global.inputs.GetMousePositionVector())));
            }
            rotation = Global.RotateTowards(position, Global.camera.GetWorldPosition(Global.inputs.GetMousePositionVector()));

            Global.camera.Pos += cameraDirection * speed;

            base.Update();
        }


    }
}
