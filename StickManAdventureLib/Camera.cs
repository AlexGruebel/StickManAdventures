using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StickManAdventureLib
{
	public class Camera
	{

		private Matrix _transform;

		public Matrix Transform => this._transform;


		private Vector2 _center;
		private Viewport _viewport;

		public Camera(Viewport viewport)
		{
			this._viewport = viewport;
		}

		public void Update(Vector2 position, int xOffset, int yOffset)
		{

			if (position.X < _viewport.Width / 2)
			{
				_center.X = _viewport.Width / 2;
			}
			else if (position.X > xOffset - (_viewport.Width / 2))
			{
				_center.X = xOffset - (_viewport.Width / 2);
			}
			else
			{
				_center.X = position.X;
			}

			if (position.Y < _viewport.Height / 2)
            {
				_center.Y = _viewport.Height / 2;
            }
			else if (position.Y > yOffset - (_viewport.Height / 2))
            {
				_center.Y = yOffset - (_viewport.Height / 2);
            }
            else
            {
				_center.Y = position.Y;
            }

			this._transform = Matrix.CreateTranslation(new Vector3(-_center.X + (_viewport.Width / 2),
													   -_center.Y + (_viewport.Height / 2),
			                                                       0));
		}

    }
}
