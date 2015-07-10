using UnityEngine;
using System.Collections;

namespace Entropy
{
	public class UnityRandom : IRandomNumberGenerator
	{

		public UnityRandom(int seed=1) {
			Random.seed = seed;
		}

		public float Next ()
		{
			return Random.value;
		}

	}
}