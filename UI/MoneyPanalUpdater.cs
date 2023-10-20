using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MoneyPanalUpdater : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		GameObject go = GameObject.Find ("play_game");

		if(go ==null)
			{
			Debug.LogError ("Can't find object named Play_Game");
			this.enabled = false;
			return;
			}

		Play pg = go.GetComponent<Play> ();

		GetComponent<Text> ().text = "" + pg.money;
	 
	}
}
