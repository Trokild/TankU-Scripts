using UnityEngine;
using System.Collections;

public class Front : MonoBehaviour {

	public GameObject SwordImpact;
	public Transform Impactpos;

	public Spiller2 tank2;

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void Vullet()
	{
		GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health -= 5f;
		tank2.ShakeTank (0.1f, 0.5f);

	}

	void Blade()
	{
		GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health -= 30f;
		tank2.ShakeTank (0.1f, 0.5f);
	}

	void BigVullet()
	{
		GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health -= 15f;
		tank2.ShakeTank (0.1f, 0.5f);
	}

	void Missle()
	{
		GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health -= 7f;
		tank2.ShakeTank (0.1f, 0.5f);
	}
		
	void BurstVullet()
	{
		GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health -= 3f;
		tank2.ShakeTank (0.05f, 0.1f);
	}

	void ShotgunHit()
	{
		GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health -= 5f;
		tank2.ShakeTank (0.1f, 0.5f);
	}

	void ShotgunFracHit()
	{
		GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health -= 7f;
		tank2.ShakeTank (0.1f, 0.5f);
	}

	void OnTriggerEnter2D(Collider2D colIn)
	{


		if (colIn.name == "Vullet") {
			Invoke ("Vullet", 0);
		}

		if (colIn.name == "Vullet(Clone)") {
			Invoke ("Vullet", 0);
		}

		if (colIn.name == "Big_vullet") {
			Invoke ("BigVullet", 0);
		}

		if (colIn.name == "Big_vullet(Clone)") {
			Invoke ("BigVullet", 0);
		}

		if (colIn.name == "BurstVullet") {
			Invoke ("BurstVullet", 0);
		}

		if (colIn.name == "BurstVullet(Clone)") {
			Invoke ("BurstVullet", 0);
		}

		if (colIn.name == "Missle") {
			Invoke ("Missle", 0);
		}

		if (colIn.name == "Missle(Clone)") {
			Invoke ("Missle", 0);
		}


		if (colIn.name == "BadeKanon") {
			Invoke ("Blade", 0);
			Invoke ("PlayImpact", 0f);
		}

		if (colIn.name == "BadeKanon(Clone)") {
			Invoke ("Blade", 0);
			Invoke ("PlayImpact", 0f);
		}

		if (colIn.name == "Shotgun") {
			Invoke ("ShotgunHit", 0);
		}

		if (colIn.name == "Shotgun(Clone)") {
			Invoke ("ShotgunHit", 0);
		}

		if (colIn.name == "ShotgunFrac") {
			Invoke ("ShotgunFracHit", 0);
		}

		if (colIn.name == "ShotgunFrac(Clone)") {
			Invoke ("ShotgunFracHit", 0);
		}

		if (colIn.name == "Missle2") {
			Invoke ("Missle", 0);
		}

		if (colIn.name == "Missle2(Clone)") {
			Invoke ("Missle", 0);
		}
	}

	void PlayImpact()
	{
		GameObject impact = (GameObject)Instantiate (SwordImpact);

		impact.transform.position = transform.position;
		impact.transform.rotation = Impactpos.rotation;
	}

}
