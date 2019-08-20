﻿using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLeveling
{
    public class Map
    {
        private TiledMap map;
        private TiledMapRenderer mapRenderer;
        // Units 
        public List<Mob> mobs = new List<Mob>();
        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
        public List<Projectile> projectiles = new List<Projectile>();
        public List<Unit> tuable = new List<Unit>();
        public string path;

        public Map(string Path)
        {
            // Map
            path = Path;
            map = Global.content.Load<TiledMap>(path);
            mapRenderer = new TiledMapRenderer(Global.graphicsDevice);
            Global.collision = new Collision();
            Global.collision.LoadCollision("../../Content/"+ path +".tmx");
            // Spawner
            spawnPoints.Add(new SpawnPoint("Autre/vide", new Vector2(500, 500), new Vector2(60, 60)));
        }

        public void Update(ref int numKilled, Hero hero)
        {
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

        public void Draw()
        {
            mapRenderer.Draw(map, null);

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
