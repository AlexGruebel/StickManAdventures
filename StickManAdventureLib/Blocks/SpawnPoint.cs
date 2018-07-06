using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace StickManAdventureLib.Blocks
{
	public class SpawnPoint : MapObject
    {
		public SpawnPoint(ContentManager contentManager, string contentName, Rectangle rectangle) : base(contentManager, contentName, rectangle)
		{
		}

		public override void Collide(MovingObject movingObject, GameTime gameTime)
        {
			collisionResult.position = movingObject.Position;
            collisionResult.velocity = movingObject.Velocity;
            collisionResult.jumbCounter = movingObject.JumbCounter;

			collisionResult.Collide = false;
			if (movingObject.Rectangle.Intersects(this.Rectangle))
			{
				base.CollisionResult.spawnPoint = new Vector2(base.rectangle.X, base.rectangle.Y);
				collisionResult.Collide = true;
			}
        }
    }
}
