using UnityEngine;
using System.Collections;

namespace Entropy
{
	public class XorshiftPlus : IRandomNumberGenerator
	{
		ulong A = 181353;
		ulong B = 7;

		public XorshiftPlus (int seed=1)
		{
			if (seed == 0)
				seed = 1;
			A = A * (uint)seed;
			B = B * (uint)seed;
		}
	
		public float Next ()
		{
			var x = A;
			var y = B;
			A = y;
			x ^= x << 23;
			x ^= x >> 17;
			x ^= y ^ (y >> 26);
			B = x;
			return (float)(x + y)/float.MaxValue;
		}

	}
}