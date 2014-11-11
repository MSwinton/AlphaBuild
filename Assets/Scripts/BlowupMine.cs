using UnityEngine;
using System.Collections;

public class BlowupMine : Mine {

	public GameObject explosion;
	public override void activate (Splodeable s)
	{
		explosion = Resources.Load <GameObject>("Prefabs/fire");
		Instantiate(explosion,transform.position,Quaternion.identity);
		s.explode ();
	}
}
