using UnityEngine;
using System.Collections;

public class PlaceSlowMine : PlaceMine<SlowTrap> {
	void Start(){
		sprite = Resources.Load<Sprite>("Sprite/slowing mine");
		splodeables = GameObject.FindWithTag("Splodeables");
	}
}
 
