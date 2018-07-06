using System;
using StickManAdventureLib;
using System.Linq;

namespace StickManAdventureLib
{
	public class LevelConfig 
    {
		public PlayerObject[] players
		{
			get;
			set;
		}

        public Map map
		{
			get;
			set;
		}

		public LevelConfig()
		{
		}


		public LevelConfig(LevelConfig config)
		{
			foreach (PlayerObject player in config.players)
			{
				player.SetStandartValues();
			}
			this.players = config.players;
			this.map = config.map;
		}
	}
}
