using UnityEngine;
using System.Collections;

public class SplittingEnemy_Base : Enemy {

	public GameObject child;
	
	void Start() {
		base.init ();
		speedMod *= 1.0f;
		aggroRadius *= 3.0f;
		aggrod = false;
		destLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update() {
		if( shouldAggro() ) aggrod = true;
		if( playerInvisibility.isVisible && inLoS()) destLocation = player.transform.position;
		
		if(aggrod) move (Time.deltaTime);
		if( player && Vector3.Distance (transform.position, player.transform.position) <= killRadius) 
			player.GetComponent<Movement>().explode();
	}
	
	public override void explode(){
		if( child != null ){
			//Make children and set their locations, also aggro them.
			GameObject child1 = (GameObject)Instantiate(child);
			SplittingEnemy_Base script1 = child1.GetComponent<SplittingEnemy_Base>();
			child1.transform.position = transform.position;
			GameObject child2 = (GameObject)Instantiate(child);
			SplittingEnemy_Base script2 = child2.GetComponent<SplittingEnemy_Base>();
			child2.transform.position = transform.position;

			//Aggro them, and move the second ooze slightly so that they aren't on top of eachother.
			script1.aggrod = true;
			script2.aggrod = true;
			script1.move (-.2f);
			script2.move(.2f);

			//Set Children's parent to 'splodable.
			child1.transform.parent = transform.parent;
			child2.transform.parent = transform.parent;

		}

		base.explode ();
		Destroy (gameObject);
		Destroy (this);
	}

	public override void slow ()
	{
		speedMod *= .3f;
	}
}
 
