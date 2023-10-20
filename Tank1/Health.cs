using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {


	public float max_Health = 100;
	[HideInInspector]
	public float cur_Health = 0;

	public float max_Health2 = 100;
	[HideInInspector]
	public float cur_Health2 = 0;

	public GameObject healthBar;
	public Text HealthText;

	public GameObject DamageBar;

	[SerializeField]
	private Color fullColor;
	[SerializeField]
	private Color lowColor;
	[SerializeField]
	private Color fullColor2;
	[SerializeField]
	private Color lowColor2;

	public GameObject Explosjon;

	public float damagetaken;
	public float bulletdamage;

	public GameObject Camera;
	public Camera2DFollow CamFoll;


	void Start () 
	{
		if (GameObject.Find ("play_game").GetComponent<Play> ().upgArmor == true) 
		{
			max_Health2 += GameObject.Find ("play_game").GetComponent<Play> ().upgHealth;
			max_Health += GameObject.Find ("play_game").GetComponent<Play> ().upgHealth;
		}
		cur_Health2 = max_Health2;
		cur_Health = max_Health;

		Camera = GameObject.Find("Main Camera");
		CamFoll = Camera.GetComponent<Camera2DFollow> ();
	}

	void Update () 
	{
		damagetaken = max_Health - cur_Health;
		HealthText.text = max_Health + " / " + cur_Health;

		if (cur_Health < 1) 
		{
			cur_Health2 = 0;
			GameObject.Find ("GameManager").GetComponent<GameManager> ().Restart();

			this.gameObject.tag = "Untagged";
			Destroy (this.gameObject,0.01f);
			PlayExplosjon();
			Debug.Log ("Health is 0", gameObject);
		}

		if (cur_Health > max_Health) 
		{
			cur_Health = max_Health;

		}

		float calc_Health = cur_Health / max_Health;
		SetHealthBar (calc_Health);

		float calc_damage = cur_Health2 / max_Health2;
		SetDamageBar (calc_damage);
	}
		
	public void SetHealthBar(float myHealth)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		healthBar.GetComponent<Image> ().color = Color.Lerp (lowColor, fullColor, (cur_Health/200));
	}

	public void SetDamageBar(float myDamage)
	{
		DamageBar.transform.localScale = new Vector3(Mathf.Clamp(myDamage,0f ,1f), DamageBar.transform.localScale.y, DamageBar.transform.localScale.z);
		DamageBar.GetComponent<Image> ().color = Color.Lerp (lowColor2, fullColor2, (cur_Health/200));
	}

	void PlayExplosjon()
	{
		GameObject explosjon = (GameObject)Instantiate (Explosjon);

		explosjon.transform.position = transform.position;
		explosjon.transform.rotation = transform.rotation;
	}

	private void	TakeDamage()
	{
		cur_Health2 -= 1;
	}

	public void damage()
	{
		StartCoroutine (InvokeMethode (TakeDamage, 0.1f, bulletdamage));
		CamFoll.damageCamera ();
	}

	public IEnumerator InvokeMethode( Action method, float interval, float invokeCount)
	{
		for (int i = 0; i < invokeCount; i++) 
		{
			method ();
			yield return new WaitForSeconds (interval);
		}
	}
}
