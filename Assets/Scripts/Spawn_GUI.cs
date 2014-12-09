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
 * 12/8 
 * Made menu item light up when pick up corresponding collectible
 * 
 * Check this out to adjust font size according to screen size
 * http://answers.unity3d.com/questions/699456/dynamic-font-size.html
 */
//=====================================================================================================================================================
using UnityEngine;
using System.Collections;

public class Spawn_GUI : MonoBehaviour {
	
	public float width_Offset; //beginning offset
	public float height_Offset;
	
	public Texture pushMineTexture;
	public Texture pushMineBlingTexture;
	public float pushBlingTimer;

	public Texture slowMineTexture;
	public Texture slowMineBlingTexture;
	public float slowBlingTimer;

	public Texture blowupMineTexture;
	public Texture blowupMineBlingTexture;
	public float blowupBlingTimer;

	public Texture invisTexture;
	public Texture invisBlingTexture;
	public float invisBlingTimer;
	
	public GUIStyle homeButtonStyle;
	
	GUIStyle textStyle; //current textStyle only works with 1024*768
	
	public int index = 1; //current weapon selected, use this public int to know selected weapon.
	
	GameObject player;

	//public float invis;

	void Start(){
		textStyle = new GUIStyle ();
		textStyle.fontSize = Screen.width/30;
		pushBlingTimer = 0;
		slowBlingTimer = 0;
		blowupBlingTimer = 0;
		invisBlingTimer = 0;
	}

	void Update(){
		if (pushBlingTimer > 0){
			pushBlingTimer -= Time.deltaTime;
		}
		if (slowBlingTimer > 0){
			slowBlingTimer -= Time.deltaTime;
		}
		if (blowupBlingTimer > 0){
			blowupBlingTimer -= Time.deltaTime;
		}
		if (invisBlingTimer > 0){
			invisBlingTimer -= Time.deltaTime;
		}
	}

	Texture togglePushTexture(){
		if (pushBlingTimer <= 0){
			return pushMineTexture;
		}
		else{
			return pushMineBlingTexture;
		}
	}

	Texture toggleBlowupTexture(){
		if (blowupBlingTimer <= 0){
			return blowupMineTexture;
		}
		else{
			return blowupMineBlingTexture;
		}
	}

	Texture toggleSlowTexture(){
		if (slowBlingTimer <= 0){
			return slowMineTexture;
		}
		else{
			return slowMineBlingTexture;
		}
	}

	Texture toggleInvisTexture(){
		if (invisBlingTimer <= 0){
			return invisTexture;
		}
		else{
			return invisBlingTexture;
		}
	}

	//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void OnGUI(){
		player = GameObject.FindGameObjectWithTag("Player");
		
		width_Offset = Screen.width/8;
		height_Offset = 0;
		
		float button_Offset = (float)Screen.width/100; //offset between buttons as number of units
		
		float button_Size = 0.12f; //button size, as a ratio of screen.width
		
		float background_Box_Size = 0.75f;
		
		float label_width_offset = Screen.width * button_Size * 2/3;
		
		float label_height_offset = 0.035f * Screen.height;
		
		GUI.Box (new Rect(width_Offset,height_Offset,Screen.width * background_Box_Size,Screen.height/9),""); //Background Box
		//----------------------------------------------------------------------------------------------------------------------------------------------------
		
		if(player != null){
			//-------------------push mine-------------------------------
			print (width_Offset + button_Offset);
			GUI.Label (new Rect (width_Offset + button_Offset , height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f), 
				           togglePushTexture());
			button_Offset += Screen.width * button_Size; //next button moved over by the width of buttons
			//number of push mines
			GUI.Label (new Rect(width_Offset + label_width_offset, label_height_offset, 20, 20), 
			           "" + player.GetComponent<PlacePushMine>().numMines, textStyle);


			//------------------slow mine--------------------------------
			print (width_Offset + button_Offset);
			GUI.Label (new Rect (width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f),
				           toggleSlowTexture());
			button_Offset += Screen.width * button_Size;
			//number of slow mines
			GUI.Label (new Rect(label_width_offset + button_Offset, label_height_offset, 20, 20), 
			           "" + player.GetComponent<PlaceSlowMine>().numMines, textStyle);


			//------------------blowup mine------------------------
			GUI.Label (new Rect (width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f),
				           toggleBlowupTexture());
			button_Offset += Screen.width * button_Size;
			//number of blowup mines
			GUI.Label (new Rect(label_width_offset + button_Offset, label_height_offset, 20, 20), 
			           "" + player.GetComponent<PlaceBlowupMine>().numMines, textStyle);


			//-----------------invis-------------------------------
			button_Offset += Screen.width * button_Size;
			GUI.Label(new Rect(width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f), 
				          toggleInvisTexture());
			//amount of invisijuice left
			GUI.Label (new Rect(width_Offset + label_width_offset + button_Offset - 10, label_height_offset, 20, 20), 
			           "" + Mathf.Round (player.GetComponent<Invisibility>().invisijuice * 10) / 10, textStyle);

			
			button_Offset += Screen.width * button_Size;
			if (GUI.Button(new Rect(width_Offset + button_Offset, height_Offset +10 , Screen.width * button_Size, Screen.height * 0.09f),"", 
			               homeButtonStyle)){
				Application.LoadLevel ("HomeMenu"); 
			}
		}
		
	}
}