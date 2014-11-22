using UnityEngine;
using System.Collections;

public class BeeScriptPlus : MonoBehaviour {

	public float jawSize;
	public float speed;
	public float pause;
	public bool spotted;
	public string maskingLayerName = "Wall";
	public GameObject bee;
	
	private float JawLocation;
	private LineOfSight script;
	private float timer ;
	private float spawnTimer = 0;
	private GameObject[] poop;
	private bool open = false;
	void Start(){
		script = GameObject.FindGameObjectWithTag ("Bee").GetComponent<LineOfSight>();
		JawLocation = transform.localPosition.y;

	}
	void Update () {
		poop = GameObject.FindGameObjectsWithTag ("Bee Minion");
		if (poop.Length < 2) {
			open = true;
				}
		if (open) {
						spawn ();
				}
		if(poop.Length >= 6){
			open = false;
		}
		if (!open) {
						attack ();
				}
		
	}
	void spawn(){
		spawnTimer += Time.deltaTime;
		if (transform.localPosition.y > -20) {
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - jawSize, transform.localPosition.z);

		}if (poop.Length >= 6) {
						transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + jawSize, transform.localPosition.z);
				}
		if (transform.localPosition.y == -20 && spawnTimer > .5f) {
			Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
						Instantiate (bee, spawnPosition, Quaternion.identity);
			spawnTimer = 0;
				}
	}

	void attack(){
				timer += Time.deltaTime;
		
				if (timer > speed) {
						timer = 0;
				}
				if (timer > 0 && timer < speed / pause) {
						transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - jawSize, transform.localPosition.z);
				} else if (timer > speed / pause && timer < speed / (pause / 2)) {
						transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + jawSize, transform.localPosition.z);
				} else if (timer > speed / (pause / 2)) {
						transform.localPosition = new Vector3 (transform.localPosition.x, JawLocation, transform.localPosition.z);
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

}
