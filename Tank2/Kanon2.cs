using UnityEngine;
using System.Collections;

public class Kanon2 : MonoBehaviour {
	
	public float Retning = 0.0f;
	public float sving = 1;
	public float trail = 0;

	public float puch = 5000;
	public float fireRate = 0f;
	private float nextFire = 0.0f;

	public Transform STATICX;
	public Transform BladePos2;

	public bool moving = false;
	public AudioSource audioTurning;
	public AudioSource swordWhip;
	public GameObject BladeKanon2;
	public bool isSword2;

	public Sprite Head2;
	public Sprite BigHead2;
	public Sprite MammutHead2;
	public Sprite BurstHead2;
	public Sprite MissleHead2;
	public Sprite BladeHead2;
	public Sprite ShotgunHead2;

	public bool Mammut2;
	public bool Burst2;
	public bool Big2;
	public bool Missle2;
	public bool SwordKanon2;
	public bool Shotgun2;

	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rb;

	void Start () 
	{
		AudioSource[] audio = GetComponents<AudioSource> ();
		audioTurning =	audio[0];
		swordWhip =	audio[1];

		rb = GetComponent<Rigidbody2D> ();

		spriteRenderer = GetComponent<SpriteRenderer> ();

		if (spriteRenderer.sprite == null) 
		{
			spriteRenderer.sprite = Head2;
		}
	}

	void Update () 
	{
		transform.position = new Vector3 (STATICX.position.x, STATICX.position.y, 0);
		if (SwordKanon2 == true) 
		{
			if (!isSword2)
			{
				Instantiate(BladeKanon2, BladePos2.position, BladePos2.rotation, transform);
				isSword2 = true;
			}

			if (trail > 0) 
			{
				trail -= Time.deltaTime * 2;
			}

			if (Input.GetKey (KeyCode.KeypadEnter) && Time.time > nextFire) 
			{
				rb.AddTorque (-puch);
				nextFire = Time.time + fireRate;
				trail += 1;
				swordWhip.Play ();
			}
		}

		if (SwordKanon2 == false) 
		{
			Destroy (GameObject.Find ("BadeKanon1(Clone)"));
			isSword2 = false;
		}
		
		if (Input.GetKey(KeyCode.Keypad2))
		{
			transform.Rotate(new Vector3(0, 0, 0.5f));
			Retning += sving;

			moving = true;
		}

		else 
		{
			moving = false;
		}
		
		if (Input.GetKey(KeyCode.Keypad3))
		{
			transform.Rotate(new Vector3(0, 0, -0.5f));
			Retning -= sving;

			moving = true;		
		}

		if (moving == true)
		{
			if (!GetComponent<AudioSource>().isPlaying) 
			{
				GetComponent<AudioSource>().Play ();
			}
		}

		if (moving == false) 
		{
			GetComponent<AudioSource>().Stop ();
		}

		if (Mammut2 == true)
		{
			spriteRenderer.sprite = MammutHead2;
		}

		if (Burst2 == true)
		{
			spriteRenderer.sprite = BurstHead2;
		}

		if (Big2 == true)
		{
			spriteRenderer.sprite = BigHead2;
		}

		if (Shotgun2 == true) 
		{
			spriteRenderer.sprite = ShotgunHead2;
		}

		if (Missle2 == true)
		{
			spriteRenderer.sprite = MissleHead2;
		}

		if (SwordKanon2 == true) 
		{
			spriteRenderer.sprite = BladeHead2;
		}
	}
}
