using UnityEngine;
using System.Collections;

public class Movement : Splodeable {
	public float baseSpeed = 2.0f;//speed under normal conditions
	private float slowTime = 5;
	protected float speed;//current speed
	public float pushSpeed = 8;
	protected Vector3 pushedVelocity;
	protected bool pushed;
	public float acceleration = 15;
	public GameObject dieAudio;
	bool lost;
	void Start(){
		speed = baseSpeed;
		lost = false;
	}
	void Update(){
		if(lost){
			return;
		}
		float t = Time.deltaTime;
		if(slowTime > 0){
			slowTime -= t;
		}
		if(slowTime < 0){
			speed = baseSpeed;
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		if(moveHorizontal != 0){
			moveHorizontal = moveHorizontal / Mathf.Abs (moveHorizontal);
		}
		float moveVertical = Input.GetAxis ("Vertical");
		if(moveVertical != 0){
			moveVertical = moveVertical / Mathf.Abs (moveVertical);
		}
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0.0f ).normalized;
		if(!pushed){
			rigidbody2D.velocity = movement * speed;
		}
		else{
			rigidbody2D.velocity += new Vector2(movement.x, movement.y) * acceleration * t;
			if( (rigidbody2D.velocity.magnitude <= baseSpeed || Vector3.Angle(rigidbody2D.velocity.normalized, pushedVelocity) > 10 )){
				pushed = false;
			}
			if(rigidbody2D.velocity.magnitude > pushSpeed){
				rigidbody2D.velocity = rigidbody2D.velocity.normalized * pushSpeed;
			}
		}
		
		transform.rotation = Quaternion.Euler(0,0,0);
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Dead Zone")
			this.lose ();
	}
	public override void explode(){//what happens when you explode.
		lose();
	}
	public override void slow(){//what happens when you get slowed down
		speed *= .5f;
	}
	public override void push(Vector3 p){
		pushed = true;
		pushedVelocity = p;
		rigidbody2D.velocity = p;
	}
	public override void blind(float t){

	}
	public void unSlow ()
	{
		speed = baseSpeed;
	}
	IEnumerator loseIn2() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel (Application.loadedLevelName);
	}
	public void lose(){//what happens when you lose
		if(!lost){
			Instantiate(dieAudio);
			StartCoroutine(loseIn2());
			lost = true;
		}
	}
}
