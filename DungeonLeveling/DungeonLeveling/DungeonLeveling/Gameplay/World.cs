using Microsoft.Xna.Framework;
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
            hero = new Hero("2d/Units/Hero/sorcier", new Vector2(Global.screenWidth/2 - 24, Global.screenHeight/2 -24), new Vector2(48, 48));
            
            // Spawner
            spawnPoints.Add(new SpawnPoint("2d/Units/Mobs/necro", new Vector2(50, 50), new Vector2(60, 60)));
            spawnPoints.Add(new SpawnPoint("2d/Units/Mobs/necro", new Vector2(Global.screenWidth / 2, 50), new Vector2(60, 60)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);
            spawnPoints.Add(new SpawnPoint("2d/Units/Mobs/necro", new Vector2(Global.screenWidth - 50, 50), new Vector2(60, 60)));
            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);

            ui = new UI();
            ui.Update(this);
        }

        public void Update()
        {
            // Update the Componenets of the world
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
    }
}
