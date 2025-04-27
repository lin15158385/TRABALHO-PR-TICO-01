using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class GameObject {
	public Texture2D texture;
	public Vector2 position;

	public GameObject(Game game, string pathToTexture, Vector2 position) {
		this.texture = game.Content.Load<Texture2D>(pathToTexture);
		this.position = position;
	}

	public Vector4 getRect() {
		return new Vector4(this.position.X, this.position.Y, this.texture.Width, this.texture.Height);
	}
}