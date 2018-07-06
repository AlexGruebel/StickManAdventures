using System;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib
{
    public interface ICollisiont
    {
		void Collision(CollisionObject collisionObject, int xMax, int yMax, GameTime gameTime);
    }
}
