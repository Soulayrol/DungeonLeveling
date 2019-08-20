#region Using XNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Content.Pipeline;
using System;
using System.Collections.Generic;
using MonoGame.Extended.Tiled.Graphics;
#endregion
 
namespace DungeonLeveling
{
    public class Main : Game
    {
        // Monogame
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public Main()
        {
            IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // Input change to 2 if you want 2 players
            Global.inputs = new InputManager(this);
        }

        protected override void Initialize()
        {
            Global.screenWidth = 640;
            Global.screenHeight = 640;
            Global.graphicsDevice = GraphicsDevice;

            graphics.PreferredBackBufferWidth = Global.screenWidth;
            graphics.PreferredBackBufferHeight = Global.screenHeight;
            // graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            Components.Add(Global.inputs);
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Take Monogame Values
            Global.content = Content;
            Global.spriteBatch = spriteBatch;
            // Load the World
            Global.gameplay = new Gameplay();
        }
        
        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // Take Monogame Values
            Global.gameTime = gameTime;
            // Input check
            Global.inputs.Update(gameTime);
            // Loop
            Global.gameplay.Update();

            

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: Global.camera.get_transformation(GraphicsDevice), samplerState: SamplerState.PointClamp);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
                Global.gameplay.Draw();
            Global.spriteBatch.End();

            Global.spriteBatch.Begin();
                Global.gameplay.world.ui.Draw(Global.gameplay.world);
            Global.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }

    #region Default
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            using (var game = new Main())
                game.Run();
        }
    }
#endif
    #endregion

}
