using System;
using Microsoft.Xna.Framework;
using MonoGame.UI.Forms;
using StickManAdventureLib;
using StickManAdventureLib.GUI;

namespace StickManAdventure.Desktop.GUI
{
	public class PauseMenu : Menu
	{
		
		public PauseMenu(Game game, ref EventHandler Exit, ref EventHandler Continue) : base(game)
		{
			this._onExit = Exit;
			this._onContinue = Continue;
		}

		private Button _exitButton;
		private Button _continueButton;

		private bool _ToDo = false;
		public override bool ToDo
		{
			get 
			{ 
				return this._ToDo; 
			}
			set
			{
				_exitButton.IsVisible = value;
				_continueButton.IsVisible = value;
				_ToDo = value;
			}
		}

		public override GameState gameState => GameState.PauseInGame;

		private event EventHandler _onExit;
		private event EventHandler _onContinue;
        
		public override void InitializeComponent()
		{

			_continueButton = new Button()
			{
				Text = "Continue",
				Size = new Vector2(200, 75),
				BackgroundColor = Color.DarkBlue,
				Location = new Vector2(150, 50),
				IsVisible = this._ToDo            
			};


			_exitButton = new Button()
			{
				Text = "Exit",
				Size = new Vector2(200, 75),
				BackgroundColor = Color.DarkBlue,
				Location = new Vector2(150, 150),
				IsVisible = this._ToDo
		    };

			_exitButton.Clicked += _onExit;
			_continueButton.Clicked += _onContinue;
			Controls.Add(_continueButton);
			Controls.Add(_exitButton);
	     }

		public override void SetSizeToWindow(GameWindow window)
		{
			_exitButton.Size = new Vector2(window.ClientBounds.Width / 5,window.ClientBounds.Height / 9);
			_continueButton.Size = new Vector2(window.ClientBounds.Width / 5, window.ClientBounds.Height / 9);

			_continueButton.Location = new Vector2(window.ClientBounds.Width / 2 - _exitButton.Size.X / 2, window.ClientBounds.Height / 4);
			_exitButton.Location = new Vector2(window.ClientBounds.Width / 2 - _exitButton.Size.X / 2, ((float)window.ClientBounds.Height) / 2.5f);
		}
        
	}
}