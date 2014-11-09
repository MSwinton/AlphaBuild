using UnityEngine;
using System.Collections;

public class SentinelTower : Enemy {

	void Start () {
		base.init();
		aggroRadius = 2.8f;
		aggrod = false;
		destLocation = this.transform.position;
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
			if( Vector3.Distance(gameObject.transform.position, player.transform.position) < aggroRadius ) aggrod = true;
			else aggrod = false;
			
			if( aggrod && inLoS() ) playerInvisibility.turnVisible();
		}
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
