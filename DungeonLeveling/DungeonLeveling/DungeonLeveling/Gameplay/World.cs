using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Penumbra;
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
        public Hero hero;
        public Map map;
        public string[] maps;
        
        //UI
        public UI ui;
        public int numKilled;

        public World()
        {
            //Camera
            // Global.camera = new Camera();
            // Hero
            var animations = new Dictionary<string, Animation>()
            {
                { "WalkDown", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_down"), 9) },
                { "WalkUp", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_up"), 9) },
                { "WalkLeft", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_left"), 9) },
                { "WalkRight", new Animation(Global.content.Load<Texture2D>("2d/Hero/hero_right"), 9) },
            };
            hero = new Hero(new Vector2(Global.screenWidth / 2, Global.screenHeight / 2), new Vector2(33, 53), animations);
            ui = new UI();
            ui.Update(this);

            maps = new string[5] { "2d/Map/map", "2d/Map/mapTop", "2d/Map/mapDown", "2d/Map/mapLeft", "2d/Map/mapRight" };
            map = new Map(maps[0], hero);
        }

        public void Update()
        {
            // Update the Componenets of the world
            if (!hero.isDead)
            {
                hero.Update();

                if(map.path == maps[0])
                {
                    if (hero.position.X < 0) { map = new Map(maps[3], hero); hero.position = new Vector2(Global.screenWidth, Global.screenHeight / 2); }
                    if (hero.position.X > Global.screenWidth) { map = new Map(maps[4], hero); hero.position = new Vector2(0, Global.screenHeight / 2); }
                    if (hero.position.Y < 0) { map = new Map(maps[1], hero); hero.position = new Vector2(Global.screenWidth / 2 + 10, Global.screenHeight); }
                    if (hero.position.Y > Global.screenWidth) { map = new Map(maps[2], hero); hero.position = new Vector2(Global.screenWidth / 2 + 10, 0); }
                }
                if(map.path == maps[1])
                    if (hero.position.Y > Global.screenWidth) { map = new Map(maps[0], hero); hero.position = new Vector2(Global.screenWidth / 2 + 10, 0); }
                if(map.path == maps[2])
                    if (hero.position.Y < 0) { map = new Map(maps[0], hero); hero.position = new Vector2(Global.screenWidth / 2 + 10, Global.screenHeight); }
                if(map.path == maps[3])
                    if (hero.position.X > Global.screenWidth) { map = new Map(maps[0], hero); hero.position = new Vector2(0, Global.screenHeight / 2); }
                if(map.path == maps[4])
                    if (hero.position.X < 0) { map = new Map(maps[0], hero); hero.position = new Vector2(Global.screenWidth, Global.screenHeight / 2); }
               
                map.Update(ref numKilled, hero);
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
            map.Draw();
            hero.Draw();
        }
        
    }
}
