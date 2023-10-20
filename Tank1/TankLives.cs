using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankLives : MonoBehaviour {

	public float TankLifePrice;
	public float TankLifeUPGPrice;
	public bool noMorelives;
	private int maxTankAmount = 5;
	public int startTank = 3;
	public int curTank;
	private int maxTank;
	private int TankPerLive = 1;
	public Image[] tankImages;
	public Sprite[] tankSprites; 

	void Start () {

		curTank = startTank * TankPerLive;
		maxTank = maxTankAmount * TankPerLive;
		cheackTankAmount ();
	}

	void cheackTankAmount()
	{
		for(int i = 0; i < maxTankAmount; i++)
		{
			if (startTank <= i) 
			{
				tankImages [i].enabled = false;
			} 
			else 
			{ 
				tankImages [i].enabled = true;
			}

		}
		UpdateTanklives ();
	}

	void UpdateTanklives()
	{
		bool empty = false;
		int i = 0;

		foreach (Image image in tankImages) 
		{
			if (empty) 
			{
				image.sprite = tankSprites [0];
			} 
			else 
			{
				i++;
				if (curTank >= i * TankPerLive) 
				{
					image.sprite = tankSprites [tankSprites.Length - 1];
				} 
				else
				{
					int currentTankLives = (int)(TankPerLive - (TankPerLive * i - curTank));
					int tankPerImage = TankPerLive / (tankSprites.Length - 1);
					int imageIndex = currentTankLives / tankPerImage;
					image.sprite = tankSprites [imageIndex];
					empty = true;
				}
			}
		}
	}

	public void TakeTankLife(int amount)
	{
		curTank += amount;
		curTank = Mathf.Clamp (curTank, 0, startTank * TankPerLive);
		UpdateTanklives ();
	}

	public void AddTankLife(int amount)
	{
		startTank++;
		startTank = Mathf.Clamp (startTank, 0, maxTankAmount);

		curTank = startTank * TankPerLive;
		maxTank = maxTankAmount * TankPerLive;

		cheackTankAmount();
	}

	public void DeathUpdate ()
	{
		if (noMorelives == true && curTank <= 0) {
			GameObject.Find ("play_game").GetComponent<Play> ().noLivesDead ();
		}

		if (noMorelives == false && curTank <= 0) {
			noMorelives = true;
		}
	}	
}
