using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

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

		public Map(ref int[,] map)
		{
			//this._contentManger = contentManager;
			this._map = map;
		}


		public ContentManager contentManager { set { this._contentManger = value; } }

		public GameObject[] gameObjects 
		    => ((GameObject[]) _mapObjects.ToArray());

		public bool ToDo => true;

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
                    
					switch (_map[y, x])
					{
						case 1:
							this._mapObjects.Add(new MapObject(this._contentManger, "Block", new Rectangle(x * size, y * size, size, size)));
							break;
						case 10:
							this._mapObjects.Add(new SpawnPoint(this._contentManger, "Block" + _map[y, x], new Rectangle(x * size, y * size, size, size)));
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
			throw new System.NotImplementedException();
		}
	}
}