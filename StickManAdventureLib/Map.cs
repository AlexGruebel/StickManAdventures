using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using StickManAdventureLib.Blocks;
using System;

namespace StickManAdventureLib
{
	public class Map : IDraw
    {
		//Aus wie viel Blöcken soll die Map bestehen --> auf Blatt notieren
		//wie soll das im Code berechnet werden

		//anzahl Y Achse / Fenster Höhe = Höhe 

		private ContentManager _contentManger;
		private List<MapObject> _mapObjects = new List<MapObject>();
		private int[,] _map;

		public int Width;
		public int Height;

		public event EventHandler OnFinish;

		public int[,] MapPlan
		{
			get { return this._map; }
			set { this._map = value; }
		}
        
		public Map(int[,] map)
		{
			//this._contentManger = contentManager;
			this._map = map;
		}


		public ContentManager contentManager { set { this._contentManger = value; } }

		public GameObject[] gameObjects 
		    => ((GameObject[]) _mapObjects.ToArray());

		public bool ToDo => true;

		public GameState gameState => GameState.InGamePlaying;

		public void GenerateMap(GameWindow window)
		{
			this._mapObjects.Clear();         
			int size = window.ClientBounds.Height / _map.GetLength(0);

			this.Height = size * _map.GetLength(0);
			this.Width = size * _map.GetLength(1);

			for (int y = 0; y < _map.GetLength(0); y++)
			{
				for (int x = 0; x < _map.GetLength(1); x++)
				{               
					//if (_map[y, x] > 0)
					//{
					//	this._mapObjects.Add(new MapObject(this._contentManger, "Block", new Rectangle(x * size, y * size, size, size)));
					//}


                    //10 Spawnpoint
                    /*
                     1 Erdblock
                     2 Grasblock
                     3 Falle
                     10 Zwischen Speicherpunkt
                     20 Ziel
                     */
                    
					switch (_map[y, x])
					{
						case 1:
						case 2:
							this._mapObjects.Add(new MapObject(this._contentManger, "Blocks/Block" + _map[y, x], new Rectangle(x * size, y * size, size, size)));
						break;
                        
						case 3:
							this._mapObjects.Add(new Trap(this._contentManger, "Blocks/Block" + _map[y, x]
							                              , new Rectangle(x * size, y * size + ((int)(size  * 0.7)), size, ((int)(size * 0.3)))));
							break;
                          
						case 10:
							this._mapObjects.Add(new SpawnPoint(this._contentManger, "Blocks/Block" + _map[y, x], new Rectangle(x * size, y * size - size, size, size * 2)));
                            break;

						case 20:
							this._mapObjects.Add(new Finish(this._contentManger, "Blocks/Block" + _map[y, x], new Rectangle(x * size, y * size - size, size, size * 2), ref OnFinish));
							break;
					}
				}
			}
		}

        //IDraw Interface, IUpdate --> erledigt
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (MapObject mapObject in this._mapObjects)
			{
				mapObject.Draw(spriteBatch);
			}
		}

		public void SetSizeToWindow(GameWindow window)
		{
			//just for Polimorphy
			this.GenerateMap(window);
		}
              
	}
}