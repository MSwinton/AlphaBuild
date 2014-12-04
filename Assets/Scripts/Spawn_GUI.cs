/*Peter Aguiar
 * October 22-23, 2014
 * Spawn_GUI.cs spawns and controls the weapon UI. Either clicking the corresponding number key, rolling the mouse wheel, or clicking the
 * number directly changes the "index" value accordingly. 
 * 
 * October 23: The last button is reserved as a menu button for later, the current index is printed next to "menu".
 * 
 * Shiying Zheng
 * 12/3/14
 * Made custom buttons
 */
//=====================================================================================================================================================
using UnityEngine;
using System.Collections;

public class Spawn_GUI : MonoBehaviour {
	
	public float width_Offset; //beginning offset
	public float height_Offset;
	
	public Texture pushMineTexture;
	public Texture slowMineTexture;
	public Texture blowupMineTexture;
	public Texture invisTexture;
	
	public GUIStyle homeButtonStyle;
	
	public GUIStyle textStyle;
	
	public int index = 1; //current weapon selected, use this public int to know selected weapon.
	
	GameObject player;
	
	//public float invis;
	
	
	//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void OnGUI(){
		player = GameObject.FindGameObjectWithTag("Player");
		
		width_Offset = Screen.width/8;
		height_Offset = 0;
		
		float button_Offset = 10; //offset between buttons
		
		float button_Size = 0.12f; //button size
		
		float background_Box_Size = 0.75f;
		
		float label_width_offset = Screen.width * button_Size * 2/3;
		
		float label_height_offset = 0.04f * Screen.height;
		
		GUI.Box (new Rect(width_Offset,height_Offset,Screen.width * background_Box_Size,Screen.height/9),""); //Background Box
		//----------------------------------------------------------------------------------------------------------------------------------------------------
		
		if(player != null){
			
			GUI.Label (new Rect (width_Offset + button_Offset , height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f), 
			           pushMineTexture);
			button_Offset += Screen.width * button_Size; //next button moved over by the width of buttons
			
			GUI.Label (new Rect(width_Offset + label_width_offset, label_height_offset, 20, 20), 
			           "" + player.GetComponent<PlacePushMine>().numMines, textStyle);
			
			GUI.Label (new Rect (width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f),
			           slowMineTexture);
			//"2 Slow (" + player.GetComponent<PlaceSlowMine>().numMines + ")", style)) {
			button_Offset += Screen.width * button_Size;
			
			GUI.Label (new Rect(label_width_offset + button_Offset, label_height_offset, 20, 20), 
			           "" + player.GetComponent<PlaceSlowMine>().numMines, textStyle);
			
			
			GUI.Label (new Rect (width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f),
			           blowupMineTexture);
			//"3 Blowup (" + player.GetComponent<PlaceBlowupMine>().numMines + ")", style)) {
			button_Offset += Screen.width * button_Size;
			
			GUI.Label (new Rect(label_width_offset + button_Offset, label_height_offset, 20, 20), 
			           "" + player.GetComponent<PlaceBlowupMine>().numMines, textStyle);
			
			button_Offset += Screen.width * button_Size;
			GUI.Label(new Rect(width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f), 
			          invisTexture);
			
			GUI.Label (new Rect(width_Offset + label_width_offset + button_Offset - 10, label_height_offset, 20, 20), 
			           "" + Mathf.Round (player.GetComponent<Invisibility>().invisijuice * 10) / 10, textStyle);
			//"Invis: " + Mathf.Round (player.GetComponent<Invisibility>().invisijuice * 10) / 10 + "s" )) {
			
			button_Offset += Screen.width * button_Size;
			if (GUI.Button(new Rect(width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f),"", 
			               homeButtonStyle)){
				
			}
		}
		
	}
}