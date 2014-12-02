using UnityEngine;
using System.Collections;

public class BoringEnemy : Enemy {
	
	void Start () {
		base.init ();
		baseSpeed *= 1.25f;
		speedMod *= 1.0f;
		killRadius *= 1.25f;
		aggrod = false;
	}
	
	// Update is called once per frame
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
		Destroy(this);
	}
}
