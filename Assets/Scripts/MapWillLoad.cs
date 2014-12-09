﻿using UnityEngine;
using System.Collections;

public class MapWillLoad : MonoBehaviour {
	public static int MAP_LENGTH_WIDTH = 20;
	public static int MAP_LENGTH_HEIGHT = 10;
	public static int CELL_SIZE = 40;
	public static Vector2[,] PositionMatrix= new Vector2[MAP_LENGTH_HEIGHT, MAP_LENGTH_WIDTH];
	public static string[,] MaterialMatrix = new string[MAP_LENGTH_HEIGHT, MAP_LENGTH_WIDTH]; 

	public GameObject floorPrefab;
	public GameObject playerPrefab;
	public GameObject main_cameraPrefab;
	public GameObject wallPrefab;

	int xpos = 0;
	int ypos = 0;

	void Start () {
		floorPrefab = (GameObject)Resources.Load("MapObjects/floor");
		playerPrefab = (GameObject)Resources.Load ("Charactors/Player");
		main_cameraPrefab = (GameObject)Resources.Load ("Camera/Main_Camera");
		wallPrefab = (GameObject)Resources.Load("MapObjects/wall");

		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			ypos+=CELL_SIZE;
			xpos=0;
			for(int j=0;j<MAP_LENGTH_WIDTH;j++){
				xpos+=CELL_SIZE;
				Instantiate(this.floorPrefab,new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),-1),Quaternion.identity);
				PositionMatrix[i,j] = new Vector3(xpos-(CELL_SIZE/2),ypos-(CELL_SIZE/2),0+1);
			}
		}

		for (int i=0; i<MAP_LENGTH_HEIGHT; i++) {
			for (int j=0; j<MAP_LENGTH_WIDTH; j++) {
				if(i==0 || i==MAP_LENGTH_HEIGHT-1 || j==0 || j==MAP_LENGTH_WIDTH-1){
					MaterialMatrix[i,j] = "wall";
					Instantiate(this.wallPrefab,PositionMatrix[i,j],Quaternion.identity);
				}else{
					MaterialMatrix[i,j] = "floor";
				}
			}
		}
				

				
		playerPrefab.GetComponent<PlayerBehaviour>().matrix_i = 5;//セットしてからインスタンス化
		playerPrefab.GetComponent<PlayerBehaviour>().matrix_j = 10;//セットしてからインスタンス化
		Instantiate (this.playerPrefab,PositionMatrix[5,10],Quaternion.identity);
		Instantiate (this.main_cameraPrefab,PositionMatrix[5,10],Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {

	}
}
