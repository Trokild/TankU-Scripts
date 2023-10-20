using UnityEngine;
using System.Collections;

public class PointTo : MonoBehaviour {

		public GameObject target;
		public float rotationSpeed = 5;
		Rigidbody2D rd;
		void Start () {

			target = GameObject.FindGameObjectWithTag ("Player");
			rd = GetComponent<Rigidbody2D> ();
			//GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(Deg2Rad(transform.eulerAngles.z))*speed,Mathf.Sin(Deg2Rad(transform.eulerAngles.z))*speed));
		}

		// Update is called once per frame
		void FixedUpdate () {
			Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
			float value = Vector3.Cross (point2Target, transform.right).z;
			rd.angularVelocity = rotationSpeed * value;
		}

		float Deg2Rad(float degIn)
		{
			return ((degIn) * Mathf.PI/180);
		}
	}
