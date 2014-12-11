﻿using UnityEngine;
using System.Collections;

/*
 * Implementation on this one is a bit janky because I wanted to have one script that could be used for any
 * type of collectable, so here's the instructions:
 * 
 * Make a sprite/prefab with the appropriate picture, and attach this script to it.
 * While your at it, give the sprite a circle collider and check "Is Trigger".  It doesn't need a Rigidbody.
 * 
 * In the thingName variable, write the name of the mine you are placing.  Use the script names for reference (Place<Name>Mine.cs).
 * For instance, if you want this to be a push mine, write "Push" in the thingName.  For your convenience, this is case insensitive.
 */

public class Collectable : MonoBehaviour {
	public string thingName;
	public int amount = 3;
	GameObject audioObject;
	GameObject cameraObject;
	Spawn_GUI gui;
	void Start(){
		audioObject = Resources.Load<GameObject>("Prefabs/Bling");
		cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		gui = cameraObject.GetComponent<Spawn_GUI>();
	}
	void OnTriggerEnter2D( Collider2D other ){
		if( other.tag == "Player" ){ 
			if( thingName.ToLower() == "flash" ){
				Instantiate(audioObject);
				other.GetComponent<PlaceFlashMine>().numMines += amount;
				Destroy(gameObject);
				return;
			}
			if( thingName.ToLower() == "blowup" ){
				Instantiate(audioObject);
				other.GetComponent<PlaceBlowupMine>().numMines += amount;
				gui.blowupBlingTimer = 1.0f;
				Destroy(gameObject);
				return;
			}
			if( thingName.ToLower() == "slow" ){
				Instantiate(audioObject);
				other.GetComponent<PlaceSlowMine>().numMines += amount;
				gui.slowBlingTimer = 1.0f;
				Destroy(gameObject);
				return;
			}
			if( thingName.ToLower() == "push" ){
				Instantiate(audioObject);
				other.GetComponent<PlacePushMine>().numMines += amount;
				gui.pushBlingTimer = 1.0f;
				Destroy(gameObject);
				return;
			}
			if( thingName.ToLower() == "invisijuice" ){
				Instantiate(audioObject);
				other.GetComponent<Invisibility>().invisijuice += amount;
				gui.invisBlingTimer = 1.0f;
				Destroy(gameObject);
				return;
			}
			if( thingName.ToLower() == "shield" && other.GetComponent<Movement>().shielded == false){
				Instantiate(audioObject);
				GameObject helmetObj = GameObject.FindGameObjectWithTag("Helmet");
				if(helmetObj != null){
					Destroy(helmetObj);
				}
				other.GetComponent<Movement>().shielded = true;
				other.GetComponent<Movement>().immunetime = 0;
				GameObject helmObj = Instantiate(Resources.Load ("Prefabs/Helmet"),Vector3.zero,Quaternion.identity) as GameObject;
				helmObj.transform.parent = other.transform;
				helmObj.transform.localPosition = new Vector3(0,0,-.1f);
				Destroy(gameObject);
				return;
			}
		}
	}
	
}
