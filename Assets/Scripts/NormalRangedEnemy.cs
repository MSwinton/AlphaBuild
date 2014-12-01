using UnityEngine;
using System.Collections;

public class NormalRangedEnemy : Enemy {
	
	public GameObject bullet;
	public float cooldown;
	public float shootRadius;
	
	void Start () {
		base.init();
		baseSpeed *=1.25f;
		speedMod *= 1.0f;
		shootRadius = 4.0f;
		killRadius = 0.8f;
		aggrod = false;
		cooldown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount < 2) {
			Destroy (gameObject);
		}

		cooldown -= Time.deltaTime;

		if (shouldAggro ())
			aggrod = true;
		if (playerInvisibility.isVisible && inLoS () && aggrod)
			destLocation = player.transform.position;
		move (Time.deltaTime);
		if(aggrod){
			if (playerInvisibility.isVisible && inLoS () && Vector3.Distance (transform.position, player.transform.position) <= shootRadius)
				shoot ();
		}
		setDest();
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}
	
	//Shoots a bullet (in this case, a rock).
	public void shoot( ){
		if (cooldown <= 0) {
			GameObject newB = (GameObject)Instantiate (bullet);
			newB.transform.position = transform.position;
			Projectile script = newB.GetComponent<Projectile> ();
			script.direction = (player.transform.position - transform.position).normalized;
			cooldown = 2.0f;
		}
	}
}
