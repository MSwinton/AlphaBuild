using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	Enemy myParent;
	public float aggroSpeed;
	public float nonAggroSpeed;
	void Start(){
		myParent = transform.GetComponentInParent <Enemy>();
	}
	// Update is called once per frame
	void Update () {
		if(myParent.aggrod){
			transform.Rotate (Vector3.back * aggroSpeed * Time.deltaTime);
		}
		else{
			transform.Rotate (Vector3.back * nonAggroSpeed * Time.deltaTime);
		}
	}
}
 
