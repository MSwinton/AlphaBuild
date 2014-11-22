using UnityEngine;
using System.Collections;

public class PounceEnemy : Enemy {

	public float cooldown;
	public float pounceRadius;
	public bool pouncing;
	public float pounceMod;

	void Start () {
		pouncing = false;
		base.init();
		baseSpeed *= 1.9f;
		speedMod *= 1.0f;
		pounceRadius = 2.0f;
		killRadius = 0.9f;
		aggrod = false;
		cooldown = 0.0f;
		pounceMod = 2.8f;
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

			cooldown -= Time.deltaTime;
			if (shouldAggro ())
				aggrod = true;
			if (playerInvisibility.isVisible && inLoS () && cooldown < 0.0f && aggrod) {
				destLocation = player.transform.position;
				if (pouncing) {
					speedMod = speedMod / pounceMod;
					pouncing = false;
				}
			}
			move (Time.deltaTime);
			if (playerInvisibility.isVisible && inLoS () && Vector3.Distance (transform.position, player.transform.position) <= pounceRadius)
				pounce ();
			if (Vector3.Distance (transform.position, player.transform.position) <= killRadius)
				player.GetComponent<Movement> ().explode ();
		}
		setDest();
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}
	
	//Pounces at player's current location.
	public void pounce( ){
		if (cooldown < 0) {
			pouncing = true;
			speedMod *= pounceMod;
			cooldown = 2.5f;
		}
	}
}
