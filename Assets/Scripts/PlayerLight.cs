using UnityEngine;
using System.Collections;

public class PlayerLight : MonoBehaviour {
	GameObject[][] floorTiles;
	void Start(){
		GameObject[] tiles = GameObject.FindGameObjectsWithTag("Floor");
		int xMax = 0;
		int yMax = 0;
		for(int i=0;i<tiles.Length;i++){
			int x = (int)tiles[i].transform.position.x;
			if(x > xMax){
				xMax = x;
			}
			int y = (int)tiles[i].transform.position.y;
			if(y > yMax){
				yMax = y;
			}
			tiles[i].GetComponent<SpriteRenderer>().color = new Color(200,200,200);
		}
		floorTiles = new GameObject[xMax+1][];
		for(int i=0;i<xMax+1;i++){
			floorTiles[i] = new GameObject[yMax+1];
		}
		for(int i=0;i<tiles.Length;i++){
			int x = (int)tiles[i].transform.position.x;
			int y = (int)tiles[i].transform.position.y;
			floorTiles[x][y] = tiles[i];
		}
	}
	void Update(){
		int x = (int)transform.position.x;
		int y = (int)transform.position.y;
		for(int i = -3;i<4;i++){
			for(int j = -3;j<4;j++){
				if(floorTiles[x+i][y+j] != null){
					SpriteRenderer rend = floorTiles[x+i][y+j].GetComponent<SpriteRenderer>();
					rend.color = new Color(255,255,255);
				}
			}
		}
	}
}
 
