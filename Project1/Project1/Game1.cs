using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace breakout
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int ballAlivesInit = 3;
        // Balls for game
        int ballAlives = 3;

        Player player;
        
        // Ball
        Ball ball;
        Vector2 ballStartPosition;
        Vector2 startDirection;

        // Block Manager
        BlockManager blockManager;
        Vector2 blocksStartPosition;
        
        // Font
        SpriteFont font;

        // Sounds
        SoundEffect soundUpLife;
        SoundEffect soundLose;
        bool soundLoseActive = true;
        SoundEffect soundHitBall;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 360;
            _graphics.ApplyChanges();

            float centerWidth = _graphics.PreferredBackBufferWidth / 2;
            
            player = new Player(this, "player", new Vector2(centerWidth - 64, _graphics.PreferredBackBufferHeight - 64));
            ballStartPosition = new Vector2(centerWidth - 8, _graphics.PreferredBackBufferHeight - 128);
            ball = new Ball(this, "ball", ballStartPosition);
            
            blocksStartPosition = new Vector2(100, 64);
            startDirection = new Vector2(1, -1);

            blockManager = new BlockManager(this, 3, 6);
            blockManager.FillBlocks(blocksStartPosition);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            soundHitBall = Content.Load<SoundEffect>("hit");
            soundLose = Content.Load<SoundEffect>("lose");
            soundUpLife = Content.Load<SoundEffect>("3up");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var keys = Keyboard.GetState();

            // Reset ballAlives
            if (keys.IsKeyDown(Keys.Space) && (ballAlives <= 0 || blockManager.CheckIfWin())) {
                blockManager.ClearBlock(blocksStartPosition);
                ballAlives = ballAlivesInit;
                ball.speedX = Ball.speed;
                ball.speedY = Ball.speed;
                soundUpLife.Play();
                soundLoseActive = true;
            }

            if (!blockManager.CheckIfWin()) {
                // Player movement
                player.Move(gameTime, keys, _graphics.PreferredBackBufferWidth);

                ball.Move(gameTime, startDirection);

                // Ball collision with the screen
                if (ball.position.X < 0 || ball.position.X + ball.texture.Width > _graphics.PreferredBackBufferWidth)
                    ball.speedX *= -1;
                if (ball.position.Y < 0 )
                    ball.speedY *= -1;
                
                if (ball.position.Y + ball.texture.Height > _graphics.PreferredBackBufferHeight) {
                    ballAlives--;
                    ball.position = ballStartPosition;
                    ball.speedX = Ball.speed;
                    ball.speedY = Ball.speed;
                }

                // Player Collision
                if (Utils.isColliding(ball.getRect(), player.getRect())) {
                    soundHitBall.Play();
                    ball.speedY *= -1;
                }

                // Blocks collision
                blockManager.CheckCollision(ball);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            if (blockManager.CheckIfWin() && ballAlives > 0) {
                _spriteBatch.DrawString(font, "You win!",
                new Vector2(_graphics.PreferredBackBufferWidth / 2 - 60, _graphics.PreferredBackBufferHeight / 2), Color.White
                );
            }
            if (ballAlives > 0 && !blockManager.CheckIfWin()) {
                player.Draw(_spriteBatch);
                blockManager.Draw(_spriteBatch);
                ball.Draw(_spriteBatch);
            }

            if (ballAlives <= 0) {
                if (soundLoseActive) {
                    soundLoseActive = false;
                    soundLose.Play();
                }
                
                _spriteBatch.DrawString(
                    font, "Game Over",
                    new Vector2(_graphics.PreferredBackBufferWidth / 2 - 80, _graphics.PreferredBackBufferHeight / 2), Color.White    
                );
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
