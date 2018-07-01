using System;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib
{
    public class CollisionResult
    {
		private bool _collide;

		public bool Collide
		{
			get
			{
				if (this._collide)
				{
					this._collide = !this._collide;
					return !this._collide;
				}
				else
				{
					return this._collide;
				}
			}

			set
			{
				this._collide = value;
			}
		}

		public int damage;
        public Vector2 velocity;
		public Vector2 spawnPoint;
		public Vector2 position;
		public byte jumbCounter;
    }
}
