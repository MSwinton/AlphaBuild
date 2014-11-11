using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	Level level;
	GameObject splodeables;
	public string inputFile;
	public string next_level;
	public GameObject floorTile, wallTile, player, exit, slow_enemy, fast_enemy, ranged_enemy, pounce_enemy, vision_tower, dead_zone, blowup_mine, push_mine, slow_mine, invisijuice;
	void Start(){
		level = new Level(inputFile);
		splodeables = new GameObject();
		splodeables.tag = "Splodeables";
		splodeables.transform.parent = this.transform;
		playLevel();
	}
	void playLevel(){
		GameObject tile;
		if (level.tiles != null) {
			for (int y = 0; y < level.tiles.Count; y++) {
				for (int x = 0; x < level.tiles[y].Count; x++) {
					if (level.tiles [y] [x] == 0) {
						tile = Instantiate (floorTile, new Vector3 (x, y, 1), Quaternion.identity) as GameObject;
						tile.transform.name = "Tiles";
					} else if (level.tiles [y] [x] == 1) {
						tile = Instantiate (wallTile, new Vector3 (x, y, 0), Quaternion.identity) as GameObject;
						tile.transform.name = "Wall";
					}
					//more types of tiles coming up, e.g. kill zone
				}
			}
		} else {
			print ("There is no level yet.");		
		}
		GameObject playerObject;
		GameObject exitObject;
		GameObject o;
		if (!(level.playerPosition == Vector3.zero && level.exitPosition == Vector3.zero)) {
			playerObject = Instantiate (player, level.playerPosition, Quaternion.identity) as GameObject;
			playerObject.transform.name = "Player";
			playerObject.transform.parent = splodeables.transform;
			exitObject = Instantiate (exit, level.exitPosition, Quaternion.identity)as GameObject;
			exitObject.transform.name = "Exit";
		}
		for(int i=0;i<level.slowEnemyPositions.Count;i++){
			o = Instantiate (slow_enemy, level.slowEnemyPositions[i], Quaternion.identity) as GameObject;
			o.transform.name = "Slow Enemy";
			o.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.fastEnemyPositions.Count;i++){
			o = Instantiate (fast_enemy, level.fastEnemyPositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Fast Enemy";
			o.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.pounceEnemyPositions.Count;i++){
			o = Instantiate (pounce_enemy, level.pounceEnemyPositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Pounce Enemy";
			o.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.rangedEnemyPositions.Count;i++){
			o = Instantiate (ranged_enemy, level.rangedEnemyPositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Ranged Enemy";
			o.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.towerPositions.Count;i++){
			o = Instantiate (vision_tower, level.towerPositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Vision Tower";
			o.transform.parent = splodeables.transform;
		}
		for(int i=0;i<level.deadZonePositions.Count;i++){
			o = Instantiate (dead_zone, level.deadZonePositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Dead Zone";
		}
		for(int i=0;i<level.blowupMinePositions.Count;i++){
			o = Instantiate (blowup_mine, level.blowupMinePositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Blowup Mine";
		}
		for(int i=0;i<level.pushMinePositions.Count;i++){
			o = Instantiate (push_mine, level.pushMinePositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Push Mine";
		}
		for(int i=0;i<level.slowMinePositions.Count;i++){
			o = Instantiate (slow_mine, level.slowMinePositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Slow Mine";
		}
		for(int i=0;i<level.invisijuicePositions.Count;i++){
			o = Instantiate (invisijuice, level.invisijuicePositions[i], Quaternion.identity)as GameObject;
			o.transform.name = "Invisijuice";
		}
	}
}
