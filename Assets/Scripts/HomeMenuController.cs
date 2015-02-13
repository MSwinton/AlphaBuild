using UnityEngine;
using System.Collections;

public class HomeMenuController : MonoBehaviour {

	public GUIStyle startButtonStyle;
	public GUIStyle tutorialButtonStyle;

	public Texture gameName;
	public Texture musicCredit;

	void OnGUI(){
		GUI.Label(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 4 , Screen.width / 2, Screen.height / 3 ), gameName);

		if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 6, Screen.height / 2 , Screen.width / 3, Screen.height / 4 ),"", 
		               startButtonStyle)){
			Application.LoadLevel ("Tutorial1-1"); 
		}

		GUI.Label(new Rect(Screen.width / 4, Screen.height / 8 * 7 , Screen.width / 2, Screen.height / 8 ), musicCredit);
	}
}
 
