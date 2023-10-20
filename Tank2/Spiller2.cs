using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spiller2 : MonoBehaviour
{
	public float svingfart = 5.0f;
	public float fart = 1.0f;
	public float Retning = 180f;
	public float sving = 1f;

	public float cur_SpeedPower = 0;
	public float max_SpeedPower = 100;
	public GameObject PowerBar;
	public bool speeding;

	public float shakeTimer;
	public float shakeAmount;

	public bool moving = false;

	Animator anim;
	public AudioSource audio;
	public AudioSource audioPwr;

	void Start()
	{
		cur_SpeedPower = max_SpeedPower;

		transform.Rotate(new Vector3(0, 0, Retning));

		anim = GetComponent<Animator>();

		AudioSource[] audios = GetComponents<AudioSource> ();
		audio =	audios[0];
		audioPwr =	audios[1];
	}	   
	
	void Update()
	{
		if (cur_SpeedPower > 100) 
		{
			cur_SpeedPower = 100;
		}

		float calc_Health = cur_SpeedPower /max_SpeedPower;
		SetPowerBar (calc_Health);


		if (speeding == true) 
		{
			audio.Stop ();
			if (!audioPwr.isPlaying) 
			{
				audioPwr.Play ();

			}

			if (cur_SpeedPower > 0) 
			{
				cur_SpeedPower -= 20 * Time.deltaTime;
			}

			if (cur_SpeedPower > 0) 
			{


				if (fart < 0.1f) {
					fart += 0.05f * Time.deltaTime;

				}
			}

			if (cur_SpeedPower < 0) 
			{
				if (fart > 0.05f) {
					fart -= 0.05f * Time.deltaTime;
				}
			}
		}

		if (speeding == false) 
		{
			if(fart  > 0.05f)
			{
				fart  -= 0.05f * Time.deltaTime;
			}
			audioPwr.Stop ();
		}

		if (shakeTimer >= 0) 
		{
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

			shakeTimer -= Time.deltaTime;
		}
		
		if (Input.GetKey(KeyCode.Keypad4))
		{
			transform.Rotate(new Vector3(0, 0, svingfart));
			Retning += sving;

			anim.SetInteger("State", 1);
			moving = true;
		}

		else 
		{
			moving = false;
		}
		
		if (Input.GetKey(KeyCode.Keypad6))
		{
			transform.Rotate(new Vector3(0, 0, -svingfart));
			Retning -= sving;

			anim.SetInteger("State", 1);
			moving = true;
		}
		
		if (Input.GetKey(KeyCode.Keypad8))
		{
			//sving = 1;
			Vector3 flytt = new Vector3(Mathf.Cos(1 * Deg2Rad(Retning)), Mathf.Sin(1 * Deg2Rad(Retning)), 0);			
			transform.position += flytt * fart;

			anim.SetInteger("State", 1);
			moving = true;
		}
		
		if (Input.GetKey(KeyCode.Keypad5))
		{
			//sving = 1;
			Vector3 flytt = new Vector3(Mathf.Cos(1 * Deg2Rad(Retning)), Mathf.Sin(1 * Deg2Rad(Retning)), 0);
			transform.position -= flytt * fart;

			anim.SetInteger("State", 1);
			moving = true;
		}

		if (Input.GetKeyUp (KeyCode.Keypad4)) 
		{
			anim.SetInteger("State", 0);
		}

		if (Input.GetKeyUp (KeyCode.Keypad6)) 
		{
			anim.SetInteger("State", 0);
		}

		if (Input.GetKeyUp (KeyCode.Keypad5)) 
		{
			anim.SetInteger("State", 0);
		}

		if (Input.GetKeyUp (KeyCode.Keypad8)) 
		{
			anim.SetInteger("State", 0);
		}

		if (Input.GetKeyDown (KeyCode.KeypadPlus)) {

			speeding = true;
		} 

		if (Input.GetKeyUp (KeyCode.KeypadPlus)) {
			speeding = false;
		} 

		if (moving == true)
		{
			if (!audio.isPlaying && !audioPwr.isPlaying) 
			{
				audio.Play ();
			}
		}

		if (moving == false) 
		{
			//Invoke ("StopAudio", 0.5f);
			audio.Stop ();
		}

		if (GameObject.Find ("Body").GetComponent<Health> ().cur_Health < 1) 
		{
			Invoke ("LoadLvl",2);
		}
	}

	public void ShakeTank (float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
	}

	
	void LoadLvl ()
	{
		Application.LoadLevel("Spiller2vant");
	}


	void Heal()
	{
		if (GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health < 100) 
		{
			GameObject.Find ("Body2").GetComponent<Health2> ().cur_Health += 4f;
		}

	}

	void OnTriggerEnter2D(Collider2D colIn)
	{
		if (colIn.name == "Repair") 
		{
			//Invoke ("Heal", 0);
		}

		if (colIn.name == "Big_Vullet_Upgrade") 
		{
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BigVullet = true;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BurstVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Vullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().MammutVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Missle = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Sword = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Shotgun = false;

			GameObject.Find ("Head2").GetComponent<Kanon2>().SwordKanon2 = false;

		}


		if (colIn.name == "Burst_Vullet_Upgrade") 
		{
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BigVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BurstVullet = true;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Vullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().MammutVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Missle = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Sword = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Shotgun = false;

			GameObject.Find ("Head2").GetComponent<Kanon2>().SwordKanon2 = false;

		}

		if (colIn.name == "Mammut_Vullet_Upgrade") 
		{
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BigVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BurstVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Vullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().MammutVullet = true;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Missle = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Sword = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Shotgun = false;

			GameObject.Find ("Head2").GetComponent<Kanon2>().SwordKanon2 = false;
		}

		if (colIn.name == "Missle_Vullet_Upgrade") 
		{
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BigVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BurstVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Vullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().MammutVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Missle = true;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Sword = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Shotgun = false;

			GameObject.Find ("Head2").GetComponent<Kanon2>().SwordKanon2 = false;

		}

		if (colIn.name == "Blade_Upgrade") 
		{
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BigVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BurstVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Vullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().MammutVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Missle = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Sword = true;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Shotgun = false;

			GameObject.Find ("Head2").GetComponent<Kanon2>().SwordKanon2 = true;

		}

		if (colIn.name == "Shotgun_Upgrade") 
		{
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BigVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().BurstVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Vullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().MammutVullet = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Missle = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Sword = false;
			GameObject.Find ("Kanon").GetComponent<Kannonfire2>().Shotgun = true;

			GameObject.Find ("Head2").GetComponent<Kanon2>().SwordKanon2 = false;

		}
	}

	public void SetPowerBar(float myPower)
	{
		PowerBar.transform.localScale = new Vector3(Mathf.Clamp(myPower,0f ,1f), PowerBar.transform.localScale.y, PowerBar.transform.localScale.z);
	}
	
	float Deg2Rad(float degIn)
	{
		return ((degIn + 90) * Mathf.PI / 180);
	}
	
}