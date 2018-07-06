using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StickManAdventureLib;
using System.Linq;
using System.Diagnostics;
using StickManAdventure.Desktop.GUI;
using StickManAdventure.GUI;
using System.Threading;
using MonoGame.UI.Forms;
using StickManAdventureLib.GUI;

namespace StickManAdventureLib
{
	public class Level : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Map map;
		private PlayerObject[] players;
		private Camera camera;
		private PauseMenu pauseMenu;
		private StartMenu startMenu;
		private LevelConfig startConfig;
		//GameState? byte 0 StartMenu, 1 Game, 2 PauseMenu?
		private IDraw[] ToDraw
		{
			get
			{
				return (new IDraw[] { (IDraw)map })
						//.Union(new IDraw[] { (IDraw)player })
						.Union((IDraw[])players)
						.Where(a => a.ToDo && (a.gameState == gameState || gameState == GameState.PauseInGame))
						.ToArray();
			}
		}

		GameState gameState = GameState.StartMenu;
		//Eigenes ToLoad Interface?? --> Ja
		private GameObject[] gameObjects
		{
			get
			{
				return (players);
			}
		}


		private IUpdate[] AllUpdate
		{
			get
			{
				return (players)
					.Where(a => a.gameState == gameState)
					.ToArray();
			}
		}

		private IUpdate[] ToUpdate
		{
			get
			{
				return AllUpdate
					.Where(a => a.ToUpdate == true && a.gameState == GameState.InGamePlaying)
					.ToArray();
			}
		}

		private IUpdate[] NotToUpdate
		{
			get
			{
				return AllUpdate
					.Where(a => a.ToUpdate == false)
					.ToArray();
			}
		}

		private GameObject[] allGameObjects
		{
			get
			{
				return (players)
					.Union(map.gameObjects)
					.Where(a => a.ToDo)
					.ToArray();
			}
		}

		private Menu[] controllMangers
		{
			get
			{
				return (new Menu[] { (Menu)pauseMenu })
					.Union(new Menu[] { (Menu)startMenu })               
					.Where(a => a.gameState == gameState )//|| (this.gameState == GameState.InGamePlaying && a.gameState == GameState.PauseInGame))
					.ToArray();
			}
		}


		private ISetSizeToWindow[] toSetSizeToWindow => (controllMangers)
			                                            .Union((ISetSizeToWindow[])ToDraw)
			                                            //.Union(new ISetSizeToWindow[] { map })
		                                                .ToArray();

		public Level(LevelConfig config) : this()
		{
			LoadConfig(config);

		}

		public Level()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			this.IsMouseVisible = true;
			Window.Title = "Stickman Adventures";
		}

		private void LoadConfig(LevelConfig config)
		{
			startConfig = new LevelConfig(config);
			map = config.map;
			this.map.contentManager = Content;
			players = config.players;
			map.OnFinish -= OnFinish;
			map.OnFinish += OnFinish;         
		}

		#region help Methods

		private void UpdateSize()
        {
            
            foreach (ISetSizeToWindow setSize in toSetSizeToWindow)
            {
                setSize.SetSizeToWindow(Window);
            }
            camera = new Camera(GraphicsDevice.Viewport);
        }

		private void SwitchPausMenu()
		{
			this.gameState = gameState == GameState.InGamePlaying ? GameState.PauseInGame : GameState.InGamePlaying;         
			this.IsMouseVisible = !this.IsMouseVisible;
			this.pauseMenu.ToDo = !this.pauseMenu.ToDo;
			this.pauseMenu.Enabled = !this.pauseMenu.Enabled;
			this.pauseMenu.Visible = !this.pauseMenu.Visible;         
			UpdateSize();
		}

		public void ToStartMenu()
		{
			this.gameState = GameState.StartMenu;
			this.startMenu.Visible = true;
			this.startMenu.Enabled = true;
			this.pauseMenu.Visible = false;
			this.pauseMenu.Enabled = false;
			this.pauseMenu.ToDo = false;
			this.IsMouseVisible = true;
			this.countPlayers = 0;
			UpdateSize();
		}

		#endregion

		#region Events
		private int countPlayers;
		private void OnFinish(object sender, System.EventArgs e)
		{
			Debug.WriteLine("Count Players:" + countPlayers);


			if (++countPlayers == players.Length)
			{
				foreach (PlayerObject player in players)
				{
					Debug.WriteLine(player.name + ": " + player.DeathCounter);
				}
				ToStartMenu();
			}
		}

		private void onStart(object sender, System.EventArgs eventArgs)
		{
			this.gameState = GameState.InGamePlaying;
			this.startMenu.Visible = false;
			this.startMenu.Enabled = false;
			this.IsMouseVisible = false;
			this.countPlayers = 0;
			LoadConfig(startConfig);
			UpdateSize();
		}

		private void OnExit(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void OnContinue(object sender, System.EventArgs eventArgs)
		{
			SwitchPausMenu();
			UpdateSize();
		}

		private void OnExitPause(object sender, System.EventArgs eventArgs)
		{
			ToStartMenu();
		}

		#endregion

		protected override void Initialize()
		{
			EventHandler eventStartStart = onStart;
			EventHandler eventExitStart = OnExit;
			startMenu = new StartMenu(this, ref eventStartStart, ref eventExitStart);
			this.Components.Add(startMenu);

			EventHandler eventExitPause = OnExitPause;
			EventHandler eventContinuePause = OnContinue;
			pauseMenu = new PauseMenu(this, ref eventExitPause, ref eventContinuePause);
			this.pauseMenu.Enabled = false;
			this.pauseMenu.Visible = false;
			this.Components.Add(pauseMenu);

			Window.AllowUserResizing = true;

			base.Initialize();
                     
			UpdateSize();

			Window.ClientSizeChanged += (object sender, EventArgs e) =>
			{
				//map.GenerateMap(Window);
				UpdateSize();
			};

		}

		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			try
			{
				foreach (GameObject gameObject in gameObjects)
				{
					gameObject.LoadContent(Content);
				}
				map.GenerateMap(Window);
			}
			catch (NullReferenceException) { }
		}


		protected override void UnloadContent()
		{

		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape) && !pauseMenu.ToDo && gameState != GameState.StartMenu)
			{
				SwitchPausMenu();
				//timer??
			}
                     

			foreach (IUpdate toUpdate in ToUpdate)
			{
				//toUpdate.Update();            
				foreach (CollisionObject collionsObj in ((CollisionObject[])allGameObjects
															.Except(new GameObject[] { (GameObject)toUpdate })
															.ToArray()))
				{
					toUpdate.Collision(collionsObj, map.Width, map.Height, gameTime);
				}
				try
				{
					camera.Update(players.Where(a => a.Health != -1)
								  .OrderByDescending(a => a.Position.X)
					              .FirstOrDefault().Position
								  , map.Width, map.Height);
				}
				catch (NullReferenceException) { }

				toUpdate.Update();
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

			try
			{
				foreach (IDraw draw in ToDraw)
				{
					draw.Draw(spriteBatch);
				}
			}
			catch (NullReferenceException) { }
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
