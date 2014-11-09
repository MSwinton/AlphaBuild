using UnityEngine;
using System.Collections;

public class SlowTrap : Mine {

	public override void activate (Splodeable s)
	{
		s.slow ();
	}
}
