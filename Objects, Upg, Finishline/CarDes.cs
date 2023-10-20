using UnityEngine;
using System.Collections;

public class CarDes : MonoBehaviour {

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

	void Start () {

		AudioSource audio = GetComponent<AudioSource> ();
		audios = audio;
	}
	
	void Update () {

		if (shakeTimer > 0) 
		{
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
			shakeTimer -= Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Burst_vullet") {
			Invoke ("Damage", 0);
		}

		if (other.gameObject.tag == "Org_vullet") {
			Invoke ("Damage", 0);
		}

		if (other.gameObject.tag == "Red_vullet") {
			Invoke ("Damage", 0);
		}	
	}

	void OnCollisionEnter2D (Collision2D colIn)
	{


		if (colIn.gameObject.tag == "Vullet") {
			Invoke ("Damage", 0);
		}



		if (colIn.gameObject.tag == "Tank2") {
			Invoke ("Damage", 0);
			audios.Play ();

		}

		if (colIn.gameObject.tag == "Big_vullet") {
			Invoke ("Damage", 0);
			Health += 1;
		}

		if (colIn.gameObject.tag == "Tank1") {
			Invoke ("Damage", 0);
			audios.Play ();

		}

		if (colIn.gameObject.tag == "Burst_vullet") {
			Invoke ("Damage", 0);
		}

		if (colIn.gameObject.tag == "BurstVullet(Clone)") {
			Invoke ("Damage", 0);
		}

		if (colIn.gameObject.tag == "BadeKanon1") {
			Invoke ("Damage", 0);;
		}

		if (colIn.gameObject.tag == "Sword") {
			Invoke ("Damage", 0);
		}
			

		if (colIn.gameObject.tag == "Missle") {
			Invoke ("Damage", 0);
			Health += 1;
		}

		if (colIn.gameObject.tag == "Missle2") {
			Invoke ("Damage", 0);
			Health += 1;
		}

		if (colIn.gameObject.tag == "Pov") 
		{
			Damage ();
			Health += 1;
		}
		if (colIn.gameObject.tag == "MemeMisslie")
		{
			Damage ();
		}
		if (colIn.gameObject.tag == "Minimissile")
		{
			Damage ();
		}
		if (colIn.gameObject.tag == "Biger_vullet") 
		{
			Damage ();
			Health += 1;
		}
		if (colIn.gameObject.tag == "Spear") 
		{
			Damage ();
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
