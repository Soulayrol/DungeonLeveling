using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using Penumbra;
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
        // Lighting
        public Light heroLight = new PointLight
        {
            Scale = new Vector2(300),
            Color = Color.White,
            CastsShadows = false
        };
        List<Light> mapLights = new List<Light>();
        private TimerMaster timeLight = new TimerMaster(200);
        Texture2D lightTex = Global.content.Load<Texture2D>("2d/Map/TexturedLight");

        public Map(string Path, Hero hero)
        {
            Global.penumbra.Hulls.Clear();
            Global.penumbra.Lights.Clear();
            // Map
            path = Path;
            map = Global.content.Load<TiledMap>(path);
            mapRenderer = new TiledMapRenderer(Global.graphicsDevice);
            Global.collision = new Collision();
            Global.collision.LoadMap("../../Content/" + path + ".tmx");
            // Spawner
            spawnPoints.Add(new SpawnPoint("Autre/vide", new Vector2(500, 500), new Vector2(60, 60)));
            
            Global.penumbra.Lights.Add(heroLight);
            foreach (KeyValuePair<Vector2, Color> obj in Global.collision.mapLight)
            {
                Light mapLight = new TexturedLight(lightTex)
                {
                    Scale = new Vector2(50),
                    Color = obj.Value,
                    Intensity = 1.2f,
                    Position = new Vector2(obj.Key.X - 16, -obj.Key.Y + 30),
                    Rotation = MathHelper.PiOver2
                };
                mapLights.Add(mapLight);
                Global.penumbra.Lights.Add(mapLight);
            }
        }

        public void Update(ref int numKilled, Hero hero)
        {
            heroLight.Position = new Vector2(hero.position.X, -hero.position.Y);

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
                    hero.xp += mobs[i].xp;
                    if(hero.xp >= hero.xpMax)
                    {
                        hero.xp -= hero.xpMax;
                        hero.xpMax = (int)(hero.xpMax * 1.3);
                        hero.niv++;
                    }
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
            timeLight.UpdateTimer();
            if (timeLight.Test())
            {
                Random rand = new Random();
                foreach (Light light in mapLights)
                {
                    float val;
                    if (light.Color == Color.White)
                        val = rand.Next(45, 50);
                    else
                        val = rand.Next(15, 50);
                    light.Scale = new Vector2(val);
                }
                timeLight.ResetToZero();
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
