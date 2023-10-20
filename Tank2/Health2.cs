using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health2 : MonoBehaviour {
	
	public float max_Health = 100;
	public float cur_Health = 0;
	public GameObject healthBar;
	public GameObject Explosjon;

	Text text;

	void Start () 
	{
		cur_Health = max_Health;
	}

	void Awake () 
	{
		text = GameObject.Find ("Text1").GetComponent<Text> ();
	}
			
	void Update () 
	{
		text.text = "Health: " + cur_Health;

		if (cur_Health < 1) 
		{
			Destroy (this.gameObject);
			PlayExplosjon();
		}

		if (cur_Health > 100) 
		{
			cur_Health = 100;
		}

		float calc_Health = cur_Health / max_Health;
		SetHealthBar (calc_Health);
	}
		
	public void SetHealthBar(float myHealth)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	void PlayExplosjon()
	{
		GameObject explosjon = (GameObject)Instantiate (Explosjon);

		explosjon.transform.position = transform.position;
	}

}
