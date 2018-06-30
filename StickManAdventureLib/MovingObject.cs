using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using StickManAdventureLib.Extensions;
namespace StickManAdventureLib
{
	public class MovingObject : GameObject, IUpdate
    {

		//in Percentage
		//public int SizeToWindow {get; set;}

		protected Vector2 velocity;
		protected Vector2 position;
		protected byte jumbCounter;
		protected Vector2 speedR;

		public override Rectangle Rectangle 
		{ get => base.rectangle; 
			set
			{
				this.position.X = value.X;
				this.position.Y = value.Y;
				base.rectangle = value;
			}
		}

		public Vector2 Position => this.position;

		public MovingObject()
		{
			this.jumbCounter = 0;
			this.speedR = new Vector2(1,1);
		}

		public override void SetSizeToWindow(GameWindow window)
		{
			base.SetSizeToWindow(window);
			//calculate speed
			//800 x 480
			this.speedR.Y = window.ClientBounds.Height / 480;
			this.speedR.X = window.ClientBounds.Width / 800;
		}


		public void AddX(int x)
		{
			//this.position.X += x;
			this.velocity.X += x;
		}

		public void AddY(int y)
		{
			this.position.Y += y;

		}


		public virtual void Update()
		{
			this.position += this.velocity;
			SetPositionRectangle((int)position.X, (int)position.Y);
			velocity.Y = 5 * this.speedR.Y;
			velocity.X = 0;


			if (this.rectangle.Left <= 0)
            {
                SetPositionRectangle(1, base.rectangle.Y);
            }

            if (this.rectangle.Top <= 0)
            {
                SetPositionRectangle(base.rectangle.X, 0);
				velocity.Y = 5f * this.speedR.Y;
            }
		}
              
		public virtual void Collision(CollisionObject collisionObject, int xMax, int yMax)
		{
			Rectangle rectangleToTouch = collisionObject.Rectangle;
            //Replace with case when?
			bool collide = false;

			if (this.rectangle.TouchTopOf(rectangleToTouch))
			{
				SetPositionRectangle(base.rectangle.X, rectangleToTouch.Y - base.rectangle.Height);
				velocity.Y = 0f;
				this.jumbCounter = 0;
				collide = true;
			}

			else if (this.rectangle.TouchBottomOf(rectangleToTouch))
			{
				SetPositionRectangle(base.rectangle.X, rectangleToTouch.Y);            
				collide = true;
			}

			if (this.rectangle.TouchRightOf(rectangleToTouch))
			{
				//Debug.WriteLine("TouchRightOf");
				position.X = rectangleToTouch.Right;
				collide = true;
			}
			if (this.rectangle.TouchLeftOf(rectangleToTouch))
			{
				//Debug.WriteLine("TouchLeftOf");
				position.X = rectangleToTouch.X - this.rectangle.Width -1;                        
				collide = true;
			}

			if (this.rectangle.Left <= 0)
			{
				SetPositionRectangle(1, base.rectangle.Y);            
			}

			if (this.rectangle.Top <= 0)
			{            
				SetPositionRectangle(base.rectangle.X, 0);
				velocity.Y = 5f * this.speedR.Y;            
			}

			if (this.rectangle.Right >= xMax)
			{
				SetPositionRectangle(xMax - this.rectangle.Width, this.rectangle.Y);
			}

			if (collide) {
				collisionObject.Collide();
			    if (collisionObject.CollisionResult != null)
			    {            
				    this.velocity += collisionObject.CollisionResult.velocity;
			    }
			}
            //Return Damage Points    ?? --> no     
		}
              
		private void SetPositionRectangle(int x, int y)
		{
			Rectangle tmp = base.rectangle;
			tmp.Location = new Point(x, y);
			base.rectangle = tmp;
		}

		/*
		public void SetSizeToWindow(GameWindow window)
		{
			int tmp = window.ClientBounds.Height * this.SizeToWindow;
			base.SetSize(tmp * (texture.Width / texture.Height), tmp);
		}
		*/
	}
}