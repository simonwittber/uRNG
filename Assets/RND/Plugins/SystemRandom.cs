using UnityEngine;
using System.Collections;

namespace Entropy
{
	public class SystemRandom : System.Random, IRandomNumberGenerator
	{


		float IRandomNumberGenerator.Next ()
		{
			return base.Next() / float.MaxValue;
		}





	}
}