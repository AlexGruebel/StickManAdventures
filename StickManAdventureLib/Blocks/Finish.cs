using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace StickManAdventureLib.Blocks
{
	public class Finish : MapObject
	{
		private event EventHandler _finish;

		public Finish(ContentManager contentManager, string contentName, Rectangle rectangle, ref EventHandler finish) : base(contentManager, contentName, rectangle)
		{
			this._finish = finish;
		}

		public override void Collide(MovingObject movingObject, GameTime gameTime)
		{
			
			this.collisionResult.Collide = false;
			this.collisionResult.ToDo = true;
			if (this.rectangle.Intersects(movingObject.Rectangle) && movingObject.ToDo)
			{
				Debug.WriteLine("Test");
				this.collisionResult.Collide = true;
				this.collisionResult.ToDo = false;
				this._finish?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}