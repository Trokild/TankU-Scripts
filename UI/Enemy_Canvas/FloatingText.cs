using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {
	public Animator animator;
	private Text damageText;
	public float AddTheDamage;
	public bool isPlaying;

	void Start()
	{
		AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo (0);
		damageText = animator.GetComponent<Text> ();
		SetText ("22");
		InvokeRepeating("turnON", 0, 0.1f);
	}
		

	public void SetText(string text)
	{
		animator.GetComponent<Text>().text = text;
	}

	void turnoff()
	{
		Debug.Log ("Turn", gameObject);
		if (animator.GetCurrentAnimatorStateInfo (0).IsName("Text_Slide"))  //normalizedTime > 1 && !animator.IsInTransition (0)
		{
			//AddTheDamage = 0;
			Debug.Log ("off", gameObject);
		}

	}

	void turnON ()
	{
		SetText (AddTheDamage.ToString());

	}

	public void BurstgoingTO ()
	{
		if ((AddTheDamage >= 0)) {
			Invoke ("turnoff", 1.3f);
		}
	}

	public void AoegoingTO()
	{
	AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo (0);
		if (AddTheDamage >= 0) 
		{
			Invoke("turnoff", 0.95f);  //clipInfo [0].clip.length
			Debug.Log ("goingTO", gameObject);
		}

		if (AddTheDamage > GameObject.Find("play_game").GetComponent<Play>().AoePlay) 
		{
			AddTheDamage = GameObject.Find("play_game").GetComponent<Play>().AoePlay;
		}
	}
}
