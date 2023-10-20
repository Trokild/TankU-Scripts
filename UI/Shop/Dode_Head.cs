using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dode_Head : MonoBehaviour {

	public ShowYourAmmo am;

	[Header ("Head Prices")]
	public int RockchildPrice;
	public int LaidaPrice;

	[Header ("")]
	public int PicidPrice;
	public int BrookesPrice;
	public int MosasaurPrice;

	[Header ("")]
	public int GigPrice;
	public int MegPrice;
	public int KilPrice;

	public AudioSource source;
	public AudioClip buy;
	public AudioClip Equipt;
	public AudioClip NoS;

	public void Standard()
	{
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		fbc.Standard_Btn ();
		nk.StandardBtn ();
		pg.Head_Level = 0;
		tu.StandartTurrentVisuall ();
		am.SwithHeadAmmo ();

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = Equipt;
		audio.Play ();
	}
	
	public void BuyRockchild()
	{
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= RockchildPrice && pg.upgRockchild == false)
		{
			pg.isBoughtTurrent [0] = 1;
			tu.RockchildTurrentVisuall ();
			//Bought() visuall particeleffect
			nk.RockchildBtn ();
			fbc.Rockchild_Btn ();
			pg.money -= RockchildPrice;
			pg.upgRockchild = true;
			pg.Head_Level = 1;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
			am.SwithHeadAmmo ();
		}

		else if(pg.upgRockchild == true)
		{
			tu.RockchildTurrentVisuall ();
			fbc.Rockchild_Btn ();
			nk.RockchildBtn ();
			pg.Head_Level = 1;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}

	}

	public void BuyLaida()
	{
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= LaidaPrice && pg.upgLaida == false)
		{
			pg.isBoughtTurrent [1] = 1;
			tu.LaidaTurrentVisuall ();
			//particle effect
			nk.LaidaBtn ();
			fbc.Laida_Btn();
			pg.money -= LaidaPrice;
			pg.upgLaida = true;
			pg.Head_Level = 2;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();

			am.SwithHeadAmmo ();
		}

		else if(pg.upgLaida == true)
		{
			tu.LaidaTurrentVisuall ();
			nk.LaidaBtn ();
			fbc.Laida_Btn();
			pg.Head_Level = 2;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
	}

	public void BuyPicid()
	{
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= PicidPrice && pg.upgPicid == false)
		{
			pg.isBoughtTurrent [2] = 1;
			tu.PicidTurrentVisuall ();
			nk.PicidBtn ();
			fbc.Picid_Btn ();
			pg.money -= PicidPrice;
			pg.upgPicid = true;
			pg.Head_Level = 3;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
			am.SwithHeadAmmo ();
		}

		else if(pg.upgPicid == true)
		{
			tu.PicidTurrentVisuall ();
			nk.PicidBtn ();
			fbc.Picid_Btn ();
			pg.Head_Level = 3;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
	}

	public void BuyBrookes()
	{	
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= BrookesPrice && pg.upgBrookes == false)
		{
			pg.isBoughtTurrent [3] = 1;
			tu.MammutTurrentVisuall ();
			nk.BrookesBtn ();
			fbc.Brookes_Btn ();
			pg.money -= BrookesPrice;
			pg.upgBrookes = true;
			pg.Head_Level = 4;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
			am.SwithHeadAmmo ();
		}

		else if(pg.upgBrookes == true)
		{
			tu.MammutTurrentVisuall ();
			nk.BrookesBtn ();
			fbc.Brookes_Btn ();
			pg.Head_Level = 4;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
	}

	public void BuyMosasaur ()
	{	
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= MosasaurPrice && pg.upgMosasaur == false)
		{
			pg.isBoughtTurrent [4] = 1;
			tu.MinigunTurrentVisuall ();
			nk.MosasaurBtn ();
			fbc.Mosasaur_Btn ();
			pg.money -= MosasaurPrice;
			pg.upgMosasaur = true;
			pg.Head_Level = 5;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
			am.SwithHeadAmmo ();
		}

		else if(pg.upgMosasaur == true)
		{
			tu.MinigunTurrentVisuall ();
			nk.MosasaurBtn ();
			fbc.Mosasaur_Btn ();
			pg.Head_Level = 5;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
	}

	public void BuyGig ()
	{	
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= GigPrice && pg.upgGig == false)
		{
			pg.isBoughtTurrent [5] = 1;
			tu.GigTurrentVisuall ();
			nk.GigBtn ();
			fbc.Gig_Btn ();
			pg.money -= GigPrice;
			pg.upgGig = true;
			pg.Head_Level = 6;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
			am.SwithHeadAmmo ();
		}

		else if(pg.upgGig == true)
		{
			tu.GigTurrentVisuall ();
			nk.GigBtn ();
			fbc.Gig_Btn ();
			pg.Head_Level = 6;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
	}

	public void BuyMeg ()
	{	
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= MegPrice && pg.upgMeg == false)
		{
			pg.isBoughtTurrent [6] = 1;
			tu.MegTurrentVisuall ();
			fbc.Meg_Btn ();
			nk.MegBtn ();
			pg.money -= MegPrice;
			pg.upgMeg = true;
			pg.Head_Level = 7;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
			am.SwithHeadAmmo ();
		}

		else if(pg.upgMeg == true)
		{
			tu.MegTurrentVisuall ();
			fbc.Meg_Btn ();
			nk.MegBtn ();
			pg.Head_Level = 7;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
	}

	public void BuyKil ()
	{	
		GameObject st = GameObject.Find ("STANDAR_Visuall");
		ShowYourTurrent tu = st.GetComponent<ShowYourTurrent> ();

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		GameObject to = GameObject.Find ("Neck");
		Neck nk = to.GetComponent<Neck> ();

		GameObject bt = GameObject.Find ("Fire_BTN");
		Fire_BTN_Changer fbc = bt.GetComponent<Fire_BTN_Changer> ();

		if(pg.money >= KilPrice && pg.upgKil == false)
		{
			pg.isBoughtTurrent [7] = 1;
			tu.KilTurrentVisuall ();
			fbc.Kill_Btn ();
			nk.KillBtn ();
			pg.money -= KilPrice;
			pg.upgKil = true;
			pg.Head_Level = 8;

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = buy;
			audio.Play ();
			am.SwithHeadAmmo ();
		}

		else if(pg.upgKil == true)
		{
			tu.KilTurrentVisuall ();
			fbc.Kill_Btn ();
			nk.KillBtn ();
			pg.Head_Level = 8;
			am.SwithHeadAmmo ();

			AudioSource audio = GetComponent<AudioSource> ();
			audio.clip = Equipt;
			audio.Play ();
		}
	}

	void SoundEquipt()
	{
		source.PlayOneShot (Equipt);
	}
}
