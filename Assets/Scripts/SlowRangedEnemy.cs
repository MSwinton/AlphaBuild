using UnityEngine;
using System.Collections;

public class SlowRangedEnemy : Enemy {

	public GameObject bullet;
	public float cooldown;
	public float shootRadius;
	
	void Start () {
		base.init();
		baseSpeed *= .5f;
		speedMod *= 1.0f;
		aggroRadius *= 3.5f;
		shootRadius = 3.0f;
		killRadius = 1.2f;
		aggrod = false;
		destLocation = this.transform.position;
		cooldown = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if( shouldAggro() ) aggrod = true;
		if( playerInvisibility.isVisible && inLoS()) destLocation = player.transform.position;
		
		if(aggrod) move (Time.deltaTime);
		if( playerInvisibility.isVisible && inLoS() && Vector3.Distance (transform.position, player.transform.position) <= shootRadius) shoot();
		if( Vector3.Distance (transform.position, player.transform.position) <= killRadius) player.GetComponent<Movement>().explode();
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}
	public override void slow ()
	{
		speedMod *= .3f;
	}

	//Shoots a bullet (in this case, a rock).
	public void shoot( ){
		if (cooldown <= 0) {
			GameObject newB = (GameObject)Instantiate (bullet);
			newB.transform.position = transform.position;
			Projectile script = newB.GetComponent<Projectile>();
			script.direction = player.transform.position - transform.position;
			cooldown = 2.0f;
		}
	}
}
