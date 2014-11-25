using UnityEngine;
using System.Collections;

public class Dynatrigger : MonoBehaviour {

	public Vector3[] positions;
	public float radius;
	public GameObject player;
	
	void Start( ){
		positions = new Vector3[1];
		positions[0] = this.transform.position;
		radius = 2.5f;
	}
	
	void OnTriggerEnter2D( Collider2D other ){
		if( (other.tag == "Player") || (other.tag == "Enemy") ){
			bool playerOwned = false;
			//First level
			Transform psplodes = GameObject.FindGameObjectWithTag("Splodeables").transform;
			foreach( Transform child in psplodes ){
				checkNSlay(child);
			}
		}
	}
	
	void checkNSlay( Transform thing ){
		foreach( Vector3 place in positions ){
			if( Vector3.Distance(thing.position, place) < radius ){
				if( thing.tag == "Player" ) thing.GetComponent<Movement>().explode();;
				if( thing.tag == "Enemy" ) thing.GetComponent<Enemy>().explode();
				if( thing.tag == "Wall" ) thing.GetComponent<Dynapile>().goBoom();
			}
		}
	}
}
