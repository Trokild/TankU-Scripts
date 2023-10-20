using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMenu : MonoBehaviour {

	public enum MenuStates {Armor, Tank, Engine, Equiptment, Ram};
	public MenuStates currentstate;

	public GameObject armorOptions;
	public GameObject tankOptions;
	public GameObject engineOptions;
	public GameObject equiptmentOptions;
	public GameObject ramOptions;

	void Awake() 
	{
		currentstate = MenuStates.Armor;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (currentstate) 
		{

		case MenuStates.Armor:

			armorOptions.SetActive (true);
			tankOptions.SetActive (false);
			engineOptions.SetActive (false);
			equiptmentOptions.SetActive (false);
			ramOptions.SetActive (false);

			break;

		case MenuStates.Engine:

			armorOptions.SetActive (false);
			tankOptions.SetActive (false);
			engineOptions.SetActive (true);
			equiptmentOptions.SetActive (false);
			ramOptions.SetActive (false);

			break;

		case MenuStates.Tank:

			armorOptions.SetActive (false);
			tankOptions.SetActive (true);
			engineOptions.SetActive (false);
			equiptmentOptions.SetActive (false);
			ramOptions.SetActive (false);

			break;

		case MenuStates.Equiptment:

			armorOptions.SetActive (false);
			tankOptions.SetActive (false);
			engineOptions.SetActive (false);
			equiptmentOptions.SetActive (true);
			ramOptions.SetActive (false);

			break;

		case MenuStates.Ram:

			armorOptions.SetActive (false);
			tankOptions.SetActive (false);
			engineOptions.SetActive (false);
			equiptmentOptions.SetActive (false);
			ramOptions.SetActive (true);

			break;
		}
	}

	public void ArmorBtn()
	{
		currentstate = MenuStates.Armor;
	}

	public void TankBtn()
	{
		currentstate = MenuStates.Tank;
	}

	public void EgineBtn()
	{
		currentstate = MenuStates.Engine;
	}

	public void EquitBtn()
	{
		currentstate = MenuStates.Equiptment;
	}

	public void RamBtn()
	{
		currentstate = MenuStates.Ram;
	}
}
