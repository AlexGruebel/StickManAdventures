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

		private Vector2 _spawnPoint;
		public Vector2 SpawnPoint => this._spawnPoint;

		public LivingObject(int health, Vector2 spawnPoint)
		{
			this.health = health;
			this._spawnPoint = spawnPoint;
		}


        //private?
        /*
		public void GetHit()
		{
			this._health--;
			if (this._health == 0)
			{
				this._isAlive = false;
			}
		}
        */
		public override void Collision(CollisionObject collisionObject, int xMax, int yMax)
		{
			base.Collision(collisionObject, xMax, yMax);
			if (base.Rectangle.Top >= yMax)
			{
				this.health = 0;
			}
			this.health -= collisionObject.CollisionResult.damage;
			//only a player can respawn... Moving it to PlayerObject?
			if ((int) collisionObject.CollisionResult.spawnPoint.X > (int) this.SpawnPoint.X)
			{
				this._spawnPoint.X = collisionObject.CollisionResult.spawnPoint.X;
				this._spawnPoint.Y = collisionObject.CollisionResult.spawnPoint.Y - this.rectangle.Height;
			}
		}
              
	}
}