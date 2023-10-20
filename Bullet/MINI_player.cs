using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MINI_player : MonoBehaviour {

	public GameObject Explosjon;
	public float speed = 250f;
	public Transform target;
	public bool targeted;
	public float rotationSpeed = 5;
	public string enemyTag = "Enemy";
	Rigidbody2D rd;

	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
		rd = GetComponent<Rigidbody2D> ();
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

		if (nearestEnemy != null) {
			target = nearestEnemy.transform;
			targeted = true;
		} else 
		{
			target = null;
			targeted = false;
		}
	}

	void Update () {

		if(targeted == true)
		{
			Vector2 point2Target = (Vector2)transform.position - (Vector2)target.position;
			point2Target.Normalize ();
			float value = Vector3.Cross (point2Target, transform.right).z;
			rd.angularVelocity = rotationSpeed * value;
			rd.velocity = transform.right * speed;
		} else 	rd.velocity = transform.right * speed;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Enemy_Tank") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
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

		if (col.gameObject.tag == "Grinder") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
		}


		if (col.gameObject.tag == "Big_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();

		}

		if (col.gameObject.tag == "Vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();

		}
		if (col.gameObject.tag == "Mine") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();

		}

		if (col.gameObject.tag == "Burst_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();

		}

		if (col.gameObject.tag == "Enemy") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject);
			PlayExplosjon();
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

		if (colIn.gameObject.tag == "Bakke")
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
