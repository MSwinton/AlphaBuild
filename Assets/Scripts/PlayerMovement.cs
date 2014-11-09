using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 1.0f;
	
	void FixedUpdate(){
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical,0.0f );
		rigidbody2D.velocity = movement * speed;
		
		transform.rotation = Quaternion.Euler(0,0,0);
		
		
	}
}
