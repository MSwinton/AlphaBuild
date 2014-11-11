using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public string nextLevel;

	private GameManager script;
	void Start(){
		script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			Application.LoadLevel (script.next_level);
		}
	}
}
