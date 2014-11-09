using UnityEngine;
using System.Collections;

public class BlowupMine : Mine {
	public override void activate (Splodeable s)
	{
		s.explode ();
	}
}
