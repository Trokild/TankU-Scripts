using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dode : MonoBehaviour {



	[Header ("Dialog Menu")]
	public GameObject DialogDode;
	public GameObject BoxDode;
	public GameObject FaceDode;

	public bool canOpenMenu;
	public bool canTalk;

	public GameObject HeadShop;
	public Animator fadeblack;

	PolygonCollider2D Cold;
	void Start()
	{
		Cold = GetComponent<PolygonCollider2D> ();
		Invoke ("EnableColi", 0.01f);

	}

	void EnableColi()
	{
		if (GameObject.Find ("play_game").GetComponent<Play> ().firstTime >= 1) {
			Cold.enabled = true;
			Debug.Log ("Cold");
		}
	}

	void OnTriggerEnter2D(Collider2D colDer )
	{
		if (colDer.gameObject.tag == "Player" && canTalk == true) 
		{

			DialogDode.SetActive (true);
			BoxDode.SetActive (true);
			FaceDode.SetActive (true);
			canOpenMenu = true;

			DialogDode.GetComponent<AnimatedDialog> ().ResetArray ();
		}

	}

	void OnTriggerExit2D(Collider2D colDer)
	{
		if (colDer.gameObject.tag == "Player") 
		{
			DialogDode.SetActive (false);
			BoxDode.SetActive (false);
			FaceDode.SetActive (false);

			HeadShop.SetActive (false);
			fadeblack.SetInteger ("Fade", 2);

			canOpenMenu = false;

			DialogDode.GetComponent<AnimatedDialog> ().ResetArray ();
		}
	}

	public void EnterMenu ()
	{
		//DialogDode.GetComponent<AnimatedDialog> ().nextTalk ();
		DialogDode.GetComponent<AnimatedDialog> ().turnOn = false;
		HeadShop.SetActive (true);
		FaceDode.SetActive (false);
		fadeblack.SetInteger ("Fade", 1);
		GameObject.Find ("Slider").GetComponent<GasHandler> ().sliderGas.value = 1;
	}

	public void LeaveMenu ()
	{

		DialogDode.SetActive (true);
		DialogDode.GetComponent<AnimatedDialog> ().nextTalk ();
		FaceDode.SetActive (true);
		BoxDode.SetActive (true);
		HeadShop.SetActive (false);
		canOpenMenu = true;
		FaceDode.SetActive (true);

		fadeblack.SetInteger ("Fade", 2);
	}

	public void SetStandard()
	{
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		nk.StandardBtn ();
		pg.Head_Level = 0;

	}
}
