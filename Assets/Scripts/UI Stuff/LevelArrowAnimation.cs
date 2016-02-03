using UnityEngine;
using System.Collections;

public class LevelArrowAnimation : MonoBehaviour {
	
	public Vector3 startPos, startScale;
	public Vector3 endPos, endScale;
	public float initT;
	private float t;
	public float duration;
	
	// Use this for initialization
	void Start () {
		transform.localPosition = startPos;
		transform.localScale = startScale;
		t = initT;
	}

	public float GetT()
	{
		return t;
	}
	
	void Render()
	{
		transform.localPosition = Vector3.Lerp (startPos, endPos, t);
		if (t < 0.5f)
			transform.localScale = Vector3.Lerp (startScale, endScale, t * 2);
		else
			transform.localScale = Vector3.Lerp (endScale, startScale, (t - 0.5f) * 2);
	}
	
	// Update is called once per frame
	void Update () {
		t += Mathf.Floor(Time.fixedDeltaTime * 100) / 100 / duration;
		if (t >= 1) {
			t = 0;
			//if(GetComponent<AudioSource>() != null) GetComponent<AudioSource>().Play();
		}
		Render ();
	}
}
