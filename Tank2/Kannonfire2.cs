using UnityEngine;
using System.Collections;

public class Kannonfire2 : MonoBehaviour {

	public GameObject VulletShoot;
	public GameObject FireVullet;
	public bool Vullet;

	public GameObject ShotgunShoot;
	public GameObject ShotgunVullet;
	public bool Shotgun;

	public GameObject BigShoot;
	public GameObject BigBullet;
	public bool BigVullet;

	public GameObject MissleShoot;
	public GameObject MissleBullet;
	public bool Missle;

	public GameObject BurstShoot;
	public GameObject BurstBullet;
	public bool BurstVullet;

	public bool MammutVullet; 
	public bool Sword;

	public Transform shotspawn;
	public Transform shotspawn2;
	public Transform shotspawn3;
	public Transform FireBulletSpawn;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	private SpriteRenderer spriteRenderer;

	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer> ();

	}

	// Update is called once per frame
	void Update () {

		if (Sword == true) 
		{
			spriteRenderer.enabled = false;
		}

		if (Sword == false) 
		{
			spriteRenderer.enabled = true;
		}

		if (Vullet == true) 
		{
			anim.SetInteger ("State", 0);
			if (Input.GetKeyDown (KeyCode.KeypadEnter) && Time.time > nextFire) {

				nextFire = Time.time + fireRate;
				Instantiate (VulletShoot, shotspawn.position, shotspawn.rotation);
				PlayShot ();
				anim.SetInteger ("State", 1);	
			}
		}

		if (Shotgun == true) 
		{
			fireRate = 1.2f;
			anim.SetInteger ("State", 8);
			if (Input.GetKeyDown (KeyCode.KeypadEnter) && Time.time > nextFire) {

				nextFire = Time.time + fireRate;
				Instantiate (ShotgunShoot, shotspawn.position, shotspawn.rotation);
				PlayShot ();
				anim.SetInteger ("State", 9);
			}
			GameObject.Find ("Head2").GetComponent<Kanon2>().Mammut2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Burst2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Big2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Missle2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Shotgun2 = true;
		}

		if (BigVullet == true) 
		{
			fireRate = 0.85f;
			anim.SetInteger ("State", 2);
			if (Input.GetKeyDown (KeyCode.KeypadEnter) && Time.time > nextFire) {

				nextFire = Time.time + fireRate;
				Instantiate (BigShoot, shotspawn.position, shotspawn.rotation);
				PlayShot ();
				//GetComponent<AudioSource>().Play ();
				anim.SetInteger ("State", 3);		

			}
			GameObject.Find ("Head2").GetComponent<Kanon2>().Mammut2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Burst2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Big2 = true;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Missle2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Shotgun2 = false;
		}

		if (BurstVullet == true) 
		{
			fireRate = 0.85f;
			anim.SetInteger ("State", 4);
			if (Input.GetKeyDown (KeyCode.KeypadEnter) && Time.time > nextFire) 
			{
				//BurstFire ();
				Invoke("BurstFire", 0f);
				Invoke("BurstFire", 0.1f);
				Invoke("BurstFire", 0.2f);

				PlayShot ();
				anim.SetInteger ("State", 5);

			}
			GameObject.Find ("Head2").GetComponent<Kanon2>().Mammut2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Burst2 = true;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Big2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Missle2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Shotgun2 = false;
		}

		if (MammutVullet == true) 
		{
			fireRate = 0.35f;
			anim.SetInteger ("State", 6);
			if (Input.GetKeyDown (KeyCode.KeypadEnter) && Time.time > nextFire) 
			{
				//BurstFire ();
				Invoke("BurstBarrle1", 0f);
				Invoke("BurstBarrle2", 0.1f);
				Invoke("BurstBarrle1", 0.2f);
				Invoke("BurstBarrle2", 0.3f);

				PlayShot ();
				anim.SetInteger ("State", 7);

			}
			GameObject.Find ("Head2").GetComponent<Kanon2>().Mammut2 = true;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Burst2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Big2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Missle2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Shotgun2 = false;
		}

		if (Missle == true) 
		{
			fireRate = 0.85f;
			anim.SetInteger ("State", 2);
			if (Input.GetKeyDown (KeyCode.KeypadEnter) && Time.time > nextFire) {

				nextFire = Time.time + fireRate;
				Instantiate (MissleShoot, shotspawn.position, shotspawn.rotation);
				PlayShot ();
				anim.SetInteger ("State", 3);	

			}

			GameObject.Find ("Head2").GetComponent<Kanon2>().Mammut2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Burst2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Big2 = false;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Missle2 = true;
			GameObject.Find ("Head2").GetComponent<Kanon2>().Shotgun2 = false;
		}
	}

	void BurstFire()
	{
		nextFire = Time.time + fireRate;
		Instantiate (BurstShoot, shotspawn.position, shotspawn.rotation);
	}

	void BurstBarrle1()
	{
		nextFire = Time.time + fireRate;
		Instantiate (BurstShoot, shotspawn2.position, shotspawn2.rotation);
	}

	void BurstBarrle2()
	{
		nextFire = Time.time + fireRate;
		Instantiate (BurstShoot, shotspawn3.position, shotspawn3.rotation);
	}

	void PlayShot()
	{
		Instantiate (FireVullet, FireBulletSpawn.position, FireBulletSpawn.rotation);
	}
}
