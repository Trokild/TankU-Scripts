using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShotgunBullet : MonoBehaviour {

	public GameObject BulletFracture;
	public GameObject Explosjon;	
	private bool once;
	public bool Mine;
	public float speed = 170f;

	public float timer = 1f;

	public Transform FracturePos1;
	public Transform FracturePos2;
	public Transform FracturePos3;
	public Transform FracturePos4;


	// Use this for initialization
	void Start () {
		if (Mine == false) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Mathf.Cos (Deg2Rad (transform.eulerAngles.z)) * speed,
				Mathf.Sin (Deg2Rad (transform.eulerAngles.z)) * speed));
		}
	}

	void Awake()
	{
		Invoke ("Blast", timer);
	}

	float Deg2Rad(float degIn)
	{
		return ((degIn) * Mathf.PI/180);
	}

	void PlayExplosjon()
	{
		GameObject explosjon = (GameObject)Instantiate (Explosjon);

		explosjon.transform.position = transform.position;
	}
	void Blast()
	{
		if (once == false) {
			Instantiate (BulletFracture, FracturePos1.position, FracturePos1.rotation);
			Instantiate (BulletFracture, FracturePos2.position, FracturePos2.rotation);
			Instantiate (BulletFracture, FracturePos3.position, FracturePos3.rotation);

			if (Mine == true) 
			{
				Instantiate (BulletFracture, FracturePos4.position, FracturePos4.rotation);
			}
			GameObject explosjon = (GameObject)Instantiate (Explosjon);

			explosjon.transform.position = transform.position;
			Destroy (this.gameObject, 0.1f);
			Debug.Log ("Three", gameObject);
			once = true;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);

			//Invoke ("Blast",0);
		}

		if (col.gameObject.tag == "BigCover") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
		}


		if (col.gameObject.tag == "Bakke") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
		}

		if (col.gameObject.tag == "Enemy_Tank") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
		}

		if (col.gameObject.tag == "Grinder") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
		}

		if (col.gameObject.tag == "BadeKanon1") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
		}


		if (col.gameObject.tag == "Big_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			//Invoke ("PlayExplosjon", 0.9f);

			Invoke ("Blast",0);
		}

		if (col.gameObject.tag == "Vullet") 
		{ 
			Debug.Log ("two", gameObject);
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			//Invoke ("PlayExplosjon", 0.9f);

			Invoke ("Blast",0);
		}

		if (col.gameObject.tag == "Burst_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			//Invoke ("PlayExplosjon", 0f);

			Invoke ("Blast",0);
		}

		if (col.gameObject.tag == "MiniMisslie") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			//Invoke ("PlayExplosjon", 0f);

			Invoke ("Blast",0);
		}
	}

	void OnTriggerEnter2D(Collider2D colIn)
	{
		if (colIn.gameObject.tag == "Side")
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}

		if (colIn.gameObject.tag == "Back")
		{
			//Invoke ("skuddryggen");
			Destroy(this.gameObject);
			PlayExplosjon();
		}

		if (colIn.gameObject.tag == "Front")
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}

		if (colIn.gameObject.tag == "Big_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			//Invoke ("PlayExplosjon", 0.9f);

			Invoke ("Blast",0);
		}

		if (colIn.gameObject.tag == "Burst_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			//Invoke ("PlayExplosjon", 0f);

			Invoke ("Blast",0);
		}

		if (colIn.gameObject.tag == "Enemy") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);

			//Invoke ("Blast",0);
		}

		if (colIn.gameObject.tag == "Player") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			//Invoke ("PlayExplosjon", 0f);

			Invoke ("Blast",0);
		}

		if (colIn.gameObject.tag == "BadeKanon1") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
		}


	}

}
