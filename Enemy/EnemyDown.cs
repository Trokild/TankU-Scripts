using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class EnemyDown : MonoBehaviour {

	public int SizeFont;

	// Update is called once per frame
	void Update () 
	{
		GameObject go = GameObject.Find ("GameManager");

		if(go ==null)
		{
			Debug.LogError ("Can't find object named Play_Game");
			this.enabled = false;
			return;
		}

		GameManager pg = go.GetComponent<GameManager> ();


		if (pg.enemyDown < pg.howMany) {
			GetComponent<Text> ().text = "" + pg.enemyDown + "/" + pg.howMany;
		} else if (pg.enemyDown >= pg.howMany) 
		{
			GetComponent<Text> ().text = "Complete";
			GetComponent<Text> ().fontSize = SizeFont;
		}

	}
}
