using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace StickManAdventureLib.Blocks
{
	public class MapObject : GameObject
    {
             
		public MapObject(ContentManager contentManager, string contentName, Rectangle rectangle)
        {
			this.contentName = contentName;
			this.LoadContent(contentManager);
			this.Rectangle = rectangle;
        }
    }
}
