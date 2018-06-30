using System;
using Microsoft.Xna.Framework.Input;
namespace StickManAdventureLib
{
    public class ControllsConfig
    {
		public Keys GoLeft { get; set; }
		public Keys GoRight { get; set; }
		public Keys Jumb { get; set; }

        //Default Werte
		public ControllsConfig()
		{
			this.GoLeft = Keys.Left;
			this.GoRight = Keys.Right;
			this.Jumb = Keys.Space;
		}
    }
}
