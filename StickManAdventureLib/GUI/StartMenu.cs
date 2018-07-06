using System;
using Microsoft.Xna.Framework;
using MonoGame.UI.Forms;
using StickManAdventureLib;
using StickManAdventureLib.GUI;

namespace StickManAdventure.GUI
{
	public class StartMenu : Menu
    {
		private Button _startButton;
		private Button _exitButton;

		public override GameState gameState => GameState.StartMenu;

		private event EventHandler _onExit;
        private event EventHandler _onStart;

		public StartMenu(Game game, ref EventHandler Start, ref EventHandler Exit) : base(game)
		{
			this._onExit = Exit;
			this._onStart = Start;
		}

             
		public override void InitializeComponent()
		{
			_startButton = new Button()
			{
				Text = "Start",
				Location = new Vector2(100, 200),
				BackgroundColor = Color.DarkBlue,
				Size = new Vector2(100, 50)
			};


			_exitButton = new Button()
			{
				Text = "Exit",
				Location = new Vector2(100, 100),
				BackgroundColor = Color.DarkBlue,
				Size = new Vector2(100, 50)
			};
			this._startButton.Clicked += this._onStart;
			this._exitButton.Clicked += this._onExit;

			Controls.Add(this._startButton);
			Controls.Add(this._exitButton);
		}

		public override void SetSizeToWindow(GameWindow window)
		{
			_startButton.Size = new Vector2(window.ClientBounds.Width / 4, window.ClientBounds.Height / 7);
			_exitButton.Size = new Vector2(window.ClientBounds.Width / 4, window.ClientBounds.Height / 7);

			_startButton.Location = new Vector2(window.ClientBounds.Width / 2 - _startButton.Size.X / 2, window.ClientBounds.Height / 2 - _startButton.Size.Y );
			_exitButton.Location = new Vector2(window.ClientBounds.Width / 2 - _exitButton.Size.X / 2, ((float)window.ClientBounds.Height) / 2 + _exitButton.Size.Y / 2);
		}
	}
}
