using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCostume : MonoBehaviour {

	public Toggle isOnMusic;
	public Toggle isOnSound;
	public GameObject fader;
	public GameObject menuPaused;
	public GameObject areYouSureExit;
	public GameObject areYouSureBase;
	private bool isPaused = false;
	public bool isSoundMuted = false;
	public bool isMusicMuted = false;
	public audio_Manager Musikk;

	public bool StartScene = false;
	public float timeStart;
	public Animator Panel;

	void Start()
	{
		if (StartScene == true) 
		{
			Invoke ("Fade", 4);
			Invoke ("SartSceneShop", timeStart);
		}else
			
		Musikk = GameObject.Find ("Music_Manager").GetComponent<audio_Manager> ();
		if(Musikk.soundmuted == true)
		{
			isSoundMuted = true;
			isOnSound.isOn = true;
			//MuteSound ();
		}

		if(Musikk.musicmuted == true)
		{
			isMusicMuted = true;
			isOnMusic.isOn = true;
			//MuteMusic ();
		}
	}
	void Fade()
	{
		Panel.SetInteger ("State", 2);
	}

	void SartSceneShop()
	{
		Application.LoadLevel(1);
	}
		
	public void ChangeToScene (int sceneToChangeTo) {
		if (AudioListener.pause == true) {
			AudioListener.pause = false;
		}
		Time.timeScale = 1;
		Application.LoadLevel(sceneToChangeTo);
	}

	public void AreYouExit()
	{
		menuPaused.SetActive (false);
		areYouSureExit.SetActive (true);
	}

	public void AreYouBase()
	{
		menuPaused.SetActive (false);
		areYouSureBase.SetActive (true);
	}

	public void Nope()
	{
		menuPaused.SetActive (true);
		areYouSureBase.SetActive (false);
		areYouSureExit.SetActive (false);
	}

	public void Exit()
	{
		GameObject.Find ("play_game").GetComponent<Play> ().Save ();
		Application.Quit();
	}
		

	public void MenuPause()
	{
		if (isPaused == false) {
			gameObject.GetComponentInChildren<Text>().text = "Resume";
			menuPaused.SetActive (true);
			fader.SetActive (true);
			Time.timeScale = 0;
			isPaused = true;
			AudioListener.pause = true;
				
		} else {
			gameObject.GetComponentInChildren<Text>().text = "Menu";
			fader.SetActive (false);
			menuPaused.SetActive (false);
			Time.timeScale = 1;
			isPaused = false;
			AudioListener.pause = false;

			areYouSureBase.SetActive (false);
			areYouSureExit.SetActive (false);
		}
	}

	public void MuteSound()
	{
		if (isPaused == false)
			return;
		Debug.Log ("MuteBtn");
		if (isSoundMuted == false) {
			menuPaused.SetActive (true);
			AudioListener.volume = 0f;
			isSoundMuted = true;
			Musikk.soundmuted = true;
		} else {
			AudioListener.volume = 1f;
			isSoundMuted = false;
			Musikk.soundmuted = false;
		}	
	}

	public void MuteMusic()
	{
		if (isPaused == false)
			return;
		Debug.Log ("MutMusicBtn");
		if (isMusicMuted == false) {
			Musikk.musicCanPlay = false;
			Musikk.musicmuted = true;
			isMusicMuted = true;
		} else {
			Musikk.musicCanPlay = true;
			Musikk.musicmuted = false;
			isMusicMuted = false;
		}	
	}
}
