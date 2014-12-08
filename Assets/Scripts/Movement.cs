using UnityEngine;
using System.Collections;

public class Movement : Splodeable {
	public float baseSpeed = 2.0f;//speed under normal conditions
	private float slowTime = 5;
	protected float speed;//current speed
	public float pushSpeed = 8;
	protected Vector3 pushedVelocity;
	protected bool pushed;
	public GameObject helmetObj;
	public float acceleration = 15;
	public GameObject dieAudio;
	public float immunetime;
	private int frameno;
	public bool shielded;
	bool lost;
	void Start(){
		speed = baseSpeed;
		lost = false;
		immunetime = 0;
		frameno = 0;
	}
	void Update(){
		if(lost){
			return;
		}
		float t = Time.deltaTime;
		if(immunetime > 0){
			immunetime -= t;
			frameno = (frameno + 1) % 5;
			if(frameno < 2){
				helmetObj.transform.localPosition = new Vector3(helmetObj.transform.localPosition.x,helmetObj.transform.localPosition.y,2);
			}
			else{
				helmetObj.transform.localPosition = new Vector3(helmetObj.transform.localPosition.x,helmetObj.transform.localPosition.y,-.1f);
			}
		}
		if(helmetObj != null && !shielded && immunetime <= 0){
			Destroy(helmetObj);
		}
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
		if (coll.gameObject.tag == "Dead Zone") this.lose();
		else if (coll.gameObject.tag == "Enemy") this.explode();
	}
	public override void explode(){//what happens when you explode.
		if( immunetime <= 0 ){
			if( shielded ){
				shielded = false;
				immunetime = 3;
				helmetObj = GameObject.FindGameObjectWithTag("Helmet");
				//Push Part
				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
				foreach( GameObject enemy in enemies ){
					if( Vector3.Distance(enemy.transform.position, transform.position) < 5 ){
						Vector3 r = enemy.transform.position - this.transform.position;
						enemy.GetComponentInParent<Enemy>().push(r.normalized * 20 / r.magnitude);
					}
				}
				GameObject audioObject;
				audioObject = Resources.Load<GameObject>("Prefabs/Boing");
				Instantiate(audioObject);
			}
			else{
				lose();
			}
		}
	}
	public override void slow(){//what happens when you get slowed down
		return;
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

	public void lose(){//what happens when you lose
		if(!lost){
			Instantiate(dieAudio);

			GameObject explosion = Resources.Load<GameObject>("Prefabs/fire");
			Instantiate(explosion,transform.position,Quaternion.identity);

			lost = true;
		}
	}
}
