using UnityEngine;
using System.Collections;

namespace Entropy
{
	public class MersenneTwister : IRandomNumberGenerator
	{
		uint[] mt = new uint[624];
		int index = 0;


		public MersenneTwister (int seed=1)
		{
			mt [0] = (uint)seed;
			for (var i=1; i<624; i++) {
				mt [i] = (uint)(1812433253 * (mt [i - 1] ^ mt [i - 1] >> 30) + i);
			}
		}

		public float Next ()
		{
			if (index == 0)
				Generate ();
			uint y = mt [index];
			y = y ^ y >> 11;
			y = y ^ y << 7 & 2636928640;
			y = y ^ y << 15 & 4022730752;
			y = y ^ y >> 18;
			index = (index + 1) % 624;
			return (float)y / float.MaxValue;
		}

		void Generate ()
		{
			for (var i=0; i<624; i++) {
				var y = (uint)((mt [i] & 0x80000000) + mt [(i + 1) % 624] & 0x7fffffff);
				mt [i] = mt [(i + 397) % 624] ^ y >> 1;
				if ((y % 2) != 0)
					mt [i] = (uint)(mt [i] ^ 0x9908b0df);
			}
		}
	}
}



