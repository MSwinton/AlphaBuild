using UnityEngine;
using System.Collections;

public class BoringEnemy : Enemy {
	
	void Start () {
		base.init ();
		baseSpeed *= 1.25f;
		speedMod *= 1.0f;
		killRadius *= 1.25f;
		aggrod = false;
		destLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
			if(player != null){
				playerInvisibility = player.GetComponent<Invisibility>();
			}
		}
		if (player != null) {
			if (shouldAggro ())
				aggrod = true;
			if (playerInvisibility.isVisible && inLoS () && aggrod)
				destLocation = player.transform.position;
			if (aggrod)
				move (Time.deltaTime);
			/*if (player && Vector3.Distance (transform.position, player.transform.position) <= killRadius) 
				player.GetComponent<Movement> ().explode ();*/
		} 
	}

	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}
}
