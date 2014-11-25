using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dynatrigger : MonoBehaviour {

	public List<Vector3> positions;
	public float radius;
	public GameObject player;
	public bool activated;
	void Start( ){
		radius = 2.5f;
		activated = false;
	}
	
	void OnTriggerEnter2D( Collider2D other ){
		if( ((other.tag == "Player") || (other.tag == "Enemy")) && !activated){
			bool playerOwned = false;
			print("SD");
			activated = true;
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
