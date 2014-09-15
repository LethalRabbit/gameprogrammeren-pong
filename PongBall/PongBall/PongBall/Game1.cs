using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PongBall
{
    public class PongBallGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ball;
        Vector2 ballPosition = new Vector2();
        float Xspeed = -4;
        float Yspeed = 4;
        int WIDTH, HEIGHT;

        static void Main()
        {
            PongBallGame game = new PongBallGame();
            game.Run();
        }

        protected override void Initialize()
        {
            WIDTH = GraphicsDevice.Viewport.Width;
            HEIGHT = GraphicsDevice.Viewport.Height;
            ballPosition = new Vector2((WIDTH / 2), (HEIGHT / 2));

            base.Initialize();
        }



        public PongBallGame()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = Content.Load<Texture2D>("simple ball");

        }

        protected override void Update(GameTime gameTime)
        {

            ballPosition.X = ballPosition.X + Xspeed;
            ballPosition.Y = ballPosition.Y + Yspeed;

            if (ballPosition.Y > HEIGHT - 30 || ballPosition.Y <= 0)
            {
                Yspeed = -Yspeed;
            }
            if (ballPosition.X > WIDTH - 30 || ballPosition.X <= 0 )
            {
                Xspeed = -Xspeed;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(ball, ballPosition, Color.White);
            spriteBatch.End();
        }
    }
}