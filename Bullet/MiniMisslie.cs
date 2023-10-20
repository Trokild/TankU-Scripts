using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMisslie : MonoBehaviour {

	public GameObject Explosjon;
	public float speed = 7f;
	public Transform target;
	public bool targeted;
	public float lifespan;

	public float rotationSpeed = 150f;

	public string enemyTag = "Player";

	Rigidbody2D rd;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		//target = GameObject.Find ("Body");
		rd = GetComponent<Rigidbody2D> ();

		//GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Deg2Rad(transform.eulerAngles.z))*speed,Mathf.Sin(Deg2Rad(transform.eulerAngles.z))*speed));
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

		if (nearestEnemy != null) 
		{
			target = nearestEnemy.transform;
			targeted = true;
		} 
		else 
		{
			target = null;
			targeted = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if(targeted == true)
		{
			Vector2 point2Target = (Vector2)transform.position - (Vector2)target.position;

			point2Target.Normalize ();

			float value = Vector3.Cross (point2Target, transform.right).z;

			rd.angularVelocity = rotationSpeed * value;

			rd.velocity = transform.right * speed;
		} else rd.velocity = transform.right * speed;

		lifespan -= Time.deltaTime;

		if(lifespan < 0)
		{
			Destroy(this.gameObject);	
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//Bouncetry
		if (col.gameObject.name == "Armor") 
		{ 
			transform.Rotate(new Vector3(0, 0, -180));
			rotationSpeed *= 2;
			speed *= 0.75f;
			//BOUNCE
		}

		if (col.gameObject.tag == "Enemy") 
		{ 
			Destroy (this.gameObject);
			PlayExplosjon();
		}
			
		if (col.gameObject.tag == "Bakke") 
		{ 
			Destroy (this.gameObject);
			PlayExplosjon();
		}


		if (col.gameObject.tag == "Big_vullet") 
		{ 
			Destroy (this.gameObject);
			PlayExplosjon();
		}

		if (col.gameObject.tag == "Vullet") 
		{ 
			Destroy (this.gameObject);
			PlayExplosjon();
		}
		if (col.gameObject.tag == "Mine") 
		{ 
			Destroy (this.gameObject);
			PlayExplosjon();
		}

		if (col.gameObject.tag == "Burst_vullet") 
		{ 
			Destroy (this.gameObject);
			PlayExplosjon();
		}

		if (col.gameObject.tag == "Lazor") 
		{ 
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);
		}

		if (col.gameObject.tag == "Happening") 
		{ 
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);
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

		if (colIn.gameObject.tag == "Bakke")
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}

		if (colIn.gameObject.tag == "Enemy")
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}

		if (colIn.gameObject.tag == "Vullet")
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
