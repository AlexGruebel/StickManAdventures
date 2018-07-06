using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using StickManAdventure.Desktop.GUI;
using StickManAdventureLib;

namespace StickManAdventure.Desktop
{
    public static class Program
    {

		[STAThread]
		static void Main()
		{
			try
			{
				LevelConfig config = JsonConvert.DeserializeObject<LevelConfig>(File.ReadAllText(Path.Combine("Levels", "Level1.json")));            
				using (var level = new Level(config))
				{
					level.Run();
				}
			}
			catch (Exception)
			{
				
			}
                     
        }
    }
}