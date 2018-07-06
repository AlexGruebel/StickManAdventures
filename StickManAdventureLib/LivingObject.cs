using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib
{
	//Implement IDisposable, Decounstructer
	public class LivingObject : MovingObject
    {
		protected int health;
		//private bool _isAlive = true;
		//public bool isAlive => _health > 0;

		public override bool ToDo => health > 0; 

		public int Health => this.health;

		protected Vector2 spawnPoint;
		public Vector2 SpawnPoint => this.spawnPoint;

		public LivingObject(int health, Vector2 spawnPoint)
		{
			this.health = health;
			this.spawnPoint = spawnPoint;
		}

		public override void SetSizeToWindow(GameWindow window)
		{
			base.SetSizeToWindow(window);
			this.spawnPoint.Y = (this.spawnPoint.Y / (float)this.lastWindowHeight) * (float)window.ClientBounds.Height;
			this.spawnPoint.X = (this.spawnPoint.X / (float)this.lastWindowHeight) * (float)window.ClientBounds.Height;
		}

		public override void Collision(CollisionObject collisionObject, int xMax, int yMax, GameTime gameTime)
		{
			base.Collision(collisionObject, xMax, yMax, gameTime);
			if (base.Rectangle.Top >= yMax)
			{
				this.health = 0;
			}

			if (collisionObject.CollisionResult.Collide)
			{
				this.health -= collisionObject.CollisionResult.damage;
				//only a player can respawn... Moving it to PlayerObject?
				if ((int)collisionObject.CollisionResult.spawnPoint.X > (int)this.SpawnPoint.X)
				{
					this.spawnPoint.X = collisionObject.CollisionResult.spawnPoint.X;
					this.spawnPoint.Y = collisionObject.CollisionResult.spawnPoint.Y - this.rectangle.Height;
				}

				if (!collisionObject.CollisionResult.ToDo)
				{
					this.health = -1;
					Debug.WriteLine(ToDo);
				}
			}
		}
        

	}
}