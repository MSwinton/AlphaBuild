/* Modified TankController.cs from http://www.unit3y.com/unity-2d-tank-game-part-x-shooting/
 * October 24,2014
 * MouseMovement.cs rotates the player object towards the mouse. 
 * Add this script to Player object.
 */
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
	public Vector3 mouse_Position; //position of mouse
	public Vector3 object_Position; //position of player

	void FixedUpdate () { //Use fixedupdate with rigidbodies.
		mouse_Position = Input.mousePosition; //Get mouse position.
		mouse_Position.z = 0.0f;  //For 2D game.
		Vector3 object_Position = Camera.main.WorldToScreenPoint(transform.position); // Get position of player relative to camera.
		mouse_Position.x = mouse_Position.x - object_Position.x;  //Calculate the distances
		mouse_Position.y = mouse_Position.y - object_Position.y;
		float angle = Mathf.Atan2(mouse_Position.y, mouse_Position.x) * Mathf.Rad2Deg - 90; //With distance calculate the angle between mouse and player.
		transform.rotation = Quaternion.Euler(new Vector3 (0, 0, angle)); //rotate. 
	}
}
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++