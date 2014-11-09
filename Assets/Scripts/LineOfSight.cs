/*Peter Aguiar
 * 10/6/2014
 * LineOfSight creates basic line of sight for an enemy 
 * that does not see through "barriers".
 * cs 361
 * &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
 * 10/13/2014
 * &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
 * HOW TO: Highlight the enemy that needs line of sight. At the top left of unity, click on "GameObject" and then "Create Empty Child Object"
 * An empty child object should be in the drop down of your enemy. If not, click and drag the new empty child and put it into the enemy. 
 * Highlight the child object. Make the transform.position in the inspector 0,0,0 so that it is centered with the parent. 
 * If you want to move the enemy object, do not highlight the child; the child will move with the parent (always make sure the child is at
 * the center of the parent at position 0,0,0 or where ever you want it to be).
 * Click "Add Component", "Physics2D", and then select a collider. 
 * Change the size of the collider to match line of sight for the collider will represent your line of sight for the enemy. 
 * Make sure the "Is Trigger" check box on the collider is MARKED (true). 
 * Place this script within your script folder.
 * Highlight the child again and click "Add Component", "Scripts", and select "LineOfSight.cs".
 * Click and drag enemy parent into the "Enemy Object" section in the child's inspector.
 * ----
 * 	ADD TAGS AND LAYERS TO EVERYTHING. 
 * 	-- At the top left of every object's inspector, there is a drop down menu for "tag". ALWAYS SELECT PLAYER ONLY FOR THE PLAYER OBJECT!
 *  -- If you want to make a custom tag, go to the previous menu, select "Add Tag...". Under the drop down menu for tag, enter your custom name
 * 	-- into an empty element listing. Increase the "Size" variable to accomidate all of your tags. Click out, and add your new tag.
 * 	-- To make a layer, click an object and click the "Layer" drop down menu in its inspector. 
 * 	-- You can add custom layers the same way as tags except use the "Leyers" drop down menu (opposed to "Tags"); 
 * 	-- Be specific or general as needed, usually layers are more specific than tags however. 
 * ----
 * Highlight the child, type in "MaskingLayerName" the layer name you gave the objects that the enemy should not see through. 
 * 
 * There are four lines of code marked with many exclamation points that you may need to change. 
 * Change instances of "Kill" to the name of your enemy's behavioral script.
 * Change instances of "move" to the public boolean name that controls if the enemy will move or not.
 * Change "Update" as needed (though sparingly and thoughtfully).
 * Add complexity to "sight" layer masking and number of booleans as needed (CARE!). 
 * &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
 * 
 */
using UnityEngine;
using System.Collections;
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
public class LineOfSight : MonoBehaviour {

	public bool spotted = false; 
	public int playerLayer;
	public GameObject enemyObject;
	public string maskingLayerName;

	public float radius = 15.0f;

	private GameObject spawn;
	private CircleCollider2D myCollider;

	private /*-->*/ Enemy /*<--*/ enemyScript; //!!!! YOU MIGHT NEED TO CHANGE !!!!

//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void Start(){
				if (enemyObject != null) { //Checks to see if enemy object exists.
						enemyScript = enemyObject.GetComponent </*!!!!->*/ Enemy /*<-!!!!*/> (); // !!!!  YOU MIGHT NEED TO CHANGE !!!!
				}
				if (enemyObject == null) {
						Debug.Log ("Can't find player object!"); //Debug
				}

		}
//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void Update () {

		if (spotted && enemyObject != null) { //If player is spotted and the enemy exists
						enemyScript./*-->*/ inLineOfSight /*<--*/ = true; //!!!! YOU MIGHT NEED TO CHANGE !!!!

				} else {
						enemyScript./*-->*/ inLineOfSight /*<--*/ = false; //!!!! YOU MIGHT NEED TO CHANGE !!!!
				}

	}
//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void sight(Transform other){
				
		Debug.DrawLine (transform.position, other.position, Color.red); //In the scene view during play, a red line will be drawn to illustrate line of sight.
		if (!Physics2D.Linecast (transform.position, other.position, 1 << LayerMask.NameToLayer (maskingLayerName)) // Check is Objects will obscure vision.
		     ) {
			spotted = true; //Player is spotted.
				} else {
						spotted = false; //Player not in sight or something obscured vision. 
				}
	}
//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void OnTriggerStay2D (Collider2D other){ //Checks objects within collider. 


		if(other.tag == "Player"){ //If an object tagged "Player" comes into the collider

			sight(other.transform); //Check to see if it can be seen. 
		}
	}
//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
	void OnTriggerExit2D(Collider2D other){ 
				if (other.tag == "Player") { //When Player leaves line of sight.
						spotted = false; //The enemy cannot see the player. 
				}
		}
	                                     

//&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

}
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
