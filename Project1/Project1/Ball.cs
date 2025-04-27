using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Ball : GameObject {
	public static float speed = 200f;
	public float speedX = speed;
	public float speedY = speed;

	public Ball(Game game, string pathToTexture, Vector2 position) : base(game, pathToTexture, position)
	{}

	public void Draw(SpriteBatch spriteBatch) {
		spriteBatch.Draw(
			this.texture,
			this.position,
			null,
			Color.Red,
			0f,
			Vector2.Zero,
			Vector2.One,
			SpriteEffects.None,
			0f
		);
	}

	public void Move(GameTime gameTime, Vector2 direction) {
		this.position.X += direction.X * this.speedX * (float)gameTime.ElapsedGameTime.TotalSeconds;
		this.position.Y += direction.Y * this.speedY * (float)gameTime.ElapsedGameTime.TotalSeconds;
	}

}