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


		if (shouldAggro ())
			aggrod = true;
		if (playerInvisibility.isVisible && inLoS () && aggrod)
			destLocation = player.transform.position;
		move (Time.deltaTime);
		/*if (player && Vector3.Distance (transform.position, player.transform.position) <= killRadius) 
			player.GetComponent<Movement> ().explode ();*/

		setDest();
	}

	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}
}
