using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StickManAdventureLib
{
	public interface IDraw : IToDo
    {
		void Draw(SpriteBatch spriteBatch);

		void SetSizeToWindow(GameWindow window);
    }
}
