﻿using UnityEngine;
using System.Collections;

public class Invisibility : MonoBehaviour {
	public bool isVisible = true;
	public float invisijuice = 5.0f;
	public KeyCode keycode = KeyCode.Space;
	void Start () {
		renderer.material.shader = Shader.Find("Transparent/Diffuse");
		turnVisible();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isVisible){
			invisijuice -= Time.deltaTime;
		}
		if (Input.GetKeyDown (keycode)) {
			if(isVisible){
				turnInvisible();
			}
			else{
				turnVisible();
			}
		}
		if (invisijuice <= 0 && !isVisible){
			turnVisible();
			invisijuice = 0.0f;
		}
	}
	public void turnInvisible(){
		renderer.material.color = new Color(5,5,5,.2f);
		isVisible = false;
	}
	public void turnVisible(){
		renderer.material.color = new Color(5,5,5,1);
		isVisible = true;
	}
}