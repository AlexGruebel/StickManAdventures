using System;
using Microsoft.Xna.Framework;
using MonoGame.UI.Forms;

namespace StickManAdventureLib.GUI
{
	public abstract class Menu : ControlManager, IToDo, ISetSizeToWindow
    {
		public Menu(Game game) : base(game)
        {
        }

		public virtual bool ToDo { get; set; }

		public virtual GameState gameState => throw new NotImplementedException();

		public virtual void SetSizeToWindow(GameWindow window)
		{
			//throw new NotImplementedException();
		}
	}
}
