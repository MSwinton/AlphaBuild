using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	public string nextLevel;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			Application.LoadLevel (nextLevel);
		}
	}
}
