using UnityEngine;
using System.Collections;

public class JawSprite : MonoBehaviour {

	public float jawSize;
	public float speed;
	public float pause;

	private float JawLocation;

	private float timer = 0;
	void Start(){
				JawLocation = transform.localPosition.y;
		}
	void Update () {
		timer += Time.deltaTime;

		if (timer > speed) {
						timer = 0;
				}
		if (timer > 0 && timer < speed / pause) {
						transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - jawSize, transform.localPosition.z);
				} else if (timer > speed / pause && timer < speed / (pause/2)) {
						transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + jawSize, transform.localPosition.z);
		} else if (timer > speed / (pause/2)) {
						transform.localPosition = new Vector3 (transform.localPosition.x, JawLocation, transform.localPosition.z);
				}



	}
}
