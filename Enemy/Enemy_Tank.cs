using UnityEngine;
using System.Collections;

public class Enemy_Tank : MonoBehaviour {

	public bool isTower;
	public bool isTank = false;
	public bool torn = false;
	public bool targeted;
	public Transform target;
	public float range = 10f;
	public float rotationSpeed = 5;
	private bool goingToRotate;
	public float rotationSpeedIdle = 50;
	public float timeToFire = 2;
	public bool burst;
	public bool vullet = true;
	public bool missile;
	public GameObject Kanon;
	public string enemyTag = "Tank1";

	Rigidbody2D rd;

	public Animator anim;
	private bool ranger;

	public AudioSource source;
	public AudioClip Range;
	public AudioClip noTarget;

	private bool paydAim;
	private bool nopAim;

	Quaternion rotationo;

	// Use this for initialization
	void Start () 
	{
		rotationo = transform.rotation;
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

			if (paydAim == false) {
				source.PlayOneShot (Range, 0.5f);
				paydAim = true;
				nopAim = true;
			}
		} 
		else 
		{
			target = null;
			paydAim = false;
			targeted = false;
			rotationo = transform.rotation;

			if (nopAim == true) 
			{
				nopAim = false;

				if (missile == true) 
				{
					Invoke ("NoAimMissileSound", 5f);
				}else
				{
				source.PlayOneShot (noTarget);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null) {

			ranger = false;
			Kanon.GetComponent<KanonEnemy>().Vullet = false;
			Kanon.GetComponent<KanonEnemy>().BurstVullet = false;
			Kanon.GetComponent<KanonEnemy>().MissleTower = false;

			StartCoroutine (StartRotating ());

			if (isTower == true && goingToRotate == true && isTank == false) 
			{
					transform.Rotate (0, 0, rotationSpeedIdle * Time.deltaTime);
			}
			return;


		}
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
		float value = Vector3.Cross (point2Target, transform.right).z;

		if (target != null)
		{
			rd.angularVelocity = rotationSpeed * value;
			if (ranger == false) 
			{
				anim.SetTrigger ("Range");
				ranger = true;
			}
			goingToRotate = false;
			Invoke ("shooting", timeToFire);
		}
	}

	void LateUpdate()
	{
		if (isTank == true && targeted == false || torn == true) {
			transform.rotation = rotationo;
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

	void shooting()
	{
		if (vullet == true) {
			Kanon.GetComponent<KanonEnemy> ().Vullet = true;
		} else if (burst == true) { 
			Kanon.GetComponent<KanonEnemy> ().BurstVullet = true;
		} else if (missile == true) {
			Kanon.GetComponent<KanonEnemy> ().MissleTower = true;
		}
	}

	private IEnumerator StartRotating()
	{
		if (goingToRotate == false) 
		{
			yield return new WaitForSeconds (2.0f);
			goingToRotate = true;
		}
	}

	public void SetRotationVector()
	{
		if (targeted == true) {
			rotationo = transform.rotation;
			Debug.Log ("SetRotationVector", gameObject);
		}
	}

	void NoAimMissileSound()
	{
		source.PlayOneShot (noTarget);
	}
}
