using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Kraas : MonoBehaviour {

	public GameObject CanvasKraas;
	public GameObject PopupText;

	public bool dialogKrass;
	private bool playdKraas;

	public GameObject DialogManagerK;
	public GameObject DialogImageK;

	[Header ("Destruced")]
	public GameObject Explosjon;
	public GameObject Coinpopup;
	private bool killed = false;

	public int Money = 10;


	[Header ("Shooting")]
	public string enemyTag = "RangeShoot";
	public bool targeted;
	public bool inRange = false;
	public Transform target;
	public GameObject Kanon;
	public float range = 10f;
	public float timeToFire = 1f;

	public bool burst;
	public bool vullet = true;

	public bool VulletTiggerEnter;
	public bool VulletBigTiggerEnter;

	[Header ("Damage")]
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

	[Header ("Movement")]
	public Rigidbody2D rb;
	private float speedBackup;
	private float noiseValues;
	public float strol;
	public float rotSpeed;
	public float speed;
	private bool look;

	Animator anim;
	public	Animator Headanim;

	[Header ("Health")]
	public GameObject healthBar;
	public float Max_Health = 50;
	public float cur_Health;

	[Header ("Audio")]
	public AudioSource source;
	public AudioClip Crit;
	public AudioClip Look;
	public AudioClip Auch;

	void Start () 
	{
		anim = GetComponent<Animator>();
		critChance = GameObject.Find ("play_game").GetComponent<Play> ().CritChancePlay;
		critDamage += GameObject.Find ("play_game").GetComponent<Play> ().CritDamagePlay;
		aoe += GameObject.Find ("play_game").GetComponent<Play> ().AoePlay;
		cur_Health = Max_Health;
		speedBackup = speed;
		rb = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		InvokeRepeating ("Strol", 0f, 1f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) 
		{
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);

			if (distanceToEnemy < shortestDistance) 
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
			targeted = true;
		} else 
		{
			target = null;
			targeted = false;
		}
	}

	public void Strol()
	{
		if (targeted == true && killed == false) {
			noiseValues = Random.Range (1, 20);

			if (noiseValues == 1) {
				StartCoroutine (Charge ());
				Debug.Log ("Charge", gameObject);
				anim.SetTrigger ("Charge");
				Headanim.SetTrigger ("HeadCharge");
			}

			if (noiseValues == 2) {
				StartCoroutine (SuperCharge ());
				Debug.Log ("SuperCharge", gameObject);
				anim.SetTrigger ("Charge");
				Headanim.SetTrigger ("HeadCharge");
			}

			if (noiseValues == 3) {
				anim.SetTrigger ("DodgeRight");
				StartCoroutine (DogeRight());
				Debug.Log ("Doge", gameObject);
			}

			if (noiseValues == 4 && cur_Health < Max_Health / 2) {
				StartCoroutine (Charge ());
				Debug.Log ("ChargeAngry", gameObject);
				anim.SetTrigger ("Charge");
				Headanim.SetTrigger ("HeadCharge");
			}

			if (noiseValues == 5 && cur_Health < Max_Health / 2) {
				Debug.Log ("SuperChargeAngry", gameObject);
				anim.SetTrigger ("Charge");
				Headanim.SetTrigger ("HeadCharge");
				StartCoroutine (SuperCharge ());
			}

			if (noiseValues == 6 && cur_Health < Max_Health / 2) {
				anim.SetTrigger ("DodgeRight");
				StartCoroutine (DogeRight());
				Debug.Log ("DogeAngry", gameObject);
			}
		}
	}

	void Update () 
	{
		if (cur_Health <= 0) 
		{
			Invoke ("Damage", 0.1f);
			GameObject.Find ("play_game").GetComponent<Play> ().KraasIsDead = true;
		}

		if (cur_Health <= Max_Health / 2 && killed  == false) 
		{
			Headanim.SetInteger ("State", 1);

			if (dialogKrass == true && playdKraas == false) 
			{
				DialogManagerK.SetActive (true);
				DialogImageK.SetActive (true);
				DialogManagerK.GetComponent<AnimatedDialog> ().TalkAngrKrass ();
				playdKraas = true;
			}
		}

		if (targeted == true && target != null && killed == false)
		{
			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

			Vector3 vectorToTarget = target.position - transform.position;
			float angle = (Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) +90;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * rotSpeed);

			anim.SetInteger("State", 1);

			if (look == false) 
			{
				Headanim.SetTrigger ("Look");
				source.PlayOneShot (Look);
				look = true;
			}
		}

		if (inRange == true || targeted == false) 
		{
			anim.SetInteger("State", 0);
		}

		if (speed > 0) 
		{
			Kanon.GetComponent<Gun>().Vullet = false;
		}
		if (cur_Health > 0) 
		{
			float calc_Health = cur_Health / Max_Health;
			SetHealthBar (calc_Health);
		}
	}

	void OnTriggerEnter2D(Collider2D colDer)
	{
		if (colDer.name == "Mine" || colDer.name == "Mine(Clone)") 
		{
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

			float randy = Random.Range (0, 150);
			BigDamage += randy;
			cur_Health -= MiniDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += MiniDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

			BigDamage -= randy;
		}

		if (colDer.name == "Yel_Vullet" || colDer.name == "Yel_Vullet(Clone)") 
		{

			StartCoroutine (SetDamageTextToZero ());

				range += 10;
				Headanim.SetTrigger ("Auch");
				source.PlayOneShot (Auch);


			float randy = Random.Range (0, 4);
			BurstDamage += randy;
			cur_Health -= BurstDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += BurstDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();

			BurstDamage -= randy;

		}

		if (colDer.name == "Org_Vullet" || colDer.name == "Org_Vullet(Clone)" ) 
		{

			StartCoroutine (SetDamageTextToZero ());

			range += 10;
			Headanim.SetTrigger ("Auch");
			source.PlayOneShot (Auch);

			float randy = Random.Range (0, 4);
			OrgDamage += randy;
			cur_Health -= OrgDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += OrgDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();

			OrgDamage -= randy;

		}

		if (colDer.name == "Red_Vullet" || colDer.name == "Red_Vullet(Clone)")
		{

			StartCoroutine (SetDamageTextToZero ());

			range += 10;
			Headanim.SetTrigger ("Auch");
			source.PlayOneShot (Auch);


			float randy = Random.Range (0, 4);
			RedDamage += randy;
			cur_Health -= RedDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += RedDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();

			RedDamage -= randy;
		}

		if (colDer.name == "God_Vullet" || colDer.name == "God_vullet(Clone)")
		{
			StartCoroutine (SetDamageTextToZero ());

			range += 10;
			Headanim.SetTrigger ("Auch");
			source.PlayOneShot (Auch);

			float randy = Random.Range (0, 4);
			GodDamage += randy;
			cur_Health -= GodDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += GodDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			PopupText.GetComponent<FloatingText> ().BurstgoingTO ();

			GodDamage -= randy;
		}

		if (colDer.name == "Bang12(Clone)") 
		{
			cur_Health -= aoe;

			if (PopupText.GetComponent<FloatingText> ().animator.GetCurrentAnimatorStateInfo (0).normalizedTime > 1 && !PopupText.GetComponent<FloatingText> ().animator.IsInTransition (0)) {
				PopupText.GetComponent<FloatingText> ().AddTheDamage += aoe;
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
				PopupText.GetComponent<FloatingText> ().AoegoingTO ();

			} else { 

				PopupText.GetComponent<FloatingText> ().AddTheDamage += aoe;
			}
		}
	}

	void OnTriggerStay2D(Collider2D colDer)
	{
		if (colDer.name == "Range" && VulletTiggerEnter == true && killed == false) 
		{
			Invoke ("shooting", timeToFire);
			inRange = true;
			//transform.position = Vector3.MoveTowards (transform.position, target.position, 0.3f);
			speed = 0;
			//			Debug.Log ("GoingToFireVullet", gameObject);
		}

		if (colDer.name == "Range_Long" && VulletBigTiggerEnter == true && killed == false) 
		{
			Invoke ("shooting", timeToFire);
			inRange = true;
			//	transform.position = Vector3.MoveTowards (transform.position, target.position, 0.2f);
			speed = 0;
			//			Debug.Log ("GoingToFIreBig", gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D colDer)
	{
		if (colDer.name == "Range" && VulletTiggerEnter == true) 
		{
			StartCoroutine (newPosition ());
			Debug.Log ("oy", gameObject);
			//			speed = speedBackup;
			//			inRange = false;
			//transform.position = Vector3.MoveTowards (transform.position, target.position, -0.0f);
		}

		if (colDer.name == "Range_Long" && VulletBigTiggerEnter == true) 
		{
			StartCoroutine (newPosition ());
			Debug.Log ("oy", gameObject);
			//			speed = speedBackup;
			//			inRange = false;
			//transform.position = Vector3.MoveTowards (transform.position, target.position, -0.0f);
		}
	}

	private IEnumerator newPosition()
	{
		Debug.Log ("Wait", gameObject);

		yield return new WaitForSeconds (2.0f);
		//currentPlace++;
		Debug.Log ("Move", gameObject);

		speed = speedBackup;
		inRange = false;
	}

	void OnCollisionEnter2D (Collision2D colIn)
	{
		if (colIn.gameObject.tag == "Vullet") 
		{
			range += 10;
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

			float randy = Random.Range (0, 10);

			VulletDamage += randy;
		
			cur_Health -= VulletDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += VulletDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);

			VulletDamage -= randy;
			source.PlayOneShot (Auch);
		}

		if (colIn.gameObject.tag == "Spear") 
		{
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;	
			range += 10;

			int hit = Random.Range (0, 101);
			float randy = Random.Range (0, 10);

			SpearDamage += randy;

			if (hit < critChance) {
				critDamage = SpearDamage;
				SpearDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

				cur_Health -= SpearDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += SpearDamage;

				SpearDamage -= randy + critDamage;
			} else 
			{
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);

				cur_Health -= SpearDamage;
				PopupText.GetComponent<FloatingText> ().AddTheDamage += SpearDamage;

				SpearDamage -= randy;
			}	
		}

		if (colIn.gameObject.tag == "Big_vullet") 
			{

			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

			range += 10;

			float randy = Random.Range (5, 16);
			BigDamage += randy;
			cur_Health -= BigDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += BigDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);

			BigDamage -= randy;

			}

			if (colIn.gameObject.tag == "Biger_vullet") 
			{
				PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
				range += 10;
				
				int hit = Random.Range (0, 101);
				float randy = Random.Range (5, 16);
				BiggerDamage += randy;

			if (hit < critChance) 
			{
				critDamage = BiggerDamage;
				BiggerDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				//	PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
			}
			cur_Health -= BiggerDamage;

			if (hit < critChance) {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
			} else {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			}

			if (hit < critChance) {
				BiggerDamage -= randy + critDamage;
			} else {
				BiggerDamage -= randy;
			}
	
			}

			if (colIn.gameObject.tag == "Minimissile") 
			{
				Debug.Log ("Hit", gameObject);
				PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

				float randy = Random.Range (0, 10);
				MiniDamage += randy;

				cur_Health -= MiniDamage;

				PopupText.GetComponent<FloatingText> ().AddTheDamage += MiniDamage;
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
				PopupText.SetActive (true);

				MiniDamage -= randy;
			}

			if (colIn.gameObject.tag == "MemeMisslie") 
			{

				PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;	
				range += 10;
				
				int hit = Random.Range (0, 101);
				float randy = Random.Range (0, 10);
				MemeDamage += randy;

			if (hit < critChance) 
			{
				critDamage = MemeDamage;
				MemeDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				//	PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
			}

			cur_Health -= MemeDamage;
			PopupText.GetComponent<FloatingText> ().AddTheDamage = MemeDamage;

			if (hit < critChance) {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
			} else {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			}

			if (hit < critChance) {
				MemeDamage -= randy + critDamage;
			} else {
				MemeDamage -= randy;
			}
			}

			if (colIn.gameObject.tag == "Missle") 
			{

				PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
				range += 10;

				float randy = Random.Range (0, 10);
				MissleDamage += randy;

				cur_Health -= MissleDamage;

				PopupText.GetComponent<FloatingText> ().AddTheDamage += MissleDamage;
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
				PopupText.SetActive (true);

				MissleDamage -= randy;
			}

			if (colIn.gameObject.tag == "Pov") 
			{

				PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
				range += 10;
				
				int hit = Random.Range (0, 101);
				float randy = Random.Range (0, 10);
				PovDamage += randy;

			if (hit < critChance) 
			{
				critDamage = PovDamage;
				PovDamage += critDamage;
				Debug.Log ("CRIT", gameObject);
				source.PlayOneShot (Crit);
				//	PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
			}

			cur_Health -= PovDamage;

			if (hit < critChance) {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);
			} else {
				PopupText.GetComponent<FloatingText> ().animator.Play ("Text_Slide", -1, 0f);
			}

			if (hit < critChance) {
				PovDamage -= randy + critDamage;
			} else {
				PovDamage -= randy;
			}
			}

		if (colIn.gameObject.tag == "Mine") 
		{
			PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;

			float randy = Random.Range (0, 150);
			MineDamage += randy;
			cur_Health -= MineDamage;

			PopupText.GetComponent<FloatingText> ().AddTheDamage += MineDamage;
			PopupText.GetComponent<FloatingText> ().animator.Play ("Text_CRIT", -1, 0f);

			MineDamage -= randy;
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

	float Deg2Rad(float degIn)
	{
		return ((degIn + 90) * Mathf.PI / 180);
	}

	void Damage()
	{
		if (killed == false) 
		{
			GameObject.Find ("play_game").GetComponent<Play> ().KraasIsDead = true;
			StartCoroutine (DeathIsNear ());
			speed = 0;
			rotSpeed = 0;

			Destroy (CanvasKraas);
			rb.bodyType = RigidbodyType2D.Kinematic;
			rb.simulated = false;

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


	void shooting()
	{
		if (killed == false) {
			Kanon.GetComponent<Gun> ().Vullet = true;
		}
	}

	public void SetHealthBar(float myHealth)
	{
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}

	private IEnumerator DeathIsNear()
	{
		GameObject.Find ("Music_Manager").GetComponent<audio_Manager> ().HalfVolume ();
		Headanim.SetInteger ("State", 0);

		DialogManagerK.SetActive (true);
		DialogImageK.SetActive (true);
		DialogManagerK.GetComponent<AnimatedDialog> ().TalkDeadKrass ();

		yield return new WaitForSeconds (4f);
		Kanon.GetComponent<Animator> ().SetTrigger ("Gun_Death");
		Headanim.SetTrigger ("Head_Death");
		anim.SetTrigger ("Body_Death");

		yield return new WaitForSeconds (1f);
		GameObject.Find ("GameManager").GetComponent<GameManager> ().enemyDown += 1;
		GameObject.Find ("Music_Manager").GetComponent<audio_Manager> ().musicCanPlay = false;
		GameObject.Find ("Music_Manager").GetComponent<audio_Manager> ().resetVol ();

		yield return new WaitForSeconds (4f);
		GameObject.Find ("GameManager").GetComponent<GameManager> ().LevelComplete ();
		GameObject.Find ("Music_Manager").GetComponent<audio_Manager> ().SwitchTrack(0);
	}

	private IEnumerator SetDamageTextToZero()
	{
		yield return new WaitForSeconds (1.1f);
		PopupText.GetComponent<FloatingText> ().AddTheDamage = 0;
	}

	private IEnumerator SuperCharge()
	{
		Debug.Log ("Wait", gameObject);

		yield return new WaitForSeconds (0.2f);
		rb.AddForce(transform.up * (-strol * 2));

		Debug.Log ("Move", gameObject);

	}

	private IEnumerator Charge()
	{
		Debug.Log ("Wait", gameObject);

		yield return new WaitForSeconds (0.2f);
		rb.AddForce(transform.up * -strol);

		Debug.Log ("Move", gameObject);

	}

	private IEnumerator DogeRight()
	{
		Debug.Log ("Wait", gameObject);

		yield return new WaitForSeconds (0.2f);
		rb.AddForce(transform.right * -strol);

		Debug.Log ("Move", gameObject);

	}


}