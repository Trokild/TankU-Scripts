using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City_Npc : MonoBehaviour {

	[Header ("Movement")]
	public Rigidbody2D rb;
	public bool isRunning;
	private float noiseValues;
	public float strol;
	public float timeBet;
	public float speed;
	public float rotSpeed;
	private bool look;
	private bool death;
	public string enemyTag = "RangeShoot";
	public bool targeted;
	public float range = 10f;
	public bool inRange = false;
	public Transform target;

	[Header ("Audio")]
	public AudioSource source;
	public AudioClip Walk;
	public AudioClip Panic;
	public AudioClip Grind;

	Animator anim;

	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		anim = GetComponent<Animator>();
	}
	
	void Update () {

		if (targeted == true && isRunning == false && target != null)
		{
			transform.position = Vector3.MoveTowards (transform.position, target.position, -speed * Time.deltaTime);

			Vector3 vectorToTarget = target.position - transform.position;
			float angle = (Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) -90;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * rotSpeed);

			if (!source.isPlaying) {
				source.PlayOneShot (Walk);
			}
			if (look == false) 
			{
				look = true;
			}
		}
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
			anim.SetInteger("State", 2);

		} else 
		{
			target = null;
			targeted = false;
			anim.SetInteger("State", 0);
		}
	}

	public void Strol()
	{
		anim.SetInteger("State", 1);
		source.PlayOneShot (Panic, 0.4f);
		noiseValues = Random.Range (1, 5);

		if (noiseValues == 1) {

			transform.rotation = Quaternion.Euler (0, 0, 90);
			rb.velocity = new Vector3 (strol, 0, 0);
		}

		if (noiseValues == 2) {

			transform.rotation = Quaternion.Euler (0, 0, -90);
			rb.velocity = new Vector3 (-strol, 0, 0);
		}

		if (noiseValues == 3) {

			transform.rotation = Quaternion.Euler (0, 0, 180);
			rb.velocity = new Vector3 (0, strol, 0);
		}

		if (noiseValues == 4) {

			transform.rotation = Quaternion.Euler (0, 0, 0);
			rb.velocity = new Vector2 (0, -strol);
		}
	}

	void OnCollisionEnter2D (Collision2D colIn)
	{
		if (colIn.gameObject.tag == "Vullet" && isRunning == false) {
			isRunning = true;
			Invoke ("Strol", 0f);
			Invoke ("Strol", timeBet);
			Invoke ("Strol", timeBet *2);
			Invoke ("Strol", timeBet *3);
			Invoke ("Strol", timeBet *4);
			Invoke ("NotRunning", timeBet *6);
		}

		if (colIn.gameObject.tag == "Big_vullet" && isRunning == false) {

			isRunning = true;
			Invoke ("Strol", 0f);
			Invoke ("Strol", timeBet);
			Invoke ("Strol", timeBet *2);
			Invoke ("Strol", timeBet *3);
			Invoke ("Strol", timeBet *4);
			Invoke ("NotRunning", timeBet *6);
		}

		if (colIn.gameObject.tag == "BadeKanon1" || colIn.gameObject.name == "Grinder") 
		{
			Debug.Log ("FQ");
			Grinder ();
			source.PlayOneShot (Grind);
		}
	}

	void OnTriggerEnter2D(Collider2D colDer)
	{
		if (colDer.gameObject.tag == "Burst_vullet" && isRunning == false) 
		{
			isRunning = true;
			Invoke ("Strol", 0f);
			Invoke ("Strol", timeBet);
			Invoke ("Strol", timeBet *2);
			Invoke ("Strol", timeBet *3);
			Invoke ("Strol", timeBet *4);
			Invoke ("NotRunning", timeBet *5);
		}
	}

	public void Grinder()
	{
		Debug.Log("FQ1");
		if (death == false) {
			GetComponent<Collider2D> ().enabled = false;
			speed = 0;
			this.gameObject.tag = "Untagged";
			anim.SetTrigger ("Grinder");
			Destroy (this.gameObject, 0.8f);
			death = true;
			Debug.Log ("FQ2");
		}
	}

	public void NotRunning()
	{
		isRunning = false;
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
}
