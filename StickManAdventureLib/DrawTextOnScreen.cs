using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StickManAdventureLib
{
    public class DrawTextOnScreen : IDraw
    {
        public bool ToDo { get; set; }

		public GameState gameState => throw new NotImplementedException();

		public String Text;
        public Vector2 PositionInPerc;
        public SpriteFont font;
		public Color color = Color.Black;
        private Vector2 _position = new Vector2(0, 0);
        
        
        public void Draw(SpriteBatch spriteBatch)
        {
			spriteBatch.DrawString(font, Text, _position, color);
        }

        public void SetSizeToWindow(GameWindow window)
        {
            
        }
        //Method does net rework
		public void Update(Vector2 mid, GameWindow window)
        {
			if (mid.X < window.ClientBounds.Width)
			{
				Debug.WriteLine(window.ClientBounds.Width / PositionInPerc.X);
				this._position.X = window.ClientBounds.Width / 100 * PositionInPerc.X;
			}
			else
			{
				this._position.X = (mid.X + window.ClientBounds.Width / 2) * PositionInPerc.X / 100;
			}
			this._position.Y = window.ClientBounds.Height * PositionInPerc.Y / 100;
        }

    }
}
