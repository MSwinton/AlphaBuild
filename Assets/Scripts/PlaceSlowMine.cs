using UnityEngine;
using System.Collections;

public class PlaceSlowMine : PlaceMine<SlowTrap> {
	void Start(){
		sprite = Resources.Load<Sprite>("Sprite/ice");
		splodeables = GameObject.FindWithTag("Splodeables");
	}
}
