using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HealthDamage : MonoBehaviour {

	public bool isInfantry;
	public bool isTower;
	public bool isGrinder = false;
	public bool isBossTower = false;
	public bool isHaba = false;
	public GameObject Head;

	[Header ("Damage")]

	public GameObject PopupText;

	public float critChance;
	public float critDamage;
	public float aoe;
	public float MineDamage;

	[Header ("")]
	public float VulletDamage;
	public float SpearDamage;
	public float BigDamage;
	public float BiggerDamage;

	[Header ("")]
	public float BurstDamage;
	public float OrgDamage;
	public float RedDamage;
	public float GodDamage;

	[Header ("")]
	public float MiniDamage;
	public float MemeDamage;
	public float MissleDamage;
	public float PovDamage;

	[Header ("")]
	public bool RamInstaled;
	public float RamDamage;
	[Header ("")]
	public SpillerBeta Player_Refrence;


	[Header ("Health")]

	public GameObject healthBar;
	public float Health = 50;
	public float cur_Health;

	private bool hitOnce;

	[Header ("Destruced")]

	public GameObject Explosjon;
	public GameObject Coinpopup;
	private bool killed = false;

	public int Money = 10;

	[Header ("Animation")]

	Animator anim;
	public	Animator damageAnim;

	[Header ("Audio")]

	public AudioSource source;
	public AudioClip Crit;
	public AudioClip Auch;


	void Start () {

		Player_Refrence = GameObject.Find ("Body").GetComponent<SpillerBeta> ();
		critChance = GameObject.Find ("play_game").GetComponent<Play> ().CritChancePlay;
		aoe += GameObject.Find ("play_game").GetComponent<Play> ().AoePlay;
		
		cur_Health = Health;

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		if (pg.upgRam == true) 
		{ 
		RamInstaled = true;
		} else RamInstaled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (cur_Health <= 0) 
		{
			Invoke ("Damage",0);
		}

		float calc_Health = cur_Health / Health;
		SetHealthBar (calc_Health);
	}

	void OnTriggerEnter2D(Collider2D colDer)
	{
		if (colDer.gameObject.tag == "Mine" || colDer.name == "Mine(Clone)") 
		{
		PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
		float randy = Random.Range (0, 10);
		MineDamage += randy;
		cur_Health -= MineDamage;
		PopupText.GetComponent<FloatingText> ().AddTheDamage += MineDamage;
		PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
		MineDamage -= randy;

		Debug.Log ("MineHitEnemy", gameObject);
		source.PlayOneShot (Crit);
		}

		if (colDer.gameObject.tag == "Burst_vullet") {

			StartCoroutine (SetDamageTextToZero ());

			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 3;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if (isGrinder == true) 
			{
				GetComponent<Enemy_Grinder> ().range += 3;
			}

			float randy = Random.Range (0, 4);
			BurstDamage += randy;
			cur_Health -= BurstDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += BurstDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();

			BurstDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine(SetBackRange());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colDer.gameObject.tag == "Org_vullet") {

			StartCoroutine (SetDamageTextToZero ());

			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 3;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if (isGrinder == true) 
			{
				GetComponent<Enemy_Grinder> ().range += 3;
			}

			float randy = Random.Range (0, 4);
			OrgDamage += randy;
			cur_Health -= OrgDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += OrgDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();

			OrgDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine(SetBackRange());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colDer.gameObject.tag == "Red_vullet") {

			StartCoroutine (SetDamageTextToZero ());

			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 3;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if (isGrinder == true) 
			{
				GetComponent<Enemy_Grinder> ().range += 3;
			}

			float randy = Random.Range (0, 4);
			RedDamage += randy;
			cur_Health -= RedDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += RedDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();

			RedDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine(SetBackRange());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colDer.gameObject.tag == "God_vullet") {

			StartCoroutine (SetDamageTextToZero ());

			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 3;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if (isGrinder == true) 
			{
				GetComponent<Enemy_Grinder> ().range += 3;
			}

			float randy = Random.Range (0, 4);
			GodDamage += randy;
			cur_Health -= GodDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += GodDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();
			GodDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine(SetBackRange());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colDer.name == "Bang12(Clone)" || colDer.name == "Bang12" ) 
		{
			Debug.Log ("AOE", gameObject);
			cur_Health -= aoe;

			if (isInfantry == true ) 
			{
				GetComponent<Enemy_Infanty> ().range += 2;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if (PopupText.GetComponent<FloatingText> ().animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 0 ) // > 1 && !PopupText.GetComponent<FloatingText> ().animator.IsInTransition (0)
			{
				PopupText.GetComponent<FloatingText> ().AddTheDamage += aoe;
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
				Debug.Log ("ifAOE", gameObject);

			} 
			else 
			{ 

				PopupText.GetComponent<FloatingText> ().AddTheDamage += aoe;
				Debug.Log ("elseAOE", gameObject);

			}
		}

		if (colDer.gameObject.tag == "Happening") 
		{
			cur_Health -= 3;
		}
	}

	void OnCollisionEnter2D (Collision2D colIn)
	{
		if (colIn.gameObject.tag == "Vullet") 
		{
			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}

			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
			float randy = Random.Range (0, 10);
			VulletDamage += randy;
			cur_Health -= VulletDamage;
			PopupText.GetComponent<FloatingText> ().AddTheDamage += VulletDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			VulletDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine (SetBackRange ());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}
	
		if (colIn.gameObject.tag == "Spear") 
		{
			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;	
			int hit = Random.Range (0, 101);
			float randy = Random.Range (0, 10);
			SpearDamage += randy;

			if (hit < critChance) 
			{
				critDamage = SpearDamage;
				SpearDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

				cur_Health -= SpearDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += SpearDamage;
				SpearDamage -= randy + critDamage;
			} 
			else 
			{
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
				cur_Health -= SpearDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += SpearDamage;
				SpearDamage -= randy;
			}

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine (SetBackRange ());
				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.tag == "Big_vullet") 
		{
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}

			float randy = Random.Range (5, 16);
			BigDamage += randy;
			cur_Health -= BigDamage;
			PopupText.GetComponent<FloatingText> ().AddTheDamage += BigDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			BigDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine (SetBackRange ());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.tag == "Biger_vullet") {

			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;	
			int hit = Random.Range (0, 101);
			float randy = Random.Range (0, 10);
			BiggerDamage += randy;

			if (hit < critChance) 
			{
				critDamage = BiggerDamage;
				BiggerDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

				cur_Health -= BiggerDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += BiggerDamage;

				BiggerDamage -= randy + critDamage;
			} 
			else 
			{
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);

				cur_Health -= BiggerDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += BiggerDamage;

				BiggerDamage -= randy;
			}

			if (hitOnce == false && isTower == true) {
				StartCoroutine (SetBackRange ());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.name == "Body") {

			if (RamInstaled == true && isInfantry == true) 
			{

				if (Player_Refrence.speeding == true) 
				{
					PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

					float randy = Random.Range (20, 35);
					RamDamage += randy;
					cur_Health -= RamDamage;

					PopupText.GetComponent<FloatingText> ().AddTheDamage += RamDamage;
					PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

					damageAnim.SetTrigger ("Auch");
					source.PlayOneShot (Auch);
					Debug.Log ("RamSpeedInf", gameObject);
					RamDamage -= randy;
					return;
				} 
				else
				{
				PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
				float Pandy = Random.Range (-5, 5);
				RamDamage += Pandy;
				cur_Health -= RamDamage;

				PopupText.GetComponent<FloatingText> ().AddTheDamage += RamDamage;
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);

				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
				Debug.Log ("RamInf", gameObject);
				RamDamage -= Pandy;
				}
			}
				
			if (RamInstaled == true && isTower == true) 
			{
				if (Player_Refrence.speeding == true) 
				{
					PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

					float randy = Random.Range (0, 9);
					RamDamage += randy;
					cur_Health -= RamDamage;

					PopupText.GetComponent<FloatingText> ().AddTheDamage += RamDamage;
					PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

					Debug.Log ("RamCRIT", gameObject);
					source.PlayOneShot (Crit);
					RamDamage -= randy;
				}
			}
		}

		if (colIn.gameObject.tag == "Minimissile") {
			
			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}

			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
			float randy = Random.Range (0, 10);
			MiniDamage += randy;
			cur_Health -= MiniDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += MiniDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.SetActive (true);
			MiniDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine (SetBackRange ());
				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}
			

		if (colIn.gameObject.tag == "MemeMisslie") {

			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}

			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;	
			int hit = Random.Range (0, 101);
			float randy = Random.Range (0, 10);
			MemeDamage += randy;

			if (hit < critChance) 
			{
				critDamage = MemeDamage;
				MemeDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
				cur_Health -= MemeDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += MemeDamage;
				MemeDamage -= randy + critDamage;
			} 
			else 
			{
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
				cur_Health -= MemeDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += MemeDamage;
				MemeDamage -= randy;
			}

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine (SetBackRange ());
				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.tag == "Missle") {

			if (isInfantry == true) 
			{
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

			float randy = Random.Range (0, 10);
			MissleDamage += randy;

			cur_Health -= MissleDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += MissleDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.SetActive (true);
			MissleDamage -= randy;

			if (hitOnce == false && isTower == true) 
			{
				StartCoroutine (SetBackRange ());

				Head.GetComponent<Enemy_Tank> ().range += 5;
				hitOnce = true;
			}
		}

		if (colIn.gameObject.tag == "Pov") {

			if (isInfantry == true) {
				GetComponent<Enemy_Infanty> ().range += 10;
				damageAnim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);
			}

			if(isGrinder == true)
			{
				GetComponent<Enemy_Grinder> ().range += 10;
			}

			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;	
			int hit = Random.Range (0, 101);
			float randy = Random.Range (0, 10);

			PovDamage += randy;

			if (hit < critChance) {
				critDamage = PovDamage;
				PovDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

				cur_Health -= PovDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += PovDamage;

				PovDamage -= randy + critDamage;
			} else {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);

				cur_Health -= PovDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += PovDamage;
				PovDamage -= randy;
			}

			if (hitOnce == false && isTower == true) {
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
			Debug.Log ("Killed", gameObject);
			Invoke ("PlayExplosjon", 0.2f);
			Invoke ("PlayCoinUp", 0.5f);
			Destroy (this.gameObject, 0.5f);
			if (isBossTower == true) 
			{
				GameObject.Find ("Turrent_Boss").GetComponent<BossTurrent>().ATowerGone ();
				Debug.Log ("BossTower", gameObject);
			}
			killed = true;
		}
	}

	void PlayExplosjon()
	{
		GameObject explosjon = (GameObject)Instantiate (Explosjon);
		explosjon.transform.position = transform.position;
		if (isHaba == false) 
		{
			GameObject.Find ("GameManager").GetComponent<GameManager> ().enemyDown += 1;
		}
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

	private IEnumerator SetDamageTextToZero()
	{
		yield return new WaitForSeconds (1.1f);
		PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
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
