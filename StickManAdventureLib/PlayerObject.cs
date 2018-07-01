using System;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace StickManAdventureLib
{
	public class PlayerObject : LivingObject
	{
		public ControllsConfig controllsConfig { get; set; }
		private string _name;
		public string name => this._name;
		private readonly int _maxHealth;
		//private double JumbMomentum = 0;


		private int deathCounter = 0;

		public PlayerObject(Vector2 spawnPoint, int health, string name) : base(health, spawnPoint)
		{
			this._name = name;
			this.controllsConfig = new ControllsConfig();
			this._maxHealth = health;
		}

      
		public override void Update(/*GameObject[] gameObjects, GameWindow window*/)
		{
			
            
            //Respawn
			if (!base.ToDo)
			{
				this.deathCounter++;
				this.position = SpawnPoint;
				base.health = this._maxHealth;
			}

            /*
			GameObject gameObject = gameObjects.Except((new GameObject[] { this }))
			                                   .Where(a => a.MinX <= this.MinX && a.MaxX >= this.MinX
							            //Funktioniert das?
							            //&& (a.MinY + this.rectangle.Height) <= this.MinY
			                                         )
					                    .OrderBy(a => a.MinY)
					                    .FirstOrDefault();

			int yNearestGround;
			if (gameObject == null)
			{
				yNearestGround = window.ClientBounds.Height;
			}
			else
			{
				yNearestGround = gameObject.MinY;
			}
			Debug.WriteLine($"yNearestGround: {yNearestGround}");
			if (yNearestGround != this.MinY)
			{
				this.JumbMomentum += 0.25;
				Debug.WriteLine(yNearestGround);
				Debug.WriteLine(this.rectangle.Height);
				int x = yNearestGround - this.rectangle.Height;
				//Debug.WriteLine(x > 2.0 + (int)this.JumbMomentum ? 2 + (int)this.JumbMomentum : x);
				this.AddY(x > 2.0 + (int)this.JumbMomentum ? 2 + (int)this.JumbMomentum : x);
				//Debug.WriteLine(this.rectangle.Y);
			}
			else
			{
				this.JumbMomentum = 0;
			}
            */
			if (Keyboard.GetState().IsKeyDown(controllsConfig.GoLeft))
			{
				base.AddX(-5 * (int)this.speedR.X);
			}
			else if (Keyboard.GetState().IsKeyDown(controllsConfig.GoRight))
			{
				base.AddX(5* (int)this.speedR.X);
			}

			if (Keyboard.GetState().IsKeyDown(controllsConfig.Jumb) && base.jumbCounter <= 2)
			{
				base.AddY(-25 * (int) this.speedR.Y);
				base.velocity.Y = 7 * (int)this.speedR.Y;
				Debug.WriteLine(base.position + "Jumb" + base.velocity);
				base.jumbCounter++;
			}
			base.Update();
		}

		public override void Collision(CollisionObject collisionObject, int xMax, int yMax)
		{
			base.Collision(collisionObject, xMax, yMax);         
		}

	}
}