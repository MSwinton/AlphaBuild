using UnityEngine;
using System.Collections;

public class Dynapile : MonoBehaviour {
	
	public void goBoom( ){
		GameObject explosion = Resources.Load<GameObject>("Prefabs/fire");
		Instantiate(explosion,transform.position,Quaternion.identity);
		GameObject.Destroy(this.gameObject);
	}
}
