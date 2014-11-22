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
						move (Time.deltaTime);
						/*if (player && Vector3.Distance (transform.position, player.transform.position) <= killRadius) 
								player.GetComponent<Movement> ().explode ();*/
				}
		setDest();
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy (this);
	}
	
}