using UnityEngine;
using System.Collections;

public class Kanon : MonoBehaviour {

	public float Retning = 0.0f;
	public float sving = 1;
	public float trailTime = 0;
	public float puch = 5000;
	public float fireRate = 0f;
	private float nextFire = 0.0f;
	public Transform STATICX;
	public Transform BladePos;
	public bool moving = false;
	public AudioSource audioTurn;
	public AudioSource Sword;
	public GameObject BladeKanon;
	bool isSword;
	public Sprite Head;
	public Sprite BigHead;
	public Sprite MammutHead;
	public Sprite BurstHead;
	public Sprite MissleHead;
	public Sprite BladeHead;
	public Sprite ShotgunHead;
	public bool Mammut;
	public bool Burst;
	public bool Big;
	public bool Missle;
	public bool SwordKanon;
	public bool Shotgun;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rb;

	void Start ()
	{
		AudioSource[] audios = GetComponents<AudioSource> ();
		audioTurn =	audios[0];
		Sword =	audios[1];
		
		rb = GetComponent<Rigidbody2D> ();
			
		spriteRenderer = GetComponent<SpriteRenderer> ();

		if (spriteRenderer.sprite == null) 
		{
			spriteRenderer.sprite = Head;
		}
	}
		
	void Update () 
	{

		transform.position = new Vector3 (STATICX.position.x, STATICX.position.y, 0);
		if (SwordKanon == true) 
		{
			if (!isSword) 
			{
				Instantiate (BladeKanon, BladePos.position, BladePos.rotation, transform);
				isSword = true;
			}
				
			if (trailTime > 0) 
			{
				trailTime -= Time.deltaTime * 2;
			}

			if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) 
			{
				rb.AddTorque (-puch);
				nextFire = Time.time + fireRate;
				trailTime += 1;
				Sword.Play ();
			}
		}

		if (SwordKanon == false) 
		{
			Destroy (GameObject.Find ("BadeKanon(Clone)"));
			isSword = false;
		}
	
		if (Input.GetKey(KeyCode.V))
		{
			transform.Rotate(new Vector3(0, 0, 0.5f));
			Retning += sving;
			moving = true;
		}
		else 
		{
			moving = false;
		}
		
		if (Input.GetKey(KeyCode.B))
		{
			transform.Rotate(new Vector3(0, 0, -0.5f));
			Retning -= sving;
			moving = true;
		}

		if (moving == true)
		{
			if (!audioTurn.isPlaying) 
			{
				audioTurn.Play ();
			}
		}

		if (moving == false) 
		{
			audioTurn.Stop ();
		}

		if (Mammut == true)
		{
			spriteRenderer.sprite = MammutHead;
		}

		if (Burst == true)
		{
			spriteRenderer.sprite = BurstHead;
		}

		if (Big == true)
		{
			spriteRenderer.sprite = BigHead;
		}

		if (Shotgun == true) 
		{
			spriteRenderer.sprite = ShotgunHead;
		}

		if (Missle == true)
		{
			spriteRenderer.sprite = MissleHead;
		}

		if (SwordKanon == true) 
		{
			spriteRenderer.sprite = BladeHead;
		}
	}
}
