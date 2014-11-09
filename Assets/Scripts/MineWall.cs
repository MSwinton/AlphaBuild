using UnityEngine;
using System.Collections;

public class MineWall : MonoBehaviour {

	public float expansion_Speed = 1.0f;
	public float delay = 100.0f;
	public float death = 500.0f;
	public BoxCollider2D collider;

	private float time = 0.0f;

	void Start(){
		collider.isTrigger = true;
		}

	void FixedUpdate () {
		time += Time.deltaTime + expansion_Speed;
		if (time > delay) {
						transform.localScale += new Vector3 (0.01f, 0, 0);
			collider.size += new Vector2(0.01f,0);
						collider.isTrigger = false;
				}
		if (time > death) {
						Destroy (gameObject);
				}

	}
}
