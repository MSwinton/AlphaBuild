using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public Vector3 direction;
	public float baseSpeed;
	public float speedMod;
	public float timer;
	public void Start(){
		baseSpeed = 3f;
		speedMod = 1.0f;
		timer = .2f;
	}

	void OnTriggerEnter2D( Collider2D other ){
		speedMod *= 1.01f;
		//GameObject player = GameObject.FindGameObjectWithTag("Player");
		if( other.tag == "Player" )	other.GetComponent<Movement>().explode();
		if( other.gameObject.tag == "Enemy" && timer<=0 ){
			other.gameObject.GetComponentInParent<Enemy>().explode ();
			Destroy(gameObject);
		}
		if( other.gameObject.layer == LayerMask.NameToLayer("Wall") || other.tag == "Player" ) Destroy(gameObject);
	}

	void Update( ){
		float t = Time.deltaTime;
		if(timer > 0){
			timer -= t;
		}
		transform.Translate(direction * baseSpeed * speedMod * t);
	}

}
