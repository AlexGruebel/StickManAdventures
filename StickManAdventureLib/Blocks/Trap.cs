using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace StickManAdventureLib.Blocks
{
	public class Trap : MapObject
	{
		public Trap(ContentManager contentManager, string contentName, Rectangle rectangle) : base(contentManager, contentName, rectangle)
		{
		}
        
		//private TimeSpan _lastExecution = new TimeSpan(0, 0, 0);
		public override void Collide(MovingObject movingObject, GameTime gameTime)      
		{
			base.collisionResult.Collide = false;
			collisionResult.position = movingObject.Position;
			if (movingObject.Rectangle.Intersects(this.rectangle))
			{
				//if (gameTime.TotalGameTime.Seconds >= _lastExecution.Seconds)
				//{
					this.collisionResult.damage = 10;               
					//this._lastExecution = gameTime.TotalGameTime.Add(new TimeSpan(0,0,1));
					this.collisionResult.Collide = true;               
				//}
			}
		}
	}
}