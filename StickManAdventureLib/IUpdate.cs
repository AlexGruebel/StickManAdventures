using System;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib
{
	public interface IUpdate : IToDo
    {
		void Update();
		void Collision(CollisionObject collisionObject, int xMax, int yMax, GameTime gameTime);
		bool ToUpdate { get; set; }
    }
}
