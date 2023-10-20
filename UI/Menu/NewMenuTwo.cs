using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMenuTwo : MonoBehaviour {

	public enum MenuStates {Standard, Burst, Missle};
	public MenuStates currentstate;

	public GameObject standardOptions;
	public GameObject burstOptions;
	public GameObject missileOptions;

	void Awake() 
	{
		currentstate = MenuStates.Standard;
	}

	void Update () 
	{
		switch (currentstate) 
		{

		case MenuStates.Standard:

			standardOptions.SetActive (true);
			burstOptions.SetActive (false);
			missileOptions.SetActive (false);
			break;

		case MenuStates.Burst:

			standardOptions.SetActive (false);
			burstOptions.SetActive (true);
			missileOptions.SetActive (false);
			break;

		case MenuStates.Missle:

			standardOptions.SetActive (false);
			burstOptions.SetActive (false);
			missileOptions.SetActive (true);
			break;
		}
	}

	public void StandarBtn()
	{
		currentstate = MenuStates.Standard;
	}

	public void BrustBtn()
	{
		currentstate = MenuStates.Burst;
	}

	public void MissileBtn()
	{
		currentstate = MenuStates.Missle;
	}
}
