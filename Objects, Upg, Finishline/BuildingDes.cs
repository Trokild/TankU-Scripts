using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDes : MonoBehaviour {

	public GameObject des1;
	public GameObject des2;
	public GameObject des3;

	public GameObject Explosjon;
	public GameObject Ruble;

	public float Timer;
	public float Amount;

	private float shakeTimer;
	private float shakeAmount;

	public AudioSource audios;

	private float Health = 0;
	// Use this for initialization
	void Start () {

		AudioSource audio = GetComponent<AudioSource> ();
		audios = audio;

	}

	// Update is called once per frame
	void Update () {

		if (shakeTimer > 0) 
		{
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;
		}
	}

	void OnCollisionEnter2D (Collision2D colIn)
	{
		if (colIn.gameObject.tag == "Big_vullet") {
			Invoke ("Damage", 0);

		}
	}

	void Damage()
	{
		Health += 1;
		Shake (Timer, Amount);
		audios.Play ();

		if (Health == 1) 
		{
			DamageInsSprite1 ();
		}

		if (Health == 2) 
		{
			DamageInsSprite2 ();
		}

		if (Health == 3) 
		{
			DamageInsSprite3 ();
		}

		if (Health >= 4) 
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}
	}

	void Shake (float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
	}

	void DamageInsSprite1()
	{
		Instantiate (des1, transform.position, transform.rotation, transform);
	}

	void DamageInsSprite2()
	{
		Instantiate (des2, transform.position, transform.rotation, transform);
	}

	void DamageInsSprite3()
	{
		Instantiate (des3, transform.position, transform.rotation, transform);
	}

	void PlayExplosjon()
	{
		GameObject explosjon = (GameObject)Instantiate (Explosjon);
		GameObject ruble = (GameObject)Instantiate (Ruble);

		explosjon.transform.position = transform.position;
		ruble.transform.position = transform.position;
		ruble.transform.rotation = transform.rotation;
	}
}
