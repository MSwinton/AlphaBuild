using UnityEngine;
using System.Collections;

public class SwitchFlip : MonoBehaviour {
	Dynatrigger trigger;
	bool activated;
	void Start(){
		trigger = this.GetComponentInParent<Dynatrigger>();
		activated = false;
		this.transform.localEulerAngles = new Vector3(0,0,30);
	}
	void Update(){
		if(!activated){
			if(trigger.activated){
				activated = true;
				transform.localEulerAngles = new Vector3(0,0,-30);
			}
		}
	}
}
 
