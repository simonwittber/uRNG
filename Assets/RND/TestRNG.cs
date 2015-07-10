using UnityEngine;
using System.Collections;
using Entropy;
using System.Collections.Generic;


public class TestRNG : MonoBehaviour {

	int count = 1000000;
	long maxTime = -1;

	void Start () {
		maxTime = Bench (new UnityRandom());
		Bench (new SystemRandom());
		Bench (new MersenneTwister());
		Bench (new Xorshift());
		Bench (new XorshiftPlus());
	}

	long Bench(IRandomNumberGenerator rng) {
		var set = new HashSet<float>();
		var clock = new System.Diagnostics.Stopwatch();
		for(var i=0; i<count; i++) {
			clock.Start();
			var f = rng.Next();
			if(f <= 0) {
				Debug.Log(rng);
				break;
			}
			clock.Stop();
			set.Add(f);
		}
		var repeats = (1f - ((float)set.Count / count)) * 100;
		if(maxTime < 0) 
			maxTime = clock.ElapsedTicks;

		Debug.Log(rng + " - " + (((float)clock.ElapsedTicks/maxTime)*100) + "% - " + repeats + "%");
		return clock.ElapsedTicks;
	}


}
