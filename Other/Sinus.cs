using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinus : MonoBehaviour {
	public float TimeCounter = 0;
	public float speed;
	public float width;
	public float height;
	
	void Update () {
		TimeCounter += Time.deltaTime * speed;

		float x = Mathf.Cos (TimeCounter) * width;
		float y = Mathf.Sin (TimeCounter) * height;
		float z = 0;

		transform.position += new Vector3 (x, y, z);
	}

	float Deg2Rad(float degIn)
	{
		return ((degIn + 90) * Mathf.PI / 180);
	}
}
