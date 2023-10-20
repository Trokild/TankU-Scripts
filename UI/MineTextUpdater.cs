using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineTextUpdater : MonoBehaviour {

	public Play pg;
	void Start () {
		
		pg = GameObject.Find ("play_game").GetComponent<Play>();
		InvokeRepeating ("UpdateMineText", 0f, 0.5f);
	}

	// Update is called once per frame
	void UpdateMineText () 
	{
			GetComponent<Text> ().text = ":" + pg.NumberOfMines + ":";

	}
}
