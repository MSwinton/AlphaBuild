using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	Enemy myParent;
	public float speed;
	void Start(){
		myParent = transform.GetComponentInParent <Enemy>();
	}
	// Update is called once per frame
	void Update () {
		if(myParent.aggrod){
			transform.Rotate (Vector3.back * speed * Time.deltaTime);
		}
	}
}
