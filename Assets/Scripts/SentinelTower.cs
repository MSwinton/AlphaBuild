using UnityEngine;
using System.Collections;

public class SentinelTower : Enemy {

	void Start () {
		base.init();
		aggroRadius = 2.8f;
		aggrod = false;
		destLocation = this.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInvisibility = player.GetComponent<Invisibility>();
	}
	
	public void OnTriggerEnter2D( Collider2D other ){
		if( other.tag == "Player" ){
			playerInvisibility.canInvis = false;
			playerInvisibility.turnVisible();
		}
	}
	
	public void OnTriggerExit2D( Collider2D other ){
		if( other.tag == "Player" )
			playerInvisibility.canInvis = true;
	}
	
	public override void explode(){
		base.explode();
		Destroy(gameObject);
		Destroy(this);
	}

	public override void slow ()
	{
		//Does nothing, towers can't move.
	}
}
