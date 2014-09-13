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
        private Texture2D ball;
        private Vector2 ballPosition = new Vector2();
        private Vector2 ballVelocity = new Vector2();
        private int WIDTH, HEIGHT;

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
            ballVelocity = new Vector2(4f, 4f);

            if (ballPosition.Y >= HEIGHT - 30)
            {
                ballVelocity.Y = ballVelocity.Y * -1;
            }
            if (ballPosition.X >= WIDTH - 30)
            {
                ballVelocity.X = ballVelocity.X * -1;
            }
            ballPosition.X = ballPosition.X + ballVelocity.X;
            ballPosition.Y = ballPosition.Y + ballVelocity.Y;
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