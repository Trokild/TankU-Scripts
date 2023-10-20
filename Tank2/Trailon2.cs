using UnityEngine;
using System.Collections;

public class Trailon2 : MonoBehaviour {

	public float trailTime = 0;
	private TrailRenderer myTrail;
	private PolygonCollider2D myColider;

	public float fireRate = 0f;
	private float nextFire = 0.7f;


	void Start () {
		myTrail = GetComponent<TrailRenderer> ();
		myColider = GetComponent<PolygonCollider2D> ();
	}

	void Update () {

		if (trailTime > 0) 
		{
			trailTime -= Time.deltaTime * 2;
			myTrail.enabled = true;
			myColider.enabled = true;
		}

		if (Input.GetKey (KeyCode.KeypadEnter) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			trailTime += 0.1f;
		}

		if (trailTime < 0) 
		{
			myTrail.enabled = false;
			myColider.enabled = false;
		}
	}
}
