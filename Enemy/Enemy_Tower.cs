using UnityEngine;
using System.Collections;

public class Enemy_Tower : MonoBehaviour {


	[Header ("Destroyed")]
	public GameObject Explosjon;
	public GameObject Coinpopup;
	public GameObject Head;
	private bool killed = false;

	[Header ("Health")]
	public GameObject healthBar;
	public float Health = 50;
	public float cur_Health;
	public int Money = 10;

	[Header ("Damage")]
	public GameObject PopupText;
	public float critChance;
	public float critDamage;

	//public float aoe;
	public float RamDamage;

	public float VulletDamage;
	public float BurstDamage;
	public float BigDamage;
	public float MissleDamage;

	private bool hitOnce;

	void Start () 
	{
		cur_Health = Health;
	}

	// Update is called once per frame
	void Update () 
	{
		float calc_Health = cur_Health / Health;
		SetHealthBar (calc_Health);

		if (cur_Health <= 0) 
		{
			Invoke ("Damage", 0);
		}
	}

	void OnCollisionEnter2D (Collision2D colIn)
	{
		if (colIn.gameObject.tag == "Vullet") {
			
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

			int hit = Random.Range (0, 101);
			float randy = Random.Range (0, 10);

			VulletDamage += randy;

			if (hit < critChance) 
			{
				VulletDamage += 1 * critDamage;
				Debug.Log ("CRIT", gameObject);
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide_CRIT", -1, 0f);
			}
			cur_Health -= VulletDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += VulletDamage;

			if (hit < critChance) {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide_CRIT", -1, 0f);
			} else {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			}

			if (hit < critChance) {
				VulletDamage -= randy + critDamage;
			} else {
				VulletDamage -= randy;
			}

			if (hitOnce == false) 
			{
				StartCoroutine(SetBackRange());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.tag == "Big_vullet") {
			
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
			float randy = Random.Range (0, 10);
			BigDamage += randy;
			cur_Health -= BigDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += BigDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);

			BigDamage -= randy;

			if (hitOnce == false) 
			{
				StartCoroutine(SetBackRange());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.tag == "Tank1") {
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
			cur_Health -= RamDamage;
			PopupText.GetComponent<FloatingText> ().AddTheDamage += RamDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
		}

		if (colIn.gameObject.tag == "Burst_vullet") {
			float randy = Random.Range (0, 21);
			BurstDamage += randy;
			cur_Health -= BurstDamage;
			PopupText.GetComponent<FloatingText> ().AddTheDamage += BurstDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();
			BurstDamage -= randy;

			if (hitOnce == false) 
			{
				StartCoroutine(SetBackRange());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.tag == "Bakke") {
			Debug.Log ("Hows that even possible?!", gameObject);
		}

		if (colIn.gameObject.tag == "MiniMisslie") {
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

			float randy = Random.Range (0, 10);
			MissleDamage += randy;
			cur_Health -= MissleDamage;
			cur_Health -= MissleDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += MissleDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.SetActive (true);
			MissleDamage -= randy;

			if (hitOnce == false) 
			{
				StartCoroutine(SetBackRange());
				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D colDer)
	{
		if (colDer.name == "BadeKanon") {
			Health -= 100;
		}

		if (colDer.name == "BadeKanon(Clone)") {
			Health -= 100;
		}

		if (colDer.gameObject.tag == "Burst_vullet") {
			float randy = Random.Range (0, 4);
			BurstDamage += randy;
			cur_Health -= BurstDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += BurstDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();
			BurstDamage -= randy;

			if (hitOnce == false) {
				StartCoroutine (SetBackRange ());
				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}
	}

	void Damage()
	{
		if (killed == false) 
		{
			Invoke ("PlayExplosjon", 0.2f);
			Invoke ("PlayCoinUp", 0.5f);
			Destroy (this.gameObject, 0.5f);
			killed = true;
		}
	}

	void PlayExplosjon()
	{
		GameObject explosjon = (GameObject)Instantiate (Explosjon);
		explosjon.transform.position = transform.position;
	}


	void PlayCoinUp()
	{
		GameObject coinup = (GameObject)Instantiate (Coinpopup);
		coinup.transform.position = transform.position + new Vector3 (0, 2 ,0);
		GameObject.Find ("play_game").GetComponent<Play> ().money += Money;
	}

	public void SetHealthBar(float myHealth)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	private IEnumerator SetBackRange()
		{
			Debug.Log ("seeu", gameObject);
			yield return new WaitForSeconds (2.0f);

			Debug.Log ("forgetit", gameObject);
			Head.GetComponent<Enemy_Tank> ().range -= 5;
			hitOnce = false;
		}
}
