using UnityEngine;
using System.Collections;

public class Enemy_Simple : MonoBehaviour {

	[Header ("Movement")]
	public Transform[] patrolPlace;
	public float moveSpeed;
	private int currentPlace;
	private bool turning = false;
	public bool Torn;
	public bool isPatroling;
	public bool isPlane;
	public float stopWait_Time = 5;
	public float rotSpeed= 5;

	public Enemy_Tank TankScript;
	public Transform TankTrans;

	Animator anim;
	AudioSource audio;
	public AudioClip torn;


	void Start () {
		anim = GetComponent<Animator>();
		audio = GetComponent<AudioSource> ();

		if (isPatroling == true) 
		{
			transform.position = patrolPlace [0].position;
			currentPlace = 0;
		}

		if (isPlane == true) 
		{
			transform.position = patrolPlace [0].position;
			currentPlace = 0;
		}
	}

	void Update () {
		if (isPatroling == true) 
		{
			
			if (currentPlace >= patrolPlace.Length) {
				currentPlace = 0;
			}

			if (transform.position == patrolPlace [currentPlace].position && turning == false) {
				StartCoroutine (newPosition ());
				currentPlace++;
			}

			if (turning == false) {

				transform.position = Vector3.MoveTowards (transform.position, patrolPlace [currentPlace].position, moveSpeed * Time.deltaTime);
			}

			Vector3 vectorToTarget = patrolPlace [currentPlace].position - transform.position;
			float angle = (Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;

			if (Torn == true) {
				Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * rotSpeed);
			}
		}
		if (isPlane == true) 
		{
			if (currentPlace >= patrolPlace.Length) {
				currentPlace = 0;
			}

			if (transform.position == patrolPlace [currentPlace].position) {
				currentPlace++;
			}
				
			transform.position = Vector3.MoveTowards (transform.position, patrolPlace [currentPlace].position, moveSpeed * Time.deltaTime);

			Vector3 vectorToTarget = patrolPlace [currentPlace].position - transform.position;
			float angle = (Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90;

			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * rotSpeed);
		}
	}

	private IEnumerator newPosition()
	{
		TankScript.SetRotationVector ();
		TankScript.torn = true;

		float volum;
		volum = audio.volume;
		audio.volume -= (volum / 3);

		turning = true;
		anim.SetTrigger ("Turn");
		audio.PlayOneShot (torn, 0.4f);
		yield return new WaitForSeconds (0.5f);
		Torn = true;
		Debug.Log ("Wait", gameObject);



		yield return new WaitForSeconds (1.0f);
		anim.SetTrigger ("TurnBack");
		TankScript.torn = false;

		yield return new WaitForSeconds (0.2f);
		audio.PlayOneShot (torn, 0.4f);

		yield return new WaitForSeconds (0.6f);

		Debug.Log ("Move", gameObject);
		turning = false;
		audio.volume = volum;

		yield return new WaitForSeconds (2.0f);
		Torn = false;
	}

	private IEnumerator stopWait()
	{
		isPatroling = false;
		yield return new WaitForSeconds (stopWait_Time);
		isPatroling = true;
	}

	float Deg2Rad(float degIn)
	{
		return ((degIn) * Mathf.PI/180);
	}

	public void StopMovingTank()
	{
		Debug.Log ("StopMovingTank", gameObject);
		StartCoroutine (stopWait ());
	}
}
