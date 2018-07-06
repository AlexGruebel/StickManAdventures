using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StickManAdventureLib
{
	public interface IDraw : IToDo, ISetSizeToWindow
    {
		void Draw(SpriteBatch spriteBatch);
              
    }
}
