using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpillerBeta : MonoBehaviour
{	
	//[Header ("BodyUpgrades")]
	public Slider GasHandleSlider;
	public GameObject Camera;
	public Camera2DFollow CamFoll;
	public GameObject MineText;

	[Header ("BodyVisuall")]
	public Sprite[] bodySprite;
	private SpriteRenderer spriteRenderer;
	public ParticleSystem[] dust;
	public ParticleSystem[] fire;
	public Transform MoveExause;
	private bool isFire;
	private bool isDusting;
	private GameObject Neck;

	[Header ("Movement")]
	public float GasHandle = 1;
	private bool movingForward;
	private bool movingBackward;
	private bool turningLeft;
	private bool turningRight;

	public float svingfart = 0.5f;
	public float fart = 0.05f;
	private float fartLow = 0.25f;
	public float fartHigh = 0.8f;
	public float Retning = -90f;
	public float sving = 0.5f;
	public float akselerering;
	public float akselerering_Down;
	private bool isReverse;
	public bool moving = false;
	public bool nirtro;

	public float cur_SpeedPower = 0;
	public float max_SpeedPower = 100;
	public GameObject PowerBar;
	public bool speeding;


	[Header ("Other")]
	public GameObject Dropper;
	public GameObject Ram;
	public float shakeTimer;
	public float shakeAmount;

	public Animator Tracks;
	[Header ("")]
	public AudioSource audio;
	public AudioClip landing;
	public bool Parashoot;


	void Start()
	{
		if (Parashoot == true) 
		{
			Neck = GameObject.Find ("Neck");
			Neck.SetActive (false);
			Invoke ("LandInLevel", 1.2f);

		}
		fartLow= fart;

		MineText = GameObject.Find ("MineText");

		GameObject go = GameObject.Find ("play_game");
		Play pg = go.GetComponent<Play> ();

		Camera = GameObject.Find("Main Camera");
		CamFoll = Camera.GetComponent<Camera2DFollow> ();

		spriteRenderer = GetComponent<SpriteRenderer> ();
		cur_SpeedPower = max_SpeedPower;

		transform.Rotate(new Vector3(0, 0, Retning));

		if (pg.upgDropper == true) 
		{
			InstallDropper ();
		} 
		else if (pg.upgDropper == false) 
		{
			MineText.SetActive (false);
			GameObject Mi = GameObject.Find ("MineBtn");
			Button Dp = Mi.GetComponent<Button> ();
			if (Dp.interactable != false) 
			{
				Dp.interactable = false;
			}
		}

		if (pg.upgNitro == true) 
		{
			nirtro = true;
			InvokeRepeating ("MoreNitro", 1, 0.5f);

			if (pg.upgArmor == true) 
			{
				changeBodyNitArm ();
			} 
			else 
			{
				changeBodyNit();
			}
		}

		if (pg.upgArmor == true && pg.upgNitro == false) 
		{
			changeBodyArm ();
		}

		if (pg.upgRam == true) 
		{
			InstallRam();
		}

		if (pg.upgNitro == false) 
		{
			PowerBar.SetActive (false);

			GameObject Ni = GameObject.Find ("NitroBtn");
			Button Np = Ni.GetComponent<Button> ();
			if (Np.interactable != false) 
			{
				Np.interactable = false;
			}
		}
	}

	public void MoreNitro()
	{
		if (speeding == false && cur_SpeedPower < max_SpeedPower) 
		{
			cur_SpeedPower += 0.75f;

			if (cur_SpeedPower > max_SpeedPower)
			{
				cur_SpeedPower = max_SpeedPower;
			}
		}	
	}

	void FixedUpdate()
	{
		GasHandle = GasHandleSlider.value;

		if (GasHandle == 0) 
		{
			movingBackward = true;
			movingForward = false;
		}

		if (GasHandle == 1) 
		{
			movingBackward = false;
			movingForward = false;
		}

		if (GasHandle == 2) 
		{
			movingBackward = false;
			movingForward = true;
		}

		float calc_Health = cur_SpeedPower /max_SpeedPower;
		SetPowerBar (calc_Health);

		if (moving == true)
		{
			audio.volume = 0.5f;
			if (isDusting == false) 
			{
				{
					foreach (ParticleSystem duster in dust) 
					{
						duster.enableEmission = true;
						isDusting = true;
					}
				}
			}

			if (!audio.isPlaying) 
			{
				audio.Play ();
			}
		}

		if (speeding == true && nirtro == true && moving == true) 
		{

			if (cur_SpeedPower > 0) 
			{
				cur_SpeedPower -= 20 * Time.deltaTime;

				if (fart < fartHigh) {
					fart += akselerering * Time.deltaTime;
					audio.pitch = 1.08f;
					CamFoll.nitroCamera ();
				}
			}

			if (cur_SpeedPower < 0) 
			{
				if (fart > fartLow) {
					fart -= fartLow * Time.deltaTime;
					audio.pitch = 1.0f;
					CamFoll.nitroCameraOFF ();

					if(isFire == true)
					{
						foreach (ParticleSystem fireing in fire) 
						{
							fireing.enableEmission = false;
							isFire = false;
						}	
					}
				}
			}
		}

		if (speeding == false) 
		{
			if(fart  > fartLow)
			{
				fart  -= akselerering_Down * Time.deltaTime;
				audio.pitch = 1.0f;
				CamFoll.nitroCameraOFF ();
			}
		}

		if (shakeTimer >= 0) 
		{
			Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

			shakeTimer -= Time.deltaTime;
		}

		if (turningLeft == true)
		{
			transform.Rotate(new Vector3(0, 0, svingfart));
			Retning += sving;
			Tracks.SetInteger("State", 3);
			moving = true;
			audio.pitch = 0.98f;
		}

		else 
		{
			moving = false;
		}

		if (turningRight == true)
		{
			transform.Rotate(new Vector3(0, 0, -svingfart));
			Retning -= sving;
			Tracks.SetInteger("State", 4);
			audio.pitch = 0.98f;
			moving = true;
		}

		if (movingForward == true)
			//(Input.GetKey(KeyCode.W))
		{
			Vector3 flytt = new Vector3(Mathf.Cos(1 * Deg2Rad(Retning)), Mathf.Sin(1 * Deg2Rad(Retning)), 0);			
			transform.position += flytt * fart;
			moving = true;

			if (turningLeft == true) 
			{
				Tracks.SetInteger("State", 3);
			}

			if (turningRight == true) 
			{
				Tracks.SetInteger("State", 4);
			}

			if (turningLeft == false && turningRight == false) 
			{
				Tracks.SetInteger("State", 1);
				if (speeding == false) 
				{
					audio.pitch = 1.0f;
				}
			}

			if(isReverse == true)
			{
				MoveExause.localPosition -= new Vector3 (MoveExause.localPosition.x, 0.78f, 0);
				MoveExause.localEulerAngles -= new Vector3 (180, 0, 0);
				isReverse = false;
			}
		}

		if (movingBackward == true)
		{
			Vector3 flytt = new Vector3(Mathf.Cos(1 * Deg2Rad(Retning)), Mathf.Sin(1 * Deg2Rad(Retning)), 0);
			transform.position -= flytt * fart;

			moving = true;

			if (turningLeft == true) 
			{
				Tracks.SetInteger("State", 3);

				if (speeding == false) 
				{
					audio.pitch = 0.97f;
				}
			}

			if (turningRight == true) 
			{
				Tracks.SetInteger("State", 4);

				if (speeding == false) 
				{
					audio.pitch = 0.97f;
				}
			}


			if (turningLeft == false && turningRight == false) 
			{
				Tracks.SetInteger("State", 2);
				if (speeding == false) {
					audio.pitch = 1.0f;
				}
			}

			if (isReverse == false) {
				MoveExause.localPosition += new Vector3 (MoveExause.localPosition.x, 0.78f, 0);
				MoveExause.localEulerAngles += new Vector3 (180, MoveExause.localEulerAngles.y, 0);
				Debug.Log ("changeposex", gameObject);
				isReverse = true;
			}
		}
			
		if (moving == false) 
		{
			audio.volume = 0.4f;
			audio.pitch = 0.9f;
			Tracks.SetInteger("State", 0);

			if (isDusting == true) 
			{
				{
					foreach (ParticleSystem duster in dust) 
					{
						duster.enableEmission = false;
						isDusting = false;
					}
				}
			}

			if(isFire == true)
			{
				foreach (ParticleSystem fireing in fire) 
				{
					fireing.enableEmission = false;
					isFire = false;
				}
			}
		}
	}

	void LoadLvl ()
	{
		Application.LoadLevel("Spiller1vant");
	}

	public void ShakeTank (float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTimer = shakeDur;
	}

	void Heal()
	{
		if (GameObject.Find ("Body").GetComponent<Health> ().cur_Health < GameObject.Find ("Body").GetComponent<Health> ().max_Health) 
		{
			GameObject.Find ("Body").GetComponent<Health> ().cur_Health += 4;
			GameObject.Find ("Body").GetComponent<Health> ().cur_Health2 += 4;
		}
			
	}

	public void NitroBtn_Down()
	{
		if (nirtro == true && cur_SpeedPower > 0 && moving == true) 
		{
			speeding = true;

			if(isFire == false)
			{
				foreach (ParticleSystem fireing in fire) 
				{
					fireing.enableEmission = true;
					isFire = true;
				}
			}
		}
	}

	public void NitroBtn_Up()
	{
		speeding = false;

		if(isFire == true)
			foreach (ParticleSystem fireing in fire) 
			{
				fireing.enableEmission = false;
				isFire = false;
			}
	}
	public void InstallDropper()
	{
		Dropper.SetActive (true);

		Dropper.GetComponent<DropThisEquptment> ().Mine = true;
		GameObject Mi = GameObject.Find ("MineBtn");
		Button Dp = Mi.GetComponent<Button> ();


		if (Dp.interactable != true) {
			Dp.interactable = true;
		}

		MineText.SetActive (true);
	}

	public void InstallRam()
	{
		Ram.SetActive (true);
	}

	public void changeBodyNit()
	{
		spriteRenderer.sprite = bodySprite [1];
		PowerBar.SetActive (true);

		GameObject Ni = GameObject.Find ("NitroBtn");
		Button Np = Ni.GetComponent<Button> ();
		if (Np.interactable != true) {
			Np.interactable = true;
		}
	}

	public void changeBodyNitArm()
	{
		spriteRenderer.sprite = bodySprite [3];
		if (PowerBar.activeSelf == false) {
			PowerBar.SetActive (true);
		}

		GameObject Ni = GameObject.Find ("NitroBtn");
		Button Np = Ni.GetComponent<Button> ();
		if (Np.interactable != true) {
			Np.interactable = true;
		}
	}

	public void changeBodyArm()
	{
		spriteRenderer.sprite = bodySprite [2];
		if (PowerBar.activeSelf == false) {
			PowerBar.SetActive (true);
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

	public void BottunForward()
	{	
		if (movingBackward == false) 
		{
			if (movingForward == false) {
				movingForward = true;
			} else if (movingForward == true) {
				movingForward = false;
				Tracks.SetInteger("State", 0);
			}
		}

		if (movingBackward == true) 
		{
			movingBackward = false;
		}
	}

	public void BottunForwardLeft()
	{
		turningLeft = true;
		movingForward = true;
	}

	public void BottunForwardRight()
	{
		movingForward = true;
		turningRight = true;
	}

	public void BottunBackward()
	{
		if (movingForward == false) 
		{	
			if (movingBackward == false) {
				movingBackward = true;
			} else if (movingBackward == true) {
				movingBackward = false;
				Tracks.SetInteger("State", 0);
			}
		}

		if (movingForward == true) 
		{
			movingForward = false;
		}
	}

	public void BottunBackwardLeft()
	{
		movingBackward = true;
		turningLeft = true;
	}

	public void BottunBackwardRight()
	{
		movingBackward = true;
		turningRight = true;
	}

	public void BottunTurnLeft()
	{
		turningLeft = true;	
	}
		
	public void BottunTrunRight()
	{
		turningRight = true;
	}

	public void BottunRealease()
	{
		turningLeft = false;
		turningRight = false;

		if (movingBackward == false || movingForward == false) 
		{
			Tracks.SetInteger ("State", 0);
		}
	}
		
	void LandInLevel ()
	{
		gameObject.GetComponent<AudioSource> ().enabled = true;
		audio.PlayOneShot (landing, 1f);
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		GameObject.Find ("Tracks").GetComponent<SpriteRenderer> ().enabled = true;
		Neck.SetActive (true);
	}
}