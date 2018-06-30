using System;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib
{
	public abstract class CollisionObject
    {
		protected Rectangle rectangle;
		protected CollisionResult collisionResult;
		public CollisionResult CollisionResult => this.collisionResult;
		public virtual Rectangle Rectangle { get => this.rectangle; set { this.rectangle = value; } }


		public CollisionObject()
		{
			collisionResult = new CollisionResult();
            collisionResult.spawnPoint = new Vector2(0, 0);
            collisionResult.velocity = new Vector2(0, 0);
		}

		public virtual void Collide() 
		{
			
		}

		//CollisionResult 
    }
}