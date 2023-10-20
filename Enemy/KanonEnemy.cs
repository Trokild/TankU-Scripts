using UnityEngine;
using System.Collections;

public class KanonEnemy : MonoBehaviour {

	public GameObject Bullet;

	public bool Vullet;
	public bool BurstVullet;
	public bool	MissleTower;

	public int miss;

	public Transform shotspawn;
	public Transform shotspawn2;
	public Transform shotspawn3;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	public Animator Head;
	public AudioSource source;
	public AudioClip Reload;

	void Start()
	{
		Vullet = false;
		BurstVullet = false;
		MissleTower = false;
	}

	void Update () {

		if (Vullet == true) 
		{

			if (Time.time > nextFire) {

				nextFire = Time.time + fireRate;
				Instantiate (Bullet, shotspawn.position, shotspawn.rotation);
				source.Play ();
				Head.SetTrigger ("Reload");
				Invoke ("PlayShot", 0.3f);
			}
		}

		if (BurstVullet == true) {

			if (Time.time > nextFire) {

				Head.SetTrigger ("Reload");
				Invoke ("BurstFire", 0f);
				Invoke ("BurstFire", 0.1f);
				Invoke ("BurstFire", 0.2f);
				Invoke ("BurstFire", 0.3f);
				Invoke ("BurstFire", 0.4f);
				Invoke ("BurstFire", 0.5f);
				Invoke ("PlayShotLoud", 1.2f);
			}
		}

		if (MissleTower == true) {

			if (Time.time > nextFire) {

				Head.SetTrigger ("Reload");
				Invoke ("MissleFire", 0f);
				Invoke ("MissleFire2", 0.1f);
				Invoke ("MissleFire3", 0.2f);
				Invoke ("PlayShot", 0.5f);
			}
		}
	}

	void BurstFire()
	{
		nextFire = Time.time + fireRate;
		Instantiate (Bullet, shotspawn.position, shotspawn.rotation);
		source.Play ();
	}

	void MissleFire()
	{
		nextFire = Time.time + fireRate;
		Instantiate (Bullet, shotspawn.position, shotspawn.rotation);
	}

	void MissleFire2()
	{
		nextFire = Time.time + fireRate;
		Instantiate (Bullet, shotspawn2.position, shotspawn.rotation);
	}

	void MissleFire3()
	{
		nextFire = Time.time + fireRate;
		Instantiate (Bullet, shotspawn3.position, shotspawn.rotation);
	}

	void PlayShot()
	{
		source.PlayOneShot (Reload, 0.5f);
	}

	void PlayShotLoud()
	{
		source.PlayOneShot (Reload, 1f);
	}
}
