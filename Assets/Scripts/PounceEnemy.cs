using UnityEngine;
using System.Collections;

public class PounceEnemy : Enemy {

	public float cooldown;
	public float pounceRadius;
	public bool pouncing;
	public float pounceMod;
	private float pounceTime;
	void Start () {
		pouncing = false;
		base.init();
		baseSpeed *= 1.9f;
		speedMod *= 1.0f;
		pounceRadius = 2.0f;
		killRadius = 0.9f;
		aggrod = false;
		destLocation = this.transform.position;
		cooldown = 0.0f;
		pounceTime = 0;
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
			float t = Time.deltaTime;
			cooldown -= t;
			pounceTime -= t;
			if (shouldAggro ())
				aggrod = true;
			if (playerInvisibility.isVisible && inLoS () && pounceTime <= 0.0f && aggrod) {
				destLocation = player.transform.position;
				if (pouncing) {
					speedMod = speedMod / pounceMod;
					pouncing = false;
					cooldown = 2.5f;
				}
			}
		

			if (aggrod && Vector3.Distance (transform.position, destLocation) > .12)
				move (Time.deltaTime);
			if (playerInvisibility.isVisible && inLoS () && Vector3.Distance (transform.position, player.transform.position) <= pounceRadius && !pouncing)
				pounce ();
			/*if (Vector3.Distance (transform.position, player.transform.position) <= killRadius)
				player.GetComponent<Movement> ().explode ();*/
		}
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}
	
	//Pounces at player's current location.
	public void pounce( ){
		if (cooldown <= 0) {
			pouncing = true;
			speedMod *= pounceMod;
			pounceTime = 2.5f;
		}
	}
	public override void push(Vector3 p){
		base.push (p);
		pounceTime = 0;
	}
}
