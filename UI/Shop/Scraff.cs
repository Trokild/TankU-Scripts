using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scraff : MonoBehaviour {

	public int nitroPrice;
	public int TankLifePrice;
	public int TankLifeUPGPrice;
	public int HealthPrice;
	public int MinePrice;
	public int DropperPrice;
	public int RamPrice;
	public float upgRateHealth;
	public GameObject DialogScraff;
	public GameObject BoxScraff;
	public GameObject FaceScraff;
	public bool canOpenMenu;
	public bool canTalk;
	public GameObject BodyShop;
	public Animator fadeblack;
	public AudioSource source;
	public AudioClip buy;
	public AudioClip Equipt;
	BoxCollider2D Cold;

	void Start()
	{

		Cold = GetComponent<BoxCollider2D> ();
		Invoke ("EnableColi", 0.01f);
	}

	void EnableColi()
	{
		if (GameObject.Find ("play_game").GetComponent<Play> ().firstTime >= 1) {
			Cold.enabled = true;
			Debug.Log ("Cold");
		}
	}

	public void EnterMenuBtn()
	{
		if (canOpenMenu == true) 
		{
			EnterMenu ();
			canOpenMenu = false;
			GameObject.Find ("Body").GetComponent<SpillerBeta> ().BottunRealease ();
			GameObject.Find ("Slider").GetComponent<GasHandler> ().sliderGas.value = 1;
		}
	}
	
	void OnTriggerEnter2D(Collider2D colDer)
	{
		if (colDer.gameObject.tag == "Player" && canTalk == true) 
		{

			DialogScraff.SetActive (true);
			BoxScraff.SetActive (true);
			FaceScraff.SetActive (true);
			canOpenMenu = true;

			DialogScraff.GetComponent<AnimatedDialog> ().ResetArray ();
		}

	}

	void OnTriggerExit2D(Collider2D colDer)
	{
		if (colDer.gameObject.tag == "Player") 
		{
			DialogScraff.SetActive (false);
			BoxScraff.SetActive (false);
			FaceScraff.SetActive (false);

			BodyShop.SetActive (false);
			fadeblack.SetInteger ("Fade", 2);

			canOpenMenu = false;

			DialogScraff.GetComponent<AnimatedDialog> ().ResetArray ();
		}
	}

	public void EnterMenu ()
	{
		DialogScraff.GetComponent<AnimatedDialog> ().turnOn = false;
		BodyShop.SetActive (true);
		FaceScraff.SetActive (false);
		fadeblack.SetInteger ("Fade", 1);
		GameObject.Find ("Slider").GetComponent<GasHandler> ().sliderGas.value = 1;
	}

	public void LeaveMenu ()
	{
		
		DialogScraff.SetActive (true);
		FaceScraff.SetActive (true);
		DialogScraff.GetComponent<AnimatedDialog> ().nextTalk ();
		BoxScraff.SetActive (true);
		BodyShop.SetActive (false);
		canOpenMenu = true;
		fadeblack.SetInteger ("Fade", 2);
	}

	public void BuyNirto()
	{
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Body");
		SpillerBeta sb = to.GetComponent<SpillerBeta> ();

		if (pg.money >= nitroPrice && pg.upgNitro == false )
		{
			sb.nirtro = true;

			pg.isBoughtBody [1] = 1;
			pg.money -= nitroPrice;
			pg.upgNitro = true;

			if (pg.upgArmor == true) 
			{
				sb.changeBodyNitArm();
				
			} else 
			{
				sb.changeBodyNit();
			}

			GameObject.Find ("ShowYourBody5").GetComponent<ShowYourBody> ().ShowNitro ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();

		}
	}

	public void HealthUPG ()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Body");
		SpillerBeta sb = to.GetComponent<SpillerBeta> ();
		Health li = to.GetComponent<Health> ();

		if (pg.money >= HealthPrice && pg.upgArmor == false) 
		{
			pg.isBoughtBody [0] = 1;
			pg.money -= HealthPrice;
			pg.upgHealth += upgRateHealth;
			pg.upgArmor = true;
			li.max_Health += upgRateHealth; 
			li.max_Health2 += upgRateHealth; 
			li.cur_Health += upgRateHealth; 
			li.cur_Health2 += upgRateHealth;

			if (pg.upgNitro == true) 
			{
				sb.changeBodyNitArm ();

			} else 
			{
				sb.changeBodyArm ();
			}

			GameObject.Find ("ShowYourBody5").GetComponent<ShowYourBody>().ShowArmor();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
		}
	}

	public void MineUPG ()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.money >= MinePrice && pg.NumberOfMines < 20 && pg.upgDropper == true) 
		{
			pg.money -= MinePrice;
			pg.NumberOfMines += 1;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
		}
	}

	public void DropperUPG ()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Body");
		SpillerBeta sb = to.GetComponent<SpillerBeta> ();

		if (pg.money >= DropperPrice && pg.upgDropper == false) 
		{
			pg.isBoughtBody[3] = 1;
			pg.money -= DropperPrice;
			pg.upgDropper = true;

			pg.NumberOfMines += 10;
			sb.InstallDropper ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();

			GameObject.Find ("ShowYourBody5").GetComponent<ShowYourBody> ().ShowDropper ();
		}
	}

	public void BuyRam ()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Body");
		SpillerBeta sb = to.GetComponent<SpillerBeta> ();

		if (pg.money >= RamPrice && pg.upgRam == false) 
		{
			pg.isBoughtBody [2] = 1;
			pg.money -= RamPrice;
			pg.upgRam = true;

			sb.InstallRam ();

			GameObject.Find ("ShowYourBody5").GetComponent<ShowYourBody> ().ShowRam ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
		}
	}

	public void talkNit()
	{
		DialogScraff.SetActive (true);
		DialogScraff.GetComponent<AnimatedDialog> ().BuyLine3 ();
		BoxScraff.SetActive (true);
	}

	public void talkArmor()
	{
		DialogScraff.SetActive (true);
		DialogScraff.GetComponent<AnimatedDialog> ().BuyLine4 ();
		BoxScraff.SetActive (true);
	}

	public void talkSto()
	{
		DialogScraff.SetActive (true);
		DialogScraff.GetComponent<AnimatedDialog> ().BuyLine5 ();
		BoxScraff.SetActive (true);
	}

	public void talkDrop()
	{
		DialogScraff.SetActive (true);
		DialogScraff.GetComponent<AnimatedDialog> ().BuyLine6 ();
		BoxScraff.SetActive (true);
	}

	public void talkRam()
	{
		DialogScraff.SetActive (true);
		DialogScraff.GetComponent<AnimatedDialog> ().BuyLine7 ();
		BoxScraff.SetActive (true);
	}

	void SoundEquipt()
	{
		source.PlayOneShot (Equipt);
	}
}
