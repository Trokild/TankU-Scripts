using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[Header ("Levels Cleared")]
	public float howMany;
	private float enemysToKill;
	public float enemyDown;
	public int enemyKilledReward;
	private bool rawardClaimed = false;

	[Space]
	public GameObject BannorMove;
	public GameObject ButtonMove;
	public Animator MedalsAnim;
	public Text LevelCompleteTxt;

	public string LevelName;
	public int WhatLevel;
	public bool isBoss = false;

	[Header ("Audio")]
	public audio_Manager Musick;
	public int whatTrack;
	public bool ChangeMusick;
	public bool isRacer;

	public AudioSource source;
	//public AudioClip questComplete;

	[Header ("Death")]

	public bool endGame;
	public float restartDelay;
	public GameObject deathUI;
	public GameObject NextLvlUI;
	public GameObject Gold_Reward;

	public Play PG;
	public bool isShop = false;


	void Start () {
		enemyDown = 0;
		enemysToKill = howMany;

		if (GameObject.Find ("Music_Manager") != null) {
			Musick = GameObject.Find ("Music_Manager").GetComponent<audio_Manager> ();

			if (ChangeMusick == true) 
			{
				Musick.SwitchTrack (whatTrack);
				Musick.Switch_Loop_track ();

			}

			if (isRacer == true) 
			{
				Musick.musicCanPlay = false;
			}

			if (isRacer == false && ChangeMusick == false && Musick.musicmuted == false) 
			{
				if (Musick.currentTrack != whatTrack) 
				{
					Musick.SwitchTrack (whatTrack);
				}

				if (Musick.musicCanPlay == false) 
				{
					Debug.Log ("OnMusic", gameObject);
					Musick.musicCanPlay = true;
				}
			}
		}

		if (deathUI.activeSelf == false) 
		{
			deathUI.SetActive (true);
		}

		if (Gold_Reward == null) 
		{
			Gold_Reward = GameObject.Find ("Gold_Reward");
		}

		if (PG == null) 
		{
			PG = GameObject.Find ("play_game").GetComponent<Play> ();
		}

		if (isShop == true) {
			Invoke ("Toti", 0.01f);
			Musick.canChangeMus = false;
		} else if (isShop == false) {
			Musick.canChangeMus = true;
		}

		InvokeRepeating ("Enemy2KillUpdate", 1, 1);
	}

	void Toti()
	{
		Debug.Log ("isShop", gameObject);
		int ptf = GameObject.Find ("play_game").GetComponent<Play> ().firstTime;
		Debug.Log(ptf);
		if (PG.firstTime >= 1) 
		{
			Debug.Log ("Totri", gameObject);
			GameObject Totri = GameObject.Find ("Tutori");
			Destroy (Totri);
		}
	}

	public void Enemy2KillUpdate()
	{
		if (rawardClaimed == false && enemyDown >= enemysToKill) 
		{
			Debug.Log ("this gets called");
			Invoke ("QuestComplete", 1);
			rawardClaimed = true;
		}
	}

	public void LevelComplete()
	{
		if (isBoss == false) {
			LevelCompleteTxt.text = "" + LevelName + " " + (WhatLevel + 1) + " Completed"; 
			if (PG.LevelOneProgress <= WhatLevel) {
				PG.LevelOneProgress += 1;
			}

			if (enemyDown >= howMany) {
				PG.Medals [WhatLevel] = 3;
			}

			if (enemyDown >= howMany / 2 && PG.Medals [WhatLevel] < 2) {
				PG.Medals [WhatLevel] = 2;
			} else if (PG.Medals [WhatLevel] < 1) {
				PG.Medals [WhatLevel] = 1;
			}
		} else if (isBoss == true) 
		{
			Debug.Log ("LevelComplete", gameObject);

			LevelCompleteTxt.text = "" + LevelName + " " + " Is defeated"; 
			if (PG.LevelOneProgress <= WhatLevel) {
				PG.LevelOneProgress += 1;
			}

			Health ht;
			ht = GameObject.Find ("Body").GetComponent<Health> ();

			if (ht.cur_Health <= (ht.max_Health * 0.25f)) 
			{
				PG.Medals [WhatLevel] = 1;
				Debug.Log ("LevelCompleteBronze", gameObject);
			}

			if (ht.cur_Health > (ht.max_Health * 0.25f) && ht.cur_Health <= (ht.max_Health * 0.75f)) 
			{
				PG.Medals [WhatLevel] = 2;
				Debug.Log ("LevelCompleteSilver", gameObject);
			}

			if (ht.cur_Health > (ht.max_Health * 0.75f)) 
			{
				PG.Medals [WhatLevel] = 3;
				Debug.Log ("LevelCompleteGold", gameObject);
			}

		}
		PG.Save ();
		Nextlvl ();
	}

	void QuestComplete()
	{
		GameObject.Find ("play_game").GetComponent<Play>().money += enemyKilledReward;
		Gold_Reward.SetActive (true);
		Debug.Log ("quest complete");
	}
	
	public void Restart()
	{
		if (endGame == false) 
		{
			endGame = true;

			GameObject.Find ("play_game").GetComponent<Play>().Deaths += 1;
			deathUI.GetComponent<Animator> ().SetInteger("State", 2);

			Debug.Log ("restart", gameObject);
			Invoke ("loadScene", restartDelay);
			deathUI.SetActive (true);
		}
	}

	public void Nextlvl()
	{
		//Invoke ("loadnextLevel", 2);
		NextLvlUI.GetComponent<Animator> ().SetInteger("Fade", 1);
		if (isBoss == false) {
			StartCoroutine (CompleteLevel ());
		} else if (isBoss == true) 
		{
			StartCoroutine (CompleteBoss ());
		}
	}

	public void Backlvl()
	{
		Invoke ("LevelCleared", 2);
		deathUI.GetComponent<Animator> ().SetInteger("State", 1);
	}

	void loadScene ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void loadnextLevel()
	{
		source.Play ();
		deathUI.GetComponent<Animator> ().SetInteger("State", 1);
		Invoke ("NextScene", 1);
		PG.Save ();
	}

	void NextScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	void MenuScene()
	{
		Application.LoadLevel(1);
	}

	public void ChangeToScene () {
		source.Play ();
		deathUI.GetComponent<Animator> ().SetInteger("Fade", 3);
		Invoke ("MenuScene", 1);
		PG.Save ();
	}

	private IEnumerator CompleteLevel()
	{
		yield return new WaitForSeconds (1f);

		BannorMove.SetActive (true);
		ButtonMove.SetActive (true);
		if (enemyDown >= howMany) 
		{
			Debug.Log ("Gold", gameObject);
			MedalsAnim.SetInteger ("Medal", 2);
		}

		if(enemyDown >= howMany / 2 && enemyDown < howMany)
		{
			Debug.Log ("Silver", gameObject);
			MedalsAnim.SetInteger ("Medal", 1);
		} 

		yield return new WaitForSeconds (1f);
		MedalsAnim.SetTrigger ("Reward");

		yield return new WaitForSeconds (1f);
		GameObject Tank;
		Tank = GameObject.Find ("Body");
		GameObject.Find ("Range").SetActive (false);
		GameObject.Find ("Range_Long").SetActive (false);
		Tank.GetComponent<SpillerBeta> ().enabled = false;
		GameObject.Find ("Main Camera").GetComponent<Camera2DFollow>().isEdndLvl = true;

		yield return new WaitForSeconds (10f);
		GameObject.Find ("Main Camera").GetComponent<Camera2DFollow>().EndLvlCamSpeed = 0;
		//loadnextLevel ();
	}

	private IEnumerator CompleteBoss()
	{
		yield return new WaitForSeconds (1f);

		BannorMove.SetActive (true);
		ButtonMove.SetActive (true);

		Health ht;
		ht = GameObject.Find ("Body").GetComponent<Health> ();

		if (ht.cur_Health > (ht.max_Health * 0.75f)) 
		{
			Debug.Log ("Gold", gameObject);
			MedalsAnim.SetInteger ("Medal", 2);
		}

		if(ht.cur_Health > (ht.max_Health * 0.25f) && ht.cur_Health <= (ht.max_Health * 0.75f))
		{
			Debug.Log ("Silver", gameObject);
			MedalsAnim.SetInteger ("Medal", 1);
		} 

		yield return new WaitForSeconds (1f);
		MedalsAnim.SetTrigger ("Reward");

		yield return new WaitForSeconds (1f);
		GameObject Tank;
		Tank = GameObject.Find ("Body");
		GameObject.Find ("Range").SetActive (false);
		GameObject.Find ("Range_Long").SetActive (false);
		Tank.GetComponent<SpillerBeta> ().enabled = false;
		GameObject.Find ("Main Camera").GetComponent<Camera2DFollow>().isEdndLvl = true;

		yield return new WaitForSeconds (10f);
		GameObject.Find ("Main Camera").GetComponent<Camera2DFollow>().EndLvlCamSpeed = 0;
		//loadnextLevel ();
	}
}
