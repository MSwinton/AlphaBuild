using UnityEngine;
using System.Collections;

public class BeeJawScript : MonoBehaviour {
	public float attackSpeed, attackPause, attackJawSize;
	public float standBySpeed, standByPause, standByJawSize;
	public bool spotted = false;
	public string maskingLayerName = "Wall";

	private bool attack;
	private bool haveSpawned ;
	private Vector2 location;
	private float timer ;
	void Start () {
		haveSpawned = false;
		attack = false;
		location.x = transform.localPosition.x;
		location.y = transform.localPosition.y;
		timer = standBySpeed;
	}
	
	// Update is called once per frame
	void Update () {

		if (spotted && CheckPosition ()) {
						attack = true;
				} else if (!spotted && CheckPosition ()) {
						attack = false;
				}
		if (attack) {
						JawMovement (attackSpeed, attackPause, attackJawSize);
				} else {
						JawMovement (standBySpeed, standByPause, standByJawSize);
				}
		
	}
	void JawMovement(float speed, float pause, float jawSize){
		timer += Time.deltaTime;
		if (timer > speed + pause) {
			transform.localPosition = new Vector3 (location.x, location.y, transform.localPosition.z);
			timer = 0;
		}
		if (timer > 0 && timer < speed / 2) {
						transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - jawSize, transform.localPosition.z);
				} else if (timer > speed / 2 && timer < speed) {
						transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + jawSize, transform.localPosition.z);
		} else {
			transform.localPosition = new Vector3 (location.x, location.y, transform.localPosition.z);		
		}
	}
	void OnTriggerStay2D(Collider2D other){
				if (other.tag == "Player") {
						Debug.DrawLine (transform.position, other.transform.position, Color.red);
						if (!Physics2D.Linecast (transform.position, other.transform.position, 1 << LayerMask.NameToLayer (maskingLayerName))) {
								spotted = true;
						} else {
								spotted = false;
						}
				}
		}
	void OnTriggerExit2D(Collider2D other){
				if (other.tag == "Player") {
						spotted = false;
				}
		}
			bool CheckPosition(){
				if ((location.y == transform.position.y) && (location.x == transform.position.x)){
					return true;
				}return false;
			}


}
 
