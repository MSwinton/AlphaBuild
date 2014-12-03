using UnityEngine;
using System.Collections;

public class NormalRangedEnemy : Enemy {
	
	public GameObject bullet;
	public float cooldown;
	public float shootRadius;
	public float reloadTime;
	void Start () {
		base.init();
		baseSpeed *=1.25f;
		speedMod *= 1.0f;
		shootRadius = 8.0f;
		killRadius = 0.8f;
		aggrod = false;
		cooldown = 0.0f;
		reloadTime = .5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.childCount < 2) {
			Destroy (gameObject);
		}

		cooldown -= Time.deltaTime;

		if ( shouldAggro() ){
			if( !aggrod ) aggroRadius *= 2;
			aggrod = true;
			destLocation = player.transform.position;
			if( Vector3.Distance(transform.position, player.transform.position) <= shootRadius )
				shoot ();
		}
		move (Time.deltaTime);
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
			cooldown = reloadTime;
		}
	}
}
