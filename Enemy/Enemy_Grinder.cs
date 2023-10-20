using UnityEngine;
using System.Collections;

public class Enemy_Grinder : MonoBehaviour {

	public bool targeted;
	public Transform target;
	public float range = 10f;
	public float rotationSpeed = 5;
	public float Timer;
	public float speed = 250f;

	public ParticleSystem[] dust;
	private bool isDusting;

	public string enemyTag = "Tank1";

	AudioSource audio;
	Animator anim;
	Rigidbody2D rd;

	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource> ();
		anim = GetComponent<Animator>();

		rd = GetComponent<Rigidbody2D> ();
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

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
			audio.pitch = 1.4f;
		} else 
		{
			target = null;
			targeted = false;
			audio.pitch = 1.25f;
		}
	}

	// Update is called once per frame
	void Update () 
	{

		if (targeted == true && Timer > 0 && target != null) {
			
			Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
			float value = Vector3.Cross (point2Target, transform.right).z;
			rd.angularVelocity = (rotationSpeed *2) * value;
			rd.velocity = transform.right * -speed;
			Timer -= Time.deltaTime;
		} 

		if (targeted == true && Timer <= 0 && target != null) {
			Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
			float value = Vector3.Cross (point2Target, transform.right).z;
			rd.angularVelocity = rotationSpeed * value;
			rd.velocity = transform.right * speed;
		}

		if (targeted == true)
		{
			anim.SetInteger("State", 1);

			if (isDusting == false) 
			{
				{
					foreach (ParticleSystem duster in dust) 
					{
						duster.enableEmission = true;
						isDusting = true;
					}
				}
			}
		}

		if (targeted == false) 
		{
			anim.SetInteger("State", 0);

			if (isDusting == true) 
			{
				{
					foreach (ParticleSystem duster in dust) 
					{
						duster.enableEmission = false;
						isDusting = false;
					}
				}
			}
		}
	}
	void OnCollisionEnter2D (Collision2D colIn)
	{
		if (colIn.gameObject.tag == "Bakke")
		{
			Invoke ("Reverse", 0.7f);
		}
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

	float Deg2Rad(float degIn)
	{
		return ((degIn) * Mathf.PI/180);
	}

	public void Reverse ()
	{
		Timer += 0.5f;
		Debug.Log ("REVERSE", gameObject);
	}
}