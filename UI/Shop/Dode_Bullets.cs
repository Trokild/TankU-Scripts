using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dode_Bullets : MonoBehaviour {

	[Header ("Bullet Prices")]
	public int SpearBulletPrice;
	public int BigBulletPrice;
	public int BigerBulletPrice;
	[Header ("")]
	public int OrangePrice;
	public int RedPrice;
	public int GodPrice;
	[Header ("")]
	public int MEMEPrice;
	public int MissilePrice;
	public int PovPrice;

	[Header ("Head Refrenses")]
	public GameObject Stand;
	public GameObject Rock;
	public GameObject Lind;

	[Header ("")]
	public GameObject Picid;
	public GameObject Brookes;
	public GameObject Mosasaur;

	[Header ("")]
	public GameObject Gig;
	public GameObject Meg;
	public GameObject Kil;

	[Header ("Audio")]
	public AudioSource source;
	public AudioClip buy;
	public AudioClip Equipt;
	public AudioClip NoS;


	public void EquiptStandBullet()
	{
			
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();
			
		if (pg.Head_Level < 3) 
		{
			Rock.GetComponent<New_Head> ().Bullet = 0;
			Stand.GetComponent<New_Head> ().Bullet = 0;
			Lind.GetComponent<New_Head> ().Bullet = 0;
			pg.Vullet_Level = 0;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}else 
		{
			Debug.Log ("NostbB");
			source.PlayOneShot (NoS, 0.5f);
		}

	}

	public void BuySpear()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level < 3) {
			if (pg.money >= SpearBulletPrice && pg.Spear == false) {
				pg.isBoughtBullet [0] = 1;
				Rock.GetComponent<New_Head> ().Bullet = 1;
				Stand.GetComponent<New_Head> ().Bullet = 1;
				Lind.GetComponent<New_Head> ().Bullet = 1;
				pg.Vullet_Level = 1;

				pg.money -= SpearBulletPrice;
				pg.Spear = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();

			} else if (pg.Spear == true) {
				Rock.GetComponent<New_Head> ().Bullet = 1;
				Stand.GetComponent<New_Head> ().Bullet = 1;
				Lind.GetComponent<New_Head> ().Bullet = 1;
				pg.Vullet_Level = 1;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				Debug.Log ("NoBuyBig");
				source.PlayOneShot (NoS, 0.5f);
			}
		} else 
		{
			Debug.Log ("NoBuySpear");
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyBigBullet()
	{	
			GameObject go = GameObject.Find ("play_game");
			Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level < 3 && pg.Head_Level > 1) {
			
			if (pg.money >= BigBulletPrice && pg.Big == false) {
				pg.isBoughtBullet [1] = 1;
				Lind.GetComponent<New_Head> ().Bullet = 2;
				pg.Vullet_Level = 2;

				pg.money -= BigBulletPrice;
				pg.Big = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();


			} else if (pg.Big == true) {
				Lind.GetComponent<New_Head> ().Bullet = 2;
				pg.Vullet_Level = 2;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		} else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyBigerBullet()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level < 3 && pg.Head_Level > 1) {

		if(pg.money >= BigerBulletPrice && pg.Bigger == false)
		{
			pg.isBoughtBullet [2] = 1;
			Rock.GetComponent<New_Head> ().Bullet = 3;
			Stand.GetComponent<New_Head> ().Bullet = 3;
			Lind.GetComponent<New_Head> ().Bullet = 3;
			pg.Vullet_Level = 3;

			pg.money -= BigerBulletPrice;
			pg.Bigger = true;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();

		}

		else if(pg.Bigger == true)
		{
			Rock.GetComponent<New_Head> ().Bullet = 3;
			Stand.GetComponent<New_Head> ().Bullet = 3;
			Lind.GetComponent<New_Head> ().Bullet = 3;
			pg.Vullet_Level = 3;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		} else 
			{
			source.PlayOneShot (NoS, 0.5f);
			}
	}

	public void EquiptStandYellow()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level >= 3 && pg.Head_Level < 6) 
		{ 
			Picid.GetComponent<New_Burst> ().Bullet = 0;
			Brookes.GetComponent<New_Burst> ().Bullet = 0;
			Mosasaur.GetComponent<New_Burst> ().Bullet = 0;
			pg.Burst_Level = 0;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyOrange()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();
		if (pg.Head_Level >= 3 && pg.Head_Level < 6) { 

			if (pg.money >= OrangePrice && pg.Orange == false) {
				pg.isBoughtBullet [3] = 1;
				Picid.GetComponent<New_Burst> ().Bullet = 1;
				Brookes.GetComponent<New_Burst> ().Bullet = 1;
				Mosasaur.GetComponent<New_Burst> ().Bullet = 1;
				pg.Burst_Level = 1;

				pg.money -= OrangePrice;
				pg.Orange = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();

			} else if (pg.Orange == true) {
				Picid.GetComponent<New_Burst> ().Bullet = 1;
				Brookes.GetComponent<New_Burst> ().Bullet = 1;
				Mosasaur.GetComponent<New_Burst> ().Bullet = 1;
				pg.Burst_Level = 1;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		}else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyRed()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level >= 4 && pg.Head_Level < 6) { 

			if (pg.money >= RedPrice && pg.Red == false) {
				pg.isBoughtBullet [4] = 1;
				Picid.GetComponent<New_Burst> ().Bullet = 2;
				Brookes.GetComponent<New_Burst> ().Bullet = 2;
				Mosasaur.GetComponent<New_Burst> ().Bullet = 2;
				pg.Burst_Level = 2;

				pg.money -= RedPrice;
				pg.Red = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();

			} else if (pg.Red == true) {
				Picid.GetComponent<New_Burst> ().Bullet = 2;
				Brookes.GetComponent<New_Burst> ().Bullet = 2;
				Mosasaur.GetComponent<New_Burst> ().Bullet = 2;
				pg.Burst_Level = 2;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		}else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyGod()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level >= 4 && pg.Head_Level < 6) { 

			if (pg.money >= GodPrice && pg.God == false) {
				pg.isBoughtBullet [5] = 1;
				Picid.GetComponent<New_Burst> ().Bullet = 3;
				Brookes.GetComponent<New_Burst> ().Bullet = 3;
				Mosasaur.GetComponent<New_Burst> ().Bullet = 3;
				pg.Burst_Level = 3;

				pg.money -= GodPrice;
				pg.God = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();

			} else if (pg.God == true) {
				Picid.GetComponent<New_Burst> ().Bullet = 3;
				Brookes.GetComponent<New_Burst> ().Bullet = 3;
				Mosasaur.GetComponent<New_Burst> ().Bullet = 3;
				pg.Burst_Level = 3;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		}else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void EquiptStandMissile()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();
		if (pg.Head_Level > 5) { 
			Gig.GetComponent<New_Missile> ().Bullet = 0;
			Meg.GetComponent<New_Missile> ().Bullet = 0;
			Kil.GetComponent<New_Missile> ().Bullet = 0;
			pg.Missile_Level = 0;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
		else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyMEME()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();
		if (pg.Head_Level > 5) { 

			if (pg.money >= MEMEPrice && pg.MEME == false) {
				pg.isBoughtBullet [6] = 1;
				Gig.GetComponent<New_Missile> ().Bullet = 1;
				Meg.GetComponent<New_Missile> ().Bullet = 1;
				Kil.GetComponent<New_Missile> ().Bullet = 1;
				pg.Missile_Level = 1;

				pg.money -= MEMEPrice;
				pg.MEME = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();

			} else if (pg.MEME == true) {
				Gig.GetComponent<New_Missile> ().Bullet = 1;
				Meg.GetComponent<New_Missile> ().Bullet = 1;
				Kil.GetComponent<New_Missile> ().Bullet = 1;
				pg.Missile_Level = 1;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		}else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyMissile()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level > 6) { 
			
			if (pg.money >= MissilePrice && pg.Missile == false) {
				pg.isBoughtBullet [7] = 1;
				Gig.GetComponent<New_Missile> ().Bullet = 2;
				Meg.GetComponent<New_Missile> ().Bullet = 2;
				Kil.GetComponent<New_Missile> ().Bullet = 2;
				pg.Missile_Level = 2;

				pg.money -= MissilePrice;
				pg.Missile = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();

				Invoke ("SoundEquipt", 1f);

			} else if (pg.Missile == true) {
				Gig.GetComponent<New_Missile> ().Bullet = 2;
				Meg.GetComponent<New_Missile> ().Bullet = 2;
				Kil.GetComponent<New_Missile> ().Bullet = 2;
				pg.Missile_Level = 2;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		}else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}

	public void BuyPov()
	{	
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.Head_Level > 6) { 

			if (pg.money >= PovPrice && pg.POV == false) {
				pg.isBoughtBullet [8] = 1;
				Gig.GetComponent<New_Missile> ().Bullet = 3;
				Meg.GetComponent<New_Missile> ().Bullet = 3;
				Kil.GetComponent<New_Missile> ().Bullet = 3;
				pg.Missile_Level = 3;

				pg.money -= PovPrice;
				pg.POV = true;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = buy;
				audio.Play ();

			} else if (pg.POV == true) {
				Gig.GetComponent<New_Missile> ().Bullet = 3;
				Meg.GetComponent<New_Missile> ().Bullet = 3;
				Kil.GetComponent<New_Missile> ().Bullet = 3;
				pg.Missile_Level = 3;

				AudioSource audio = GetComponent<AudioSource> ();
				audio.clip = Equipt;
				audio.Play ();
			}else 
			{
				source.PlayOneShot (NoS, 0.5f);
			}
		}else 
		{
			source.PlayOneShot (NoS, 0.5f);
		}
	}
	void SoundEquipt()
	{
		source.PlayOneShot (Equipt);
	}
}
