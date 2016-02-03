using UnityEngine;
using System.Collections;

public class MenuWaveColor : MonoBehaviour {

	public Color colorIn;	
	public Color colorOut;
	public float initT;
	private float t;
	public float duration;
	
	// Use this for initialization
	void Start () {
		t = initT;
	}
	
	void Render()
	{
		if (t < 0.5f)
			GetComponent<Renderer>().material.color = Color.Lerp (colorOut, colorIn, t * 2);
		else
			GetComponent<Renderer>().material.color = Color.Lerp (colorIn, colorOut, (t - 0.5f) * 2);
	}
	
	// Update is called once per frame
	void Update () {
		t += Mathf.Floor(Time.fixedDeltaTime * 100) / 100 / duration;
		if (t >= 1)
			t = 0;
		Render ();
	}
}
