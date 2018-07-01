using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using StickManAdventureLib.Extensions;

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

		public virtual void Collide(MovingObject movingObject) 
		{
			Rectangle rectangleThatTouch = movingObject.rectangle;
			collisionResult.position = movingObject.Position;
			collisionResult.velocity = movingObject.Velocity;
			collisionResult.jumbCounter = movingObject.JumbCounter;
                     
			this.collisionResult.Collide = false;
			if (rectangleThatTouch.TouchTopOf(this.rectangle))
            {
				//SetPositionRectangle(base.rectangle.X, rectangleToTouch.Y - base.rectangle.Height);
				collisionResult.position.Y = this.rectangle.Y - rectangleThatTouch.Height;
				collisionResult.velocity.Y = 0f;
				collisionResult.jumbCounter = 0;
				collisionResult.Collide = true;
				Debug.WriteLine("Collide TopOf");
            }

			else if (rectangleThatTouch.TouchBottomOf(this.rectangle))
            {
                //SetPositionRectangle(base.rectangle.X, rectangleToTouch.Y);
				collisionResult.position.Y = this.rectangle.Y;
				collisionResult.Collide = true;
				Debug.WriteLine("Collide BottomOf");
            }

			if (rectangleThatTouch.TouchRightOf(this.rectangle))
            {
				//position.X = rectangleToTouch.Right;            
				collisionResult.position.X = this.rectangle.Right;//, rectangleThatTouch.Y);
				collisionResult.velocity.X = 0;
				Debug.WriteLine("Collide Right:" + collisionResult.position.X);
				collisionResult.Collide = true;
            }

			if (rectangleThatTouch.TouchLeftOf(this.rectangle))
            {
				Debug.WriteLine("Collide Left");
				collisionResult.position.X = this.rectangle.X - rectangleThatTouch.Width;
				collisionResult.Collide = true;
            }
		}

    }
}