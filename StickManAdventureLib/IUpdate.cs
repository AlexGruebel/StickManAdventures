using System;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib
{
	public interface IUpdate : ICollision, IToDo
    {
		void Update();
              
    }
}
