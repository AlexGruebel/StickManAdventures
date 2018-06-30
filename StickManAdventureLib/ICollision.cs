using System;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib
{
    public interface ICollision
    {
		void Collision(CollisionObject collisionObject, int xMax, int yMax);
    }
}
