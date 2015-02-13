using UnityEngine;
using System.Collections;

public class ClickTutorial : MonoBehaviour {
	public string nextLevel;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("mouse 0"))
			Application.LoadLevel(nextLevel);
	}
}
 
