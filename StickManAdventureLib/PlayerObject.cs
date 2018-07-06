using System;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace StickManAdventureLib
{
	public class PlayerObject : LivingObject
	{
		public ControllsConfig controllsConfig { get; set; }
		private string _name;
		public string name => this._name;
		private readonly int _maxHealth;
		//private double JumbMomentum = 0;
		private SpriteFont _font;
		private float _scaleFont = 0f;
             
		private int deathCounter = 0;
		private static Vector2 _spawnPointForThePlayers;    

		public int DeathCounter { get => this.deathCounter; }

		public PlayerObject(Vector2 spawnPoint, int health, string name) : base(health, spawnPoint)
		{
			this._name = name;
			this.controllsConfig = new ControllsConfig();
			this._maxHealth = health;
		}

      
		public override void Update()
		{
			//Debug.WriteLine(this.Health);
            //Respaw,n
            
			if (base.health == -1)
            {
                return;
            }

			if (!base.ToDo && base.health != -1)
			{
				this.deathCounter++;
				this.position = SpawnPoint;
				base.health = this._maxHealth;            
			}


            
			if (Keyboard.GetState().IsKeyDown(controllsConfig.GoLeft))
			{
				base.AddX(-6 * (int)this.speedR.X);
			}
			else if (Keyboard.GetState().IsKeyDown(controllsConfig.GoRight))
			{
				base.AddX(6* (int)this.speedR.X);
			}

			if (Keyboard.GetState().IsKeyDown(controllsConfig.Jumb) && base.jumbCounter <= 2)
			{
				base.AddY(-20 * (int) this.speedR.Y);
				base.velocity.Y = -10 * (int)this.speedR.Y;
				base.jumbCounter++;
			}
			base.spawnPoint = _spawnPointForThePlayers;
			base.Update();
		}

		public override void Collision(CollisionObject collisionObject, int xMax, int yMax, GameTime gameTime)
		{
			base.Collision(collisionObject, xMax, yMax, gameTime);
			if (_spawnPointForThePlayers.X < base.SpawnPoint.X)
			{
				_spawnPointForThePlayers = base.SpawnPoint;
			}
		}

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
			_font = content.Load<SpriteFont>("Font/Arial");
            //font
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			//spriteBatch.DrawString(font, name, new Vector2(position.X, position.Y - 20), Color.Black,scale: 10f); 
			spriteBatch.DrawString(_font, name + this.Health, new Vector2(position.X, position.Y - 20 * this._scaleFont), Color.Black, 0.0f, new Vector2(0,0), this._scaleFont, new SpriteEffects(), 0.0f);
		}

		public override void SetSizeToWindow(GameWindow window)
		{
			base.SetSizeToWindow(window);
			this._scaleFont = window.ClientBounds.Height / 400;
		}

        //tmp solution
		public void SetStandartValues()
		{
			this.rectangle = new Rectangle(0, 0, 0, 0);
			this.position = new Vector2(0, 0);
			this.velocity = new Vector2(0, 0);
			this.jumbCounter = 0;
			this.health = 10;
			this.spawnPoint = new Vector2(0, 0);         
			_spawnPointForThePlayers = new Vector2(0, 0);
		}
	}
}