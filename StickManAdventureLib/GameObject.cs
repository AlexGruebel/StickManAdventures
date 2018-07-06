using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StickManAdventureLib
{
	public class GameObject : CollisionObject, IDraw
	{

		//private Rectangle _rectangle;

		public Texture2D texture { get; set; }
		//public  override Rectangle Rectangle { get => base.rectangle; set { base.rectangle = value; } }
		public String contentName { get; set; }

		public int SizeRelativeToWindowHeightInPerc {get;set;}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, Rectangle, Color.White);
			//spriteBatch.DrawString(null, rectangle.X + "x" + rectangle.Y, new Vector2(rectangle.X, rectangle.Y - 2), Color.Red);
        }


		public int MinX { get => this.Rectangle.X; }

		public int MinY { get => this.Rectangle.Y; }

		public int MaxX { get => this.Rectangle.X + this.Rectangle.Width; }

		public virtual bool ToDo => true;

		public GameState gameState => GameState.InGamePlaying;

		public virtual void LoadContent(ContentManager content)
		{
			//Debug.WriteLine(this.contentName);
			this.texture = content.Load<Texture2D>(this.contentName);	
		}

		protected void SetSize(int width, int height) 
		{
			base.rectangle.Width = width;
			base.rectangle.Height = height;
		}

		public virtual void SetSizeToWindow(GameWindow window)
		{
			//Achtung: minimale Rundungsfehler können auftreten
			int height = (int)((window.ClientBounds.Height / 100.00) * (double)SizeRelativeToWindowHeightInPerc);
			this.SetSize((int)((double)(texture.Width / (double)texture.Height) * (double)height), height);         
		}


	}
}
