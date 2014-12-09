using UnityEngine;
using System.Collections;

public class SentinelTower : Enemy {
	GameObject light;
	Color lightColor;
	Color inactiveColor;
	Color activeColor;
	float blinkTimer;
	bool blink;

	void Start () {
		base.init();
		aggroRadius = 2.8f;
		aggrod = false;
		destLocation = this.transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerInvisibility = player.GetComponent<Invisibility>();
		light = transform.FindChild("Area Light").gameObject;
		inactiveColor = Color.blue;
		activeColor = Color.red;
		blinkTimer = 0.1f;
		blink = false;
	}
	
	public void OnTriggerEnter2D( Collider2D other ){
		if( other.tag == "Player" ){
			playerInvisibility.canInvis = false;
			playerInvisibility.turnVisible();
			light.light.color = activeColor;
			blink = true;
		}
	}
	
	public void OnTriggerExit2D( Collider2D other ){
		if( other.tag == "Player" ){
			playerInvisibility.canInvis = true;
			light.light.color = inactiveColor;
			blink = false;
			light.light.intensity = 2.5f;
		}
	}

	void Update(){
		float t = Time.deltaTime;
		if (blink){
			if (blinkTimer >= 0){
				blinkTimer -= t;
				light.light.intensity = 2.5f;
			}
			else if (blinkTimer >= -0.1f){
				blinkTimer -= t;
				light.light.intensity = 1.0f;
			}
			else{
				blinkTimer = 0.1f;
			}
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
