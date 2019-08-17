using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{
    // Classe avec tout les obj du jeu
    public class World
    {

        // Units 
        public Hero hero;
        public List<Mob> mobs = new List<Mob>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
        public List<Projectile> projectiles = new List<Projectile>();
        public List<Unit> tuable = new List<Unit>();

        // Initialisation de tous les obj
        
        //UI
        public UI ui;
        public int numKilled;


        public World()
        {
            //Camera
            Global.camera = new Camera();
            // Hero
            var animations = new Dictionary<string, Animation>()
            {
                { "WalkDown", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_down"), 9) },
                { "WalkUp", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_up"), 9) },
                { "WalkLeft", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_left"), 9) },
                { "WalkRight", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_right"), 9) },
            };
            hero = new Hero(GetWorldPosition(new Vector2(Global.screenWidth / 2 - 24, Global.screenHeight / 2 - 24)), new Vector2(33, 53), animations);

            // Spawner
            spawnPoints.Add(new SpawnPoint("Autre/vide", GetWorldPosition(new Vector2(1000, 600)), new Vector2(60, 60)));
            
            ui = new UI();
            ui.Update(this);
        }

        public void Update()
        {
            // Update the Componenets of the world
            if (!hero.isDead)
            {
                hero.Update();

                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(mobs.ToList<Unit>());
                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < mobs.Count; i++)
                {
                    mobs[i].Update(hero);
                    if (mobs[i].isDead)
                    {
                        numKilled++;
                        mobs.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < spawnPoints.Count; i++)
                {
                    spawnPoints[i].Update();
                    if (spawnPoints[i].isDead)
                    {
                        spawnPoints.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                if(Global.inputs.IsPressed(Input.Start) || Global.inputs.IsPressed(Keys.Enter))
                {
                    Global.gameplay.ResetWorld();
                }
            }
            // Update UI
            ui.Update(this);
        }

        public void Draw()
        {
            foreach (SpawnPoint spawnPoint in spawnPoints)
            {
                spawnPoint.Draw();
            }
            foreach (Mob mob in mobs)
            {
                mob.Draw();
            }
            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw();
            }

            hero.Draw();
            
        }

        public virtual void AddMob(object obj)
        {
            mobs.Add((Mob)obj);
        }
        public virtual void AddProjectile(object obj)
        {
            projectiles.Add((Projectile)obj);
        }
        public Vector2 GetWorldPosition(Vector2 screenPosition)
        {
            return screenPosition + Global.camera.Pos;
        }
    }
}
