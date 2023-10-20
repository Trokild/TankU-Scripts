using UnityEngine;

public class MenuSelecter : MonoBehaviour {

	public int selectedMenu;
	// Use this for initialization
	void Awake () 
	{
		SelectMenu ();
	}
	
	void SelectMenu ()
	{
		int i = 0;
		foreach (Transform menu in transform) 
		{
			if (i == selectedMenu) 
				menu.gameObject.SetActive (true);		 
			else 
				menu.gameObject.SetActive (false);
			i++;
		}
		
	}

	public void NextBtn()
	{
		int prevSelectedMenu = selectedMenu;

		if (selectedMenu >= transform.childCount - 1)
			selectedMenu = 0;
		else
			selectedMenu++;
		
		if (prevSelectedMenu != selectedMenu) 
		{
			SelectMenu ();
		}
	}

	public void PrevBtn()
	{
		int prevSelectedMenu = selectedMenu;

		if (selectedMenu <= 0)
			selectedMenu = transform.childCount - 1;
		else
			selectedMenu--;

		if (prevSelectedMenu != selectedMenu) 
		{
			SelectMenu ();
		}
	}
}
