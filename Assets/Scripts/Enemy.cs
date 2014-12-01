using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class Enemy : Splodeable {

	public float baseSpeed = 1;
	protected float speedMod = 1; //speed modifier for traps
	protected float pushSpeed = 20;// speed that it can be pushed by a push mine
	public float aggroRadius = 1;
	public float killRadius = 1;
	public float slowTime = 10;
	public Vector3 destLocation; //to find the player and kill it!!!
	public GameObject player;
	public List<Vector3> pathPoints;
	int curPoint;
	public bool inLineOfSight = false;
	protected Invisibility playerInvisibility;
	public bool aggrod;
	public Vector3 velocity;
	public float maxAcceleration = 5;
	private bool pushed;
	private Vector3 pushedVelocity;
	private float slowTimer;
	public bool disturbed = false;

	//public abstract void Update();
	public void init(){
		if(pathPoints!=null){
			if(pathPoints.Count > 0){
				curPoint = 0;
				destLocation = pathPoints[curPoint];
			}
			else{
				destLocation = this.transform.position;
			}
		}
		else{
			destLocation = this.transform.position;
		}
		//Set player
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInvisibility = player.GetComponent<Invisibility>();
	}



	//Accelerates in the direction of its destination. 
	//Normally its speed can't exceed baseSpeed * speedMod
	//but if it gets pushed by a push mine, it can go to pushSpeed
	public void move(float t){
		if(speedMod < 1){
			slowTimer -= t;
		}
		if (slowTimer < 0){
			speedMod = 1;
		}
		Vector3 curLocation = transform.position;
		float distToDest = (destLocation - curLocation).magnitude;
		Vector3 direction = (destLocation - curLocation).normalized;
		velocity += (direction * maxAcceleration * t);// * baseSpeed * speedMod * t);
		if(distToDest < .5){
			velocity *= distToDest;
		}
		if(velocity.magnitude > baseSpeed * speedMod && !pushed ){
			velocity = velocity.normalized * baseSpeed * speedMod;
		}
		else if( (velocity.magnitude <= baseSpeed * speedMod || 
		Mathf.Acos (Vector3.Dot (velocity.normalized, pushedVelocity.normalized)) > .3 ) && pushed ){
			pushed = false;
		}
		else if(pushed && velocity.magnitude > pushSpeed){
			velocity = velocity.normalized * pushSpeed;
		}
		
		transform.Translate (velocity * t);
	}

	public override void explode(){
		//print ("Boom");
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Dead Zone")
			this.explode ();
	}
	public override void push(Vector3 p){
		velocity = p;
		pushed = true;
		pushedVelocity = velocity;
	}
	public void setDest(){
		if(!aggrod && pathPoints.Count > 0){
			if((transform.position - pathPoints[curPoint]).magnitude < .5){
				curPoint = (curPoint + 1)%pathPoints.Count;
				destLocation = pathPoints[curPoint];
			}
		}
	}
	//used for the flash mine
	public override void blind(float t){
		
	}

	//check if an object is in line of sight
	public bool inLoS(){
		return !Physics2D.Linecast(transform.position, player.transform.position, 1 << LayerMask.NameToLayer("Wall"));
	}
	public override void slow ()
	{
		speedMod *= 0.2f;
		slowTimer = slowTime;
	}
	//Determines whether the enemy should aggro.
	public bool shouldAggro( ){
		//In Line of sight of player, player is visible, and in range of player
		return ( inLoS() && playerInvisibility.isVisible && ((player.transform.position - this.transform.position).magnitude < aggroRadius) );

	}



}
