using UnityEngine;
using System.Collections;

public class PlayerSprite : MonoBehaviour {

	public Sprite visible;
	public Sprite invisible;
	private GameObject player;

	private Invisibility script;
	private SpriteRenderer spriteRenderer;
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		player = GameObject.FindWithTag ("Player");
		if (spriteRenderer == null) {
			Debug.Log ("Can't find SpriteRenderer!");
		}
		script = player.GetComponent<Invisibility> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!script.isVisible) {
			spriteRenderer.sprite = invisible;
		} else {
			spriteRenderer.sprite = visible;
		}
	}
}
 
