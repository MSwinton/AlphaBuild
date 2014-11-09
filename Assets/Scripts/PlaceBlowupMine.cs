using UnityEngine;
using System.Collections;

public class PlaceBlowupMine : PlaceMine<BlowupMine> {
	void Start(){
		sprite = Resources.Load<Sprite>("Sprite/exploding mine");
		splodeables = GameObject.FindWithTag("Splodeables");
	}
}
