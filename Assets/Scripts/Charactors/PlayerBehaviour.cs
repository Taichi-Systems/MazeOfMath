﻿using UnityEngine;
using System.Collections;

public class PlayerBehaviour : CharactorBehaviour {
	public static int Player_i,Player_j;
	// Use this for initialization
	void Start () {
		base.Start ();
		self_name = "Player";
		Player_i = matrix_i;
		Player_j = matrix_j;

	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		Self_position = transform.position;
		if (move_state == false) {
			if (Input.GetKeyDown (KeyCode.RightArrow) && ( MapWillLoad.MaterialMatrix[matrix_i,matrix_j+1] == "None" || MapWillLoad.MaterialMatrix[matrix_i,matrix_j+1] == "Stairs") ) {
				//画像移動処理
				Interfaces.turn_add();
				right_move();
			} else if (Input.GetKeyDown (KeyCode.LeftArrow) && ( MapWillLoad.MaterialMatrix[matrix_i,matrix_j-1] == "None" || MapWillLoad.MaterialMatrix[matrix_i,matrix_j-1] == "Stairs")) {
				Interfaces.turn_add();
				left_move();
			} else if (Input.GetKeyDown (KeyCode.UpArrow) && ( MapWillLoad.MaterialMatrix[matrix_i+1,matrix_j] == "None" || MapWillLoad.MaterialMatrix[matrix_i+1,matrix_j] == "Stairs")) {
				Interfaces.turn_add();
				up_move();
			} else if (Input.GetKeyDown (KeyCode.DownArrow) && ( MapWillLoad.MaterialMatrix[matrix_i-1,matrix_j] == "None" || MapWillLoad.MaterialMatrix[matrix_i-1,matrix_j] == "Stairs")) {;
				Interfaces.turn_add();
				down_move();
			}
		}
		Player_i = matrix_i;
		Player_j = matrix_j;
		//transform.position = Ppos;
	}

}
