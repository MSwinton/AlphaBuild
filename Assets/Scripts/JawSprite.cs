using UnityEngine;
using System.Collections;

public class JawSprite : MonoBehaviour {

	public float jawSize;
	public float speed;
	public float pause;
	private float startY;
	private float JawLocation;
	public float yDist = .3f;
	private float timer = 0;
	void Start(){
			JawLocation = transform.localPosition.y;
			startY = JawLocation;
		}
	void Update () {
		timer += Time.deltaTime;

		if (timer > speed) {
			timer = 0;
		}
		if (timer > 0 && timer < speed / pause && (startY - transform.localPosition.y) < yDist) {
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - jawSize, transform.localPosition.z);
		} 
		else if (timer > speed / pause && timer < speed / (pause/2) &&(startY - transform.localPosition.y) > 0) {
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + jawSize, transform.localPosition.z);
		} 
		else if (timer > speed / (pause/2)) {
			transform.localPosition = new Vector3 (transform.localPosition.x, JawLocation, transform.localPosition.z);
		}



	}
}
