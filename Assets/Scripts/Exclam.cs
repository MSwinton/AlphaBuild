using UnityEngine;
using System.Collections;

public class Exclam : MonoBehaviour {
	
	private SpriteRenderer sprendor;
	private Enemy parent;
	private float timer;
	public float activeTime = .5f;
	// Use this for initialization
	void Start() {
		parent = gameObject.GetComponentInParent<Enemy>();
		renderer.enabled = false;
		timer = -1;
	}
	void Update(){
		if(parent.aggrod && timer < 0){
			renderer.enabled = true;
			timer = activeTime;
			print(timer);
		}
		if(timer > 0){
			timer -= Time.deltaTime;
			
			if(timer <= 0){
				Destroy(gameObject);
			}
		}
	}
	
}
