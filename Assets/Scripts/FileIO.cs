using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

/*
 * The format of a level file should be:
 * TILES
 * 1 1 1 1 1 1 1
 * 1 0 0 1 0 0 1
 * 1 0 0 0 0 0 1
 * 1 0 0 1 1 1 1
 * PLAYER
 * (0,0,0)
 * FAST ENEMY
 * (3,1,5) (2,4,7) (9,1,3)
 * ...
 */

public class FileIO : MonoBehaviour{

	public int[][] ReadFromFile(string fileName){
		TextAsset txt = (TextAsset) Resources.Load ("LevelFiles/" + fileName, typeof (TextAsset));
		string content = txt.text;
		List<string> lines = new List<string> (Regex.Split(content, "\r\n"));

		int tileStart = -1;
		int tileEnd = -1;

		print (lines[0]);
		print (string.Compare(lines[0], "TILES")); //???????!!!!!!!!!!!!!

		for (int i = 0; i < lines.Count; i++){
			print (lines[i]);
			if (string.Compare(lines[i], "TILES") == 0){
				tileStart = i;
			}
			if (lines[i].Length == 0 || (string.Compare(lines[i][0].ToString(), "1") == 0 && string.Compare(lines[i][0].ToString(),"0") == 0)){
				tileEnd = i;
				break;
			}
		}

		if (tileStart != -1){
			if (tileEnd == -1) tileEnd = lines.Count;
			int[][] tiles = new int[tileEnd-tileStart-1][];
			int tilePosition = 0;
			for (int i = tileStart; i < tileEnd; i++){
				if (string.Compare(lines[i],"TILES" ) == 0) {
					continue;
				}
				string[] line = lines[i].Split(' ');
				tiles[tilePosition] = new int[line.Length];
				for (int j = 0; j < line.Length; j++){
					tiles[tilePosition][j] = int.Parse(line[j]);
				}
				tilePosition++;
			}
			return tiles;
		}
		return null;
	}

	public void WriteToFile(int[][] tiles, string fileName){
		string path = "Assets/Resources/LevelFiles/" + fileName + ".txt";
		StreamWriter sw;
		if (File.Exists(path)) {
			sw = new StreamWriter(path);
		}
		else {
			sw = File.CreateText(path);
		}
		sw.WriteLine("TILES");
		for (int i = 0; i < tiles.Length; i++){
			string line = "";
			for (int j = 0; j < tiles[i].Length; j++){
				line += tiles[i][j].ToString();
				if (j < tiles[i].Length - 1) line += " ";
			}
			sw.WriteLine(line);
		}
		sw.Close();
	}

}
