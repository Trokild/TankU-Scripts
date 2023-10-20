using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float aplpha = 1.0f;
	private int fadeDir = -1;

	void OnGuid()
	{
		aplpha += fadeDir * fadeSpeed * Time.deltaTime;
		aplpha = Mathf.Clamp01 (aplpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, aplpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture(new Rect(0,0,  Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade (int direction)
	{
		Debug.Log("did it work", gameObject);
		fadeDir = direction;
		return(fadeSpeed);
	}

	void Start()
	{
		BeginFade (-1);
	}

}