using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	private float timer = 0.0f;
	public float speed = 1.0f;

	public Sprite explosion_1, explosion_2, explosion_3;
	public SpriteRenderer spriteRenderer;

	void Update () {
	if (timer > 0 && timer < speed/3) {
						spriteRenderer.sprite = explosion_1;
				} else if (timer > speed/3 && timer < 2*speed/3 ){
						spriteRenderer.sprite = explosion_2;
				} else if (timer > 2*speed/3 && timer < speed) {
						spriteRenderer.sprite = explosion_3;
				}
				else if (timer > speed) {
						Destroy (gameObject);
				}
		timer += Time.deltaTime;
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag != "Barrier" && other.tag!="LineOfSight"){
			Destroy(other.gameObject);
		}
	}
}
 
