using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Enemy_Infanty : MonoBehaviour {

	[Header ("Shooting")]
	public string enemyTag = "RangeShoot";
	public string RangeName = "Range";
	public bool targeted;
	public bool inRange = false;
	public Transform target;
	public GameObject Kanon;
	public float range = 10f;
	public float timeToFire = 1f;

	public bool burst;
	public bool vullet = true;

	public bool VulletTiggerEnter;

	[Header ("Movement")]
	public Rigidbody2D rb;
	private float speedBackup;
	private float noiseValues;
	public float strol;
	public float rotSpeed;
	public float speed;
	private float backupSpeed;
	private bool gotRunOver;
	private bool look;
	public float Push;

	Animator anim;
    public	Animator Headanim;
	public	Animator Gunanim;

	[Header ("Audio")]
	private bool paydAim;
	private bool nopAim;

	public AudioSource source;
	public AudioClip Look;
	public AudioClip Aim;
	public AudioClip NoAim;


	void Start () 
	{
		backupSpeed = speed;
		anim = GetComponent<Animator>();
		speedBackup = speed;
		InvokeRepeating ("Strol", 0f, Random.Range (0.5f, 8));
		rb = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();
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
			//rb.isKinematic = false;
			Gunanim.SetInteger("Aim", 1);

			if (paydAim == false) {
				source.PlayOneShot (Aim);
				paydAim = true;
				nopAim = true;
			}
		} 
		else 
		{
			target = null;
			targeted = false;
			Gunanim.SetInteger("Aim", 0);
			paydAim = false;

			if (nopAim == true) {
				source.PlayOneShot (NoAim);
				nopAim = false;
			}
		}
	}

	public void Strol()
	{
		if (targeted == false) {

			transform.rotation = Quaternion.Euler(0,0,0);
			
			noiseValues = Random.Range (1, 5);

			if (noiseValues == 1) {
				
				transform.rotation = Quaternion.Euler(0,0,90);
				rb.velocity = new Vector2 (strol, 0);
				anim.SetTrigger ("Tigger");
			}

			if (noiseValues == 2) {
				
				transform.rotation = Quaternion.Euler(0,0,-90);
				rb.velocity = new Vector2 (-strol, 0);
				anim.SetTrigger ("Tigger");
			}

			if (noiseValues == 3) {
				
				transform.rotation = Quaternion.Euler(0,0,180);
				rb.velocity = new Vector2 (0, strol);
				anim.SetTrigger ("Tigger");
			}

			if (noiseValues == 4) {
				
				transform.rotation = Quaternion.Euler(0,0,0);
				rb.velocity = new Vector2 (0,  -strol);
				anim.SetTrigger ("Tigger");
			}
		}
	}
		
	void Update () 
	{

		if (targeted == true && target != null)
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
	}

	void OnTriggerStay2D(Collider2D colDer)
	{
		if (colDer.name == RangeName && VulletTiggerEnter == true) 
		{
			Gunanim.SetInteger("Aim", 1);
			Invoke ("shooting", timeToFire);
			inRange = true;
			speed = 0;
		}
	}

	void OnTriggerExit2D(Collider2D colDer)
	{
		if (colDer.name == RangeName && VulletTiggerEnter == true) 
		{
			StartCoroutine (newPosition ());
			Debug.Log ("oy", gameObject);
			inRange = false;
		}
	}

	private IEnumerator newPosition()
	{
		Debug.Log ("Wait", gameObject);

		yield return new WaitForSeconds (2.0f);
		Debug.Log ("Move", gameObject);

		speed = speedBackup;
		inRange = false;
	}

	void OnCollisionEnter2D (Collision2D colIn)
	{
		if (colIn.gameObject.name == "Body") {

			rb.AddForce(transform.up * (strol * Push));
		}
			
		if (colIn.gameObject.tag == "Enemy_Tank") {

			GetComponent<Collider2D> ().enabled = false;
			speed = 0;
			gotRunOver = true;
			Headanim.SetTrigger ("RunOver");
			StartCoroutine (GetUp ());
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
		
	void shooting()
	{
		if (gotRunOver == false) 
		{
			Kanon.GetComponent<Gun> ().Vullet = true;
		}
	}

	private IEnumerator GetUp()
	{
		yield return new WaitForSeconds (2.0f);

		GetComponent<Collider2D> ().enabled = true;
		speed = backupSpeed;
		Headanim.SetTrigger ("PopUp");
		gotRunOver = false;
	}
}
