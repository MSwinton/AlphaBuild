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
		pounceRadius = 3.0f;
		killRadius = 0.9f;
		aggrod = false;
		cooldown = 0.0f;
		pounceMod = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount < 3) {
			Destroy (gameObject);
		}


		cooldown -= Time.deltaTime;
		if ( shouldAggro() ){
			if( !aggrod ) aggroRadius *= 2;
			aggrod = true;
			if( cooldown < 0.0f ){
				destLocation = player.transform.position;
				//If it was pouncing, stop.
				if (pouncing) {
					speedMod = speedMod / pounceMod;
					pouncing = false;
				}
				//If it should start pouncing, do it.
				if( Vector3.Distance (transform.position, player.transform.position) <= pounceRadius ){
					pounce();
				}
			}
		}
		move (Time.deltaTime);
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
