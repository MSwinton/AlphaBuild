using UnityEngine;
using System.Collections;

public class HomeMenuController : MonoBehaviour {

	public GUIStyle startButtonStyle;
	public GUIStyle tutorialButtonStyle;

	public Texture gameName;

	void OnGUI(){
		GUI.Label(new Rect(Screen.width / 2 - Screen.width / 4, Screen.height / 4 - Screen.height / 6 , Screen.width / 2, Screen.height / 3 ), gameName);

		if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 6, Screen.height / 2 - Screen.height / 8 , Screen.width / 3, Screen.height / 4 ),"", 
		               startButtonStyle)){
			Application.LoadLevel ("Easy1"); 
		}
		if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 6, Screen.height / 4 * 3 - Screen.height / 16 , Screen.width / 3, Screen.height / 4),"", 
		               tutorialButtonStyle)){
			Application.LoadLevel ("Tutorial1-1"); 
		}
	}
}
