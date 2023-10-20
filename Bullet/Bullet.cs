using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

	public GameObject Explosjon;	
	public float speed = 170f;
	public float lifespan;
	public int dmgB = 0;

	void Start () {
		GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Deg2Rad(transform.eulerAngles.z))*speed,
		                                   Mathf.Sin(Deg2Rad(transform.eulerAngles.z))*speed));
	}
		
	void Update () {

		lifespan -= Time.deltaTime;

		if(lifespan < 0)
			Destroy(this.gameObject);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
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

		if (col.gameObject.tag == "Player") 
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


		if (col.gameObject.tag == "Big_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.3f);
			Invoke ("PlayExplosjon", 0.2f);
		}

		if (col.gameObject.tag == "Biger_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.3f);
			Invoke ("PlayExplosjon", 0.2f);
		}

		if (col.gameObject.tag == "Vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			Invoke ("PlayExplosjon", 0.9f);
		}

		if (col.gameObject.tag == "Spear") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			Invoke ("PlayExplosjon", 0.9f);
		}

		if (col.gameObject.tag == "Minimissile") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			Invoke ("PlayExplosjon", 0.9f);
		}

		if (col.gameObject.tag == "MemeMisslie") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 1);
			Invoke ("PlayExplosjon", 0.9f);
		}

		if (col.gameObject.tag == "Burst_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);
		}

		if (col.gameObject.tag == "Pov") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);
		}

		if (col.gameObject.tag == "Enemy") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);
		}

		if (col.gameObject.tag == "Lazor") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);
		}

		if (col.gameObject.tag == "Happening") 
		{ 
			//cur_Health -= 10;
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

		if (colIn.gameObject.tag == "Bakke")
		{
			Destroy(this.gameObject);
			PlayExplosjon();
		}

		if (colIn.gameObject.tag == "Burst_vullet") 
		{ 
			//cur_Health -= 10;
			Destroy (this.gameObject, 0.01f);
			Invoke ("PlayExplosjon", 0f);
		}

		if (colIn.gameObject.tag == "Enemy") 
		{ 
			if (dmgB == 0) {
				Destroy (this.gameObject, 0.01f);
				Invoke ("PlayExplosjon", 0f);
			} else 
			{ 
				Invoke ("PlayExplosjon", 0f);
				dmgB -= 1;
			}
		}
        
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
}
