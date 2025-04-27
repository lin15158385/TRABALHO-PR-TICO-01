using Microsoft.Xna.Framework;

public class Utils {
	public static bool isColliding(Vector4 rect, Vector4 rect2) {
		if (
			rect.X > rect2.X + rect2.Z
			|| rect.X + rect.Z < rect2.X
			|| rect.Y > rect2.Y + rect2.W
			|| rect.Y + rect.W < rect2.Y
		) return false;

		return true;
	}
}