using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject Bullet;

	public bool friendlyFire;

	public bool Vullet;
	public bool BurstVullet;

	public Transform shotspawn;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	Animator anim;
	public AudioSource Source;

	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		if (Vullet == true && friendlyFire == false) 
		{
			anim.SetInteger ("Aim", 1);
			if (Time.time > nextFire) {

				nextFire = Time.time + fireRate;
				Instantiate (Bullet, shotspawn.position, shotspawn.rotation);
				Source.Play ();
				anim.SetTrigger ("Gun_Tigger");
			}
		}

		if (BurstVullet == true) {
			if (Time.time > nextFire) {
				Invoke ("BurstFire", 0f);
				Invoke ("BurstFire", 0.1f);
				Invoke ("BurstFire", 0.2f);
				Invoke ("BurstFire", 0.3f);
				Invoke ("BurstFire", 0.4f);
				Invoke ("BurstFire", 0.5f);
			}
		}
	}

	void BurstFire()
	{
		nextFire = Time.time + fireRate;
		Instantiate (Bullet, shotspawn.position, shotspawn.rotation);
		Source.Play ();
	}
		
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "BigCover" || other.gameObject.tag == "Enemy_Tank") {
			friendlyFire = true;
		} else
			friendlyFire = false;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "BigCover"|| other.gameObject.tag == "Enemy_Tank") 
		{
			friendlyFire = false;
		}
	}
}