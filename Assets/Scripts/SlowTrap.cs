using UnityEngine;
using System.Collections;

public class SlowTrap : Mine {
	GameObject audioObject;
	void Start(){
		audioObject = Resources.Load<GameObject>("Prefabs/SlowMineSound");
	}
	public override void activate (Splodeable s)
	{
		Instantiate(audioObject);
		s.slow ();
	}
}
 
