using System;
using Microsoft.Xna.Framework;

namespace StickManAdventureLib.Extensions
{
    public static class RectangleHelp
    {
		public static bool TouchTopOf(this Rectangle r1, Rectangle r2) 
		    => (r1.Bottom >= r2.Top - 1 &&
					r1.Bottom <= r2.Top + (r2.Height / 5) &&
					r1.Right >= r2.Left + (r2.Width / 5) &&
					r1.Left <= r2.Right - (r2.Width / 5)
				   );

		public static bool TouchBottomOf(this Rectangle r1, Rectangle r2)
		    => (r1.Top >= r2.Bottom - 1 &&
		        r1.Top <= r2.Bottom + (r2.Height / 5) &&
		        r1.Right >= r2.Left + (r2.Width / 2) &&
                r1.Left <= r2.Right - (r2.Width / 2)
                );
		// (r2......)     (r1......)
        // left|right <-- left|right
        // r2.right  + 1 >= r1.Left
		// r2.right - (r2.Width / 5) <= r1.Left
		public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
		=> (r1.Left <= r2.Right + 1 &&
			r1.Left >= r2.Right - (r2.Width / 5) &&
		    r1.Top <= r2.Bottom - (r2.Height / 5) &&
		    r1.Bottom >= r2.Top + (r2.Height / 5)
		   );

		public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
		=> (r1.Right >= r2.Left - 1 &&
		    r1.Right <= r2.Left + (r2.Width / 5) &&
		    r1.Top <= r2.Bottom - (r2.Height / 2) &&
            r1.Bottom >= r2.Top + (r2.Height / 2)
           );


	}
}