using UnityEngine;
using System.Collections;

public class PlaceMine<T> : MonoBehaviour where T : Mine {

	public float blastRadius;
	public float detonateRadius;
	public int numMines;
	protected Sprite sprite;
	public GameObject splodeables;
	public KeyCode keycode = KeyCode.E;
	public float reloadTime;
	public float armTime;
	protected float timer;
	protected void Start(){
		timer = 0;
		splodeables = GameObject.FindWithTag("Splodeables");
		//numMines = 5;
	}
	protected void Update () {
		if(Input.GetKeyDown(keycode) && numMines > 0 && timer <= 0){
			placeMine(this.transform.position);
			numMines--;
			timer = reloadTime;
		}
		if(timer > 0)
			timer-= Time.deltaTime;
	}
	protected void placeMine(Vector3 position){
		GameObject mineObject = new GameObject();
		mineObject.name = "Mine";
		SpriteRenderer spriterenderer = mineObject.AddComponent<SpriteRenderer>();
		spriterenderer.sprite = sprite;
		T mineScript = mineObject.AddComponent<T>();
		mineScript.init(splodeables,armTime,detonateRadius,blastRadius);
		mineScript.transform.position = position;
	}
}
