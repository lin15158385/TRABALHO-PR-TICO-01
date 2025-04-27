using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Block : GameObject {
	public Color color;
	public bool isAlive = true;

	public Block(Game game, string pathToTexture, Vector2 position, Color color) : base(game, pathToTexture, position)
	{
		this.color = color;
	}

	public void Draw(SpriteBatch spriteBatch) {
		spriteBatch.Draw(
			this.texture,
			this.position,
			null,
			this.color,
			0f,
			Vector2.Zero,
			Vector2.One,
			SpriteEffects.None,
			0f
		);
	}
}