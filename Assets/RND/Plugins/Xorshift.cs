using UnityEngine;
using System.Collections;

namespace Entropy
{
	public class Xorshift : IRandomNumberGenerator
	{

		uint x = 13, y = 181353, z = 397, w = 301827;

		public Xorshift (uint seed=1)
		{
			if (seed == 0)
				seed = 1;
			x = x + seed;
			y = y / seed;
			z = z * seed;
			w = w / seed;
		}

		public float Next ()
		{
			var t = x ^ (x << 11);
			x = y; 
			y = z; 
			z = w;
			w = w ^ (w >> 19) ^ t ^ (t >> 8);
			return (float)w/float.MaxValue;
		}

	}
}