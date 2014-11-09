using UnityEngine;
using System.Collections;

public class InvisResource : MonoBehaviour {
	private Shader invis;
	private Shader visible;
	
	public float speed = 1.0f;
	public float invisJuice = 3.0f;
	
	private bool isVisible;

	private float deltaTime;
	
	void Start(){
		invis  = Shader.Find ("Transparent/Diffuse");
		visible = Shader.Find ("Sprites/Default");
		isVisible = true;
		 
	}
	void Update(){
		deltaTime = Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(isVisible && invisJuice > 0.0f){
				renderer.material.shader = invis;
				renderer.material.color = new Color(1,1,1,.5f);
				isVisible = false;
			}
			else{
				renderer.material.shader = visible;
				renderer.material.color = new Color(1,1,1,1);
				isVisible = true;
			}
		}
		if (invisJuice < 0) {
			renderer.material.shader = visible;
			renderer.material.color = new Color (1, 1, 1, 1);
		}
		if (!isVisible) {
						invisJuice -= deltaTime;
				}
	}
}
