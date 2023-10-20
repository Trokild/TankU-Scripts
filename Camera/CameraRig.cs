using UnityEngine;
using System.Collections;

public class CameraRig : MonoBehaviour {

	public GameObject Tank1;
	public GameObject Tank2;

	public GameObject Gamefocus;
	public bool isFocus;

	// Update is called once per frame
	void Update () {
		if (isFocus == true) {
			if (Gamefocus != null && Tank1 != null && Tank2 != null) 
				{
				transform.position = (Tank1.transform.position + Tank2.transform.position + Gamefocus.transform.position) / 3;
				} 
				else isFocus = false;
			} 
			else if(Tank1 != null && Tank2 != null)
			{
			transform.position = (Tank1.transform.position + Tank2.transform.position) / 2;
			}
	}
}
