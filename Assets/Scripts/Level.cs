using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

public class Level{
	
	public List<List<int>> tiles;
	public int width = 50;
	public int height = 50;
	public Vector3 playerPosition;
	public Vector3 exitPosition;
	public List<Vector3> slowEnemyPositions;
	public List<Vector3> fastEnemyPositions;
	public List<Vector3> pounceEnemyPositions;
	public List<Vector3> rangedEnemyPositions;
	public List<Vector3> towerPositions;
	public List<Vector3> deadZonePositions;
	
	public Level(string fileName){
		tiles = new List<List<int>>(); // if we need to add new rows we need to initialize a List<int> element and add to tiles
		slowEnemyPositions = new List<Vector3>();
		fastEnemyPositions = new List<Vector3>();
		pounceEnemyPositions = new List<Vector3>();
		rangedEnemyPositions = new List<Vector3>();
		towerPositions = new List<Vector3>();
		deadZonePositions = new List<Vector3>();
		
		
		/*for(int i=0;i<width;i++){
			tiles.Add (new List<int>());
			for (int j = 0; j < height; j++){
				tiles[i].Add (0);
			}
		}*/
		
		if (fileName == ""){
			//setDimensions(100,100);
			return;
		}
		
		TextAsset txt = (TextAsset) Resources.Load ("LevelFiles/" + fileName, typeof (TextAsset));
		string content = txt.text;
		List<string> lines = new List<string> (Regex.Split(content, "\r\n"));
		
		int tileStart = -1;
		int tileEnd = -1;
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "TILES") == 0){
				tileStart = i;
			}
		}
		for (int i = tileStart+1; i < lines.Count; i++){
			if (lines[i].Length == 0 || (string.Compare(lines[i][0].ToString(), "1") != 0 && string.Compare(lines[i][0].ToString(),"0") != 0)){
				tileEnd = i;
				break;
			}
		}
		if (tileStart != -1){
			if (tileEnd == -1) tileEnd = lines.Count;
			int tilePosition = 0;
			int i;
			for (i = tileStart; i < tileEnd; i++){
				if (string.Compare(lines[i],"TILES" ) == 0) {
					continue;
				}
				string[] line = lines[i].Split(' ');
				tiles.Add(new List<int>());
				int j;
				for (j = 0; j < line.Length; j++){
					tiles[tilePosition].Add (int.Parse(line[j]));
				}
				width = j;
				tilePosition++;
			}
			height = i;
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "PLAYER") == 0){
				string playerLine = lines[i+1];
				string[] playerLineSplit = playerLine.Split (',');
				playerPosition = new Vector3(float.Parse (playerLineSplit[0]), float.Parse (playerLineSplit[1]),0);
				break;
			}
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "EXIT") == 0){
				string exitLine = lines[i+1];
				string[] exitLineSplit = exitLine.Split (',');
				exitPosition = new Vector3(float.Parse (exitLineSplit[0]), float.Parse (exitLineSplit[1]),0);
				break;
			}
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "SLOW ENEMY") == 0){
				string BELine = lines[i+1];
				string[] BELineSplit = BELine.Split (' ');
				for (int j = 0; j < BELineSplit.Length; j++) {
					string[] BE = BELineSplit[j].Split(',');
					slowEnemyPositions.Add (new Vector3(float.Parse(BE[0]), float.Parse(BE[1]), 0));
				}
				break;
			}
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "FAST ENEMY") == 0){
				string FELine = lines[i+1];
				string[] FELineSplit = FELine.Split (' ');
				for (int j = 0; j < FELineSplit.Length; j++) {
					string[] FE = FELineSplit[j].Split(',');
					fastEnemyPositions.Add (new Vector3(float.Parse(FE[0]), float.Parse(FE[1]), 0));
				}
				break;
			}
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "POUNCE ENEMY") == 0){
				string PELine = lines[i+1];
				string[] PELineSplit = PELine.Split (' ');
				for (int j = 0; j < PELineSplit.Length; j++) {
					string[] PE = PELineSplit[j].Split(',');
					pounceEnemyPositions.Add(new Vector3(float.Parse(PE[0]), float.Parse(PE[1]), 0));
				}
				break;
			}
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "RANGED ENEMY") == 0){
				string RELine = lines[i+1];
				string[] RELineSplit = RELine.Split (' ');
				for (int j = 0; j < RELineSplit.Length; j++) {
					string[] RE = RELineSplit[j].Split(',');
					rangedEnemyPositions.Add (new Vector3(float.Parse(RE[0]), float.Parse(RE[1]), 0));
				}
				break;
			}
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "TOWER") == 0){
				string RELine = lines[i+1];
				string[] RELineSplit = RELine.Split (' ');
				for (int j = 0; j < RELineSplit.Length; j++) {
					string[] RE = RELineSplit[j].Split(',');
					towerPositions.Add(new Vector3(float.Parse(RE[0]), float.Parse(RE[1]), 0));
				}
				break;
			}
		}
		
		for (int i = 0; i < lines.Count; i++){
			if (string.Compare(lines[i], "DEAD ZONE") == 0){
				string RELine = lines[i+1];
				string[] RELineSplit = RELine.Split (' ');
				for (int j = 0; j < RELineSplit.Length; j++) {
					string[] RE = RELineSplit[j].Split(',');
					deadZonePositions.Add (new Vector3(float.Parse(RE[0]), float.Parse(RE[1]), 0));
				}
				break;
			}
		}
		
	}
	
	public void write(string fileName){
		if (fileName == "") return;
		
		string path = "Assets/Resources/LevelFiles/" + fileName + ".txt";
		
		StreamWriter sw;
		if (File.Exists(path)) {
			sw = new StreamWriter(path);
		}
		else {
			sw = File.CreateText(path);
		}
		
		sw.WriteLine("TILES");
		for (int i = 0; i < tiles.Count; i++){
			string line = "";
			for (int j = 0; j < tiles[i].Count; j++){
				line += tiles[i][j].ToString();
				if (j < tiles[i].Count - 1) line += " ";
			}
			sw.WriteLine(line);
		}
		
		sw.WriteLine("PLAYER");
		string playerLine = playerPosition[0].ToString() + "," + playerPosition[1].ToString();
		sw.WriteLine(playerLine);
		
		sw.WriteLine("EXIT");
		string exitLine = exitPosition[0].ToString() + "," + exitPosition[1].ToString();
		sw.WriteLine(exitLine);
		
		if (slowEnemyPositions.Count > 0){
			sw.WriteLine("SLOW ENEMY");
			string boringEnemyLine = "";
			for (int i = 0; i < slowEnemyPositions.Count; i++){
				boringEnemyLine += slowEnemyPositions[i][0].ToString() + "," + slowEnemyPositions[i][1].ToString();
				if (i < slowEnemyPositions.Count - 1){
					boringEnemyLine += " ";
				}
			}
			sw.WriteLine(boringEnemyLine);
		}
		
		if (fastEnemyPositions.Count > 0){
			sw.WriteLine("FAST ENEMY");
			string fastEnemyLine = "";
			for (int i = 0; i < fastEnemyPositions.Count; i++){
				fastEnemyLine += fastEnemyPositions[i][0].ToString() + "," + fastEnemyPositions[i][1].ToString();
				if (i < fastEnemyPositions.Count - 1){
					fastEnemyLine += " ";
				}
			}
			sw.WriteLine(fastEnemyLine);
		}
		
		if (pounceEnemyPositions.Count > 0){
			sw.WriteLine("POUNCE ENEMY");
			string pounceEnemyLine = "";
			for (int i = 0; i < pounceEnemyPositions.Count; i++){
				pounceEnemyLine += pounceEnemyPositions[i][0].ToString() + "," + pounceEnemyPositions[i][1].ToString();
				if (i < pounceEnemyPositions.Count - 1){
					pounceEnemyLine += " ";
				}
			}
			sw.WriteLine(pounceEnemyLine);
		}
		
		if (rangedEnemyPositions.Count > 0){
			sw.WriteLine("RANGED ENEMY");
			string rangedEnemyLine = "";
			for (int i = 0; i < rangedEnemyPositions.Count; i++){
				rangedEnemyLine += rangedEnemyPositions[i][0].ToString() + "," + rangedEnemyPositions[i][1].ToString();
				if (i < rangedEnemyPositions.Count - 1){
					rangedEnemyLine += " ";
				}
			}
			sw.WriteLine(rangedEnemyLine);
		}
		
		if (towerPositions.Count > 0){
			sw.WriteLine("TOWER");
			string towerLine = "";
			for (int i = 0; i < towerPositions.Count; i++){
				towerLine += towerPositions[i][0].ToString() + "," + towerPositions[i][1].ToString();
				if (i < towerPositions.Count - 1){
					towerLine += " ";
				}
			}
			sw.WriteLine(towerLine);
		}
		
		if (deadZonePositions.Count > 0){
			sw.WriteLine("DEAD ZONE");
			string deadZoneLine = "";
			for (int i = 0; i < deadZonePositions.Count; i++){
				deadZoneLine += deadZonePositions[i][0].ToString() + "," + deadZonePositions[i][1].ToString();
				if (i < deadZonePositions.Count - 1){
					deadZoneLine += " ";
				}
			}
			sw.WriteLine(deadZoneLine);
		}
		
		
		sw.Close();
	}
	public void setDimensions(int x, int y){
		tiles = new List<List<int>>();
		width = x;
		height = y;
		for(int i=0;i<width;i++){
			tiles.Add (new List<int>());
			for (int j = 0; j < height; j++){
				tiles[i].Add (0);
			}
		}
	}
}