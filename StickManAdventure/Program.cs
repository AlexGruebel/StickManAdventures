using System;
using Microsoft.Xna.Framework;
using StickManAdventureLib;
namespace StickManAdventure.Desktop
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			LevelConfig config = new LevelConfig();

			int[,] map = new int[,] {
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{1,1,0,1,1,1,0,1,1,1,1,0,0,0,1,1,1,1,0,0,1,1,1,1,1,0,1,1,1,1},
				{1,1,1,1,0,1,1,1,1,1,1,0,0,0,1,1,1,1,0,0,1,1,1,1,1,0,1,1,1,1},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			};
            
			config.map = new Map(ref map);

			config.player = new PlayerObject(new Vector2(0,0),10, "Alex")
			{
				contentName = "StickmanSingle",
				//SizeToWindow = 10,
				Rectangle = new Microsoft.Xna.Framework.Rectangle(0, 0, 0, 0),
				SizeRelativeToWindowHeightInPerc = 17,
                
			};
            
			using (var level = new Level(config))
			{
				level.Run();
			}
        }
    }
}