using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace StickManAdventureLib
{
	public class SpawnPoint : MapObject
    {
		public SpawnPoint(ContentManager contentManager, string contentName, Rectangle rectangle) : base(contentManager, contentName, rectangle)
		{
		}

		public override void Collide()
        {
			base.CollisionResult.spawnPoint = new Vector2(base.rectangle.X, base.rectangle.Y);
        }
    }
}
