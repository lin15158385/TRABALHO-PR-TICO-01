using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player : GameObject {

	private float speed = 450f;

	public Player(Game game, string pathToTexture, Vector2 position) : base(game, pathToTexture, position)
	{}

	public void Draw(SpriteBatch spriteBatch) {
		spriteBatch.Draw(
			this.texture,
			this.position,
			null,
			Color.White,
			0f,
			Vector2.Zero,
			Vector2.One,
			SpriteEffects.None,
			0f
		);
	}

	public void Move(GameTime gameTime, KeyboardState keys, int width) {
		if (keys.IsKeyDown(Keys.Right) && this.position.X + this.texture.Width < width)
			this.position.X += this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
		if (keys.IsKeyDown(Keys.Left) && this.position.X > 0)
			this.position.X -= this.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
	}
}