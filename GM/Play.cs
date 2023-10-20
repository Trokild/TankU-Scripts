using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play : MonoBehaviour {
	public GameObject Arrow;
	public GameObject Serj;
	public int firstTime = 0;
	public int Deaths;

	[Header ("Money")]
	public int money = 0;

	[Header ("BodyUpgrades")]
	public bool upgArmor;
	public bool upgNitro;
	public bool upgDropper;
	public bool upgRam;

	[Header ("HeadUpgrades")]

	[Space]
	public int Head_Level;
	[Space]
	public bool upgStandard;
	public bool upgRockchild;
	public bool upgLaida;
	[Space]

	public bool upgPicid;
	public bool upgBrookes;
	public bool upgMosasaur;
	[Space]

	public bool upgGig;
	public bool upgMeg;
	public bool upgKil;

	public int[] isBoughtTurrent; 
	//	0 = rockchild
	//	1 = layda
	//	2 = picid
	//	3 = brookes
	//	4 = mosasaur
	//	5 = gig
	//	6 = meg
	//	7 = kil

	[Header ("BulletUpgrades")]
	[Space]
	public int Vullet_Level;
	public bool Standard;
	public bool Spear;
	public bool Big;
	public bool Bigger;
	[Space]
	public int Burst_Level;
	public bool Yellow;
	public bool Orange;
	public bool Red;
	public bool God;
	[Space]
	public int Missile_Level;
	public bool Mini;
	public bool MEME;
	public bool Missile;
	public bool POV;

	public int[] isBoughtBullet; 
//	0 = spear
//	1 = Big
//	2 = Bigger
//	3 = Orange
//	4 = red
//	5 = God
//	6 = Meme
//	7 = Missile
//	8 = pow

	[Header ("Stat Upgrades")]
	[Space]
	public float upgHealth = 0;
	public float upgFireRate = 0;
	public float CritChancePlay = 0;
	public float CritDamagePlay = 0;
	public float AoePlay = 0;
	public int[] isBoughtBody;

//	public bool tanklifeUPG;

	public int NumberOfMines;
	[Space]
	[Header ("LevelProgression")]

	public int LevelOneProgress = 1;
	public int[] Medals;
	public int numberOfLevels = 10;

	public bool LevelOneCleared;
	public bool LevelTwoCleared;
	public bool LevelThreeCleared;
	public bool LevelFourCleared;
	public bool LevelFiveCleared;

	[Header ("Bosses")]
	public bool KraasIsDead;
	public bool RacerIsDead;
	[Space]

	[Header ("BulletUPG")]
	public bool AoeVulletUPG;
	public bool BiggerVulletUPG;

	[Header ("Payed")]

	public bool AoeVulletUPGpayd;
	public bool BiggerVulletUPGpayd;

	public bool ShotgunUPpayd;
	public bool MissleUPGpayd;
	public bool BigVulletUPGpayd;
	public bool MammutUPGpayd;
	public bool BurstUPGpayd;

	static Play ThisIsTheOne;
	private bool GameLoaded;

	void Start()
	{
		isBoughtTurrent = new int[8];
		isBoughtBullet = new int[9];
		isBoughtBody = new int[4];

		Medals = new int[numberOfLevels];
		if (GameLoaded == false) 
		{
			Load ();
			WhatHaveYouBought ();
			GameLoaded = true;
		}
		
		GetComponent <Button> ();
		if (ThisIsTheOne != null) 
		{
			Destroy (this.gameObject);
			return;
		}

		ThisIsTheOne = this;
		GameObject.DontDestroyOnLoad (this.gameObject);

		if (firstTime == 0) 
		{
			Invoke ("Tutor", 2);
		}
	}
	
	public void Save()
	{
		SaveLoad.SavePlayer (this);
	}

	public void Load()
	{
	int[] loadedStats = SaveLoad.LoadPlayer ();

			Medals[0] = loadedStats [0];
			Medals[1] = loadedStats [1];
			Medals[2] = loadedStats [2];
			Medals[3] = loadedStats [3];
			Medals[4] = loadedStats [4];

			Medals[5] = loadedStats [5];
			Medals[6] = loadedStats [6];
			Medals[7] = loadedStats [7];
			Medals[8] = loadedStats [8];
			Medals[9] = loadedStats [9];

	

			LevelOneProgress = loadedStats [10];
			money =  loadedStats [11];

			Head_Level = loadedStats [12];

			Vullet_Level = loadedStats [13];
			Burst_Level =  loadedStats [14];
			Missile_Level = loadedStats [15];

			isBoughtTurrent [0] = loadedStats [16];
			isBoughtTurrent [1] = loadedStats [17];

			isBoughtTurrent [2] = loadedStats [18];
			isBoughtTurrent [3] = loadedStats [19];
			isBoughtTurrent [4] = loadedStats [20];

			isBoughtTurrent [5] = loadedStats [21];
			isBoughtTurrent [6] = loadedStats [22];
			isBoughtTurrent [7] = loadedStats [23];


			isBoughtBullet [0] = loadedStats [24];
			isBoughtBullet [1] = loadedStats [25];
			isBoughtBullet [2] = loadedStats [26];

			isBoughtBullet [3] = loadedStats [27];
			isBoughtBullet [4] = loadedStats [28];
			isBoughtBullet [5] = loadedStats [29];

			isBoughtBullet [6] = loadedStats [30];
			isBoughtBullet [7] = loadedStats [31];
			isBoughtBullet [8] = loadedStats [32];

			isBoughtBody [0] = loadedStats [33];
			isBoughtBody [1] = loadedStats [34];
			isBoughtBody [2] = loadedStats [35];
			isBoughtBody [3] = loadedStats [36];

			NumberOfMines = loadedStats [37];

			Medals[10] = loadedStats [38];
			Medals[11] = loadedStats [39];
			Medals[12] = loadedStats [40];
			Medals[13] = loadedStats [41];
			Medals[14] = loadedStats [42];

			firstTime = loadedStats [43];
	}

	void WhatHaveYouBought()
	{
			// Turrents
			if (isBoughtTurrent [0] == 1) 
			{
				upgRockchild = true;
			}
		
			if (isBoughtTurrent [1] == 1) 
			{
				upgLaida = true;
			}

			if (isBoughtTurrent [2] == 1) 
			{
				upgPicid = true;
			}

			if (isBoughtTurrent [3] == 1) 
			{
				upgBrookes = true;
			}

			if (isBoughtTurrent [4] == 1) 
			{
				upgMosasaur = true;
			}

			if (isBoughtTurrent [5] == 1) 
			{
				upgGig = true;
			}

			if (isBoughtTurrent [6] == 1) 
			{
				upgMeg = true;
			}

			if (isBoughtTurrent [7] == 1) 
			{
				upgKil = true;
			}

			//Bullets

			if (isBoughtBullet [0] == 1) 
			{
				Spear = true;
			}

			if (isBoughtBullet [1] == 1) 
			{
				Big = true;
			}

			if (isBoughtBullet [2] == 1) 
			{
				Bigger = true;
			}

			if (isBoughtBullet [3] == 1) 
			{
				Orange = true;
			}

			if (isBoughtBullet [4] == 1) 
			{
				Red = true;
			}

			if (isBoughtBullet [5] == 1) 
			{
				God = true;
			}

			if (isBoughtBullet [6] == 1) 
			{
				MEME = true;
			}

			if (isBoughtBullet [7] == 1) 
			{
				Missile = true;
			}

			if (isBoughtBullet [8] == 1) 
			{
				POV = true;
			}

			//Body
			if (isBoughtBody [0] == 1) 
			{
				upgArmor = true;
				upgHealth = 300;
			}

			if (isBoughtBody [1] == 1) 
			{
				upgNitro = true;
			}

			if (isBoughtBody [2] == 1) 
			{
				upgRam = true;
			}

			if (isBoughtBody [3] == 1) 
			{
				upgDropper = true;
			}
	}

	void Tutor()
	{
		if (firstTime == 0) 
		{
			Serj.SetActive (true);
			Arrow.SetActive (true);
			Debug.Log ("Totor", gameObject);
		}
	}
			
	public void noLivesDead ()
	{
		ShotgunUPpayd = false;
		MissleUPGpayd= false;
		BigVulletUPGpayd= false;
		MammutUPGpayd= false;
		BurstUPGpayd= false;

		upgHealth = 0;
		upgFireRate = 0;
	}
}
