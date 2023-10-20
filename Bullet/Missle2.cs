using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Missle2 : MonoBehaviour {

	public GameObject Explosjon;
	public float speed = 250f;
	public GameObject target;
	public float rotationSpeed = 5;

	Rigidbody2D rd;

	void Start () {

		target = GameObject.Find ("Body");
		rd = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
		point2Target.Normalize ();
		float value = Vector3.Cross (point2Target, transform.right).z;
		rd.angularVelocity = rotationSpeed * value;
		rd.velocity = transform.right * speed;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "BigCover") 
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


		if (col.gameObject.tag == "Bakke") 
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


		if (col.gameObject.tag == "Big_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			Invoke ("PlayExplosjon", 0.9f);
		}

		if (col.gameObject.tag == "Vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			Invoke ("PlayExplosjon", 0.9f);
		}

		if (col.gameObject.tag == "Burst_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0);
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

		if (colIn.gameObject.tag == "Sword")
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}

		if (colIn.gameObject.tag == "Burst_vullet")
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}

	}
	void PlayExplosjon()
	{
		GameObject explosjon = (GameObject)Instantiate (Explosjon);
		explosjon.transform.position = transform.position;
	}

	float Deg2Rad(float degIn)
	{
		return ((degIn) * Mathf.PI/180);
	}
}
