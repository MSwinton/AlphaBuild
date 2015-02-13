using UnityEngine;
using System.Collections;

public class FastEnemy : Enemy {
	
	void Start () {
		base.init ();
		baseSpeed *= 2.2f;
		speedMod *= 1.0f;
		aggroRadius *= 3.5f;
		killRadius *= 0.85f;
		aggrod = false;
	}
	
	void Update () {
		if (transform.childCount < 2) {
			Destroy (gameObject);
		}
		
		
		if (shouldAggro ()){
			if( !aggrod ) aggroRadius *= 2;
			aggrod = true;
			destLocation = player.transform.position;
		}
		
		move (Time.deltaTime);
		setDest();
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy (this);
	}
	
} 
