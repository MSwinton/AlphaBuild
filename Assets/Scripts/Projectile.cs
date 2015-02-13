using UnityEngine;
using System.Collections;

public class Projectile : Enemy {
	public Vector3 direction;

	public float timer;
	public void Start(){
		transform.parent = GameObject.FindGameObjectWithTag ("Splodeables").transform;
		baseSpeed = 10f;
		speedMod = 1.0f;
		timer = .03f;
	}

	void OnTriggerEnter2D( Collider2D other ){
		//GameObject player = GameObject.FindGameObjectWithTag("Player");
		if( other.tag == "Player" )	other.GetComponent<Movement>().explode();
		if( other.gameObject.tag == "Enemy" && timer<=0 ){
			other.gameObject.GetComponentInParent<Enemy>().explode ();
			Destroy(gameObject);
		}
		if( other.gameObject.layer == LayerMask.NameToLayer("Wall") || other.tag == "Player" ) Destroy(gameObject);
	}
	public override void  push(Vector3 something){
		direction = something.normalized * direction.magnitude ;
		print (direction);
	}
	void Update( ){
		float t = Time.deltaTime;
		if(timer > 0){
			timer -= t;
		}
		transform.Translate(direction * baseSpeed * speedMod * t);
	}

}
 
