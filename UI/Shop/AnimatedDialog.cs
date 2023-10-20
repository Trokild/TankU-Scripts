using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedDialog : MonoBehaviour {

	public Text textArea;
	[Multiline]
	public string[] strings;
	public float typeSpeed = 0.1f;
	public GameObject DialogImage;

	public AudioSource source;
	public AudioClip talk1;

	public Animator talkbox;

	public int stringIndex = 0;
	public int characterIndex = 0;
	private bool isOff;
	private bool isTalking;
	public bool turnOn;
	public bool isKraas = false;

	public PolygonCollider2D dode_ref;
	public BoxCollider2D scraff_ref;
	public CircleCollider2D pilot_ref;

	void Awake () {
		
		if (this.gameObject == enabled) 
		{
			StartCoroutine (DisplayTime ());
		}


		if (isKraas == true) {
			Debug.Log ("TalkIntro", gameObject);
			Invoke ("ResetArray", 0);
			Invoke ("TalkBtn", 3);
			Invoke ("StopTheTalk", 6);
		} else if ( isKraas == false)
			{
			source.PlayOneShot (talk1);
			}
			
	}

	public void TalkAngrKrass()
	{
		StartCoroutine (DisplayTime ());
		talkbox.SetInteger ("State", 1);
		Debug.Log ("TalkAngry", gameObject);
		Invoke ("TalkBtn", 0.1f);
		Invoke ("TalkBtn", 2);
		Invoke ("StopTheTalk", 4);
	}

	public void TalkAngrTower()
	{
		StartCoroutine (DisplayTime ());
		talkbox.SetInteger ("State", 1);
		Debug.Log ("TalkAngry", gameObject);
		Invoke ("TalkBtn", 0.1f);
	}

	public void TalkAngrTower2()
	{
		StartCoroutine (DisplayTime ());
		talkbox.SetInteger ("State", 2);
		Debug.Log ("TalkAngry", gameObject);
		Invoke ("TalkBtn", 0.1f);
		Invoke ("StopTheTalk", 3);
	}

	public void TalkDeadKrass()
	{
		StartCoroutine (DisplayTime ());
		talkbox.SetInteger ("State", 2);
		Debug.Log ("TalkAngry", gameObject);
		Invoke ("TalkBtn", 0.1f);
		Invoke ("TalkBtn", 3);
		Invoke ("StopTheTalk", 6);
	}

	IEnumerator DisplayTime()
	{
		while (1 == 1 && isOff == false) 
		{
			yield return new WaitForSeconds (typeSpeed);
			if (characterIndex > strings [stringIndex].Length) {
				continue;
			}
			textArea.text = strings [stringIndex].Substring (0, characterIndex);
			characterIndex++;
		}
		if (isOff == true)
		{
			characterIndex = 0;
		}

	}

	IEnumerator StopTalking()
	{
		isTalking = true;
		yield return new WaitForSeconds (3);
		DialogImage.SetActive (false);
		isTalking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) && isOff == false) 
		{
			TalkBtn ();
		}
	}

	public void ResetArray()
	{
		textArea.text = " ";
		isOff = false;
		stringIndex = 0;
		characterIndex = 0;
		StartCoroutine (DisplayTime ());
		talkbox.SetTrigger("Talk");
		source.PlayOneShot (talk1);
	}

	public void nextTalk()
	{
		textArea.text = " ";
		isOff = false;
		stringIndex = 1;
		characterIndex = 0;

		talkbox.SetTrigger("Talk");
		source.PlayOneShot (talk1);

		if (turnOn == false) 
		{
			StartCoroutine (DisplayTime ());
			turnOn = true;
		}
	}

	public void BuyLine3()
	{
		if (isTalking == false) 
		{
			StartCoroutine (StopTalking ());

			isOff = false;
			stringIndex = 2;
			characterIndex = 0;

			talkbox.SetTrigger ("Talk");
			source.PlayOneShot (talk1);

			if (turnOn == false) {
				StartCoroutine (DisplayTime ());
				turnOn = true;
			}
		}
	}

	public void BuyLine4()
	{
		if (isTalking == false) 
		{
			StartCoroutine (StopTalking ());

			isOff = false;
			stringIndex = 3;
			characterIndex = 0;
			talkbox.SetTrigger ("Talk");
			source.PlayOneShot (talk1);

			if (turnOn == false) {
				StartCoroutine (DisplayTime ());
				turnOn = true;
			}
		}
	}

	public void BuyLine5()
	{
		if (isTalking == false) 
		{
			StartCoroutine (StopTalking ());

			isOff = false;
			stringIndex = 4;
			characterIndex = 0;

			talkbox.SetTrigger("Talk");
			source.PlayOneShot (talk1);
				
			if (turnOn == false) 
			{
				StartCoroutine (DisplayTime ());
				turnOn = true;
			}
		}
	}

	public void BuyLine6()
	{
		if (isTalking == false) 
		{
			StartCoroutine (StopTalking ());

			isOff = false;
			stringIndex = 5;
			characterIndex = 0;

			talkbox.SetTrigger ("Talk");
			source.PlayOneShot (talk1);

			if (turnOn == false) 
			{
				StartCoroutine (DisplayTime ());
				turnOn = true;
			}
		}
	}

	public void BuyLine7()
	{
		if (isTalking == false) 
		{
			StartCoroutine (StopTalking ());

			isOff = false;
			stringIndex = 6;
			characterIndex = 0;

			talkbox.SetTrigger ("Talk");
			source.PlayOneShot (talk1);

			if (turnOn == false) 
			{
				StartCoroutine (DisplayTime ());
				turnOn = true;
			}
		}
	}

	public void StopTheTalk()
	{
		source.Stop ();
		DialogImage.SetActive (false);

	}

	public void StraightTalker()
	{
		stringIndex++;
		characterIndex = 0;
		talkbox.SetTrigger ("Talk");
		source.PlayOneShot (talk1);

		if (stringIndex == strings.Length) {
			
			dode_ref.enabled = true;
			scraff_ref.enabled = true;
			pilot_ref.enabled = true;

			source.Stop ();
			stringIndex = 0;
			characterIndex = 0;
			DialogImage.SetActive (false);
			isOff = true;
		}
	}

	public void TalkBtn()
	{
		if (isOff == false) 
		{
			if (characterIndex < strings [stringIndex].Length) {
				characterIndex = strings [stringIndex].Length;
			} else if (stringIndex < strings.Length) {
				stringIndex++;
				characterIndex = 0;
				talkbox.SetTrigger ("Talk");
				source.PlayOneShot (talk1);
			}

			if (stringIndex == strings.Length) {
				source.Stop ();
				stringIndex = 0;
				characterIndex = 0;
				DialogImage.SetActive (false);
				isOff = true;
			}
		}
	}
}
