using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterFocus : MonoBehaviour {

	public bool dialog;
	private bool playd;
	public bool isRacerBoss = false;

	public GameObject Leech;
	public GameObject DialogManager;
	public GameObject DialogImage;
	//public audio_Manager Musikk;

	void Start () {
		if (isRacerBoss == true) {
			InvokeRepeating ("FocusRacer", 0, 0.5f);
		}
	}


	void OnTriggerEnter2D(Collider2D colDer)
	{
		if (colDer.gameObject.tag == "Player") 
		{
			GameObject.Find ("Camera_Rig").GetComponent<CameraRig> ().isFocus = true;

			if (dialog == true && playd == false) 
			{
				DialogManager.SetActive (true);
				DialogImage.SetActive (true);
				playd = true;

				if (isRacerBoss == false) 
				{
					Invoke ("KraasRange", 3);
				}
			}
		}

	}
	void FocusRacer()
	{
		transform.position = Leech.transform.position;
	}

	void KraasRange()
	{
		GameObject.Find ("Krass").GetComponent<Kraas> ().range += 10;
	}

	void OnTriggerExit2D(Collider2D colDer)
	{
		if (colDer.gameObject.tag == "Player") 
		{
			GameObject.Find ("Camera_Rig").GetComponent<CameraRig> ().isFocus = false;
		}
	}
}
