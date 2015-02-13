using UnityEngine;
using System.Collections;

public class PointTowardsPlayer : MonoBehaviour {
	Enemy myParent;
	void Start(){
		myParent = transform.GetComponentInParent <Enemy>();
	}
	// Update is called once per frame
	void Update () {
		if(myParent.aggrod){
			Vector3 dest = myParent.destLocation;
			Vector3 direction = dest - transform.position;
			float angle = Vector3.Angle(new Vector3(-1,1,0),direction);
			if(-direction.x<direction.y){
				angle *= -1;
			}
			transform.localEulerAngles = new Vector3(0,0,angle);
		}
	}
}
 
