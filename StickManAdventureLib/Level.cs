using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StickManAdventureLib;
using System.Linq;
using System.Diagnostics;

namespace StickManAdventureLib
{
	public class Level : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Map map;
		private PlayerObject player;
		private Camera camera;

        /*
		private IToDo[] ToDo
        {
            get
            {
				return (new IToDo[] { (GameObject)player })
					.Union(map.gameObjects)
					.Where(a => a.ToDo)
                    .ToArray();
            }
        }
        */

		private IDraw[] ToDraw
		{
			get
			{
				return (new IDraw[] { (IDraw)map })
					.Union(new IDraw[] { (IDraw)player })
					.Where(a => a.ToDo)
					.ToArray();
			}
		}
        
        //Eigenes ToLoad Interface?? --> Ja
		private GameObject[] gameObjects
		{
			get
			{
				return (new GameObject[] { (GameObject)player });
			}
		}

        

		private IUpdate[] ToUpdate
		{
			get
			{
				return (new IUpdate[] { (IUpdate)player });
			}
		}

		private GameObject[] allGameObjects
		{
			get
			{
				return (new GameObject[] { (GameObject)player })
					.Union(map.gameObjects)
					.Where(a => a.ToDo)
					.ToArray();
			}
		}

		public Level(LevelConfig config)
        {
			graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			map = config.map;
			player = config.player;
			this.map.contentManager = Content;
        }

		protected override void Initialize()
        {
			base.Initialize();
			Window.AllowUserResizing = true;         


			void UpdateSize()
			{
				player.SetSizeToWindow(Window);            
			}

			UpdateSize();
                     
            Window.ClientSizeChanged += (object sender, EventArgs e) => {
				UpdateSize();
				map.GenerateMap(Window);
            };
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
			camera = new Camera(GraphicsDevice.Viewport);
			foreach (GameObject gameObject in gameObjects)
			{
				gameObject.LoadContent(Content);
			}

			map.GenerateMap(Window);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			Window.Title = Window.ClientBounds.Width + " x " + Window.ClientBounds.Height;

			foreach (IUpdate toUpdate in ToUpdate)
			{
				//toUpdate.Update();            
				foreach (CollisionObject collionsObj in ((CollisionObject[]) allGameObjects
				                                            .Except(new GameObject[] { (GameObject) toUpdate})            
				                                            .ToArray()))
				{
					toUpdate.Collision(collionsObj, map.Width, map.Height);
				}
				camera.Update(player.Position, map.Width, map.Height);
				toUpdate.Update();     
			}

            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null,camera.Transform);
			foreach (IDraw draw in ToDraw)
			{
				draw.Draw(spriteBatch);
			}
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
